using System.Collections;
using UnityEngine;

public class Awan : MonoBehaviour
{
    public float kecepatanMin;
    public float kecepatanMax;

    private float speed;
    private GameObject player;
    private PlayerController playerController;
    private Rigidbody2D rb;

    private void Start()
    {
        speed = Random.Range(Mathf.Abs(kecepatanMin), Mathf.Abs(kecepatanMax));

        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
        rb = player.GetComponent<Rigidbody2D>();
    }

    //
    private void FixedUpdate()
    {
        if (player.transform.position.x > -3f && !playerController.isPaused && !playerController.isDead)
        {
            transform.Translate(Vector2.right * (Time.deltaTime * rb.velocity.x * speed));
        }
        else
        {
            transform.Translate(Vector2.left * (Time.deltaTime * speed));
        }
        
    }

    private void Update()
    {

        if (transform.position.x < player.transform.position.x - 12f) { Destroy(gameObject); }
    }
}