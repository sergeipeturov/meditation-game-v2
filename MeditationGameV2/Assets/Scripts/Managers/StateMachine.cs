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
    /// <summary>
    /// показывается главное меню
    /// </summary>
    mainMenu,
    /// <summary>
    /// начинается обычная игра (но еще до дого, как игрок впервые коснулся круга)
    /// </summary>
    gameNormal,
    /// <summary>
    /// играется обычная игра (после того, как игрок коснулся круга и у того исчезл ореол)
    /// </summary>
    gameNormalPlaying,
    /// <summary>
    /// обычная игра, когда таймер заполнен и от игрока нужно отпустить палец с круга
    /// </summary>
    gameNormalPreBoss,
    /// <summary>
    /// начинается игра с боссом (но еще до дого, как игрок впервые коснулся круга)
    /// </summary>
    boss,
    /// <summary>
    /// играется игра с боссом (после того, как игрок коснулся круга и у того исчезл ореол)
    /// </summary>
    bossPlaying,
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
