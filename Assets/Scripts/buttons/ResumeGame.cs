using UnityEngine;

public class ResumeGame : MonoBehaviour
{
    [SerializeField] public GameObject pauseCanvas;

    public void Resume()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseCanvas.SetActive(false);
    }
}
