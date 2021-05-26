using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManScript : MonoBehaviour
{
    public void Move(Vector3 position)
    {
        Debug.Log("Man Moving");
        //if (canMove)
        //{
            transform.position = new Vector3(position.x, position.y, 0.0f);
        //}
    }

    private bool canMove = true;
}
