using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PemunculObstakel : MonoBehaviour
{
    [System.Serializable]
    public class PenjarakanLevel
    {
        public float jarakKurang;
        public float pelatukJarak;
        public bool sudahkahJarak = false;
    }

    public GameObject player;
    public GameObject obstakel;
    public GameObject coins;

    public float radiusObs = 5f;
    public float jarakMuncul = 4f;
    public float jarakCelah = 1f;


    public float presentasiAnimasi = 40f;
    public float posisiTriggerAnimasi = 80f;

    public PenjarakanLevel[] Penjarakan;

    private Transform obsPos;
    private Transform playerPos;
    private PlayerController playerController;

    private Animator objAnimator;

    private int count = 1;
    private float posy;
    private float jarakMunculSebenarnya;
    private float jarakAntarPlayer;

    // Start is called before the first frame update
    void Start()
    {
        obsPos = obstakel.GetComponent<Transform>();
        objAnimator = gameObject.GetComponent<Animator>();

        playerPos = player.GetComponent<Transform>();
        playerController = player.GetComponent<PlayerController>();

        jarakMunculSebenarnya = jarakMuncul;

        for (int i = 0; i < 4; i++)
        {
            posy = Random.Range(-radiusObs, radiusObs);
            Vector3 posisiObs = new Vector3(jarakMunculSebenarnya, posy, obsPos.position.z);
            MembuatObstakel(obstakel, posisiObs, jarakCelah, count);

            count++;
            jarakAntarPlayer += jarakMuncul / 2;
            jarakMunculSebenarnya += jarakMuncul / 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerPos.position.x >= jarakAntarPlayer && playerController.isPlaying)
        {
            jarakObs(Penjarakan);

            posy = Random.Range(-radiusObs, radiusObs);
            Vector3 posisiObs = new Vector3(jarakMunculSebenarnya, posy, obsPos.position.z);
            MembuatObstakel(obstakel, posisiObs, jarakCelah, count);

            count++;
            jarakAntarPlayer += jarakMuncul / 2;
            jarakMunculSebenarnya += jarakMuncul / 2;
        }
    }

    private void MembuatAnimasi(Transform animObject, int probability)
    {
        int possibility = Random.Range(probability, 100);

        if (probability == possibility)
        {
            Animator obsAnim = animObject.gameObject.AddComponent<Animator>();
            obsAnim.runtimeAnimatorController = objAnimator.runtimeAnimatorController;
        }
    }

    public void MembuatObstakel(GameObject obj, Vector3 pos, float jarak, int jumlah)
    {
        GameObject obsBaru = Instantiate(obj, pos, Quaternion.identity);

        Transform obsObject = obsBaru.transform.GetChild(0);
        Transform obsTop = obsObject.GetChild(0);
        Transform obsBottom = obsObject.GetChild(1);

        float jarakTopy = obsTop.position.y;
        float jarakBottomy = obsBottom.position.y;

        Vector3 obsTopPos = new Vector3(obsTop.position.x, jarakTopy + jarak, obsTop.position.z);
        Vector3 obsBottomPos = new Vector3(obsBottom.position.x, jarakBottomy - jarak, obsBottom.position.z);

        obsTop.position = obsTopPos;
        obsBottom.position = obsBottomPos;

        MunculkanCoin(2, obsObject);

        obsBaru.name = obj.name + " " + jumlah.ToString();
        obsBaru.transform.parent = gameObject.transform;

        if (playerPos.position.x > posisiTriggerAnimasi)
        {
            MembuatAnimasi(obsObject, (int)presentasiAnimasi);
        }
    }

    public void jarakObs(PenjarakanLevel[] jarakLevel)
    {
        for (int i = 0; i < jarakLevel.Length; i++)
        {
            if (playerPos.position.x > jarakLevel[i].pelatukJarak && !jarakLevel[i].sudahkahJarak)
            {
                jarakCelah -= jarakLevel[i].jarakKurang;

                jarakLevel[i].sudahkahJarak = true;
            }
        }
    }

    public void MunculkanCoin(int seed, Transform parent)
    {
        int valRange = Random.Range(0, seed);
        int valTarget = 0;

        if (valRange == valTarget)
        {
            GameObject coinBaru = Instantiate(coins, new Vector3(
                parent.position.x,
                parent.position.y,
                -2f
                ), Quaternion.identity);

            coinBaru.transform.parent = parent;
        }
    }
}
