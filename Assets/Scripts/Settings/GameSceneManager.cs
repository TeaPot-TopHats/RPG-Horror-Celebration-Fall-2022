using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneManager : MonoBehaviour
{
    public GameObject pasueMenuPrefap;

    private Canvas Canvas;
    private Canvas _Canvas;
    private GameObject pauseMenuInstance;
    public GameObject canvasPrefab;


    public void Update()
    {
        if (!PauseMenu.GameIsPaused)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                OpenPauseMenu();
                PauseMenu.GameIsPaused = true;
                Debug.Log("pasue menu repsonding");
            }
            
        }
        DontDestroyOnLoad(gameObject);
    }
    /*
     * A method that open our prefap Pause Menu
     * It checks if instance of our pasue menu exist or not.
     * It Istantiate one if it does not exist.
     * else if it exist set the pause menu instance to be true.
     */
    public void OpenPauseMenu()
    {
        if(pauseMenuInstance == null)
        {
            Instantiate(pasueMenuPrefap, SceneCanvas.transform);
        }
        else
        {
            pauseMenuInstance.SetActive(true);
        }// end of if-else


    }// end of OpenPauseMenu

    /*
     * A method that Make sure a canvas is avaiable.
     * It checks if  canvas variable is set
     * If not, look in sence for a canvas
     * If no canvas found in scene, create one
     */
    private Canvas SceneCanvas
    {
        get {
            if(_Canvas == null)
            {
                _Canvas = FindObjectOfType<Canvas>();
                if (_Canvas == null)
                {
                    _Canvas = Instantiate(canvasPrefab).GetComponent<Canvas>();
                }
            }
            return _Canvas;
        }

    }
}// end of class
