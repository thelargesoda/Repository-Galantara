using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PlayerInventory : MonoBehaviour
{

    public int JumlahArtefak{get; set;}
   
    public UnityEvent<PlayerInventory> PlayerInventoryChanged;
   public void artefakDiambil()
    {
        JumlahArtefak++;

        PlayerInventoryChanged.Invoke(this);
    }

}
