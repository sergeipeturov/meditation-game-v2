using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbitionScript : Enemy
{
    private void Start()
    {
        GetComponent<SpriteRenderer>().color = Color.green;
        IsDangerous = false;
    }

    private void Update()
    {
        curWaitTime += Time.deltaTime;
        if (curWaitTime < maxWaitTime)
            GetComponent<SpriteRenderer>().color = Color.Lerp(Color.green, Color.red, curWaitTime);
        if (curWaitTime >= maxWaitTime)
        {
            //curWaitTime = 0.0f;
            //maxWaitTime = Random.Range(0.8f, 3.0f);
            IsDangerous = true;
            GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * 60.0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.tag.Contains("GameBorder"))
            {
                Destroy(gameObject);
            }
        }
    }

    private float maxWaitTime = 1.0f;
    private float curWaitTime = 0.0f;
}
