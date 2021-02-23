using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRCharacterController : MonoBehaviour
{
  public float walkSpeed=10.0f;
  public float gravity=9.81f/10.0f;
  public float fallSpeed=0;
  private CharacterController characterController;
  private Transform playerTransform;
  public Transform headTransform;
  public Transform playAreaTransform;
  public float minSpeedReducingFOV = 1.0f;
  public GameObject fovReducer;
  // Start is called before the first frame update
  void Start()
  {
    characterController = GetComponent<CharacterController>();
    playerTransform = GetComponent<Transform>();
  }

  // Update is called once per frame
  void Update()
  {
    // characterController.center = headTransform.position - playerTransform.position + headsetoffset;
    float horizontalInput = Input.GetAxis("Horizontal");
    float verticalInput = Input.GetAxis("Vertical");
    Vector3 playerRight = Vector3.Normalize(new Vector3(headTransform.right.x,0.0f,headTransform.right.z));
    Vector3 playerForward = Vector3.Normalize(new Vector3(headTransform.forward.x,0.0f,headTransform.forward.z));
    Vector3 movement = Vector3.Normalize(headTransform.right * horizontalInput + headTransform.forward * verticalInput); //(x,y,z)
    if (movement.magnitude > minSpeedReducingFOV) {
      fovReducer.SetActive(true);
    } else {
        fovReducer.SetActive(false);
    }
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

  public void OnAreaTeleport() {
    Vector3 pos = playAreaTransform.position;
    TeleportTo(pos);
    playAreaTransform.position = pos;
  }

}
