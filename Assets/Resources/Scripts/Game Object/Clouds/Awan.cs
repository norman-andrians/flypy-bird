using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Awan : MonoBehaviour
{
    public float kecepatan;

    private void FixedUpdate()
    {
        transform.Translate(Vector2.left * (Time.deltaTime * kecepatan));
    }
}
