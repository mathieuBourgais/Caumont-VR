using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepVR : MonoBehaviour
{
    public CharacterController body;
    public float maxPitch = 1.2f;
    public float maxVolume = 1f;
    public float minPitch = 0.8f;
    public float minVolume = 0.8f;
    public float minStepSpeed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      bool isMoving = (body.isGrounded && body.velocity.magnitude > minStepSpeed);
      if ( Time.deltaTime != 0.0f && isMoving && !GetComponent<AudioSource>().isPlaying ) {
        GetComponent<AudioSource>().volume = Random.Range(minVolume,maxVolume);
        GetComponent<AudioSource>().pitch = Random.Range(minPitch,maxPitch);
        GetComponent<AudioSource>().Play();
      }
    }
}
