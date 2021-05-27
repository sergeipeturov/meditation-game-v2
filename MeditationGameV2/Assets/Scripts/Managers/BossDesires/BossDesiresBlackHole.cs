using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDesiresBlackHole : MonoBehaviour
{
    public delegate void BossDamage();
    public event BossDamage BossDamageNotify;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.tag.Contains("Enemy"))
            {
                if (collision.gameObject.GetComponent<Enemy>().IsDangerous)
                {
                    Destroy(collision.gameObject);
                    BossDamageNotify?.Invoke();
                }
            }
        }
    }
}
