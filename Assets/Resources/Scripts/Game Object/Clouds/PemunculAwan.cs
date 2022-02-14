using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PemunculAwan : MonoBehaviour
{
    public GameObject cameraObj;
    public Vector2 offSet;

    // variabel objek untuk awan
    public GameObject[] awan;
    public GameObject awanParent;

    public Vector2 jarakMin;
    public Vector2 jarakMax;

    public float waktu = 6f;

    public bool tampilkanDebug;

    private Transform lokasiParent;

    // Start is called before the first frame update
    void Start()
    {
        lokasiParent = awanParent.GetComponent<Transform>();

        StartCoroutine(munculkanAwan(awan, lokasiParent, transform, jarakMin, jarakMax, waktu, tampilkanDebug));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(cameraObj.transform.position.x + offSet.x, this.transform.position.y, -5f);
    }

    // fungsi untuk memunculkan awan
    public IEnumerator munculkanAwan(GameObject[] cloud, Transform par, Transform spLocation, Vector2 min, Vector2 max, float delay, bool showDebug)
    {
        while (true)
        {
            int indexAwan = Random.Range(0, awan.Length);

            float posisix = Random.Range(min.x, max.x);
            float posisiy = Random.Range(min.y, max.y);

            Vector3 posAwan = new Vector3(spLocation.position.x + posisix, spLocation.position.y + posisiy, -2f);

            membuatAwan(cloud[indexAwan], par, posAwan);

            if (showDebug)
                Debug.Log("memunculkan awan");

            yield return new WaitForSeconds(delay);
        }
    }

    public void membuatAwan(GameObject cld, Transform pr, Vector3 pos)
    {
        // variabel untuk memunculkan awan
        var awanBaru = Instantiate(cld, pos, Quaternion.identity);
        awanBaru.transform.parent = pr.transform;
    }
}
