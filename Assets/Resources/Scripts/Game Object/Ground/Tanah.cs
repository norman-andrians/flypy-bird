using UnityEngine;

public class Tanah : MonoBehaviour
{
    public string nama;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hancurkan " + gameObject.name);
        if (collision.gameObject.tag == nama) Destroy(gameObject);
    }
}
