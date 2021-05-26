using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossGameManager : MonoBehaviour
{
    public GameObject Man;
    public GameObject[] LifeUIs;
    public GameObject TimerSlider;

    private void Awake()
    {
        BossGameState = BossGameState.intro;
        Man.GetComponent<ManScript>().DamageNotify += BossGameManager_DamageNotify;
        foreach (var item in LifeUIs)
            item.SetActive(true);
        lifes = 5;
        SetTimerSlider();
    }

    public BossGameState BossGameState
    {
        get { return bossGameState; }
        private set
        {
            bossGameState = value;
            OnBossGameStateChange();
        }
    }

    private void OnBossGameStateChange()
    {
        if (BossGameState == BossGameState.intro)
        {
            //Man.GetComponent<Animator>().SetTrigger("bossIntro");
        }
    }

    private void Update()
    {
        /*if (BossGameState == BossGameState.intro)
        {
            curAnimDelay += Time.deltaTime;
            if (curAnimDelay >= maxAnimDelay)
            {
                Man.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
            }
        }*/

        if (GameManager.Instance.StateMachine.GameState == GameState.bossPlaying)
        {
            curTimerSliderTime += Time.deltaTime;
            TimerSlider.GetComponent<Slider>().value = curTimerSliderTime;
            if (curTimerSliderTime >= maxTimerSliderTime)
            {
                //TODO: gameover (win)
            }
        }
    }

    private void BossGameManager_DamageNotify()
    {
        LifeUIs[lifes - 1].SetActive(false);
        lifes--;
        //TODO: gameover (fail) + animation of damage
    }

    protected virtual void SetTimerSlider()
    {
        maxTimerSliderTime = 60.0f;
        TimerSlider.GetComponent<Slider>().maxValue = maxTimerSliderTime;
    }

    private BossGameState bossGameState;
    float curAnimDelay = 0.0f;
    float maxAnimDelay = 1.5f;
    int lifes = 5;
    float maxTimerSliderTime = 60.0f;
    float curTimerSliderTime = 0.0f;
}
