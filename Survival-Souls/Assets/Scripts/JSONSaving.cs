using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JSONSaving : MonoBehaviour
{
    public static JSONSaving SharedInstance;
    public PlayerData playerData;
    private string path;
    private string persistentPath;

    void Awake()
    {
        SharedInstance = this;
        SetPath();
        LoadPreLoadData();
    }
  


    private void SetPath()
    {
        path = Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
        persistentPath = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
    }

    public string GetPath()
    {
        return this.path;
    }

    public void SaveData(PlayerData playerData)
    {
        string savePath = persistentPath;


        string json = JsonUtility.ToJson(playerData);


        using StreamWriter writer = new StreamWriter(savePath);
        writer.Write(json);
    }

    public PlayerData LoadData()
    {
        using StreamReader reader = new StreamReader(persistentPath);
        string json = reader.ReadToEnd();

        playerData = JsonUtility.FromJson<PlayerData>(json);

        return playerData;
    }

    private void LoadPreLoadData()
    {
        if (!System.IO.File.Exists(Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SaveData.json"))
        {
            playerData = new PlayerData(0, 0, 0, 0, 0, 0, 0, false, false, false);
            SaveData(playerData);
        }
        else
        {
            using StreamReader reader = new StreamReader(persistentPath);
            string json = reader.ReadToEnd();

            playerData = JsonUtility.FromJson<PlayerData>(json);
        }


    }
    public PlayerData LoadDataFromPath(string persistentPath)
    {
        using StreamReader reader = new StreamReader(persistentPath);
        string json = reader.ReadToEnd();

        playerData = JsonUtility.FromJson<PlayerData>(json);

        return playerData;
    }

}
