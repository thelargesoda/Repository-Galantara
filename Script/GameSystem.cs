using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;



    public class GameSystem : MonoBehaviour
    {
       
        public GameObject LevelSelesaiUI;
        public Transform player;
        public PlayerMovement Movement;
        public static GameSystem Instance;
        public int LevelUnlockStatus = 1;
        

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);   // Å© kills the scene copy
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadGame(); // load only once, on the surviving instance
    }


private void Start()
    {
        Debug.Log("GameSystem instance ID: " + GetInstanceID());
    }
    public void LevelClearance()
    {

        if(SceneManager.GetActiveScene().name == "Level 1" && LevelUnlockStatus != 3)
        {
            LevelUnlockStatus = 2;
        }
        if (SceneManager.GetActiveScene().name == "Level 2")
        {
            LevelUnlockStatus = 3;
        }




    }
    public void SaveGame()
    {
        Debug.Log("Save Succes");

       

        SaveSystem.SavePlayer(this);

    }

    public void LoadGame() 
    {

        Debug.Log("Load Succes");
        Debug.Log("LevelStatus is " + LevelUnlockStatus);
        PlayerLevelData data = SaveSystem.LoadData();

        LevelUnlockStatus = data.LevelUnlockStatus;

    }
        public void ResetGameData()
    {
       
        LevelUnlockStatus = 1;
        SaveSystem.ResetSave();
        SaveSystem.SavePlayer(this);

        Debug.Log("Game data reset to default.");
    }


    

        public void Pause()
        {
            Time.timeScale = 0;
        }
        public void Continue()
        {
            Time.timeScale = 1;
        }



   

        public void LevelSelesai()
        {
            LevelSelesaiUI.SetActive(true);

        }

        public void Quit()
        {
            Debug.Log("Quit");
            Application.Quit();

        }

    void Update()
    {
       
    }
}


