using System.Collections;
using UnityEngine;

public class PemindahGunung : MonoBehaviour
{
    [System.Serializable]
    public class ObjectPegunungan
    {
        public GameObject gunung;
        public float jarak;
        public float maxJarak;
    }

    public GameObject player;
    public ObjectPegunungan[] objGunung;

    private float[] jarakPosAwal;
    private float[] jarakPosAkhir;
    private float[] maxJarak;

    private void Start()
    {
        jarakPosAwal = new float[objGunung.Length];
        jarakPosAkhir = new float[objGunung.Length];
        maxJarak = new float[objGunung.Length];

        for (int i = 0; i < objGunung.Length; i++)
        {
            jarakPosAwal[i] = objGunung[i].jarak;
            jarakPosAkhir[i] = Random.Range(objGunung[i].jarak, objGunung[i].maxJarak);
            maxJarak[i] = objGunung[i].maxJarak;
        }
    }

    private void Update()
    {
        for (int i = 0; i < objGunung.Length; i++)
        {
            if (objGunung[i].gunung.transform.position.x < player.transform.position.x - objGunung[i].jarak)
            {
                objGunung[i].gunung.transform.position = new Vector3(
                    jarakPosAkhir[i],
                    objGunung[i].gunung.transform.position.y,
                    objGunung[i].gunung.transform.position.z
                );

                objGunung[i].jarak += jarakPosAwal[i];
                objGunung[i].maxJarak += maxJarak[i];

                jarakPosAkhir[i] = Random.Range(objGunung[i].jarak, objGunung[i].maxJarak);
            }
        }
    }
}
