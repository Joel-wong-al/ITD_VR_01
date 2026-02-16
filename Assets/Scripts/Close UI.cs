using UnityEngine;

public class CloseUI : MonoBehaviour
{
    public GameObject congratsCanvas;

    public void DismissMessage()
    {
        if (congratsCanvas != null)
        {
            congratsCanvas.SetActive(false);
            Debug.Log("Tutorial UI Dismissed.");
        }
    }
}