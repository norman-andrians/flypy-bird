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

        for (int i = 0; i < 2; i++)
        {
            Vector3 awanPos =  posisiAwan(jarakMin, jarakMax);
            membuatAwan(awan[i], awanParent.transform, awanPos);
        }

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
        while (true && awanParent.transform.childCount < 6)
        {
            int indexAwan = Random.Range(0, awan.Length);

            Vector3 posAwan = posisiAwan(min, max);

            membuatAwan(cloud[indexAwan], par, posAwan);

            if (showDebug)
                Debug.Log("memunculkan awan");

            yield return new WaitForSeconds(delay);
        }
    }

    public Vector3 posisiAwan(Vector2 min, Vector2 max)
    {
        float posisix = Random.Range(min.x, max.x);
        float posisiy = Random.Range(min.y, max.y);

        return new Vector3(transform.position.x + posisix, transform.position.y + posisiy, 2f);
    }

    public void membuatAwan(GameObject cld, Transform pr, Vector3 pos)
    {
        var awanBaru = Instantiate(cld, pos, Quaternion.identity);
        awanBaru.transform.parent = pr.transform;
    }
}
