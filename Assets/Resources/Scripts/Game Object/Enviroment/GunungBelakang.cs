using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunungBelakang : MonoBehaviour
{
    public GameObject player;

    private Transform playerLoc;

    // Start is called before the first frame update
    void Start()
    {
        playerLoc = player.GetComponent<Transform>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (playerLoc.position.x > -3f)
        {
            transform.position = new Vector3(playerLoc.position.x, transform.position.y, transform.position.z);
        }
    }
}
