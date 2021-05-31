using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NormalGameManager : MonoBehaviour
{
    public static NormalGameManager Instance { get { return GameObject.Find("NormalGameManager").GetComponent<NormalGameManager>(); } }
    public EffectorManager EffectorManager { get { return GetComponent<EffectorManager>(); } }
    public EffectorUIManager EffectorUIManager { get { return GetComponent<EffectorUIManager>(); } }

    public NormalGameState NormalGameState
    {
        get { return normalGameState; }
        private set
        {
            normalGameState = value;
            OnNormalGameStateChange();
        }
    }

    private void Awake()
    {
        NormalGameState = NormalGameState.intro;
    }

    private void Update()
    {
        if (GameManager.Instance.StateMachine.GameState == GameState.gameNormalPlaying)
        {
            if (!GameManager.Instance.PlayerManager.PosistiveThoughts.Any() && !GameManager.Instance.PlayerManager.NegativeThoughts.Any())
            {
                timeWithoutThoughts += Time.deltaTime;
                EffectorUIManager.UpdateTimerSlider(timeWithoutThoughts);
                if (timeWithoutThoughts >= GameManager.Instance.LevelsManager.CurrentLevel.TimeToReach)
                {
                    GoBossFight();
                }
            }
            else
            {
                timeWithoutThoughts = 0.0f;
                EffectorUIManager.UpdateTimerSlider(timeWithoutThoughts);
            }
        }
    }

    private void OnNormalGameStateChange()
    {
        if (NormalGameState == NormalGameState.intro)
        {
            GameManager.Instance.Circle.SetActive(false);
            EffectorUIManager.SetTimerSlider(GameManager.Instance.LevelsManager.CurrentLevel.TimeToReach);
            EffectorUIManager.DisablePanels();
            GameManager.Instance.Background.GetComponent<BackgroundManager>().GoBlackBack();
            GameManager.Instance.UIManager.ShowIntro(GameManager.Instance.CurrentLevel);
            GameManager.Instance.UIManager.IntroPanel.transform.Find("Button").GetComponent<LevelIntroButton>().GoLevelNotify += GoToChoiseOfThoughts;
        }

        if (NormalGameState == NormalGameState.choiseOfThoughts)
        {
            GameManager.Instance.UIManager.ShowChoiseOfThoughts(GameManager.Instance.CurrentLevel);
            SetThoughtChoises();
            GameManager.Instance.UIManager.ChoiseOfThoughtsPanel.transform.Find("Button").GetComponent<LevelIntroButton>().GoLevelNotify += GoToPrePlay;
        }

        if (NormalGameState == NormalGameState.prePlay)
        {
            GameManager.Instance.Background.GetComponent<BackgroundManager>().GoUsualBack();
            GameManager.Instance.UIManager.DisableChoiseOfThoughts();

            GameManager.Instance.Circle.SetActive(true);
            GameManager.Instance.CircleScript.BlockMove(false);
            GameManager.Instance.CircleScript.EnableOreol();

            foreach (var item in thoughtChoises)
            {
                GameManager.Instance.PlayerManager.AddThought(item.Thought);
            }
        }
    }

    private void GoToChoiseOfThoughts()
    {
        GameManager.Instance.UIManager.DisableIntro();
        NormalGameState = NormalGameState.choiseOfThoughts;
    }

    private void GoToPrePlay()
    {
        NormalGameState = NormalGameState.prePlay;
    }

    private void SetThoughtChoises()
    {
        //set model
        thoughtChoises.Clear();
        switch (GameManager.Instance.CurrentLevel)
        {
            case 1: //две думы - положительная и отрицательная
                Thought thought = new Thought(true);
                while (thought.IsMomental)
                {
                    thought = Thought.GetRandomPositiveThought();
                    MeditationGameUtils.SetTimeOfLife(ref thought);
                }
                thoughtChoises.Add(new ThoughtChoise(thought));
                thought = new Thought(true);
                while (thought.IsMomental)
                {
                    thought = Thought.GetRandomNegativeThought();
                    MeditationGameUtils.SetTimeOfLife(ref thought);
                }
                thoughtChoises.Add(new ThoughtChoise(thought));
                break;
            case 2: //три думы - две положительные, одна отрицательная
                for (int i = 0; i < 2; i++)
                {
                    thought = new Thought(true);
                    while (thought.IsMomental || thoughtChoises.Any(x => x.Thought.Name == thought.Name))
                    {
                        thought = Thought.GetRandomPositiveThought();
                        MeditationGameUtils.SetTimeOfLife(ref thought);
                    }
                    thoughtChoises.Add(new ThoughtChoise(thought));
                }
                thought = new Thought(true);
                while (thought.IsMomental)
                {
                    thought = Thought.GetRandomNegativeThought();
                    MeditationGameUtils.SetTimeOfLife(ref thought);
                }
                thoughtChoises.Add(new ThoughtChoise(thought));
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                break;
        }

        //set view
        for (int i = 1; i <= 8; i++)
        {
            GameManager.Instance.UIManager.ChoiseOfThoughtsPanel.transform.Find("ThoughtChoisesPanel").Find($"TC_{i}").gameObject.SetActive(true);
            GameManager.Instance.UIManager.ChoiseOfThoughtsPanel.transform.Find("ThoughtChoisesPanel").Find($"TC_{i}").gameObject.GetComponent<Image>().sprite = GameManager.Instance.SpritesManager.GetDefaultSprite();
        }
        switch (GameManager.Instance.CurrentLevel)
        {
            case 1: //две думы - положительная и отрицательная
                for (int i = 3; i <= 8; i++)
                {
                    GameManager.Instance.UIManager.ChoiseOfThoughtsPanel.transform.Find("ThoughtChoisesPanel").Find($"TC_{i}").gameObject.SetActive(false);
                }
                thoughtChoises[0].ThoughtChoiseViewName = "TC_1";
                thoughtChoises[1].ThoughtChoiseViewName = "TC_2";
                break;
            case 2: //три думы - две положительные, одна отрицательная
                for (int i = 4; i <= 8; i++)
                {
                    GameManager.Instance.UIManager.ChoiseOfThoughtsPanel.transform.Find("ThoughtChoisesPanel").Find($"TC_{i}").gameObject.SetActive(false);
                }
                thoughtChoises[0].ThoughtChoiseViewName = "TC_1";
                thoughtChoises[1].ThoughtChoiseViewName = "TC_2";
                thoughtChoises[2].ThoughtChoiseViewName = "TC_3";
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                break;
        }

        GameManager.Instance.UIManager.ChoiseOfThoughtsPanel.transform.Find("Button").GetComponent<Button>().interactable = false;
    }

    public void OnThoughtChoiseClick(int index)
    {
        var th = thoughtChoises.First(x => x.ThoughtChoiseViewName == $"TC_{index}");
        if (!th.IsOpened)
        {
            th.IsOpened = true;
            var thName = th.Thought.Name;
            var sprit = GameManager.Instance.SpritesManager.GetSpriteByThoughtName(thName);
            GameManager.Instance.UIManager.ChoiseOfThoughtsPanel.transform.Find("ThoughtChoisesPanel").Find($"TC_{index}").gameObject.GetComponent<Image>().sprite = sprit;
            if (AllOpened())
                GameManager.Instance.UIManager.ChoiseOfThoughtsPanel.transform.Find("Button").GetComponent<Button>().interactable = true;
        }
    }

    public void ChangeForAds()
    {
        //TODO: watch ads
        SetThoughtChoises();
    }

    private bool AllOpened()
    {
        bool res = true;
        foreach (var item in thoughtChoises)
        {
            if (!item.IsOpened)
            {
                res = false;
                return res;
            }
        }
        return res;
    }

    private void GoBossFight()
    {
        GameManager.Instance.StateMachine.GameState = GameState.gameNormalPreBoss;
        GameManager.Instance.CircleScript.EnableOreol();

        //GameManager.Instance.GoBossGame();
    }

    private NormalGameState normalGameState;
    private List<ThoughtChoise> thoughtChoises = new List<ThoughtChoise>();
    private float timeWithoutThoughts = 0.0f;
}
