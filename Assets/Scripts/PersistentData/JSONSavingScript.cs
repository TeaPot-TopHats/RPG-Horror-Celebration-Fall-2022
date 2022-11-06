using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class JSONSavingScript : MonoBehaviour
{
    
    
    public Playerstat myplayer = new Playerstat();
    private string path = "";
    private string persistentPath = "";
    // Start is called before the first frame update

   
 
  
    void Start()
    {
        //CreatePlayerData();
        SetPaths();
        SavaData();
        LoadData();
        DontDestroyOnLoad(gameObject);

    }// END OF START

    /*
     * A method that set path want the data to be saved to 
     * 
     * There are 2 path to choose
     * path saved the data in unity asset folder
     * presistent path save the data in user data file in C/:drive
     * 
     * we want to save to a user data app file in launched game.
     */
    private void SetPaths()
    {
        path = Application.dataPath + Path.AltDirectorySeparatorChar + "SavaData.json";
        persistentPath = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SavaData.json";

    }// END OF SETPATHS

    /*
     * A method that save data to a Json file
     * It set chosen path to save to
     * It take the data wanted to be save to a Json file
     * It steam the data wanted to be sive to Json file
     * Write the data to Json file
     * close the writer.
     */
    public void SavaData()
    {
        string savaPath = persistentPath; // set saving path to path

        Debug.Log("Saving Data at "+ savaPath);

        string json = JsonUtility.ToJson(myplayer); // writing the data to json file
        Debug.Log("Data that are being save are: " + json);

        using StreamWriter writer = new StreamWriter(savaPath); // steaming the save data to a file
        writer.Write(json);
        writer.Close();

        Debug.Log( "Saving has been successful\n");
    }// END OF SAVADATA

    /*
     * A method that load data saved to a Json file
     * It load A stream of data from the set path for data
     * It read the whole Json file to the end
     * It set data to that data from Json file
     */
    public void LoadData()
    {

        Debug.Log("Loading Data From: \n" + persistentPath);
                  
        using StreamReader reader = new StreamReader(persistentPath); // load data from saved path
        string json = reader.ReadToEnd(); // tell json to read
        Playerstat data = JsonUtility.FromJson<Playerstat>(json);
        Debug.Log(" data that where saved: " + data.ToString());
      
        Debug.Log("Loadng has been successful\n");
        
    }// END OF LOADDATA

    /*
     * For testing that actually saved to a Json file
     * 
     * Comment out in launch but not necessary 
     *
     */
    public void showData()
    {
        
        if (Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log(myplayer.health);
        }
    }
}// END OF CLASS
