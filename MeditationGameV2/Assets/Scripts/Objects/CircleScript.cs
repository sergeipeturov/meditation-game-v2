using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleScript : MonoBehaviour
{
    public Animator CircleAnimator;
    public GameObject OreolGameObject;

    private void Awake()
    {
        CircleAnimator = GameObject.Find("Circle").gameObject.GetComponent<Animator>();
        OreolGameObject = GameObject.Find("Oreol").gameObject;
        EnableOreol();
        StartCircleIdleAnim();
    }

    public void StartMoving()
    {
        isMoving = true;
        EndCircleIdleAnim();
        DisableOreol();
    }

    public void EndMoving()
    {
        isMoving = false;
        StartCircleIdleAnim();
    }

    public void Move(Vector3 position)
    {
        transform.position = new Vector3(position.x, position.y, position.z); //норм
        //GetComponent<Rigidbody2D>().AddForce(position); //не норм
        //transform.Translate(position); //плохо
    }

    private void EnableOreol()
    {
        OreolGameObject.SetActive(true);
    }

    private void DisableOreol()
    {
        OreolGameObject.SetActive(false);
    }

    private void StartCircleIdleAnim()
    {
        CircleAnimator.SetBool("isMoving", false);
    }

    private void EndCircleIdleAnim()
    {
        CircleAnimator.SetBool("isMoving", true);
    }

    private bool isMoving = false;
}
