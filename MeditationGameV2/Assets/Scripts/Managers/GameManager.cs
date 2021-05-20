using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject Circle;
    public GameObject Background;
    public CircleScript CircleScript { get { return Circle.GetComponent<CircleScript>(); } }
    public InputManager InputManager { get { return GetComponent<InputManager>(); } }
    public StateMachine StateMachine { get { return GetComponent<StateMachine>(); } }
    public UIManager UIManager { get { return GetComponent<UIManager>(); } }
    public MainMenuManager MainMenuManager { get { return GetComponent<MainMenuManager>(); } }
    public SpritesManager SpritesManager { get { return GetComponent<SpritesManager>(); } }
    public int CurrentLevel { get; private set; }
    public static GameManager Instance { get { return GameObject.Find("GameManager").GetComponent<GameManager>(); } }

    //private Scene _CurrentScene; //все, что связано с этими переменными - ебучие костыли, но пока не хочу с этим разбираться, для такой простой игры хватит и костылей
    //private Scene CurrentScene 
    //{
    //    get { return _CurrentScene; } 
    //    set
    //    {
    //        _CurrentScene = value;
    //        SceneManager_sceneLoaded();
    //    }
    //}

    private void Awake()
    {
        Application.targetFrameRate = 60;
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(Circle);
        DontDestroyOnLoad(Background);
    }

    private void Update()
    {
        //if (StateMachine.GameState == GameState.gameNormal && (CurrentScene == null || CurrentScene.name != "NormalGame"))
        //    CurrentScene = SceneManager.GetActiveScene();
    }

    public void SetUpLevel()
    {
        CurrentLevel = MainMenuManager.SelectedLevel;
        StateMachine.GameState = GameState.gameNormal;
        SceneManager.LoadScene(1);
        
    }

    private void SceneManager_sceneLoaded()
    {
        //if (StateMachine.GameState == GameState.gameNormal && CurrentScene.name == "NormalGame")
        //{
        //    Background.GetComponent<BackgroundManager>().GoBlackBack();
        //   UIManager.ShowIntro(CurrentLevel);
        //    UIManager.IntroPanel.transform.Find("Button").GetComponent<LevelIntroButton>().GoLevelNotify += GoLevel;
        //}
    }

    private void GoLevel()
    {
        //Background.GetComponent<BackgroundManager>().GoUsualBack();
        //UIManager.DisableIntro();

        //Circle.SetActive(true);
        //CircleScript.BlockMove(false);
        //CircleScript.EnableOreol();
    }
}
