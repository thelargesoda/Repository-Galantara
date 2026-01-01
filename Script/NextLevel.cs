using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public void NextLevelLoad(string level) // Memulai next lvl/scene
    {
        SceneManager.LoadScene(level);
    }
}
