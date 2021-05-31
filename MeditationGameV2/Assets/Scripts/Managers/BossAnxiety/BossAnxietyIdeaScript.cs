using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnxietyIdeaScript : MonoBehaviour
{
    public delegate void OnDestroyIdea(GameObject gameObject);
    public event OnDestroyIdea OnDestroyIdeaNotify;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.tag.Contains("GameBorder"))
            {
                OnDestroyIdeaNotify?.Invoke(gameObject);
            }
        }
    }
}
