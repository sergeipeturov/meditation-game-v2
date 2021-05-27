using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossGameManager : MonoBehaviour
{
    public GameObject Man;
    public GameObject[] LifeUIs;
    public GameObject TimerSlider;
    public GameObject FailPanel;

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

    public virtual void OnOKClick()
    {
        //TODO: выход в меню выбора уровня
    }

    public void GoWin()
    {
        FailPanel.GetComponent<Animator>().SetTrigger("fadeIn");
        GameManager.Instance.CircleScript.FingerReleaseEventNotify -= GoWin;
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
                SetWinText();
                GameManager.Instance.StateMachine.GameState = GameState.bossPreWin;
                GameManager.Instance.CircleScript.EnableOreol();
                GameManager.Instance.CircleScript.FingerReleaseEventNotify += GoWin;
            }
        }
    }

    private void BossGameManager_DamageNotify()
    {
        if (GameManager.Instance.StateMachine.GameState == GameState.bossPlaying)
        {
            LifeUIs[lifes - 1].SetActive(false);
            lifes--;
            //TODO: animation of damage
        }

        if (lifes == 0)
        {
            SetFailText();
            GameManager.Instance.StateMachine.GameState = GameState.bossFail;
            FailPanel.GetComponent<Animator>().SetTrigger("fadeIn");
        }
    }

    protected virtual void SetTimerSlider()
    {
        maxTimerSliderTime = 60.0f;
        TimerSlider.GetComponent<Slider>().maxValue = maxTimerSliderTime;
    }

    protected virtual void SetFailText()
    {

    }

    protected virtual void SetWinText()
    {

    }

    private BossGameState bossGameState;
    float curAnimDelay = 0.0f;
    float maxAnimDelay = 1.5f;
    int lifes = 5;
    float maxTimerSliderTime = 60.0f;
    float curTimerSliderTime = 0.0f;
}
