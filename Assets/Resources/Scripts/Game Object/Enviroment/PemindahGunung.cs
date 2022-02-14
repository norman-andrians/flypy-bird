using System.Collections;
using UnityEngine;

public class PemindahGunung : MonoBehaviour
{
    [System.Serializable]
    public class ObjectPegunungan
    {
        public GameObject gunung;
        public float jarakAwal;
        public float jarakAkhir;
    }

    public GameObject player;
    public ObjectPegunungan[] objGunung;

    private Vector2[] jarakPosAwal;
    private Vector2[] jarakPosAkhir;

    private PlayerController playerController;

    private void Start()
    {
        playerController = player.GetComponent<PlayerController>();

        jarakPosAwal = new Vector2[objGunung.Length];
        jarakPosAkhir = new Vector2[objGunung.Length];

        for (int i = 0; i < objGunung.Length; i++)
        {
            jarakPosAwal[i] = new Vector2(objGunung[i].jarakAwal, jarakPosAwal[i].y);
            jarakPosAkhir[i] = new Vector2(objGunung[i].jarakAkhir, jarakPosAkhir[i].y);
        }
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < objGunung.Length; i++)
        {
            jarakPosAwal[i] = new Vector2(player.transform.position.x + objGunung[i].jarakAwal, jarakPosAwal[i].y);
            jarakPosAkhir[i] = new Vector2(player.transform.position.x - objGunung[i].jarakAkhir, jarakPosAkhir[i].y);

            if (playerController.isPlaying && objGunung[i].gunung.transform.position.x <= player.transform.position.x - objGunung[i].jarakAkhir)
            {
                objGunung[i].gunung.transform.position = new Vector3(
                    jarakPosAwal[i].x,
                    objGunung[i].gunung.transform.position.y,
                    objGunung[i].gunung.transform.position.z
                );
            }
        }
    }
}
