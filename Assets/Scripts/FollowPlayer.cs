using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    Transform player;
    public Vector3 offset;

    void Start()
    {
        player = GameObject.Find("player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + offset;
    }
}
