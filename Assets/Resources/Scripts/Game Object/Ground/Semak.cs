using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Semak : MonoBehaviour
{
    public PlayerController playerController;
    public GameObject player;

    [System.Serializable]
    public class ObjSemak
    {
        public GameObject semak;
        public float jarakAwal;
        public float jarakAkhir;
    }

    public ObjSemak[] objSemak;

    private Transform playerpos;
    private Vector2[] posAwal;
    private Vector2[] posAkhir;

    // Start is called before the first frame update
    void Start()
    {
        playerpos = player.GetComponent<Transform>();

        posAwal = new Vector2[objSemak.Length];
        posAkhir = new Vector2[objSemak.Length];

        for (int i = 0; i < objSemak.Length; i++)
        {
            posAwal[i] = new Vector2(objSemak[i].jarakAwal, posAwal[i].y);
            posAkhir[i] = new Vector2(objSemak[i].jarakAkhir, posAkhir[i].y);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerController.isPlaying)
        {
            for (int i = 0; i < objSemak.Length; i++)
            {
                posAwal[i] = new Vector2(objSemak[i].jarakAwal + playerpos.position.x, posAwal[i].y);
                posAkhir[i] = new Vector2(-objSemak[i].jarakAkhir + playerpos.position.x, posAkhir[i].y);

                if (objSemak[i].semak.transform.position.x <= playerpos.position.x - objSemak[i].jarakAkhir)
                {
                    objSemak[i].semak.transform.position = new Vector3(
                        posAwal[i].x,
                        objSemak[i].semak.transform.position.y,
                        -1f
                        );
                }
            }
        }
    }
}
