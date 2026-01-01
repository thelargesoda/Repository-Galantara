using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveSystem 
{

    public static void SavePlayer(GameSystem LevelStatus)
    {

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Player.Data";
        FileStream Stream = new FileStream(path, FileMode.Create);

        PlayerLevelData data = new PlayerLevelData(LevelStatus);

        formatter.Serialize(Stream, data);
        Stream.Close();
    }

    public static void ResetSave()
    {
        string path = Application.persistentDataPath + "/Player.Data";

        if (File.Exists(path))
        {
            File.Delete(path);
            Debug.Log("Save data reset successfully.");
        }
        else
        {
            Debug.Log("No save data to reset.");
        }
    }


    public static PlayerLevelData LoadData()
    {
        string path = Application.persistentDataPath + "/Player.Data";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream Stream = new FileStream(path, FileMode.Open);

            PlayerLevelData data = formatter.Deserialize(Stream) as PlayerLevelData;
            Stream.Close();

            return data;
        }
        else 
        { 
                Debug.Log("Save File not found in " + path);
                return null;
        }
    }

   
}
