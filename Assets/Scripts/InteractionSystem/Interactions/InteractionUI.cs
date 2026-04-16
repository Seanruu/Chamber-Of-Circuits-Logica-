using UnityEngine;

public class InteractionUI : MonoBehaviour
{
    public GameObject interactText;

    public static InteractionUI instance;

    void Awake()
    {
        instance = this;
    }

    public void Show()
    {
        interactText.SetActive(true);
    }

    public void Hide()
    {
        interactText.SetActive(false);
    }
}