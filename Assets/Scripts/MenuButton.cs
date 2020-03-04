using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{

    Button b;

    // Start is called before the first frame update
    void Start()
    {
        b = gameObject.GetComponent<Button>();
        b.onClick.AddListener(this.openMenu);
    }

    void openMenu()
    {
        Debug.Log("Menu Button Pressed!!!");
        SceneManager.LoadScene(0);
    }
}
