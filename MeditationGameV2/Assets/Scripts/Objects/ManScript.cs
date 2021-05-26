using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManScript : MonoBehaviour
{
    public delegate void Damage();
    public event Damage DamageNotify;

    public void Move(Vector3 position)
    {
        Debug.Log("Man Moving");
        if (canMove)
        {
            transform.position = new Vector3(position.x, position.y, 0.0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.tag.Contains("Enemy"))
            {
                if (collision.gameObject.GetComponent<Enemy>().IsDangerous)
                {
                    Destroy(collision.gameObject);
                    DamageNotify?.Invoke();
                }
            }
        }
    }

    private bool canMove = true;
}
