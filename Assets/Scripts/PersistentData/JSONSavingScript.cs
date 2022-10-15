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

    // Update is called once per frame

    /**
     * creater a player data in this method.
     * this is making a new instant of player data and currently has 4 arguments player {name, health, ammo, attack power} more can be adding 
     * this is only a test data change it to the actuall player data later on. 
     */
    //private void CreatePlayerData()
    //{
        
    //    //myplayer = new Playerstat();

    //    // PlayerDataTest = new PlayerDataTest("sys", 100, 140, 139);
    
    //}// END OF CREATEPLAYERDATA



    private void SetPaths()
    {
        path = Application.dataPath + Path.AltDirectorySeparatorChar + "SavaData.json";
        persistentPath = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SavaData.json";

    }// END OF SETPATHS

    public void SavaData()
    {
        string savaPath = persistentPath; // set saving path to path

        Debug.Log("Saving Data at "+ savaPath);

        string json = JsonUtility.ToJson(myplayer); // wrting the data to json file
        Debug.Log("Data that are being save are: " + json);

        using StreamWriter writer = new StreamWriter(savaPath); // steaming the save data to a file
        writer.Write(json);
        writer.Close();

        Debug.Log( "Saving has been successful\n");
    }// END OF SAVADATA

    public void LoadData()
    {

        Debug.Log("Loading Data From: \n" + persistentPath);
                  
        using StreamReader reader = new StreamReader(persistentPath); // load data from saved path
        string json = reader.ReadToEnd(); // tell json to read
        Playerstat data = JsonUtility.FromJson<Playerstat>(json);
        Debug.Log(" data that where saved: " + data.ToString());
      
        Debug.Log("Loadng has been successful\n");
        
    }// END OF LOADDATA

    public void showData()
    {
        
        if (Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log(myplayer.health);
        }
    }
}// END OF CLASS
