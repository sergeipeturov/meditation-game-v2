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
    mainMenu, //показывается главное меню
    gameNormal, //начинается обычная игра (но еще до дого, как игрок впервые коснулся круга)
    gameNormalPlaying, //играется обычная игра (после того, как игрок коснулся круга и у того исчезл ореол)
    gameNormalPreBoss, //обычная игра, когда таймер заполнен и от игрока нужно отпустить палец с круга
    boss, //начинается игра с боссом (но еще до дого, как игрок впервые коснулся круга)
    bossPlaying, //играется игра с боссом (после того, как игрок коснулся круга и у того исчезл ореол)
}

public enum NormalGameState
{
    intro,
    choiseOfThoughts,
    prePlay
}

public enum BossGameState
{
    intro
}
