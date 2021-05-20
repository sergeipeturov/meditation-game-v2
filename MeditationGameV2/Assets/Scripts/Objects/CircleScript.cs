﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleScript : MonoBehaviour
{
    public Animator CircleAnimator { get; private set; }
    public GameObject OreolGameObject { get; private set; }

    private void Awake()
    {
        CircleAnimator = GameObject.Find("Circle").gameObject.GetComponent<Animator>();
        OreolGameObject = GameObject.Find("Oreol").gameObject;
        EnableOreol();
        StartCircleIdleAnim();
    }

    public void BlockMove(bool block)
    {
        canMove = !block;
    }

    public void StartMoving()
    {
        if (canMove)
        {
            isMoving = true;
            isSystem = false;
            EndCircleIdleAnim();
            DisableOreol();

            if (GameManager.Instance.StateMachine.GameState == GameState.mainMenu)
            {
                GameManager.Instance.MainMenuManager.MainMenuFadeIn();
            }
        }
    }

    public void EndMoving()
    {
        if (canMove)
        {
            isMoving = false;
            StartCircleIdleAnim();

            if (GameManager.Instance.StateMachine.GameState == GameState.mainMenu)
            {
                GameManager.Instance.MainMenuManager.MainMenuFadeOut();
                isSystem = true;
                transform.position = new Vector3(0.0f, 0.0f, 0.0f);
            }
        }
    }

    public void Move(Vector3 position)
    {
        if (canMove)
        {
            transform.position = new Vector3(position.x, position.y, 0.0f);
        }
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isSystem)
        {
            if (GameManager.Instance.StateMachine.GameState == GameState.mainMenu)
            {
                if (collision != null)
                {
                    if (collision.gameObject.tag.Contains("MainMenuButton"))
                    {
                        GameManager.Instance.MainMenuManager.SelectButton(collision.gameObject.GetComponent<MainMenuButtonScript>());
                        collision.gameObject.transform.rotation = Quaternion.AngleAxis(+25.0f, Vector3.forward) * collision.gameObject.transform.rotation;
                    }
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!isSystem)
        {
            if (GameManager.Instance.StateMachine.GameState == GameState.mainMenu)
            {
                if (collision != null)
                {
                    if (collision.gameObject.tag.Contains("MainMenuButton"))
                    {
                        GameManager.Instance.MainMenuManager.DeselectButton(collision.gameObject.GetComponent<MainMenuButtonScript>());
                        collision.gameObject.transform.rotation = Quaternion.AngleAxis(-25.0f, Vector3.forward) * collision.gameObject.transform.rotation;
                    }
                }
            }
        }
    }

    private bool isMoving = false;
    private bool isSystem = false;
    private bool canMove = true;
}
