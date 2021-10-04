using UnityEngine;

public class Awan : MonoBehaviour
{
    public Transform spawner;

    public float kecepatanMin;
    public float kecepatanMax;

    private float speed;

    private void Start()
    {
        speed = Random.Range(Mathf.Abs(kecepatanMin), Mathf.Abs(kecepatanMax));
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.left * (Time.deltaTime * speed));

        if (transform.position.x < (spawner.position.x - 10f))
        {
            Destroy(gameObject);
        }
    }
}
