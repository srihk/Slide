using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    public bool endTrigger;
    float forwardForce = 2000f;
    float sidewardForce = 100f;
    static float sensitivity = 0.6f;
    float speedup_factor = 0.0002f;
    // Use this for initialization
    void Start()
    {
        rb = GameObject.Find("player").GetComponent<Rigidbody>();
        setSensitivity(PlayerPrefs.GetFloat("Sensitivity", 0.6f));
        // Set initial time scale to 0.8
        Time.timeScale = 0.8f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.isGamePaused() && Time.timeScale < 2)
            Time.timeScale += speedup_factor * Time.deltaTime;
        Debug.Log("TimeScale: " + Time.timeScale);
    }

    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        if (!PauseMenu.isGamePaused())
        {
            if (Input.GetKey("d") || (Input.touchCount > 0 && Input.GetTouch(0).position.x > Screen.width * 2 / 3))
            {
                rb.AddForce(sidewardForce * sensitivity * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }
            if (Input.GetKey("a") || (Input.touchCount > 0 && Input.GetTouch(0).position.x < Screen.width / 3))
            {
                rb.AddForce(-sidewardForce * sensitivity * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }
        }
        if (rb.position.y < -1f && endTrigger == false)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    public static float getSensitivity()
    {
        return sensitivity;
    }

    public static void setSensitivity(float newSensitivity)
    {
        sensitivity = newSensitivity;
    }
}
