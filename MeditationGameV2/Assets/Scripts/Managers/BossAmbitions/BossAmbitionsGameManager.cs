using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BossAmbitionsGameManager : BossGameManager
{
    protected override void SetFailText()
    {
        FailPanel.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = "Пока что Вы не готовы отказаться от своих амбиций. Продолжайте Вашу медитацию.";
    }

    protected override void SetWinText()
    {
        FailPanel.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = "Теперь вы свободны от амбиций. Но впереди еще долгий путь к совершенству. Продолжайте Вашу медитацию.";
    }
}
