using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DisplayInfo : MonoBehaviour
{
    public string playerTag = "Player" ;
    private GameObject player;
    public GameObject infoUI;
    public GameObject infoUIVR;
    public float interactDistance=5.0f;
    public float interactAngle=60.0f;
    public bool displayed=false;
    public bool visited=false;
    public GameObject body;
    public GameObject token;
    public GameObject pointLight;
    public Material visitedBodyMaterial;
    public Material visitedTokenMaterial;
    public Color visitedLightColor;
    // Start is called before the first frame update
    void Start()
    {
      player = GameObject.FindWithTag(playerTag);
    }

    // Update is called once per frame
    void Update()
    {
      if(!displayed && !PauseMenu.IsPaused && Input.GetKeyDown(KeyCode.E) && PlayerInRange()) {
        showInfo();
      } else if (displayed && Input.GetKeyDown(KeyCode.Escape)) {
        hideInfo();
      }
    }

    bool PlayerInRange()
    {
      float visionAngle = Vector3.Angle(player.GetComponent<Transform>().forward, body.transform.position-player.GetComponent<Transform>().position);
      float distanceToPlayer = Vector3.Distance(player.GetComponent<Transform>().position,body.transform.position);
      return (distanceToPlayer < interactDistance && visionAngle < interactAngle);
    }

    void showInfo()
    {
      displayed=true;
      infoUI.SetActive(true);
      Time.timeScale = 0.0f;
      PauseMenu.IsPaused = true;
      Cursor.visible = true;
      Cursor.lockState= CursorLockMode.None;
    }


    public void hideInfo()
    {
      displayed=false;
      infoUI.SetActive(false);
      Time.timeScale = 1f;
      PauseMenu.IsPaused = false;
      Cursor.visible = false;
      Cursor.lockState= CursorLockMode.Locked;
      if (!visited) {
        visited = true;
        body.GetComponent<Renderer>().sharedMaterial = visitedBodyMaterial;
        token.GetComponent<Renderer>().sharedMaterial = visitedTokenMaterial;
        pointLight.GetComponent<Light>().color = visitedLightColor;
      }
    }


      public void showInfoVR()
      {
        displayed=true;
        infoUIVR.SetActive(true);
        if (!visited) {
          visited = true;
          body.GetComponent<Renderer>().sharedMaterial = visitedBodyMaterial;
          token.GetComponent<Renderer>().sharedMaterial = visitedTokenMaterial;
          pointLight.GetComponent<Light>().color = visitedLightColor;
        }
      }


      public void hideInfoVR()
      {
        displayed=false;
        infoUIVR.SetActive(false);

      }


}
