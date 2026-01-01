using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform player;
    public Text scoreText;
    public float StartNumber;

    void Start()
    {
        StartNumber = player.position.z;
    }
    void Update()
    {
        float score = player.position.z - StartNumber;
        scoreText.text = score.ToString("0");
    }
}
