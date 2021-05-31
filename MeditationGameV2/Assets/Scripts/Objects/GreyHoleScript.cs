using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreyHoleScript : MonoBehaviour
{
    public void Unlock()
    {
        isLocked = false;
        if (lockedObj != null)
        {
            if (lockedObj.tag.Contains("Idea"))
            {
                lockedObj.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                lockedObj.GetComponent<Rigidbody2D>().gravityScale = 1;
                lockedObj.GetComponent<Rigidbody2D>().mass = 1;
            }
            lockedObj = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isLocked)
        {
            if (collision != null)
            {
                if (collision.gameObject.tag.Contains("Idea"))
                {
                    lockedObj = collision.gameObject;
                    lockedObj.transform.position = new Vector3(transform.position.x, transform.position.y, 0.0f);
                    lockedObj.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                    lockedObj.GetComponent<Rigidbody2D>().gravityScale = 0;
                    lockedObj.GetComponent<Rigidbody2D>().mass = 1000000;
                }
                isLocked = true;
            }
        }
    }

    private bool isLocked;
    private GameObject lockedObj;
}
