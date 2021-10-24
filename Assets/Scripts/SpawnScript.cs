using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour
{

    public GameObject spawnObj;
    public float spawnMin = 1f;
    public float spawnMax = 2f;
    GameObject player;
    public Vector3 spawnPoint;
    public float offset;
    public Quaternion rotation;
    public float x_offset = 1f;
    public float initialAudioOffset = 1f;
    private float audioOffset = 2f;
    AudioSource audioSource;
    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("player");
        StartCoroutine("Spawn");
        StartCoroutine("PlayAudio");
    }

    IEnumerator FadeAudio(float duration = 1.54f)
    {
        float currentTime = 0.0f;
        float start = audioSource.volume;
        
        while (audioSource.volume > 0 && currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume -= start / duration * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        yield break;
    }

    IEnumerator PlayAudio()
    {
        audioSource = this.GetComponent<AudioSource>();


        if (audioSource != null)
        {
            yield return new WaitForSeconds(initialAudioOffset);

            while (true)
            {
                audioSource.volume = 0.7f;
                audioSource.Play();
                StartCoroutine(FadeAudio());
                yield return new WaitForSeconds(Random.Range(spawnMin + audioOffset, spawnMax + audioOffset));
            }
        }

        yield break;
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            spawnPoint.z = player.transform.position.z + offset;
            spawnPoint.x += x_offset;
            x_offset = -x_offset;
            Instantiate(spawnObj, spawnPoint, rotation);
            yield return new WaitForSeconds(Random.Range(spawnMin, spawnMax));
        }
    }
}
