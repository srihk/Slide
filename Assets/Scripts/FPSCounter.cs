using UnityEngine.UI;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    // Start is called before the first frame update

    private Text fpstext;
    private float HUDRefreshRate = 1f;
    private float timer;

    void Start()
    {
        fpstext = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.unscaledTime > timer)
        {
            int fps = (int)(1f / Time.unscaledDeltaTime);
            fpstext.text = "FPS: " + fps;
            timer = Time.unscaledTime + HUDRefreshRate;
        }
    }
}
