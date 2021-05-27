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

    public BossType BossType { get; set; }

    private void Awake()
    {
        BossGameState = BossGameState.intro;
        Man.GetComponent<ManScript>().DamageNotify += BossGameManager_DamageNotify;
        foreach (var item in LifeUIs)
            item.SetActive(true);
        lifes = 5;
        SetBossType();
        SetTimerSlider();
        SetBossLifes();
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
        GameManager.Instance.GoToLevelChoiseMenu();
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
            if (BossType == BossType.timer)
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

    protected virtual void SetBossType()
    {
        BossType = BossType.timer;
        if (BossType == BossType.timer)
        {
            TimerSlider.SetActive(true);
        }
        if (BossType == BossType.lifer)
        {
            TimerSlider.SetActive(false);
        }
    }

    protected virtual void SetTimerSlider()
    {
        maxTimerSliderTime = 60.0f;
        TimerSlider.GetComponent<Slider>().maxValue = maxTimerSliderTime;
    }

    protected virtual void SetBossLifes()
    {

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

public enum BossType
{
    timer,
    lifer
}
