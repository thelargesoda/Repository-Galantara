using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golok : MonoBehaviour
{
    [SerializeField] GameObject X;
    GameSystem gameSystem;
    AudioManager audioManager;
    private void Awake()
    {
        gameSystem = FindObjectOfType<GameSystem>();
    }

    public void OnTriggerEnter(Collider other)
        {
        PlayerInventory PlayerInventory = other.GetComponent<PlayerInventory>();

      

        if (PlayerInventory != null)
        {

         
            FindObjectOfType<PlayerMovement>().golokBuff();
            FindObjectOfType<UIhandler>().GolokUI();
            gameSystem.Pause();
            PlayerInventory.artefakDiambil();
            X.SetActive(false);
        }
    }
}
