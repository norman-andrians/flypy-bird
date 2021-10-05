using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PemunculTanah : MonoBehaviour
{
    public GameObject objekTanah;

    private Transform locParent;
    private Transform locTanah;

    // Start is called before the first frame update
    void Start()
    {
        locParent = gameObject.GetComponent<Transform>();
        locTanah = objekTanah.GetComponent<Transform>();

        float posx = 0;

        for (int i = 0; i < 3; i++)
        {
            Vector3 posisi = new Vector3(posx, locTanah.position.y, -1);

            var tanahBaru = Instantiate(objekTanah, posisi, Quaternion.identity);
            tanahBaru.transform.parent = locParent.parent;

            posx += 5.12f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
