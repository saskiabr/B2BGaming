using UnityEngine;

public class LookController : MonoBehaviour
{
    public float speed = 1;
    public DynamicJoystick variableJoystick;
    public Rigidbody rb;
    public float sensitivity = 1;
    public Transform CameraHolder;

    private float verticalLookRotation;
    private int lookTouchId = -1;

    private void FixedUpdate()
    {   
        if (Timer.GameEnded) { return; }

        // Get the player's forward and right directions
        Vector3 forward = transform.forward;
        Vector3 right = transform.right;

        // Calculate the joystick movement
        Vector3 direction;
        if (ExperimentSettings.IsControlCondition)
        {
            // Normal vertical control
            direction = forward * variableJoystick.Vertical + right * variableJoystick.Horizontal;
        }
        else
        {   // Inverted vertical control
            direction = forward * -variableJoystick.Vertical + right * variableJoystick.Horizontal;
        }

        // Move the player
        Vector3 move = direction * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + move);
    }

    private void Update()
    {
        if (Timer.GameEnded) { return; }

        // This is in charge of looking around
        HandleTouchInput();
    }

    private void HandleTouchInput()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);

            if (touch.phase == TouchPhase.Began)
            {
                // Check if the touch is on the right half of the screen
                if (touch.position.x > Screen.width / 2)
                {
                    lookTouchId = touch.fingerId;
                }
            }
            else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                // Handle looking around
                if (touch.fingerId == lookTouchId)
                {
                    Vector2 touchDelta = touch.deltaPosition;

                    // Horizontal rotation (around Y axis)
                    transform.Rotate(Vector3.up * touchDelta.x * sensitivity * Time.deltaTime);

                    // Vertical rotation
                    verticalLookRotation -= touchDelta.y * sensitivity * Time.deltaTime;

                    // Clamp vertical rotation to avoid flipping
                    verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);
                    CameraHolder.localEulerAngles = new Vector3(verticalLookRotation, 0, 0);
                }
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                if (touch.fingerId == lookTouchId)
                {
                    lookTouchId = -1; // Reset look touch ID when the touch ends
                }
            }
        }
    }
}
