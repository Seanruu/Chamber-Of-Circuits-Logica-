using UnityEngine;

public class HelpButton : MonoBehaviour
{
    public GameObject helpButton;
    public bool isOpen;

    void Start()
    {
        helpButton.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (isOpen)
                CloseHelp();
            else
                OpenHelp();
        }
    }

    public void OpenHelp()
    {
        helpButton.SetActive(true);

        // Show cursor so player can interact
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        isOpen = true;
    }

    public void CloseHelp()
    {
        helpButton.SetActive(false);

        // Hide cursor again (for FPS style games)
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        isOpen = false;
    }
}