using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.tag.Contains("Idea"))
            {
                GameManager.Instance.Ideas.Remove(collision.gameObject);
                Destroy(collision.gameObject);
            }
        }
    }
}
