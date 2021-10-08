using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("untuk memulai")]
    public float journeyTime;
    public float kecepatan;
    public float delay = 1f;

    [Header("gameplay")]
    public float kecepatanBurung = 4f;

    // public Vector2 lokasiKedua;

    [HideInInspector]
    public Rigidbody2D rb;
    // private float waktuMulai;
    // private float waktuMulai2;

    public bool isPlaying;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        // waktuMulai = delay;
        // waktuMulai2 = delay;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (isPlaying)
        {
            rb.velocity = new Vector2(kecepatanBurung * Time.deltaTime, rb.velocity.y);
        }
    }

    /* kode ghaib :'v
    public void mulaiJalanPos(Vector2 lokDua)
    {
        float frac = (Time.time - waktuMulai) / journeyTime * kecepatan;
        transform.position = Vector3.Slerp(transform.position, new Vector3(lokDua.x, lokDua.y, -1), frac);
    }
    */
}