using System.Collections;
using UnityEngine;

public class Awan : MonoBehaviour
{
    public float deadTime;
    public float kecepatanMin;
    public float kecepatanMax;

    private float speed;

    private void Start()
    {
        speed = Random.Range(Mathf.Abs(kecepatanMin), Mathf.Abs(kecepatanMax));
        StartCoroutine(waktuMati(gameObject, deadTime * speed));
    }

    //
    private void FixedUpdate()
    {
        transform.Translate(Vector2.left * (Time.deltaTime * speed));
    }

    public IEnumerator waktuMati(GameObject obj, float t)
    {
        yield return new WaitForSeconds(t);
        Destroy(obj);
    }
}
