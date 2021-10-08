using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public Vector2 offset;
    private Transform playerPos;

    // Start is called before the first frame update
    void Start()
    {
        playerPos = player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(playerPos.position.x + offset.x, transform.position.y + offset.y, playerPos.position.z);
    }
}
