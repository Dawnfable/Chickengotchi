using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenAttributes : MonoBehaviour, ISavable
{
    public void Save()
    {
        Debug.Log("Save Method For Chicken" + gameObject.transform.position.x + gameObject.transform.position.y);
        SaveManager.instance.toBeSaved.chickenXPosition = gameObject.transform.position.x;
        SaveManager.instance.toBeSaved.chickenYPosition = gameObject.transform.position.y;
    }

    public void Load()
    {
        Debug.Log("Load Method For Chicken");
        Save loading = SaveManager.instance.loadedSave;
        if (loading != null)
        {
            Debug.Log("Setting Chicken Position" + loading.chickenXPosition + loading.chickenXPosition);
            gameObject.transform.position = new Vector3(loading.chickenXPosition, loading.chickenYPosition);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
