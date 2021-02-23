using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayerController : MonoBehaviour
{
    public float walkSpeed=10.0f;
    public float gravity=9.81f/10.0f;
    public float fallSpeed=0;
    private CharacterController characterController;
    private Transform playerTransform;
    public InfoDisplayersManager manager;
    // Start is called before the first frame update
    void Start()
    {
      characterController = GetComponent<CharacterController>();
      playerTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
      float horizontalInput = Input.GetAxis("Horizontal");
      float verticalInput = Input.GetAxis("Vertical");
      Vector3 movement = Vector3.Normalize(playerTransform.right * horizontalInput + playerTransform.forward * verticalInput); //(x,y,z)

      characterController.Move(movement * walkSpeed * Time.deltaTime);

      //simulate gravity
      if(characterController.isGrounded)
         {
             fallSpeed = 0;
         }
         else
         {
             fallSpeed -= gravity * Time.deltaTime;
             characterController.Move(new Vector3(0, fallSpeed, 0));
         }
    }

    public void TeleportTo(Vector3 newPosition) {
      characterController.enabled = false; // characterController prevent teleportation so we have to disable it while changing position
      playerTransform.position = newPosition;
      characterController.enabled = true;
    }
}
