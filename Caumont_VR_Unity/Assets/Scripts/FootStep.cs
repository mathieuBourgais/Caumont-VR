using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStep : MonoBehaviour
{
    private CharacterController controller;
    public float maxPitch = 1.2f;
    public float maxVolume = 1f;
    public float minPitch = 0.8f;
    public float minVolume = 0.8f;

    // Start is called before the first frame update
    void Start()
    {
      controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
      bool isMoving = (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0);
      if ( Time.deltaTime != 0.0f && controller.isGrounded && isMoving && !GetComponent<AudioSource>().isPlaying ) {
        GetComponent<AudioSource>().volume = Random.Range(minVolume,maxVolume);
        GetComponent<AudioSource>().pitch = Random.Range(minPitch,maxPitch);
        GetComponent<AudioSource>().Play();
      }
    }
}
