using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;
    public Vector2 offset;
    private Transform playerPos;
    private PlayerController pc;

    private void Start()
    {
        playerPos = player.GetComponent<Transform>();
        pc = player.GetComponent<PlayerController>();

        if (playerPos.position.x >= offset.x)
            Debug.LogWarning("posisi " + player.name + " harus kurang dari offset " + gameObject.name);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (playerPos.position.x >= -offset.x)
        {
            transform.position = new Vector3(playerPos.position.x + offset.x, offset.y, transform.position.z);
        }
    }
}
