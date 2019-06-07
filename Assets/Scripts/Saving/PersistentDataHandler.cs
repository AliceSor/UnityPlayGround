using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


[CreateAssetMenu()]
public class PersistentDataHandler : ScriptableObject
{
    public string filename = "PersistentData";
    public PersistentData persistentData;

    //In case sript will be enabled when changing scene
    private bool firstLoad = true;

    void OnEnable()
    {
        Debug.Log("PersistentDataHandler Enabled");
        if (firstLoad)
        {
            LoadProgres();
            firstLoad = false;
        }

    }

    void OnDestroy()
    {
        Debug.Log("PersistentDataHandler Destroyed");

        SaveProgres();
    }

    public void SaveProgres()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + filename);
        bf.Serialize(file, persistentData);
        file.Close();
    }

    public void LoadProgres()
    {
        if (File.Exists(Application.persistentDataPath + filename))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + filename, FileMode.Open);
            persistentData = (PersistentData)bf.Deserialize(file);
            file.Close();
        }
        else
        {
            persistentData = new PersistentData();
        }
    }

    public void DeleteProgress()
    {
        if (File.Exists(Application.persistentDataPath + filename))
        {
            File.Delete(Application.persistentDataPath + filename);
            persistentData = new PersistentData();
        }
    }

    //Todo: move elsewhere
   
}//PersistensDataHandler
