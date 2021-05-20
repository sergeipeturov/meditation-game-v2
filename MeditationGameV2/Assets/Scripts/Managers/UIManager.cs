using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject IntroPanel { get; set; }
    public GameObject ChoiseOfThoughtsPanel { get; set; }

    public void ShowIntro(int level)
    {
        IntroPanel = GameObject.Find("Canvas").transform.Find("IntroPanel").gameObject;
        var levelTitle = IntroPanel.transform.Find("LevelTitle").GetComponent<TextMeshProUGUI>();
        var introText = IntroPanel.transform.Find("IntroText").GetComponent<TextMeshProUGUI>();
        IntroPanel.SetActive(true);
        switch (level)
        {
            case 1:
                levelTitle.text = $"Этап 1.{Environment.NewLine}Амбиции";
                introText.text = $"Здесь будет глубокомысленное описание 1 этапа.";
                break;
            case 2:
                levelTitle.text = $"Этап 2.{Environment.NewLine}Беспокойства";
                introText.text = $"Здесь будет глубокомысленное описание 2 этапа.";
                break;
            case 3:
                levelTitle.text = $"Этап 3.{Environment.NewLine}Желания";
                introText.text = $"Здесь будет глубокомысленное описание 3 этапа.";
                break;
            case 4:
                levelTitle.text = $"Этап 4.{Environment.NewLine}Страхи";
                introText.text = $"Здесь будет глубокомысленное описание 4 этапа.";
                break;
            case 5:
                levelTitle.text = $"Этап 5.{Environment.NewLine}Уныние";
                introText.text = $"Здесь будет глубокомысленное описание 5 этапа.";
                break;
            case 6:
                levelTitle.text = $"Этап 6.{Environment.NewLine}Стресс";
                introText.text = $"Здесь будет глубокомысленное описание 6 этапа.";
                break;
            case 7:
                levelTitle.text = $"Этап 7.{Environment.NewLine}Сожаления";
                introText.text = $"Здесь будет глубокомысленное описание 7 этапа.";
                break;
            case 8:
                levelTitle.text = $"Этап 8.{Environment.NewLine}Самолюбие";
                introText.text = $"Здесь будет глубокомысленное описание 8 этапа.";
                break;
        }    
    }

    public void DisableIntro()
    {
        if (IntroPanel == null) IntroPanel = GameObject.Find("Canvas").transform.Find("IntroPanel").gameObject;
        IntroPanel.SetActive(false);
    }

    public void ShowChoiseOfThoughts(int level)
    {
        ChoiseOfThoughtsPanel = GameObject.Find("Canvas").transform.Find("ChoiseOfThoughtsPanel").gameObject;
        var levelTitle = ChoiseOfThoughtsPanel.transform.Find("LevelTitle").GetComponent<TextMeshProUGUI>();
        var text = ChoiseOfThoughtsPanel.transform.Find("Text").GetComponent<TextMeshProUGUI>();
        text.text = $"Вы начнете с этими думами (нажмите на каждую, чтобы открыть):";
        ChoiseOfThoughtsPanel.SetActive(true);
        var button = ChoiseOfThoughtsPanel.transform.Find("Button").GetComponent<Button>();
        button.interactable = false;
        switch (level)
        {
            case 1:
                levelTitle.text = $"Этап 1.{Environment.NewLine}Амбиции";
                break;
            case 2:
                levelTitle.text = $"Этап 2.{Environment.NewLine}Беспокойства";
                break;
            case 3:
                levelTitle.text = $"Этап 3.{Environment.NewLine}Желания";
                break;
            case 4:
                levelTitle.text = $"Этап 4.{Environment.NewLine}Страхи";
                break;
            case 5:
                levelTitle.text = $"Этап 5.{Environment.NewLine}Уныние";
                break;
            case 6:
                levelTitle.text = $"Этап 6.{Environment.NewLine}Стресс";
                break;
            case 7:
                levelTitle.text = $"Этап 7.{Environment.NewLine}Сожаления";
                break;
            case 8:
                levelTitle.text = $"Этап 8.{Environment.NewLine}Самолюбие";
                break;
        }
    }

    public void DisableChoiseOfThoughts()
    {
        if (ChoiseOfThoughtsPanel == null) ChoiseOfThoughtsPanel = GameObject.Find("Canvas").transform.Find("ChoiseOfThoughtsPanel").gameObject;
        ChoiseOfThoughtsPanel.SetActive(false);
    }

}
