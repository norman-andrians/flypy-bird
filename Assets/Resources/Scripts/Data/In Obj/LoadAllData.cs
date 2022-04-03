using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LoadAllData : MonoBehaviour
{
    public Player playerDat;

    // Start is called before the first frame update
    void Start()
    {
        string pathDat = Application.persistentDataPath + "/player.dat";

        if (File.Exists(pathDat)) playerDat.LoadData();
        else playerDat.SaveData();
    }
}
