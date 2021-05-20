using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public void GoBlackBack()
    {
        GetComponent<SpriteRenderer>().color = new Color(0, 0, 0);
    }

    public void GoUsualBack()
    {
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
    }
}
