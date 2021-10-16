using System.Collections;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [System.Serializable]
    public class ScrollBackground
    {
        public GameObject spriteObject;
        public Vector3 startPos, endpos;
        public float speed;
    }

    public Vector2 layerParentOffset;
    public GameObject player;
    public GameObject[] layerParent;
    public ScrollBackground[] scrollBg;

    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player.transform.position.x >= layerParentOffset.x && !playerController.isDead)
        {
            for (int a = 0; a < layerParent.Length; a++)
            {
                layerParent[a].transform.position = new Vector3(player.transform.position.x, layerParentOffset.y, layerParent[a].transform.position.z);
            }
            for (int c = 0; c < scrollBg.Length; c++)
            {
                if (scrollBg[c].spriteObject.transform.position.x > scrollBg[c].endpos.x)
                    scrollBg[c].spriteObject.transform.position += Vector3.left * scrollBg[c].speed * Time.deltaTime;
                else scrollBg[c].spriteObject.transform.position = scrollBg[c].startPos;
            }
        }
    }
}
