using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour
{
    public static Vector3 ScreenToWorld(Camera camera, Vector3 position)
    {
        position.z = camera.nearClipPlane;
        return camera.ScreenToWorldPoint(position);
    }

    public static Vector3 ScreenToWorld(Vector3 position)
    {
        position.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(position);
    }

    /*public static GameObject GetGameManager()
    {
        //return GameObject.Find("GameManager");
        return GameObject.FindGameObjectWithTag("GameController");
    }*/
}
