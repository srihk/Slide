using UnityEngine;

public class groundfollow : MonoBehaviour
{

	public GameObject player;
	public GameObject ground;
	public float offset;
	public Vector3 zrev;

    // Update is called once per frame
    void FixedUpdate()
    {
		zrev.z = player.transform.position.z + offset;
		ground.transform.position = zrev;
    }
}
