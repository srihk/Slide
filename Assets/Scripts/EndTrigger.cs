using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public GameManager gameManager;

    public void OnTriggerEnter()
    {
        playerMovement.endTrigger = true;
    }
}