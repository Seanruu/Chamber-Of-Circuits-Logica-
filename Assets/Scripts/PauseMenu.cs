using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isPaused;

    // OPTIONAL: assign your player/controller if needed
    public MonoBehaviour playerController;

    void Start()
    {
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;

        // 🔑 IMPORTANT FIX
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // OPTIONAL (for FPS games)
        if (playerController != null)
            playerController.enabled = false;

        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;

        // 🔑 IMPORTANT FIX
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // OPTIONAL
        if (playerController != null)
            playerController.enabled = true;

        isPaused = false;
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}