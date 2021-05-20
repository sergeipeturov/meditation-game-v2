using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public GameState GameState { get; set; }

    private void Awake()
    {
        GameState = GameState.mainMenu;
    }
}

public enum GameState
{
    mainMenu
}
