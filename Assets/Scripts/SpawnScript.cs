using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

	public GameObject spawnObj;
	public float spawnMin = 1f;
	public float spawnMax = 2f;
	public GameObject player;
	public Vector3 spawnPoint;
	public float offset;
	public Quaternion rotation;
	// Use this for initialization
	void Start () {
		Spawn();
	}

    void Spawn()
	{
		spawnPoint.z = player.transform.position.z + offset;
		Instantiate(spawnObj, spawnPoint, rotation);
		Invoke("Spawn", Random.Range(spawnMin, spawnMax));
	}
}
