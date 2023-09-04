using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class InventorySave
{
    public InventoryObject data; // ScriptableObject

    private string dataPath;

    void Awake()
    {           
        dataPath = Application.persistentDataPath + "/data.dat";
        LoadData();
    }

    // 데이터 로드
    void LoadData()
    {
        if (File.Exists(dataPath))
        {
            // 파일이 존재하면 로드
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(dataPath, FileMode.Open);
            data = (InventoryObject)bf.Deserialize(file);
            file.Close();
        }
        else
        {
            // 파일이 존재하지 않으면 생성
            data = ScriptableObject.CreateInstance<InventoryObject>();
            SaveData();
        }
    }

    // 데이터 저장
    void SaveData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(dataPath);
        bf.Serialize(file, data);
        file.Close();
    }
}
