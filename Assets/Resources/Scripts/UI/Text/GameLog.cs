using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;


public class GameLog : MonoBehaviour
{
    public GameObject debugObj;
    public TextMeshProUGUI textMesh;
    private PlayerData data;
    private string path;

    private bool isError = false;

    void Start()
    {
        data = SaveSystem.LoadPlayer();
        path = Application.persistentDataPath + "/player.dat";

        if (!File.Exists(path))
        {
            textMesh.text += "[ERROR] NullFileException: Save file not found in \"" + path + "\"\n\n";
            isError = true;
        }
        if (data == null)
        {
            textMesh.text += "[ERROR] NullReferenceException: \"data\" Object reference not set to an instance of an object";
            isError = true;
        }

        debugObj.SetActive(isError);
    }
}
