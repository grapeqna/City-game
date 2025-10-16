using UnityEngine;

public class TriggerPause : MonoBehaviour
{
    [SerializeField] public GameObject pauseCanvas;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Setup();
        }
    }
    public void Setup()
    {

        Time.timeScale = 0;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        pauseCanvas.SetActive(true);

    }

}
