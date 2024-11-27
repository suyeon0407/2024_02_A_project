using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header ("Player Movement")]
    public float moveSpeed = 5.0f;
    public float jumpForce = 5.0f;
    public float rotationSpeed = 10.0f;

    [Header("Camera Settings")]
    public Camera firstPersonCamera;
    public Camera thirdPersonCamera;
    public float mouseSensitivity = 2.0f;

    public float radius = 5.0f;
    public float minRadius = 1.0f;
    public float maxRadius = 10.0f;

    public float yMinLimit = -90;
    public float yMaxLimit = 90;

    private float theta = 0.0f;
    private float phi = 0.0f;
    private float targetVericalRotation = 0;
    private float verticalRoatationSpeed = 240f;

    public bool isFirstPerson = true;
    //private bool isGrounded;
    private Rigidbody rb;

    public float fallingThreshHold = -0.1f;

    [Header("Ground Check Setting")]
    public float groundCheckDistance = 0.3f;
    public float slopedLimit = 45f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;
        SetupCameras();
        SetActiveCamera();
    }

    void Update()
    {
        HandleRotation();
        HandleCameraToggle();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            HandleJump();
        }
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }
   

    void SetupCameras()
    {
        firstPersonCamera.gameObject.SetActive(isFirstPerson);
        firstPersonCamera.gameObject.SetActive(!isFirstPerson);
    }

    void SetActiveCamera()
    {
        firstPersonCamera.gameObject.SetActive(isFirstPerson);
        thirdPersonCamera.gameObject.SetActive(!isFirstPerson);
    }
    void HandleRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
    }

    public void HandleMovement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement;

        if(!isFirstPerson)
        {
            Vector3 cameraForward = thirdPersonCamera.transform.forward;
            cameraForward.y = 0.0f;
            cameraForward.Normalize();

            Vector3 cameraRight = thirdPersonCamera.transform.right;
            cameraRight.y = 0.0f;
            cameraRight.Normalize();

            movement = cameraRight * moveHorizontal + cameraForward * moveVertical;
        }
        else
        {
            movement = transform.right*moveHorizontal+transform.forward*moveVertical;
        }

        if(movement.magnitude > 0.1f)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation,toRotation,rotationSpeed * Time.deltaTime);
        }

        rb.MovePosition(rb.position+movement*moveSpeed*Time.deltaTime);
    }

    void HandleCameraToggle()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            isFirstPerson = !isFirstPerson;
            SetActiveCamera();
        }
    }
    public void HandleJump()
    {
        if(isGrounded())
        {

        }
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

    }

    public bool isGrounded()
    {
        return Physics.Raycast(transform.position,Vector3.down,2.0f);
    }

    public bool isFalling()
    {
        return rb.velocity.y < fallingThreshold && !isGrounded();
    }

    public float GetVerticalVelocity()
    {
        return rb.velocity.y;
    }
}
