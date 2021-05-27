using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDesiresBlackHoles : MonoBehaviour
{
    public GameObject[] BlackHoles;

    private void Start()
    {
        foreach (var item in BlackHoles)
        {
            item.GetComponent<BossDesiresBlackHole>().BossDamageNotify += BossDesiresBlackHoles_BossDamageNotify;
        }
        ActivateBlackHole(4);
    }

    public void ActivateBlackHole(int num)
    {
        foreach (var item in BlackHoles)
        {
            item.SetActive(false);
        }
        if (num >= 0)
            BlackHoles[num].SetActive(true);
    }

    private void BossDesiresBlackHoles_BossDamageNotify()
    {
        GameObject.Find("BossGameManager").GetComponent<BossGameManager>().BossDamage();
        ActivateBlackHole(GameObject.Find("BossGameManager").GetComponent<BossGameManager>().BossLifes - 1);
    }
}
