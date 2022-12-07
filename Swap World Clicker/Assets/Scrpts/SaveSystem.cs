using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.Collections;

public class SaveSystem : MonoBehaviour
{
    public WorldData  _worldData;

    private void Awake()
    {
        Load();
        UpgradeStore.OnDateChange.AddListener(Save);
    }

    public void Load()
    {
        Debug.Log(Application.persistentDataPath + "/playerInfo.dat");
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            WorldData data = (WorldData)bf.Deserialize(file);
            _worldData = data;
            file.Close();
        }
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
        bf.Serialize(file, _worldData);
        file.Close();
    }

}

[System.Serializable]
public class WorldData
{
    public StoreData[] storeDates;
}

[System.Serializable]
public class StoreData
{
    [HideInInspector]public string name = $"World";
    public int worldId;
    public bool isUnlock;
    public ClickerData [] clickerData;
}

[System.Serializable]

public class ClickerData
{
    [HideInInspector] public string name = $"Clicker";
    public int clickerId;
    public int currentLevel;
    public int cost;
    public bool isUnlock;
    public int scoreAdd;
}