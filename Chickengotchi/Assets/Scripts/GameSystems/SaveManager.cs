using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;
    Save toBeSaved { get; set; }
    Save loadedSave;

    private void Awake()
    {
        instance = this;
        loadedSave = Load();

        if (loadedSave != null)
        {
            toBeSaved = loadedSave;
        }
        else
        {
            toBeSaved = new Save();
        }
    }

    private Save Load()
    {
        Save loadedSave = null;
        if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            loadedSave = (Save)bf.Deserialize(file);
            file.Close();

            Debug.Log("Game Loaded");
        }
        else
        {
            Debug.Log("No game saved!");
        }
        return loadedSave;
    }

    void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(file, toBeSaved);
        file.Close();

        Debug.Log("Game Saved");
    }
}
