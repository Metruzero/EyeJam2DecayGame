using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    [Header("UI References")]
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public Button closeButton;

    private void Awake()
    {
        Instance = this;

        dialoguePanel.SetActive(false);
    }

    public void ShowDialogue(string text)
    {
        dialoguePanel.SetActive(true);
        dialogueText.text = text;
    }

    public void CloseDialogue()
    {
        dialoguePanel.SetActive(false);
    }
}