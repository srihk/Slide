using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

	public GameObject spawnObj;
	public float spawnMin = 1f;
	public float spawnMax = 2f;
	/*public float x_offset1 = -1f;
	public float x_offset2 = 1f;*/
	GameObject player;
	public Vector3 spawnPoint;
	public float offset;
	public Quaternion rotation;
	// Use this for initialization
	void Start () {
		player = GameObject.Find("player");
		Spawn();	
	}

    void Spawn()
	{
		spawnPoint.z = player.transform.position.z + offset;
		/*rotation.x = Random.Range(x_offset1, x_offset2);
		rotation.y = Random.Range(x_offset1, x_offset2);
		rotation.z = Random.Range(x_offset1, x_offset2);
		rotation.w = Random.Range(x_offset1, x_offset2);*/
		Instantiate(spawnObj, spawnPoint, rotation);
		Invoke("Spawn", Random.Range(spawnMin, spawnMax));
	}
}
