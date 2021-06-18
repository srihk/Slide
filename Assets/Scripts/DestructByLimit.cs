using UnityEngine;
using System.Collections;

public class DestructByLimit : MonoBehaviour
{
    float limit = -1f;
    public bool isPillar = false;
    GameManager gameManager;

    void Start()
    {
        if (isPillar)
        {
            limit = -20f;
        }
        gameManager = FindObjectOfType<GameManager>();
    }

    void FixedUpdate()
    {
        if (isPillar)
            transform.position += new Vector3(0f, -2.5f * Time.fixedDeltaTime, 0f);
        if (GetComponent<Rigidbody>().position.y < limit)
            Destroy(gameObject);
    }

    void Update()
    {
        if (!isPillar)
        {
            if (PauseMenu.isGamePaused())
            {
                if (gameObject.GetComponent<AudioSource>().isPlaying)
                {
                    gameObject.GetComponent<AudioSource>().Pause();
                }
            }
            else
            {
                if (!gameObject.GetComponent<AudioSource>().isPlaying)
                {
                    gameObject.GetComponent<AudioSource>().UnPause();
                }
            }
            
            if (gameManager.gameEnded())
            {
                gameObject.GetComponent<AudioSource>().Stop();
            }
        }
    }
}
