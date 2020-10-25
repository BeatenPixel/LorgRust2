using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseCanvas;
    public KeyCode pauseKey = KeyCode.Escape;
   
    public bool isPaused = false;
    private void Start() {
        pauseCanvas.SetActive(false);
    }   


    private void Update() {
        if (Input.GetKeyDown(pauseKey)) {
            isPaused = !isPaused;
        }
        
        if(isPaused == true) {
            Time.timeScale = 0.0f;
            pauseCanvas.SetActive(true);
        }
        else if(isPaused == false) {
            Time.timeScale = 1.0f;
            pauseCanvas.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }   
    }
    public void ResumeGame() {
        Debug.Log("Resuming game..");
        isPaused = false;
    }
    public void ExitGame() {
        Debug.Log("Quiting game..");
        Application.Quit();
    }


}
