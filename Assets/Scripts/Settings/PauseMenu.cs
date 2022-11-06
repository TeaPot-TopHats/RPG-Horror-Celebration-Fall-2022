using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour

{
    public static PauseMenu instance;
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;


    // Update is called once per frame
    void Update() {

        /*
            An if statement that check for the game if paused or not 
        */
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (GameIsPaused) {
                Resume();
                LockMouseCursor();
            } else if (!GameIsPaused) {
                Pause();
                UnlockMouseCursor();
            }

        }// end of if input
        
    }// end of void update 

    /*
     * Resume method basiclly restart the game and let the time flow normally
     */
    public void Resume() {
        if (!GameIsPaused) {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1;
            GameIsPaused = false;
        }
       
    }// end of reusme method

    /*
     * Pause method basiclly pasues the game and set the time flow to zero.
     */
    public void Pause() {

        if (GameIsPaused) {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }
      
        
    }// end of pause method

    public void DialoguePause()
    {
        Time.timeScale = 0;
        GameIsPaused = true;
    }

    public void ResmueWithClick()
    {
        Time.timeScale = 1;
        GameIsPaused = false;
    }

    public void UnlockMouseCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
     public void LockMouseCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
    }
    public void LoadMenu()
    {
        Debug.Log("Loading menu...");
    }// end of LoadMenu method

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
    }
}// end of Class
