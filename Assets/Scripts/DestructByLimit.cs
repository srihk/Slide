using UnityEngine;
using System.Collections;

public class DestructByLimit : MonoBehaviour {
	public float limit = -1f;
	void FixedUpdate () {
		if (GetComponent<Rigidbody>().position.y < limit)
			Destroy(gameObject);
	}
}
