using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Karambit : MonoBehaviour
{
    [SerializeField] GameObject X;
    GameSystem gameSystem;
    private void Awake()
    {
        gameSystem = FindObjectOfType<GameSystem>();
    }

    public void OnTriggerEnter(Collider other)
    {
        PlayerInventory PlayerInventory = other.GetComponent<PlayerInventory>();



        if (PlayerInventory != null)
        {


            FindObjectOfType<PlayerMovement>().karambitBuff();
            FindObjectOfType<UIhandler>().KarambitUI();
            gameSystem.Pause();
            PlayerInventory.artefakDiambil();
            X.SetActive(false);
        }
    }
}
