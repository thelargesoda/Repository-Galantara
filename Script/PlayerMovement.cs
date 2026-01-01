using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    AudioManager audioManager;
    public Transform player;
    public float MajuX = 1500f;
    public float XNegative = 50f;
    public float XPositive = 50f;
    public float Ystart;
    public float IncreaseSpeedLvl;
    public float YPositive = 13f;
    public Rigidbody X;
    public bool IsGrounded = false;
    public bool WasGrounded = false;
    public bool WasGroundedBefore = true;
    public float gravityScale = 2f;
    public Collision x;
    public GameSystem gameSystem;

    public bool isFlying = false;
    public float targetY = 20f;

    private void Awake()
    {

        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        gameSystem = FindObjectOfType<GameSystem>();
       
    }
    void Start()
    {
        Ystart = player.position.y;
        targetY = player.position.y + targetY;
        audioManager.BackgroundPlay();
        audioManager.Play();
        X = GetComponent<Rigidbody>();
        gameSystem.Pause();

        if (SceneManager.GetActiveScene().name == "Level 1")
        {
            IncreaseSpeedLvl = 1500;
        }

        if (SceneManager.GetActiveScene().name == "Level 2")
        {
            IncreaseSpeedLvl = 2000;
        }

        if (SceneManager.GetActiveScene().name == "Level 3")
        {
            IncreaseSpeedLvl = 2500;
        }

        NormalState();

    }

    public void NormalState()
    {
        MajuX = IncreaseSpeedLvl;
        XNegative = 50f;
        XPositive = 50f;
        YPositive = 13f;
        isFlying = false;
        x.enabled = true;
        FindObjectOfType<PlayerAnimation>().UnFlying();
        
    }
    public void golokBuff()
    {
        MajuX = MajuX * 2;
        XPositive = XPositive * 2;
        XNegative = XNegative * 2;
        X.useGravity = true;
        

        Invoke("NormalState", 6f);
    }
    public void kerisBuff()
    {
        isFlying = true;
        X.useGravity = false;
        FindObjectOfType<PlayerAnimation>().Flying();
        

        Invoke("NormalState", 6f);

    }

    public void karambitBuff()
    {


        YPositive = YPositive * 3;
        Invoke("NormalState", 4.5f);

    }
    public void kujangBuff()
    {

        x.enabled = false;
        Invoke("NormalState", 8f);

    }








    public void OnCollisionEnter(UnityEngine.Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Ground")
        {
            IsGrounded = true;
        }
    }

    public void OnCollisionExit(UnityEngine.Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsGrounded = false;
        }

    }
    void Update()
    {

        WasGroundedBefore = WasGrounded;
        WasGrounded = IsGrounded;

        if (!WasGroundedBefore && WasGrounded)
        {

            audioManager.PlayRunLoop();
        }

        if (WasGroundedBefore && !WasGrounded)
        {

            audioManager.StopRunLoop();
        }




        if (isFlying)
        {
            Vector3 pos = transform.position;
            pos.y = Mathf.Lerp(pos.y, targetY, Time.deltaTime * 5f);

            transform.position = pos;
        }

        // Pergerakan Player
        X.AddForce(0, 0, MajuX * Time.deltaTime);

        if (Input.GetKey(KeyCode.A)) // Pergerakan X axis negatif (Kiri)
        {
            X.AddForce(-XNegative * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey(KeyCode.D)) // Pergerakan X axis positif (Kanan)
        {
            X.AddForce(XPositive * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            audioManager.PlaySFXNonLoop(audioManager.Jump);
            X.AddForce(Vector3.up * YPositive, ForceMode.VelocityChange);
            FindObjectOfType<PlayerAnimation>().JumpAnim();
        }
        
    }

    void FixedUpdate()
    {
        
        
            X.AddForce(Physics.gravity * gravityScale, ForceMode.Acceleration);  // mengatur kekuatan gravitasi in game


        




    }
}





