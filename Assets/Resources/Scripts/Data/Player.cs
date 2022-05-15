using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [HideInInspector] public int point = 0;
    [HideInInspector] public int bestPoint = 0;

    // simpan data pemain
    public void SaveData()
    {
        SaveSystem.SavePlayer(this);
    }

    // muat data pemain
    public void LoadData()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        bestPoint = data.bestScore;
    }

    void Start()
    {
        LoadData();
    }
}
