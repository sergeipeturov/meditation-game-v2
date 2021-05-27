using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BossDesiresGameManager : BossGameManager
{
    protected override void SetFailText()
    {
        FailPanel.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = "Пока что Вы в плену своих желаний. Продолжайте Вашу медитацию.";
    }

    protected override void SetWinText()
    {
        FailPanel.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = "Теперь желания больше не властны над Вами. Продолжайте в том же духе.";
    }
}
