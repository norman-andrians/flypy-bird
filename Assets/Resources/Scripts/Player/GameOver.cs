using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    public GameObject player;
    public TextMeshProUGUI ptsObj;
    public TextMeshProUGUI bestPtsObj;
    public Player playerDat;

    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.isDead)
        {
            ptsObj.text = playerDat.point.ToString();
            bestPtsObj.text = playerDat.bestPoint.ToString();
        }
    }
}
