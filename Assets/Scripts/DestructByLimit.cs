using UnityEngine;
using System.Collections;

public class DestructByLimit : MonoBehaviour {
	public Rigidbody rb;
	void FixedUpdate () {
		if (rb.position.y < -1f)
			Destroy(rb.gameObject);
	}
}
