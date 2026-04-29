using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public GameObject buttonPanel, creditPanel;

    private void Start()
    {
        buttonPanel.SetActive(true);
        creditPanel.SetActive(false);
    }

    public void OpenCredits()
    {
        buttonPanel.SetActive(false);
        creditPanel.SetActive(true);
    }

    public void CloseCredits()
    {
        buttonPanel.SetActive(true);
        creditPanel.SetActive(false);
    }
}
