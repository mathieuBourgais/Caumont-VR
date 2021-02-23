using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused = false;
    public GameObject menuUI;
    // Start is called before the first frame update
    void Start()
    {
      Cursor.visible = false;
      Cursor.lockState= CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            if (IsPaused) {
                Resume();
            } else {
                Pause();
            }
        }
    }

    void Resume() {
      menuUI.SetActive(false);
      Time.timeScale = 1f;
      IsPaused = false;
      Cursor.visible = false;
      Cursor.lockState= CursorLockMode.Locked;
    }

    void Pause() {
      menuUI.SetActive(true);
      Time.timeScale = 0.0f;
      IsPaused = true;
      Cursor.visible = true;
      Cursor.lockState= CursorLockMode.None;
    }
}
