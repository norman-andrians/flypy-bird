using UnityEngine;

public class PemunculTanah : MonoBehaviour
{
    public PlayerController playerController;

    public GameObject objekTanah;
    public GameObject player;

    private Transform playerPos;
    private Transform locParent;
    private Transform locTanah;

    private float jarak = 5f;
    private float jarakan;
    private float posx;
    private int count = 1;

    private const float TANAH_WIDTH = 5.12f;

    // Start is called before the first frame update
    private void Start()
    {
        posx -= TANAH_WIDTH;
        jarakan = jarak;

        playerPos = player.GetComponent<Transform>();
        locParent = gameObject.GetComponent<Transform>();
        locTanah = objekTanah.GetComponent<Transform>();

        Debug.Log("test script");

        for (int i = 0; i < 4; i++)
        {
            Vector3 posisi = new Vector3(posx, locTanah.position.y, -2f);
            membuatTanah(posisi, objekTanah, locParent, i);
            posx += TANAH_WIDTH;

            Debug.Log("Memunculkan " + i.ToString());
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (playerPos.position.x >= jarak && playerController.isPlaying)
        {
            Vector3 posisi = new Vector3(posx, locTanah.position.y, -2f);
            membuatTanah(posisi, objekTanah, locParent, count);
            posx += TANAH_WIDTH;

            Debug.Log("Memunculkan " + count.ToString());
            jarak += jarakan;
            count++;

            Debug.Log("Jarak: " + jarak.ToString());
        }
    }

    private void membuatTanah(Vector3 pos, GameObject obj, Transform objParent, int c)
    {
        var tanahBaru = Instantiate(obj, pos, Quaternion.identity);

        tanahBaru.name = obj.name + " " + c.ToString();
        tanahBaru.transform.parent = objParent.parent;
    }
}
