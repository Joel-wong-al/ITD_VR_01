using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LoginManager : MonoBehaviour
{
    [Header("References")]
    public TMP_InputField passwordInput;
    public TextMeshProUGUI feedbackText;

    [Header("Settings")]
    public string correctPassword = "mypassword";
    public string successSceneName = "MainScene";

    void Start()
    {
        if (feedbackText != null)
            feedbackText.text = "";
    }

    /// <summary>
    /// Call this from your login button's poke event (XRPokeInteractable → Select Entered)
    /// </summary>
    public void OnLoginButtonPressed()
    {
        ValidatePassword();
    }

    /// <summary>
    /// Alternative function for direct attachment to button GameObject
    /// Wire this to XRPokeInteractable's Select Entered event
    /// </summary>
    public void OnButtonPoked()
    {
        Debug.Log("🎯 BUTTON POKED!"); // Add this line
        ValidatePassword();
    }

    void ValidatePassword()
    {
        // Validate inputs
        if (passwordInput == null)
        {
            ShowFeedback("ERROR: Password input not assigned!", Color.red);
            Debug.LogWarning("LoginManager: passwordInput not assigned");
            return;
        }

        if (feedbackText == null)
        {
            Debug.LogWarning("LoginManager: feedbackText not assigned");
            return;
        }

        // Get entered password
        string entered = passwordInput.text == null ? string.Empty : passwordInput.text.Trim();

        // Check if empty
        if (string.IsNullOrEmpty(entered))
        {
            ShowFeedback("Please enter a password", Color.yellow);
            return;
        }

        // Validate password
        if (entered == correctPassword)
        {
            ShowFeedback("Login successful! Loading...", Color.green);
            Debug.Log("✓ Login successful");

            // Load the success scene after a short delay
            Invoke(nameof(LoadSuccessScene), 1f);
        }
        else
        {
            ShowFeedback("Incorrect password. Try again.", Color.red);
            Debug.Log("✗ Login failed");
        }
    }

    void ShowFeedback(string message, Color color)
    {
        // Display message and keep it visible
        feedbackText.text = message;
        feedbackText.color = color;
    }

    void LoadSuccessScene()
    {
        if (string.IsNullOrEmpty(successSceneName))
        {
            Debug.LogError("LoginManager: successSceneName is not set!");
            return;
        }

        Debug.Log($"Loading scene: {successSceneName}");
        SceneManager.LoadScene(successSceneName);
    }
}
