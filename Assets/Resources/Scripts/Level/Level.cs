using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public Stats stats;
    public levelStats level;

    private void Update()
    {

    }

    public enum Stats
    {
        Diam,
        Bermain,
        Berhenti,
        Kalah
    }

    public enum levelStats
    {
        Mudah,
        Lumayan,
        Susah,
        TingkatDewa
    }
}
