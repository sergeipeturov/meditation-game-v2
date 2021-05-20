using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public GameObject[] MainMenuButtons;
    public GameObject[] MainMenuTexts;

    public MainMenuButtonScript SelectedButton { get; private set; }

    private void Update()
    {
        if (isWaitForSubmenu)
        {
            GameManager.Instance.CircleScript.BlockMove(true);
            curWaitTime += Time.deltaTime;
            if (curWaitTime >= maxWaitTime)
            {
                curWaitTime += Time.deltaTime;
                OpenSubmenu(SelectedButton.Index);
                if (curWaitTime >= maxWaitTime + 1.0f)
                {
                    curWaitTime = 0.0f;
                    GameManager.Instance.Circle.SetActive(false);
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

    private void OpenSubmenu(int submenuIndex)
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

    private float maxWaitTime = 1.0f;
    private float curWaitTime = 0.0f;
    private bool isWaitForSubmenu = false;
}
