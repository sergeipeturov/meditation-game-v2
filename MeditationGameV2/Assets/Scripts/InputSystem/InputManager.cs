using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(-1)] //чтобы запускался перед всеми остальными
public class InputManager : MonoBehaviour
{
    private void Awake()
    {
        touchControls = new TouchControls();
        mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        touchControls.Enable();
    }

    private void OnDisable()
    {
        touchControls.Disable();
    }

    void Start()
    {
        touchControls.Touch.TouchPress.started += ctx => StartTouch(ctx);
        touchControls.Touch.TouchPress.canceled += ctx => EndTouch(ctx);
    }

    private void Update()
    {
        if (isOnTouch)
        {
            Vector3 touchPosition = Utils.ScreenToWorld(mainCamera, touchControls.Touch.TouchPosition.ReadValue<Vector2>());
            //Debug.Log("position: " + touchPosition);
            if (circleScript != null)
            {
                circleScript.Move(touchPosition);
            }
        }
    }

    private void StartTouch(InputAction.CallbackContext context)
    {
        Vector3 touchPosition = Utils.ScreenToWorld(mainCamera, touchControls.Touch.TouchPosition.ReadValue<Vector2>());
        //Debug.Log("Touch STARTED " + touchPosition);
        isOnTouch = true;

        RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero);
        var collider = hit.collider;
        if (collider != null)
        {
            if (collider.gameObject.tag.Contains("Circle"))
            {
                circleScript = collider.gameObject.GetComponent<CircleScript>();
                circleScript.StartMoving();
            }
        }
    }

    private void EndTouch(InputAction.CallbackContext context)
    {
        //Debug.Log("Touch ENDED " + Utils.ScreenToWorld(mainCamera, touchControls.Touch.TouchPosition.ReadValue<Vector2>()));
        isOnTouch = false;
        
        if (circleScript != null)
        {
            circleScript.EndMoving();
            circleScript = null;
        }
    }

    private TouchControls touchControls;
    private Camera mainCamera;
    private bool isOnTouch = false;
    private CircleScript circleScript; //это конечно неправильно, надо через события делать, но для такого простого приложения можно и так, думаю
}
