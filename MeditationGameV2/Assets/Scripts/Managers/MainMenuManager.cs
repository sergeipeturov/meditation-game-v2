using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    public GameObject[] MainMenuButtons;
    public GameObject[] MainMenuTexts;

    public GameObject LevelSelectingPanel;
    public TextMeshProUGUI LevelDescriptionText;

    public MainMenuButtonScript SelectedButton { get; private set; }
    public int SelectedLevel { get; private set; }

    private void Update()
    {
        if (GameManager.Instance.StateMachine.GameState == GameState.mainMenu)
        {
            if (isWaitForSubmenu)
            {
                GameManager.Instance.CircleScript.BlockMove(true);
                curWaitTime += Time.deltaTime;
                if (curWaitTime >= maxWaitTime)
                {
                    curWaitTime += Time.deltaTime;
                    FadeOutAll();
                    if (curWaitTime >= maxWaitTime + 2.0f)
                    {
                        curWaitTime = 0.0f;
                        GameManager.Instance.Circle.SetActive(false);
                        OpenSubmenu(SelectedButton.Index);
                        isWaitForSubmenu = false;
                    }
                }
            }
        }
    }

    public void SelectButton(MainMenuButtonScript mainMenuButtonScript)
    {
        SelectedButton = mainMenuButtonScript;
        mainMenuButtonScript.Selected = true;
    }

    public void DeselectButton(MainMenuButtonScript mainMenuButtonScript)
    {
        SelectedButton = null;
        mainMenuButtonScript.Selected = false;
    }

    public void MainMenuFadeIn()
    {
        foreach (var item in MainMenuButtons)
        {
            item.GetComponent<Animator>().SetTrigger("fadeIn");
        }
        foreach (var item in MainMenuTexts)
        {
            if (item.GetComponent<Animator>() == null)
                item.SetActive(true);
            else
                item.GetComponent<Animator>().SetTrigger("fadeIn");
        }
    }

    public void MainMenuFadeOut()
    {
        foreach (var item in MainMenuButtons)
        {
            if (!item.GetComponent<MainMenuButtonScript>().Selected)
                item.GetComponent<Animator>().SetTrigger("fadeOut");
        }
        if (SelectedButton != null && (SelectedButton.Index == 0 || SelectedButton.Index == 1))
        {
            isWaitForSubmenu = true;
        }
    }

    public void SelectLevel(int level)
    {
        SelectedLevel = level;
        switch (level)
        {
            case 1:
                LevelDescriptionText.text = "Этап 1. Амбиции.";
                break;
            case 2:
                LevelDescriptionText.text = "Этап 2. Беспокойства.";
                break;
            case 3:
                LevelDescriptionText.text = "Этап 3. Желания.";
                break;
            case 4:
                LevelDescriptionText.text = "Этап 4. Страхи.";
                break;
            case 5:
                LevelDescriptionText.text = "Этап 5. Уныние.";
                break;
            case 6:
                LevelDescriptionText.text = "Этап 6. Стресс.";
                break;
            case 7:
                LevelDescriptionText.text = "Этап 7. Сожаления.";
                break;
            case 8:
                LevelDescriptionText.text = "Этап 8. Самолюбие.";
                break;
        }
    }

    private void FadeOutAll()
    {
        SelectedButton.GetComponent<Animator>().SetTrigger("fadeOut");
        foreach (var item in MainMenuTexts)
        {
            if (item.GetComponent<Animator>() == null)
                item.SetActive(false);
            else
                item.GetComponent<Animator>().SetTrigger("fadeOut");
        }
    }

    private void OpenSubmenu(int submenuIndex)
    {
        switch (submenuIndex)
        {
            case 0:
                LevelSelectingPanel.SetActive(true);
                break;
            case 1:
                break;
        }
    }

    private float maxWaitTime = 1.0f;
    private float curWaitTime = 0.0f;
    private bool isWaitForSubmenu = false;
}
