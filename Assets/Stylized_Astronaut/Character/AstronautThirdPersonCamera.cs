using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AstronautThirdPersonCamera
{

  public class AstronautThirdPersonCamera : MonoBehaviour
  {
    [Header("Camera Settings")]
    public Camera firstPersonCamera;
    public AstronautThirdPersonCamera thirdPersonCamera;

    private float mouseSenesitivity = 200.0f;

    public float cameraDistanse = 5.0f;
    public float minDistanse = 1.0f;
    public float maxDistanse = 10.0f;

    private float currentX = 0.0f;
    private float currentY = 45.0f;

    private const float Y_ANGLE_MIN = 0.0f;
    private const float Y_ANGLE_MAX = 50.0f;

    public float radius = 5.0f;
    public float minRadius = 1.0f;
    public float maxRadius = 10.0f;

    public float yMinLimit = -90;
    public float yMaxLimit = 90;
    

    

    private void Start()
    {
        camTransform = transform;
    }

    private void Update()
    {
        currentX += Input.GetAxis("Mouse X");
        currentY += Input.GetAxis("Mouse Y");

        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
    }

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        camTransform.position = lookAt.position + rotation * dir;
        camTransform.LookAt(lookAt.position);
    }
  }
}
