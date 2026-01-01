using System. Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{

    private TextMeshProUGUI ArtText;
    void Start() {
        ArtText = GetComponent<TextMeshProUGUI>();
    }

public void UpdateDiamondText(PlayerInventory playerInventory)
    { 
    ArtText.text = playerInventory.JumlahArtefak.ToString();
    }

        }