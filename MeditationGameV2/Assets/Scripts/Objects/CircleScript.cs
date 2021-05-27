using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleScript : MonoBehaviour
{
    public delegate void FingerReleaseEvent();
    public event FingerReleaseEvent FingerReleaseEventNotify;

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
        if (GameManager.Instance.StateMachine.GameState == GameState.boss)
        {
            manScript = GameObject.Find("Man").GetComponent<ManScript>();
        }

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

            if (GameManager.Instance.StateMachine.GameState == GameState.gameNormal)
            {
                GameManager.Instance.StateMachine.GameState = GameState.gameNormalPlaying;
                NormalGameManager.Instance.EffectorUIManager.EnablePanels();
            }

            if (GameManager.Instance.StateMachine.GameState == GameState.boss)
            {
                GameManager.Instance.StateMachine.GameState = GameState.bossPlaying;
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

            if (GameManager.Instance.StateMachine.GameState == GameState.gameNormalPreBoss)
            {
                transform.position = new Vector3(0.0f, 0.0f, 0.0f);
                GameManager.Instance.GoBossGame();
            }

            if (GameManager.Instance.StateMachine.GameState == GameState.bossPreWin)
            {
                GameManager.Instance.StateMachine.GameState = GameState.bossWin;
                FingerReleaseEventNotify?.Invoke();
            }
        }
    }

    public void Move(Vector3 position)
    {
        if (canMove)
        {
            transform.position = new Vector3(position.x, position.y, 0.0f);
            if (GameManager.Instance.StateMachine.GameState == GameState.bossPlaying)
            {
                if (manScript != null)
                {
                    manScript.Move(position);
                }
            }
        }
    }

    public void EnableOreol()
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //love realization
        if (GameManager.Instance.PlayerManager.PosistiveThoughts.Any(x => x.Name == Names.Positive_9_Love))
        {
            if (collision != null && collision.gameObject != null && collision.gameObject.tag == "Idea")
            {
                Destroy(collision.gameObject);
                //TODO: добавить анимацию уничтожения
            }
        }
    }

    private bool isMoving = false;
    private bool isSystem = false;
    private bool canMove = true;
    private ManScript manScript;
}
