using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    Transform player;
    Text score;
    // Update is called once per frame
    void Start()
    {
        player = GameObject.Find("player").GetComponent<Transform>();
        score = gameObject.GetComponent<Text>();
        score.text = "0";
    }
    void Update()
    {
        score.text = "SCORE: " + player.position.z.ToString("0");
    }
}
