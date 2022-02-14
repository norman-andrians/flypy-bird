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

    // Start is called before the first frame update
    void Start()
    {
        playerController = player.GetComponent<PlayerController>();
        playerRb = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (player.transform.position.x >= layerParentOffset.x && !playerController.isPaused)
        {
            for (int a = 0; a < layerParent.Length; a++)
            {
                layerParent[a].transform.position = new Vector3(player.transform.position.x, layerParentOffset.y, layerParent[a].transform.position.z);
            }
            for (int c = 0; c < scrollBg.Length; c++)
            {
                if (playerRb.velocity.x > 0)
                    scrollBg[c].spriteObject.transform.position += Vector3.left * Time.deltaTime * scrollBg[c].speed;
                else scrollBg[c].spriteObject.transform.position += Vector3.right * Time.deltaTime * scrollBg[c].speed;
            }
        }
    }
}
