using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CloseInfoVRAdapter : MonoBehaviour
{
    public DisplayInfo mydisplayer;
    public string handTag ="VRHand";

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other) {
      if (other.gameObject.tag == handTag ) {
          mydisplayer.hideInfoVR();
      }
    }
}
