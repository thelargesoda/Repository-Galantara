using UnityEngine;
using UnityEngine.SceneManagement;
public class EndTrigger : MonoBehaviour
{
    public PlayerMovement Movement;
    public GameSystem gameSystem;

    private void Awake()
    {
        gameSystem = FindObjectOfType<GameSystem>();
    }
    
    void OnTriggerEnter ()
    {       
        Movement.enabled = false;
        FindObjectOfType<UIhandler>().levelingEnd();
        FindObjectOfType<AudioManager>().StopRunLoop();


        gameSystem.LevelClearance();
        gameSystem.SaveGame();
    }


}

