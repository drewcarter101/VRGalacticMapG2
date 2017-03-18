using UnityEngine;

[RequireComponent(typeof(Camera))]
public class GhostFreeRoamCamera : MonoBehaviour
{
    public float initialSpeed = 10f;
    public float increaseSpeed = 1.25f;

    public bool allowMovement = true;
    public bool allowRotation = true;

    public KeyCode forwardButton = KeyCode.W;
    public KeyCode backwardButton = KeyCode.S;
    public KeyCode rightButton = KeyCode.D;
    public KeyCode leftButton = KeyCode.A;

    public float cursorSensitivity = 0.025f;
    public bool cursorToggleAllowed = true;
    public KeyCode cursorToggleButton = KeyCode.Escape;

    private float currentSpeed = 0f;
    private bool moving = false;
    private bool togglePressed = false;

    private void OnEnable()
    {
        if (cursorToggleAllowed) {
			Cursor.lockState = CursorLockMode.Locked;
        }
    }

    private void LateUpdate()
    {
        if (allowMovement)
        {
            bool lastMoving = moving;
            Vector3 deltaPosition = Vector3.zero;

            if (moving)
                currentSpeed += increaseSpeed * Time.deltaTime;

            moving = false;

            CheckMove(forwardButton, ref deltaPosition, transform.forward);
            CheckMove(backwardButton, ref deltaPosition, -transform.forward);
            CheckMove(rightButton, ref deltaPosition, transform.right);
            CheckMove(leftButton, ref deltaPosition, -transform.right);

            if (moving)
            {
                if (moving != lastMoving)
                    currentSpeed = initialSpeed;

                transform.position += deltaPosition * currentSpeed * Time.deltaTime;
            }
            else currentSpeed = 0f;            
        }



        if (allowRotation)
        {
			//TODO: update the camera movement system to Quaternions:
			//Incrementing the eulerAngles causes the reseting

            Vector3 eulerAngles = transform.eulerAngles;
            eulerAngles.x += -Input.GetAxis("Mouse Y") * 100f * cursorSensitivity;
			eulerAngles.y += Input.GetAxis ("Mouse X") * 100f * cursorSensitivity;

			//added (by corrado)so that camera doesn't flip "upside down"
			//eulerAngles.x = Mathf.Clamp(eulerAngles.x, 0f, 180f);
			while(eulerAngles.y > 180) eulerAngles.y -= 360;
			while(eulerAngles.y < -180) eulerAngles.y += 360;


			transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, eulerAngles, 1f);
            
        }

        if (cursorToggleAllowed)
        {
            if (Input.GetKey(cursorToggleButton))
            {
				togglePressed = !togglePressed;

				if (togglePressed) {
					Cursor.lockState = CursorLockMode.None;
				} else {
					Cursor.lockState = CursorLockMode.Locked;
				}

            }
            //else togglePressed = false;
        }
        else
        {
            togglePressed = false;
			Cursor.lockState = CursorLockMode.Locked;
        }
    }

    private void CheckMove(KeyCode keyCode, ref Vector3 deltaPosition, Vector3 directionVector)
    {
        if (Input.GetKey(keyCode))
        {
            moving = true;
            deltaPosition += directionVector;
        }
    }
    public void setMoveable()
    {

        allowMovement = !allowMovement;
        allowRotation = !allowRotation;
    }
}
