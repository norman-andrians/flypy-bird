using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstakel : MonoBehaviour
{
    public string nama;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == nama)
        {
            Destroy(gameObject);
        }
    }
}
