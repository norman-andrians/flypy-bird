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

    public float radiusObs = 5f;
    public float jarakMuncul = 4f;
    public float jarakCelah = 1f;

    public PenjarakanLevel[] Penjarakan;

    private Transform obsPos;
    private Transform playerPos;
    private PlayerController playerController;

    private int count = 1;
    private float posy;
    private float jarakMunculSebenarnya;
    private float jarakAntarPlayer;

    // Start is called before the first frame update
    void Start()
    {
        obsPos = obstakel.GetComponent<Transform>();
        playerPos = player.GetComponent<Transform>();
        playerController = player.GetComponent<PlayerController>();

        jarakMunculSebenarnya = jarakMuncul;

        for (int i = 0; i < 4; i++)
        {
            posy = Random.Range(-radiusObs, radiusObs);
            Vector3 posisiObs = new Vector3(jarakMunculSebenarnya, posy, obsPos.position.z);
            membuatObstakel(obstakel, posisiObs, jarakCelah, count);

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
            membuatObstakel(obstakel, posisiObs, jarakCelah, count);

            count++;
            jarakAntarPlayer += jarakMuncul / 2;
            jarakMunculSebenarnya += jarakMuncul / 2;
        }
    }

    public void membuatObstakel(GameObject obj, Vector3 pos, float jarak, int jumlah)
    {
        GameObject obsBaru = Instantiate(obj, pos, Quaternion.identity);

        Transform obsTop = obsBaru.transform.GetChild(0);
        Transform obsBottom = obsBaru.transform.GetChild(1);

        float jarakTopy = obsTop.position.y;
        float jarakBottomy = obsBottom.position.y;

        Vector3 obsTopPos = new Vector3(obsTop.position.x, jarakTopy + jarak, obsTop.position.z);
        Vector3 obsBottomPos = new Vector3(obsBottom.position.x, jarakBottomy - jarak, obsBottom.position.z);

        obsTop.position = obsTopPos;
        obsBottom.position = obsBottomPos;

        obsBaru.name = obj.name + " " + jumlah.ToString();
        obsBaru.transform.parent = gameObject.transform;
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
}
