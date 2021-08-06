using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;
    public Save toBeSaved { get; set; }
    public Save loadedSave { get; set; }

    private List<ISavable> savables = new List<ISavable>();
    private void Awake()
    {
        instance = this;
        savables.Add((ChickenAttributes)FindObjectOfType(typeof(ChickenAttributes)));

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

    private void OnDestroy()
    {
        Save();
    }

    private Save Load()
    {
        loadedSave = null;
        string path = Application.persistentDataPath + "/gamesave.save";
        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(path, FileMode.Open);
            Debug.Log(path);
            if (file.Length != 0)
            {
                loadedSave = (Save)bf.Deserialize(file);
                Debug.Log("asdf" + loadedSave.chickenXPosition + loadedSave.chickenYPosition);
            }
            file.Close();

            Debug.Log("Game Loaded");
        }
        else
        {
            Debug.Log("No game saved!");
        }
        RequestObjectsLoad();
        return loadedSave;
    }

    private void RequestObjectsLoad()
    {
        foreach (ISavable save in savables)
        {
            save.Load();
        }
    }

    void Save()
    {
        RequestObjectsSave();
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(file, toBeSaved);
        file.Close();

        Debug.Log("Game Saved");
    }

    private void RequestObjectsSave()
    {
        foreach (ISavable save in savables)
        {
            save.Save();
        }
    }
}
