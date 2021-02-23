using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Droplet : MonoBehaviour
{
    private AudioSource soundSource;
    private Rigidbody dropletBody;
    public float maxPitch = 1.2f;
    public float maxVolume = 1f;
    public float minPitch = 0.8f;
    public float minVolume = 0.8f;
    public float spawnProbability = 0.05f;
    public float maxSpawnDistance=10f;
    public float minSpawnDistance=2f;
    public float spawnHeight=3f;
    public Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        soundSource = GetComponent<AudioSource>();
        dropletBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
      Vector3 newPosition;
      if(dropletBody.IsSleeping() && !soundSource.isPlaying) {
        float rnd = Random.Range(0f,1f);
        if (rnd < spawnProbability) {
          float spawnAngle = Random.Range(-90f,90f); // spawn the droplet somehere in front of the player
          float spawnDistance = Random.Range(minSpawnDistance, maxSpawnDistance);
          newPosition = playerTransform.position +  spawnDistance*(Mathf.Cos(spawnAngle)*playerTransform.forward + Mathf.Sin(spawnAngle)*playerTransform.right);
          newPosition = newPosition + spawnHeight*Vector3.up;
          if (Physics.Raycast(newPosition,Vector3.down)) {
            dropletBody.position = newPosition;
            dropletBody.WakeUp();
          }
        }
      } else if (!dropletBody.IsSleeping() && !Physics.Raycast(dropletBody.position,Vector3.down)) { // if for some reasons the droplet is going through the floor
          if (!soundSource.isPlaying) { //sometimes OnTriggerEnter is not called when the droplet go to fast through the floor so we need to check tht the audio as been launched
            soundSource.volume = Random.Range(minVolume,maxVolume);
            soundSource.pitch = Random.Range(minPitch,maxPitch);
            soundSource.Play();
          }
          dropletBody.Sleep();
      }
    }

    void OnTriggerEnter(Collider other) {
        if (!soundSource.isPlaying) {
          soundSource.volume = Random.Range(minVolume,maxVolume);
          soundSource.pitch = Random.Range(minPitch,maxPitch);
          soundSource.Play();
          dropletBody.Sleep();
        }
    }

}
