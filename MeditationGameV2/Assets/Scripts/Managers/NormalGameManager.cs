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

    private void OnNormalGameStateChange()
    {
        if (NormalGameState == NormalGameState.intro)
        {
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
            case 1: //две думы - положительная и отрицательная //test: на время теста - одна
                Thought thought = new Thought(true);
                //while (thought.IsMomental) //test раскомментить
                //{
                //    thought = Thought.GetRandomPositiveThought();
                //    thought.SetTimeOfLife(GameManager.Instance.LevelsManager.CurrentLevel.ThoughtsTimeOfLife);
                //    if (GameManager.Instance.PlayerManager.NegativeThoughts.Any(x => x.Name == Names.Negative_9_Boredom))
                //      thought.IncreaseTimeOfLife(Constants.BonusToTimeOfLifeFromBoredom);
                //    if (GameManager.Instance.PlayerManager.PosistiveThoughts.Any(x => x.Name == Names.Positive_4_Inspiration))
                //      thought.IncreaseTimeOfLife(Constants.BonusToTimeOfLifeFromInspiration);
                //}
                thought = Thought.GetThoughtByName(Names.Negative_6_Guilt); //test
                thought.SetTimeOfLife(GameManager.Instance.LevelsManager.CurrentLevel.ThoughtsTimeOfLife);
                thoughtChoises.Add(new ThoughtChoise(thought));
                /*thought = new Thought(true); //test раскомментить
                while (thought.IsMomental)
                {
                    thought = Thought.GetRandomNegativeThought();
                    thought.SetTimeOfLife(GameManager.Instance.LevelsManager.CurrentLevel.ThoughtsTimeOfLife);
                    if (GameManager.Instance.PlayerManager.NegativeThoughts.Any(x => x.Name == Names.Negative_9_Boredom))
                      thought.IncreaseTimeOfLife(Constants.BonusToTimeOfLifeFromBoredom);
                    if (GameManager.Instance.PlayerManager.PosistiveThoughts.Any(x => x.Name == Names.Positive_4_Inspiration))
                      thought.IncreaseTimeOfLife(Constants.BonusToTimeOfLifeFromInspiration);
                }
                thoughtChoises.Add(new ThoughtChoise(thought));*/
                break;
            case 2:
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
                for (int i = 2; i <= 8; i++) //test. must be 3
                {
                    GameManager.Instance.UIManager.ChoiseOfThoughtsPanel.transform.Find("ThoughtChoisesPanel").Find($"TC_{i}").gameObject.SetActive(false);
                }
                thoughtChoises[0].ThoughtChoiseViewName = "TC_1";
                //thoughtChoises[1].ThoughtChoiseViewName = "TC_2"; //test раскомментить
                break;
            case 2:
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

    private NormalGameState normalGameState;
    private List<ThoughtChoise> thoughtChoises = new List<ThoughtChoise>();
}
