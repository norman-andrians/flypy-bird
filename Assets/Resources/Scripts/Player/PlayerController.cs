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
    public float gayaTerbang = 20f;
    public float angelPower = 2f;

    // public Vector2 lokasiKedua;

    [HideInInspector]
    public Rigidbody2D rb;
    // private float waktuMulai;
    // private float waktuMulai2;
    private float kecepatanSebenarnya;

    [HideInInspector] public bool isPlaying;
    [HideInInspector] public enum Stats { diam, main, pause, kalah } // useless :v
    [HideInInspector] public Stats status;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        status = Stats.diam;

        kecepatanSebenarnya = kecepatanBurung / 2;

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
            transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, rb.velocity.y * angelPower);

            if (transform.position.x >= 0f)
            {
                kecepatanBurung = kecepatanSebenarnya;
            }

            if (Input.touchCount > 0)
            {
                Vector2 gaya = new Vector2(rb.velocity.x, gayaTerbang * Time.deltaTime);
                rb.velocity = gaya;
            }
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