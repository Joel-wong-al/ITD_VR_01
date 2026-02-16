using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{
    public TutorialManager manager;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider is the VR Player (usually tagged 'Player')
        if (other.CompareTag("Player"))
        {
            manager.OnTriggerZoneCleared();
            this.gameObject.SetActive(false); // Disable after use [cite: 13]
        }
    }
}