using UnityEngine;
using UnityEngine.Events;

public class TutorialManager : MonoBehaviour
{
    [Header("Sequence Settings")]
    public GameObject[] triggerZones;      // 3 Trigger zones
    public GameObject[] teleportAreas;     // 2 teleport areas
    public GameObject spatialUIMessage;    // Congrats message after all tasks

    private int currentTriggerIndex = 0; // Track which trigger zone is active
    private int currentTeleportIndex = 0; // Track which teleport area is active

    void Start()
    {

        SetAllInactive(triggerZones);
        SetAllInactive(teleportAreas);
        spatialUIMessage.SetActive(false);

        if (triggerZones.Length > 0)
        {
            triggerZones[0].SetActive(true);
        }
    }

    public void OnTriggerZoneCleared()
    {
        currentTriggerIndex++;
        if (currentTriggerIndex < triggerZones.Length)
        {
            triggerZones[currentTriggerIndex].SetActive(true);
        }
        else
        {
            EnableFirstTeleport();
        }
    }

    void EnableFirstTeleport()
    {
        if (teleportAreas.Length > 0)
            teleportAreas[0].SetActive(true);
    }

    public void OnTeleportCleared()
    {
        currentTeleportIndex++;
        if (currentTeleportIndex < teleportAreas.Length)
        {
            teleportAreas[currentTeleportIndex].SetActive(true);
        }
        else
        {
            spatialUIMessage.SetActive(true);
        }
    }

    void SetAllInactive(GameObject[] objects)
    {
        foreach (GameObject obj in objects) obj.SetActive(false);
    }
}