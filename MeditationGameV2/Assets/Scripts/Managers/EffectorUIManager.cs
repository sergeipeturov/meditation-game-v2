using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectorUIManager : MonoBehaviour
{
    public GameObject[] PositiveUIs;
    public GameObject[] NegativeUIs;
    public GameObject PositiveUIsPanel;
    public GameObject NegativeUIsPanel;
    public GameObject TimerSlider;

    public void EnablePanels()
    {
        PositiveUIsPanel.SetActive(true);
        NegativeUIsPanel.SetActive(true);
    }

    public void DisablePanels()
    {
        PositiveUIsPanel.SetActive(false);
        NegativeUIsPanel.SetActive(false);
    }

    public void UpdatePositiveUIs(List<Thought> thoughts)
    {
        foreach (var item in PositiveUIs)
        {
            var thought = thoughts.FirstOrDefault(x => x.Name == item.name);
            if (thought != null)
            {
                item.SetActive(true);
                item.GetComponent<Image>().fillClockwise = true;
                item.GetComponent<Image>().fillAmount = 1 - (thought.CurrentTimeOfLife / thought.TimeOfLife);
            }
            else
            {
                item.SetActive(false);
            }    
        }
    }

    public void UpdateNegativeUIs(List<Thought> thoughts)
    {
        foreach (var item in NegativeUIs)
        {
            var thought = thoughts.FirstOrDefault(x => x.Name == item.name);
            if (thought != null)
            {
                item.SetActive(true);
                item.GetComponent<Image>().fillClockwise = true;
                item.GetComponent<Image>().fillAmount = 1 - (thought.CurrentTimeOfLife / thought.TimeOfLife);
            }
            else
            {
                item.SetActive(false);
            }
        }
    }

    public void SetTimerSlider(float timeToReach)
    {
        TimerSlider.GetComponent<Slider>().maxValue = timeToReach;
    }

    public void UpdateTimerSlider(float time)
    {
        if (time > 0)
        {
            TimerSlider.SetActive(true);
            TimerSlider.GetComponent<Slider>().value = time;
        }
        else
        {
            TimerSlider.GetComponent<Slider>().value = time;
            TimerSlider.SetActive(false);
        }
    }
}
