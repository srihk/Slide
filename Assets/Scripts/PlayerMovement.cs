using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	Rigidbody rb;
	public bool endTrigger;
	float forwardForce = 2000f;
	float sidewardForce = 100f;
	// Use this for initialization
	void Start () {
		rb = GameObject.Find("player").GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		rb.AddForce (0, 0, forwardForce * Time.deltaTime);
		if (!PauseMenu.isGamePaused())
		{
			if (Input.GetKey("d") || (Input.touchCount > 0 && Input.GetTouch(0).position.x > Screen.width*2 / 3))
			{
				rb.AddForce(sidewardForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
			}
			if (Input.GetKey("a") || (Input.touchCount > 0 && Input.GetTouch(0).position.x < Screen.width / 3))
			{
				rb.AddForce(-sidewardForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
			}
		}
		if(rb.position.y < -1f && endTrigger == false)
		{
			FindObjectOfType<GameManager>().EndGame();
		}
	}
}
