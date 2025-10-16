using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public string scene;

    // Function to be called when the button is clicked
    public void RestartScene()
    {
        if (!string.IsNullOrEmpty(scene))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(scene);
        }
        else
        {
            Debug.LogError("Scene name is not set!");
        }
    }
}
