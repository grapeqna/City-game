using UnityEngine;

public class ExitGame : MonoBehaviour
{
    // Function to exit the game
    public void QuitGame()
    {
        Debug.Log("Game is exiting...");

        // Exit the game
        Application.Quit();

        // This will only work in a built application, not in the Unity Editor.
        // To stop play mode in the Editor, uncomment the line below.
        //UnityEditor.EditorApplication.isPlaying = false;
    }
}
