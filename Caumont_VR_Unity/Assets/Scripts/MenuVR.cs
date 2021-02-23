using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuVR : MonoBehaviour
{
    public static bool isDisplayed = false;
    public GameObject menuUI;
    public GameObject menuPointer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ToggleVRMenu() {
        if (isDisplayed) {
          menuUI.SetActive(false);
          menuPointer.SetActive(false);
          isDisplayed = false;
        } else {
          menuUI.SetActive(true);
          menuPointer.SetActive(true);
          isDisplayed = true;
        }
    }

}
