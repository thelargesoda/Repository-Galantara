using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIhandler : MonoBehaviour
{
    public GameObject LevelingUI;
    public GameObject LevelMenu;
    public GameObject Menu;
    public GameObject BuffUI;
    public GameObject Lose_UI;
    public Collision Checker;      // Pengecek Collision untuk trigger UI
    public GameObject health2;    // Gambar untuk HP = 2
    public GameObject health1;    // Gambar untuk HP = 1
    public GameObject health0;    // Gambar untuk HP = 0
    public GameObject MainUI1;
    public GameObject MainUI2;
    public GameObject Level2Locked;
    public Button Level2;
    public Button Level3;
    public GameObject Level3Locked;
    public GameSystem Game;
    public PlayerMovement FalseScript1;
    public GameObject Golok;
    public GameObject Karambit;
    public GameObject Keris;
    public GameObject Bedog;
    public GameObject Kujang;
    public AudioManager audioManager;
    

    void Awake()
    {
        Game = FindObjectOfType<GameSystem>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

    }
    void Start()
    {


        if (SceneManager.GetActiveScene().name != "MainMenu")
        { BuffUI.SetActive(false); return;}
                     
        Menu.SetActive(true);
        LevelMenu.SetActive(false);

        

    }


    public void LoadStatus()
    {
        Game.LoadGame();
    }
    public void ResetStatus()
    {
        Game.ResetGameData();
    }

    public void LevelingOnClick1(string levelName)
    {
        int LevelIndex = int.Parse(levelName.Replace("Level", ""));

      
            SceneManager.LoadScene(levelName);
        

        
    }
    public void levelingEnd()
    {
        LevelingUI.SetActive(true);
    }
    public void GolokUI()
    {
        Golok.SetActive(true);
    }
    public void KarambitUI()
    {
        Karambit.SetActive(true);
    }
    public void KerisUI()
    {
        Keris.SetActive(true);
    }

    public void KujangUI()
    {
        Kujang.SetActive(true);
    }

    public void CloseWeaponUI(GameObject weaponUI)
    {

        weaponUI.SetActive(false);
        Game.Continue();
    }

    public void mulaiUI()
    {
        LevelingUI.SetActive(true);

        if (Game.LevelUnlockStatus == 2 || Game.LevelUnlockStatus >= 3)
        {
            Debug.Log("Level 2 Unlocked");
            Level2Locked.SetActive(false);
            Level3.interactable = true;
        }
        else 
        {
            
            Level2Locked.SetActive(true);
            Level2.interactable = false; ;   
        
        }


        if (Game.LevelUnlockStatus == 3)
        {
            Debug.Log("Level 3 Unlocked");
            Level3Locked.SetActive(false);
            Level3.interactable = true;
        }
    
        else 
        { 
            
            Level3Locked.SetActive(true);
            Level3.interactable = false;



        }
    }

    public void OnClickSound()
    {
        audioManager.PlaySFXNonLoop(audioManager.Click);
    }

    public void KembaliUI()
    {
        LevelingUI.SetActive(false);
    }

    public void MusicON()
    {
        audioManager.IsMuted = false;
        audioManager.MusicMenuPlay();
        audioManager.Play();
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void MusicOFF()
    {
        audioManager.IsMuted = true;
        audioManager.MusicMenuStop();
        
    }

    public void MainUI()
    {
        MainUI1.SetActive(true);
        MainUI2.SetActive(true);
    }
    public void Level(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void LoseUI()
    {
        Lose_UI.SetActive(true);
        MainUI1.SetActive(false);
        MainUI2.SetActive(false);
        Game.enabled = false;
        Checker.enabled = false;
        FalseScript1.enabled = false;
        
    }

    public void BackToMenu()
    {
        audioManager.MusicMenuPlay();
        audioManager.Play();

    }
    void Update()
    {
       
        UpdateHealthUI();
       

    }

    


    // Pengupdate UI Health dari Player
    void UpdateHealthUI()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
            return;

        if (Checker.health == 2)
        {
            health2.SetActive(true);
        
        }
        if (Checker.health == 1)
        {
            health1.SetActive(true);
        }
        if (Checker.health == 0)
        {
            health0.SetActive(true);
            LoseUI();
        }
        
   

            
    }





}


