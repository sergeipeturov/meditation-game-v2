using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BleckHolesManager : MonoBehaviour
{
    public GameObject[] BlackHoles;

    private void Start()
    {
        currentTimeBetweenBlackHoles = 0.0f;
        timeBetweenBlackHoles = Random.Range(GameManager.Instance.LevelsManager.CurrentLevel.MinTimeBetweenBlackHoles, GameManager.Instance.LevelsManager.CurrentLevel.MaxTimeBetweenBlackHoles);
        isBlackHoleOn = false;
        TurnOffAllBlackHoles();
    }

    private void Update()
    {
        if (GameManager.Instance.StateMachine.GameState == GameState.gameNormalPlaying)
        {
            if (GameManager.Instance.LevelsManager.CurrentLevel.ChanceOfBlackHole == 0) return;

            if (!isBlackHoleOn)
            {
                currentTimeBetweenBlackHoles += Time.deltaTime;
                if (currentTimeBetweenBlackHoles >= timeBetweenBlackHoles)
                {
                    currentTimeBetweenBlackHoles = 0.0f;
                    timeBetweenBlackHoles = Random.Range(GameManager.Instance.LevelsManager.CurrentLevel.MinTimeBetweenBlackHoles, GameManager.Instance.LevelsManager.CurrentLevel.MaxTimeBetweenBlackHoles);
                    timeOfLifeBlackHole = Constants.BlackHoleTimeOfLife;
                    currentTimeTimeOfLifeBlackHole = 0.0f;
                    if (Randomizer.GetResultByChanse(GameManager.Instance.LevelsManager.CurrentLevel.ChanceOfBlackHole))
                    {
                        int bhIndex = Random.Range(0, BlackHoles.Length);
                        BlackHoles[bhIndex].SetActive(true);
                        isBlackHoleOn = true;
                    }
                }
            }
            else
            {
                currentTimeTimeOfLifeBlackHole += Time.deltaTime;
                if (currentTimeTimeOfLifeBlackHole >= timeOfLifeBlackHole)
                {
                    TurnOffAllBlackHoles();
                    isBlackHoleOn = false;
                }
            }
        }
    }

    private void TurnOffAllBlackHoles()
    {
        foreach (var item in BlackHoles)
        {
            item.SetActive(false);
        }
    }

    private float timeBetweenBlackHoles;
    private float currentTimeBetweenBlackHoles;
    private float timeOfLifeBlackHole;
    private float currentTimeTimeOfLifeBlackHole;
    private bool isBlackHoleOn;
}
