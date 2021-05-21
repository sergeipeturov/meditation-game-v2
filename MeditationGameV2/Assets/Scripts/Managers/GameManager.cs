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
    public Instantiator Instantiator { get { return GetComponent<Instantiator>(); } }
    public LevelsManager LevelsManager { get { return GetComponent<LevelsManager>(); } }
    public PlayerManager PlayerManager { get { return GetComponent<PlayerManager>(); } }
    public int CurrentLevel { get; private set; }
    public static GameManager Instance { get { return GameObject.Find("GameManager").GetComponent<GameManager>(); } }

    private void Awake()
    {
        Application.targetFrameRate = 60;
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(Circle);
        DontDestroyOnLoad(Background);
    }

    public void SetUpLevel()
    {
        CurrentLevel = MainMenuManager.SelectedLevel;
        StateMachine.GameState = GameState.gameNormal;
        SceneManager.LoadScene(1);
    }
}
