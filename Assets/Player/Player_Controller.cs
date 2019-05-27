using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{

    public bool isInteracting = false;

    public Transform Player;
    public Options POptions;
    public CharacterController controller;

    public Transform RightLeg;
    public Transform LeftLeg;

    public Transform Camera1;
    public Transform CameraHFocus;
    public Transform CameraVFocus;
    public Transform Camera3;

    public float optCamSpeed = 10f;
    private float legSpeed = 500f;
    private float moveSpeed = 8f;
    private float turnSpeed = 200f;
    private float vertCamSpeed = 50f;
    private float horCamSpeed = 100f;
    private float camZoomSpeed = 1f;
    private float jumpForce = 5000f;
    public float mouseSensitivity = 100f;

    public GameObject FirstPersonCrosshairs;
    public int perspective = 0;
    public int THIRD_PERSON = 0;
    public int FIRST_PERSON = 1;

    // Start is called before the first frame update
    void Start()
    {
        FirstPerson();

        FindObjectOfType<InteractableUI>().ShowInteractable("Instructions", "'W/A/S/D' to move, Left Click on stuff to interact with it, 'V' to switch between 1st and 3rd person. In third person hold Right Click and move mouse to change camera angles. 'Escape' to show options (Mouse Sensitivity and Volume).", "", "", null, null);
    }

    // Update is called once per frame
    void Update()
    {

        float _moveSpeed = moveSpeed;
        float _legSpeed = legSpeed;
        float _vertCamSpeed = vertCamSpeed;
        float _turnSpeed = turnSpeed;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            _moveSpeed = _moveSpeed * 2f;
            _legSpeed = _legSpeed * 2f;
        }

        // Interactable

        if (!isInteracting &&  Input.GetKeyDown(KeyCode.Mouse0)) {
            Ray ray = (perspective == FIRST_PERSON ? Camera1.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition) : Camera3.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Interactable i =  hit.collider.gameObject.GetComponent<Interactable>();
                if (i != null)
                {
                    i.Interact();
                }
            }

        }

        // Jump

        /*if (!isInteracting && Input.GetKeyDown(KeyCode.Space))
        {
            
        }*/

        // Falling
        if (!controller.isGrounded)
        {
            controller.Move(-transform.up * _moveSpeed * 2 * Time.deltaTime);
        }

        // Perspectives

        if (!isInteracting && perspective == FIRST_PERSON)
        {
            transform.Rotate(Vector3.up, Time.deltaTime * Input.GetAxis("Mouse X") * mouseSensitivity);
            Camera1.Rotate(Vector3.left, Time.deltaTime * Input.GetAxis("Mouse Y") * mouseSensitivity);

            if (Camera1.localEulerAngles.x > 55f && Camera1.localEulerAngles.x < 180f)
            {
                Camera1.Rotate(Vector3.left, Camera1.localEulerAngles.x - 55f);
            }
            else if (Camera1.localEulerAngles.x < 300f && Camera1.localEulerAngles.x > 180f)
            {
                Camera1.Rotate(Vector3.left, Camera1.localEulerAngles.x - 300f);
            }
        }

        if (!isInteracting && Input.GetKey(KeyCode.A))
        {
            if (perspective == FIRST_PERSON) controller.Move(transform.right * -_moveSpeed * Time.deltaTime);
            else transform.Rotate(Vector3.up, Time.deltaTime * -_turnSpeed);
        }

        if (!isInteracting && Input.GetKey(KeyCode.D))
        {
            if (perspective == FIRST_PERSON) controller.Move(transform.right * _moveSpeed * Time.deltaTime);
            else transform.Rotate(Vector3.up, Time.deltaTime * _turnSpeed);
        }

        if (!isInteracting && perspective == THIRD_PERSON && Input.GetKey(KeyCode.Mouse1))
        {
            CameraVFocus.Rotate(Vector3.left, Time.deltaTime * Input.GetAxis("Mouse Y") * _vertCamSpeed * optCamSpeed);
            CameraHFocus.Rotate(Vector3.up, Time.deltaTime * Input.GetAxis("Mouse X") * horCamSpeed * optCamSpeed);

            if (CameraVFocus.localEulerAngles.x > 60f && CameraVFocus.localEulerAngles.x < 200f)
            {
                CameraVFocus.Rotate(Vector3.left, CameraVFocus.localEulerAngles.x - 60f);
            }
            else if (CameraVFocus.localEulerAngles.x < 5f || CameraVFocus.localEulerAngles.x > 200f)
            {
                CameraVFocus.Rotate(Vector3.left, CameraVFocus.localEulerAngles.x - 5f);
            }

        }

        /*if (!isInteracting && perspective == THIRD_PERSON && Input.mouseScrollDelta != Vector2.zero)
        {

            Camera3.Translate(Vector3.forward * Input.mouseScrollDelta.y * camZoomSpeed, Space.Self);

            float camDistance = Vector3.Distance(CameraVFocus.position, Camera3.position);

            if (camDistance > 10f)
            {
                Camera3.Translate(Vector3.forward * (camDistance - 10f), Space.Self);
            }
            else if (camDistance < 4f)
            {
                Camera3.Translate(Vector3.forward * (camDistance - 4f), Space.Self);
            }
        }*/

        if (!isInteracting && Input.GetKeyDown(KeyCode.V))
        {
            if (perspective == THIRD_PERSON)
            {
                FirstPerson();
            }
            else
            {
                ThirdPerson();
            }
        }

        // Walking

        if (!isInteracting && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)))
        {

            float rOffset = 0f;
            float lOffset = 0f;

            if (RightLeg.localEulerAngles.z < 315f && RightLeg.localEulerAngles.z > 45f)
            {
                legSpeed = -legSpeed;
                if (RightLeg.localEulerAngles.z > 180f)
                {
                    rOffset = 316f - RightLeg.localEulerAngles.z;
                    lOffset = 44f - LeftLeg.localEulerAngles.z;
                }
                else
                {
                    rOffset = 44f - RightLeg.localEulerAngles.z;
                    lOffset = 316f - LeftLeg.localEulerAngles.z;
                }
            }
            else if (LeftLeg.localEulerAngles.z < 315f && LeftLeg.localEulerAngles.z > 45f)
            {
                legSpeed = -legSpeed;
                if (LeftLeg.localEulerAngles.z > 180f)
                {
                    lOffset = 316f - LeftLeg.localEulerAngles.z;
                    rOffset = 44f - RightLeg.localEulerAngles.z;
                }
                else
                {
                    lOffset = 44f - LeftLeg.localEulerAngles.z;
                    rOffset = 316f - RightLeg.localEulerAngles.z;
                }
            }

            /*float _moveSpeed = moveSpeed;
            float _legSpeed = legSpeed;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                _moveSpeed = _moveSpeed * 2f;
                _legSpeed = _legSpeed * 2f;
            }*/

            if (Input.GetKey(KeyCode.W)) controller.Move(transform.forward * _moveSpeed * Time.deltaTime);
            else if (Input.GetKey(KeyCode.S)) controller.Move(transform.forward * -_moveSpeed * Time.deltaTime);

            //RightLeg.Rotate(Vector3.forward, (Time.deltaTime * _legSpeed) + rOffset);
            //LeftLeg.Rotate(Vector3.forward, (Time.deltaTime * -_legSpeed) + lOffset);

        }

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.W))
        {
            //RightLeg.localRotation.eulerAngles.Set(0f, 0f, 0f);
            //LeftLeg.localRotation.eulerAngles.Set(0f, 0f, 0f);
            legSpeed = 500f;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (POptions.open) POptions.Close();
            else POptions.Open();
        }

    }

    public void ThirdPerson()
    {
        perspective = THIRD_PERSON;
        UnlockMouse();
        HideCrosshairs();
        Camera1.gameObject.SetActive(false);
        Camera3.gameObject.SetActive(true);
    }

    public void FirstPerson()
    {
        perspective = FIRST_PERSON;
        LockMouse();
        ShowCrosshairs();
        Camera3.gameObject.SetActive(false);
        Camera1.gameObject.SetActive(true);
    }

    public void LockMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void UnlockMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ShowCrosshairs()
    {
        FirstPersonCrosshairs.SetActive(true);
    }

    public void HideCrosshairs()
    {
        FirstPersonCrosshairs.SetActive(false);
    }

    public void Die(string dm)
    {
        FindObjectOfType<Death>().EndGame(dm);
    }

    public void StartInteracting()
    {
        isInteracting = true;
        UnlockMouse();
        HideCrosshairs();
    }

    public void StopInteracting()
    {
        isInteracting = false;
        if (perspective == FIRST_PERSON)
        {
            LockMouse();
            ShowCrosshairs();
        }
        else
        {
            UnlockMouse();
        }
    }

}
