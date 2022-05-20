using System.Collections;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [System.Serializable]
    public class ScrollBackground
    {
        public GameObject spriteObject;
        public float speed;
    }

    public Vector2 layerParentOffset;
    public GameObject player;
    public GameObject[] layerParent;
    public ScrollBackground[] scrollBg;

    private PlayerController playerController;
    private Rigidbody2D playerRb;

    private float playerSpeed;

    // Start is called before the first frame update
    void Start()
    {
        playerController = player.GetComponent<PlayerController>();
        playerRb = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        playerSpeed = playerRb.velocity.x;
        if (player.transform.position.x >= layerParentOffset.x && !playerController.isPaused)
        {
            for (int a = 0; a < layerParent.Length; a++)
            {
                layerParent[a].transform.position = new Vector3(player.transform.position.x, layerParentOffset.y, layerParent[a].transform.position.z);
            }
            for (int c = 0; c < scrollBg.Length; c++)
            {
                if (player.transform.position.x >= -3f)
                    scrollBg[c].spriteObject.transform.position += Vector3.left * Time.deltaTime * (playerSpeed/2.5f);
                else
                    scrollBg[c].spriteObject.transform.position += Vector3.left * Time.deltaTime * (playerSpeed/3);
            }
        }
    }
}
