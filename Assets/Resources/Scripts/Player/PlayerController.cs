﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject gameoverObj;
    public GameObject pauseObj;

    public string tagMati;
    public Sprite spriteTerbang;
    public Sprite spriteJatuh;
    public Sprite spriteMati;

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
    private SpriteRenderer playerSprite;
    private Animator pauseAnim;

    [HideInInspector] public bool isPlaying;
    [HideInInspector] public bool isDead = false;
    [HideInInspector] public bool isPaused = false;
    [HideInInspector] public enum Stats { diam, main, pause, kalah } // useless :v
    [HideInInspector] public Stats status;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        playerSprite = gameObject.GetComponent<SpriteRenderer>();
        pauseAnim = pauseObj.GetComponent<Animator>();
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
        if (!isDead)
        {
            if (rb.velocity.y > 0)
                playerSprite.sprite = spriteTerbang;
            else playerSprite.sprite = spriteJatuh;
        }
        else playerSprite.sprite = spriteMati;

        if (isPlaying && !isDead)
        {
            transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, rb.velocity.y * angelPower);
            if (!isPaused)
            {
                rb.simulated = true;
                rb.velocity = new Vector2(kecepatanBurung * Time.deltaTime, rb.velocity.y);

                if (transform.position.x >= 0f)
                {
                    kecepatanBurung = kecepatanSebenarnya;
                }

                if (rb.velocity.y < 0 && !isPaused)
                {
                    if (Input.touchCount > 0)
                    {
                        Vector2 gaya = new Vector2(rb.velocity.x, gayaTerbang * Time.deltaTime);
                        rb.velocity = gaya;
                    }
                }
            }
            else if (isPaused)
            {
                rb.simulated = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == tagMati)
        {
            StartCoroutine(endPause());
            isDead = true;
            gameoverObj.SetActive(true);
        }
    }

    /* kode ghaib :'v
    public void mulaiJalanPos(Vector2 lokDua)
    {
        float frac = (Time.time - waktuMulai) / journeyTime * kecepatan;
        transform.position = Vector3.Slerp(transform.position, new Vector3(lokDua.x, lokDua.y, -1), frac);
    }
    */

    private IEnumerator endPause()
    {
        pauseAnim.SetTrigger("Hide");
        yield return new WaitForSeconds(.8f);
        pauseObj.SetActive(false);
    }
}