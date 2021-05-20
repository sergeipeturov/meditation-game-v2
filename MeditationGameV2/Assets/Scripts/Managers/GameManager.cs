using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Circle;
    public CircleScript CircleScript { get { return Circle.GetComponent<CircleScript>(); } }
    public InputManager InputManager { get { return GetComponent<InputManager>(); } }
    public StateMachine StateMachine { get { return GetComponent<StateMachine>(); } }
    public UIManager UIManager { get { return GetComponent<UIManager>(); } }
    public MainMenuManager MainMenuManager { get { return GetComponent<MainMenuManager>(); } }
    public static GameManager Instance { get { return GameObject.Find("GameManager").GetComponent<GameManager>(); } }

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
}
