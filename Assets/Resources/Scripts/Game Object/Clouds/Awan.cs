using System.Collections;
using UnityEngine;

public class Awan : MonoBehaviour
{
    public float kecepatanMin;
    public float kecepatanMax;

    private float speed;
    private GameObject player;

    private void Start()
    {
        speed = Random.Range(Mathf.Abs(kecepatanMin), Mathf.Abs(kecepatanMax));
        player = GameObject.Find("Player");
    }

    //
    private void FixedUpdate()
    {
        transform.Translate(Vector2.left * (Time.deltaTime * speed));
    }

    private void Update()
    {
        if (transform.position.x < player.transform.position.x - 18f) { Destroy(gameObject); }
    }
}