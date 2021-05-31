using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreyHoleManager : MonoBehaviour
{
    public GameObject[] GreyHoles;

    private void Start()
    {
        currentTimeBetweenGreyHoles = 0.0f;
        timeBetweenGreyHoles = Random.Range(GameManager.Instance.LevelsManager.CurrentLevel.MinTimeBetweenGreyHoles, GameManager.Instance.LevelsManager.CurrentLevel.MaxTimeBetweenGreyHoles);
        isGreyHoleOn = false;
        TurnOffAllGreyHoles();
    }

    private void Update()
    {
        if (GameManager.Instance.StateMachine.GameState == GameState.gameNormalPlaying)
        {
            if (GameManager.Instance.LevelsManager.CurrentLevel.ChanceOfGreyHole == 0) return;

            if (!isGreyHoleOn)
            {
                currentTimeBetweenGreyHoles += Time.deltaTime;
                if (currentTimeBetweenGreyHoles >= timeBetweenGreyHoles)
                {
                    currentTimeBetweenGreyHoles = 0.0f;
                    timeBetweenGreyHoles = Random.Range(GameManager.Instance.LevelsManager.CurrentLevel.MinTimeBetweenGreyHoles, GameManager.Instance.LevelsManager.CurrentLevel.MaxTimeBetweenGreyHoles);
                    timeOfLifeGreyHole = Constants.GreyHoleTimeOfLife;
                    currentTimeTimeOfLifeGreyHole = 0.0f;
                    if (Randomizer.GetResultByChanse(GameManager.Instance.LevelsManager.CurrentLevel.ChanceOfGreyHole))
                    {
                        int bhIndex = Random.Range(0, GreyHoles.Length);
                        GreyHoles[bhIndex].SetActive(true);
                        isGreyHoleOn = true;
                    }
                }
            }
            else
            {
                currentTimeTimeOfLifeGreyHole += Time.deltaTime;
                if (currentTimeTimeOfLifeGreyHole >= timeOfLifeGreyHole)
                {
                    TurnOffAllGreyHoles();
                    isGreyHoleOn = false;
                }
            }
        }
    }

    private void TurnOffAllGreyHoles()
    {
        foreach (var item in GreyHoles)
        {
            item.GetComponent<GreyHoleScript>().Unlock();
            item.SetActive(false);
        }
    }

    private float timeBetweenGreyHoles;
    private float currentTimeBetweenGreyHoles;
    private float timeOfLifeGreyHole;
    private float currentTimeTimeOfLifeGreyHole;
    private bool isGreyHoleOn;
}
