using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerLevelData
{
    public int LevelUnlockStatus;

    public PlayerLevelData (GameSystem levelStatus)
    {
        LevelUnlockStatus = levelStatus.LevelUnlockStatus;
    }
}
