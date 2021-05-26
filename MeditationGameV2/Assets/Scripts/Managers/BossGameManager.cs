using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGameManager : MonoBehaviour
{
    public GameObject Man;

    private void Awake()
    {
        BossGameState = BossGameState.intro;
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
    }

    private BossGameState bossGameState;
    float curAnimDelay = 0.0f;
    float maxAnimDelay = 1.5f;
}
