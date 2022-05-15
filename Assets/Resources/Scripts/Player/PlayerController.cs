using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Options options;
    public Animator CameraMovement;
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

    public AudioClip buttonSound;

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

    public Player playerDat;

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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0)
        {
            BirdFly();
        }
    }

    private void FixedUpdate()
    {
        if (!isDead)
        {
            if (rb.velocity.y > 3.5f)
            {
                playerSprite.sprite = spriteTerbang;
            }
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

                if (transform.position.x >= 0f) { kecepatanBurung = kecepatanSebenarnya; }
            }
            else if (isPaused)
            {
                rb.simulated = false;
            }
        }
    }

    private void BirdFly()
    {
        // if (rb.velocity.y < 3f)
        if (isPlaying && !isDead)
            rb.velocity = Vector2.up * gayaTerbang;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Poin")
        {
            playerDat.point++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == tagMati && !isDead)
        {
            if (options.isVibrate) Handheld.Vibrate();
            if (playerDat.point > playerDat.bestPoint) playerDat.bestPoint = playerDat.point;

            playerDat.SaveData();

            StartCoroutine(endPause());
            gameoverObj.SetActive(true);
            CameraMovement.enabled = true;
            isDead = true;
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