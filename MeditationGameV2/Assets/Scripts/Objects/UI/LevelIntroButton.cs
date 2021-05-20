using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelIntroButton : MonoBehaviour
{
    public delegate void GoLevel();
    public event GoLevel GoLevelNotify;

    public void OnGoLevelClick()
    {
        GoLevelNotify?.Invoke();
    }
}
