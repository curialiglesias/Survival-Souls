using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JSONSaving : MonoBehaviour
{
    public static JSONSaving SharedInstance;
    private PlayerData playerData;
    private string path;
    private string persistentPath;

    void Awake()
    {
        SharedInstance = this;
    }
    void Start()
    {
        //CreatePlayerData();
        SetPath();
    }

    private void CreatePlayerData()
    {
        playerData = new PlayerData(0, 1, 1, 1, 1, 1);
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

        Debug.Log("Saving Data at " + savePath);
        string json = JsonUtility.ToJson(playerData);
        Debug.Log(json);

        using StreamWriter writer = new StreamWriter(savePath);
        writer.Write(json);
    }

    public PlayerData LoadData()
    {
        using StreamReader reader = new StreamReader(persistentPath);
        string json = reader.ReadToEnd();

        PlayerData data = JsonUtility.FromJson<PlayerData>(json);
        Debug.Log(data.ToString());

        return data;
    }

}
