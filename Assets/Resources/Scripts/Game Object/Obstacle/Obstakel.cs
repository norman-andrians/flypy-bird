using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstakel : MonoBehaviour
{
    public string nama;

    private GameObject player;
    private GameAudio gameAudio;
    private BoxCollider2D colider;

    void Start()
    {
        colider = gameObject.GetComponent<BoxCollider2D>();
        gameAudio = GameObject.Find("Audio Source").GetComponent<GameAudio>();
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if (transform.position.x < player.transform.position.x -18f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameAudio.pointSound();
            Destroy(colider);
        }
    }
}
