using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LightModes
{
  OnHead,
  Torch,
  Global
}

public class LightSelector : MonoBehaviour
{
    private LightModes currentMode;
    public GameObject headLight;
    public GameObject torch;
    public GameObject globalLight;
    // Start is called before the first frame update
    void Start()
    {
      currentMode=LightModes.OnHead;
      torch.SetActive(false);
      headLight.SetActive(true);
      globalLight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeToTorch()
    {
        if(currentMode != LightModes.Torch) {
          currentMode = LightModes.Torch;
          torch.SetActive(true);
          headLight.SetActive(false);
          globalLight.SetActive(false);
        }
    }

    public void ChangeToHead()
    {
      if(currentMode != LightModes.OnHead) {
        currentMode = LightModes.OnHead;
        torch.SetActive(false);
        headLight.SetActive(true);
        globalLight.SetActive(false);
      }
    }

    public void ChangeToGlobal()
    {
      if(currentMode != LightModes.Global) {
        currentMode = LightModes.Global;
        torch.SetActive(false);
        headLight.SetActive(false);
        globalLight.SetActive(true);
      }
    }
}
