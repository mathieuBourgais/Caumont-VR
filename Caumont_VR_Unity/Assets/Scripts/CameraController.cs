using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // horizontal rotation speed
    public float horizontalSpeed = 1f;
    // vertical rotation speed
    public float verticalSpeed = 1f;
    private float xRotation = 0.0f;
    private float yRotation = 0.0f;
    private Camera playerVision;
    private Transform playerTransform;
    public GameObject headLight;

    // Start is called before the first frame update
    void Start()
    {
        playerVision = Camera.main;
        playerTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
      if (!PauseMenu.IsPaused) {
        float mouseX = Input.GetAxis("Mouse X") * horizontalSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * verticalSpeed;
        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        playerVision.transform.eulerAngles = new Vector3(xRotation, yRotation, 0.0f); //update camera
        playerTransform.eulerAngles = new Vector3(0.0f, yRotation, 0.0f); // enable the player to face the good direction
        headLight.transform.eulerAngles = new Vector3(xRotation, yRotation, 0.0f); // the head light follow the camera
      }

    }
}
