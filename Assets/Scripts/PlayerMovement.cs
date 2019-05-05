using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public Rigidbody rb;
	public bool endTrigger;
	public float forwardForce = 2000f;
	public float sidewardForce = 500f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		rb.AddForce (0, 0, forwardForce * Time.deltaTime);
		if (Input.GetKey ("d") || ( Input.touchCount > 0 && Input.GetTouch(0).position.x > Screen.width / 2)) {
			rb.AddForce (sidewardForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
		}
		if (Input.GetKey ("a") || ( Input.touchCount > 0 && Input.GetTouch(0).position.x < Screen.width / 2)) {
			rb.AddForce (-sidewardForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
		}
		if(rb.position.y < -1f && endTrigger == false)
		{
			FindObjectOfType<GameManager>().EndGame();
		}
	}
}
