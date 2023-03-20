using UnityEngine;

public class PemunculTanah : MonoBehaviour
{
    public PlayerController playerController;

    public GameObject objekTanah;
    public GameObject player;

    private Transform playerPos;
    private Transform locParent;
    private Transform locTanah;

    private float jarak = 3.98f; // jarak poin kamera => batas + (panjang pixel / 4) = 5.4f + (5.12 * 4)
    private float posx;
    private int count = 1; // jumlah tanah

    private const float TANAH_WIDTH = 5.12f; // panjang tanah

    // Start is called before the first frame update
    private void Start()
    {
        posx -= TANAH_WIDTH;

        // Komponen
        playerPos = player.GetComponent<Transform>();
        locParent = gameObject.GetComponent<Transform>();
        locTanah = objekTanah.GetComponent<Transform>();

        // Pemunculan pada awal game (Start)
        for (int i = 0; i < 4; i++)
        {
            Vector3 posisi = new Vector3(posx, locTanah.position.y, locTanah.position.z);
            MembuatTanah(posisi, objekTanah, locParent, i);
            posx += TANAH_WIDTH;

            // Debug.Log("Memunculkan " + i.ToString());
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        // pemunculan tanah ketika posisi player lebih dari jarak
        if (playerPos.position.x >= jarak && playerController.isPlaying)
        {
            Vector3 posisi = new Vector3(posx, locTanah.position.y, locTanah.position.z);
            MembuatTanah(posisi, objekTanah, locParent, count);
            posx += TANAH_WIDTH;
            jarak += TANAH_WIDTH;
            count++;

            // Debug.Log("Memunculkan " + count.ToString());
            // Debug.Log("Jarak: " + jarak.ToString());
        }
    }

    // function untuk pemanggilan tanah
    private void MembuatTanah(Vector3 pos, GameObject obj, Transform objParent, int c)
    {
        var tanahBaru = Instantiate(obj, pos, Quaternion.identity);

        tanahBaru.name = obj.name + " " + c.ToString();
        tanahBaru.transform.parent = objParent.parent;
    }
}
