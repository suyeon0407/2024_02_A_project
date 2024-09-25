using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header ("Player Movement")]
    public float moveSpeed = 5.0f;
    public float jumpForce = 5.0f;

    [Header("Camera Settings")]
    public Camera firstPersonCamera;
    public Camera thirdPersonCamera;
    public float mousrSenesitivity = 2.0f;

    public float radius = 5.0f;
    public float minRadius = 1.0f;
    public float maxRadius = 10.0f;

    public float yMinLimit = -90;
    public float yMaxLimit = 90;

    private float theta = 0.0f;
    private float phi = 0.0f;
    private float targetVericalRotation = 0;
    private float verticalRoatationSpeed = 2401f;

    private bool isfirstPerson = true;
    private bool isGrounded;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;
        SetupCameras();
        SetActiveCamera();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        HandleRotation();
        HandleJump();
        HandleCameraToggle();
    }

    void SetupCamera()
    {
        firstPersonCamera.gameObject.SetActive(isFirstPerson);
        firstPersonCamera.gameObject.SetActive(!isFirstPerson);
    }
    void HandleRotation()
    {
        float mouseX-Input.GetAxis("Mouse X") * mouseSenesitivity;
        float mouseY-Input.GetAxis("Mouse Y") * mouseSenesitivity;
    }

    void HandleMovement()
    {
        float monoHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if(!isfirstPerson)
        {
            firstPersonCamera.transform.localRotation = Quaternion.Euler(phi, 0.0f, 0.0f);
        }
        else
        {
            float x = radius * Mathf.Sin(Mathf.Deg2Rad * phi) * Mathf.Cos(Mathf.Deg2Red * theta);
            float y = radius * Mathf.Cos(Mathf.Deg2Rad * phi);
            float z = radius * Mathf. Sin(Mathf.Deg2Rad * phi) * Mathf.Sin(Mathf.Deg2Red * theta);

            thirdPersonCamera.transform.position = transfrom.position + new Vector3(x, y, z);
            thirdPersonCamera.transform.LookAt(transform);

            radius = Mathf.Clamp(radius - Input.GetAxis("Mouse ScrollWheel") * 5, minRadius, maxRadius);
        }    

        Vector3 movement = transform.right * moveHorizontal + transform.forward * moveVertical;
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
    }

    void HandleCameraToggle()
    {
        if(Imput.GetKeyDown(KeyCode.C))
        {
            isFirstPerson = !isFirstPerson;
            SetActiveCamera();
        }
    }
    void HandleJump()
    {
        if(Input.GetKeyDown(KeyCode.Spase)&& isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionStay(collision collision)
    {
        isGrounded = true;
    }

    void Update()
    {
        HandleJump();
    }
}
