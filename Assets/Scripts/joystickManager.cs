using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class joystickManager : MonoBehaviour
{
    public static joystickManager instance { get; private set; }

    // Player movement
    private Vector2 moveTouchStartPosition;
    private Vector2 moveInput;

    public float Horizontal { get; private set; }
    public float Vertical { get; private set; }
    public bool IsMoving { get; private set; }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(this.gameObject);
            return;
        }
    }
    void Update()
    {
        GetTouchInput();
    }
    void GetTouchInput()
    {
        // Iterate through all the detected touches
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch t = Input.GetTouch(i);
            switch (t.phase)
            {
                case TouchPhase.Began:
                    moveTouchStartPosition = t.position;
                    break;
                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    moveInput = Vector2.zero;
                    break;
                case TouchPhase.Moved:
                    moveInput = (t.position - moveTouchStartPosition).normalized;
                    break;
                case TouchPhase.Stationary:
                    break;
            }
        }
        Vertical = moveInput.y;
        Horizontal = moveInput.x;

        if (moveInput == Vector2.zero)
            IsMoving = false;
        else
            IsMoving = true;

    }
}
