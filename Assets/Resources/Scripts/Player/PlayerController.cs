using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("untuk memulai")]
    public float journeyTime;
    public float kecepatan;

    private float waktuMulai;

    public bool isPlaying;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying)
            mulaiJalanPos(1);
    }

    public void mulaiJalanPos(float hitungMundur)
    {
        if (hitungMundur < 0)
        {
            float frac = (Time.time - waktuMulai) / journeyTime * kecepatan;
            transform.position = Vector3.Slerp(transform.position, new Vector3(0, 0, 0), frac);
        }
        else
            hitungMundur -= Time.deltaTime;
    }
}
