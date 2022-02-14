using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DevLog : MonoBehaviour
{
    public TextMeshProUGUI textLog;

    public GameObject player;

    private float fps;
    private float playerSpeed;

    private PlayerController playerController;
    private Rigidbody2D playerRb;

    private void Start()
    {
        playerController = player.GetComponent<PlayerController>();
        playerRb = player.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        fps = 1 / Time.deltaTime;

        textLog.text = "FPS:" + fps.ToString("F2") + "\nplayer speed: " + playerRb.velocity.x.ToString("F");
    }
}
