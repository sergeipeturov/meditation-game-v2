using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailFieldScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var idea = collision.gameObject.GetComponent<IdeaScript>();
        if (idea != null)
        {
            GameManager.Instance.PlayerManager.AddThought(idea.Thought);
        }
    }
}
