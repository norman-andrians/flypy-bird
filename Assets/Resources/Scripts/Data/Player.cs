using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int point = 0;
    public int bestPoint = 0;

    public void SaveData()
    {
        SaveSystem.SavePlayer(this);
    }
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
