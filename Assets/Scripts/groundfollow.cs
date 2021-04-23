using UnityEngine;

public class groundfollow : MonoBehaviour
{

    GameObject player;
    public float offset;
    public Vector3 zrev;

    void Start()
    {
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        zrev.z = player.transform.position.z + offset;
        transform.position = zrev;
    }
}
