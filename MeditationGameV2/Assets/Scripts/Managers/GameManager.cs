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
    public MainMenuManager MainMenuManager { get { return GameObject.Find("MainMenuManager").gameObject.GetComponent<MainMenuManager>(); } }
    public SpritesManager SpritesManager { get { return GetComponent<SpritesManager>(); } }
    public Instantiator Instantiator { get { return GetComponent<Instantiator>(); } }
    public LevelsManager LevelsManager { get { return GetComponent<LevelsManager>(); } }
    public PlayerManager PlayerManager { get { return GetComponent<PlayerManager>(); } }
    public List<GameObject> Ideas { get; set; } = new List<GameObject>();
    public int CurrentLevel { get; private set; }
    public static GameManager Instance { get { return GameObject.Find("GameManager").GetComponent<GameManager>(); } }

    private static Dictionary<string, GameObject> _instances = new Dictionary<string, GameObject>();
    public string ID;

    private void Awake()
    {
        Application.targetFrameRate = 60;

        if (_instances.ContainsKey(ID))
        {
            var existing = _instances[ID];
            // A null result indicates the other object was destoryed for some reason
            if (existing != null)
            {
                if (ReferenceEquals(gameObject, existing))
                    return;
                Destroy(gameObject);
                // Return to skip the following registration code
                return;
            }
        }
        // The following code registers this GameObject regardless of whether it's new or replacing
        _instances[ID] = gameObject;

        DontDestroyOnLoad(gameObject);

        //DontDestroyOnLoad(this.gameObject);
        //DontDestroyOnLoad(Circle);
        //DontDestroyOnLoad(Background);
    }

    public void SetUpLevel()
    {
        CurrentLevel = MainMenuManager.SelectedLevel;
        StateMachine.GameState = GameState.gameNormal;
        SceneManager.LoadScene(1);
    }

    public void GoBossGame()
    {
        StateMachine.GameState = GameState.boss;
        SceneManager.LoadScene(CurrentLevel + 1);
    }

    public void GoToLevelChoiseMenu()
    {
        StateMachine.GameState = GameState.mainMenu;
        SceneManager.LoadScene(0);
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        MainMenuManager.OpenSubmenu(0);
        SceneManager.sceneLoaded -= SceneManager_sceneLoaded;
    }
}
