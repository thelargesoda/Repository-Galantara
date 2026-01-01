using UnityEngine;
using System.Collections;


    public class Collision : MonoBehaviour
    {

         AudioManager audioManager;
        public PlayerMovement Movement;
        public Transform player;
        public Transform respawnPoint;
        public Transform respawnPointWater;
        public GameSystem gameSystem;
        public float RespawnTime = 2f;
        public bool isLose = false;
        public int health = 3;
        bool GameSelesai = false;
        bool isWater = false;
    



    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();    
        gameSystem = FindObjectOfType<GameSystem>();
        Movement = FindObjectOfType<PlayerMovement>();
    
    }

    
    public void OnCollisionEnter(UnityEngine.Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle" && enabled)
        {

            audioManager.PlaySFXNonLoop(audioManager.Death);
            Movement.enabled = false;
            isLose = true;
            FindObjectOfType<AudioManager>().StopRunLoop();
            EndGame();
            FindObjectOfType<PlayerAnimation>().FailAnim();
            health -= 1;
        }
    }

    public void OnTriggerEnter(Collider colliderInfo)
    {
        if (colliderInfo.CompareTag("Water"))
        {

            audioManager.PlaySFXNonLoop(audioManager.Death);
            Movement.enabled = false;
            isLose = true;
            isWater = true;
            FindObjectOfType<AudioManager>().StopRunLoop();
            Invoke("EndGame", 2f);
            FindObjectOfType<PlayerAnimation>().FailAnim();
            health -= 1;
        }

        if (colliderInfo.CompareTag("Item"))
        {

            StartCoroutine(PlayBuffSound());

        }
    }




    public void EndGame()
    {
        if (isWater == true)
        {

            player.transform.position = respawnPointWater.position;
            isWater = false;
                
        }

        if (GameSelesai == false)
        {
            GameSelesai = true;

            Invoke("ResetGame", 2f);
        }

        }

    void ResetGame()
    {
        if (!enabled) return;

        player.transform.position = respawnPoint.position;
        player.transform.rotation = respawnPoint.rotation;

        // Reset physics
        Rigidbody rb = player.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        // Reset animator
        Animator anim = player.GetComponent<Animator>();
        if (anim != null)
        {
            anim.Rebind();
            anim.Update(0);
        }
        Movement.enabled = true;
        GameSelesai = false;
        StartCoroutine(IgnoreObstacles(RespawnTime));

    }






    // Mengabaikan Objek ber tag "Obstacle" saat respawn
    public IEnumerator IgnoreObstacles(float durasi)
    {
        FindObjectOfType<AudioManager>().PlayRunLoop();
        Collider playerCol = player.GetComponent<Collider>();

        // ambil semua obstacle yang ada di scene
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");

        // Mengabaikan semua collider di obstacle
        foreach (GameObject obj in obstacles)
        {
            foreach (Collider col in obj.GetComponentsInChildren<Collider>())
            {
                Physics.IgnoreCollision(playerCol, col, true);
            }
        }

        yield return new WaitForSeconds(durasi);

        // aktifkan kembali collision
        foreach (GameObject obj in obstacles)
        {
            foreach (Collider col in obj.GetComponentsInChildren<Collider>())
            {
                Physics.IgnoreCollision(playerCol, col, false);
            }
        }
    }

    IEnumerator PlayBuffSound()
    {
        // Menunggu game di unpaused
        yield return new WaitUntil(() => Time.timeScale > 0);

        // Memainkan audio
        audioManager.PlaySFXNonLoop(audioManager.ReceiveBuff);
        FindObjectOfType<UIhandler>().BuffUI.SetActive(true);

        yield return new WaitForSeconds(2f);
        FindObjectOfType<UIhandler>().BuffUI.SetActive(false); 

    }

}





