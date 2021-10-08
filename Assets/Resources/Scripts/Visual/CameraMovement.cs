using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;
    private Transform playerPos;
    private PlayerController pc;

    private void Start()
    {
        playerPos = player.GetComponent<Transform>();
        pc = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (playerPos.position.x >= 0f)
        {
            transform.position = new Vector3(playerPos.position.x, 0f, -10f);
        }
    }
}
