using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BossAnxietyGameManager : BossGameManager
{
    protected override void SetBossType()
    {
        BossType = BossType.lifer;
    }

    protected override void SetFailText()
    {
        FailPanel.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = "Беспокойства не покидают Вас. Продолжайте Вашу медитацию.";
    }

    protected override void SetWinText()
    {
        FailPanel.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = "Вы побороли Ваши беспокойства. Но путь только начинается.";
    }
}
