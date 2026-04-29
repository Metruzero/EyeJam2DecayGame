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
        TimeManager.OnPhaseChanged += PhaseSpecificDialogue;
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

    private void PhaseSpecificDialogue(int phase)
    {
        if (TimeManager.Instance.currentLoop == 1)
        {
            switch (phase)
            {
                case 0:
                    ShowDialogue("Where... ship... self destruct? What?!");
                    break;
                case 1:
                    ShowDialogue("What's happening to me?!");
                    break;
                case 2:
                    ShowDialogue("No no no... I can barely move, what happened to my legs? Someone HELP ME!");
                    break;

            }
        }
        if (TimeManager.Instance.currentLoop == 2)
        {
            switch (phase)
            {
                case 0:
                    ShowDialogue("Wha- I'm back?");
                    break;
                case 1:
                    ShowDialogue("No no, not again.");
                    break;
                case 2:
                    ShowDialogue("I feel so gross.");
                    break;

            }
        }

        if (TimeManager.Instance.currentLoop > 2)
        {
            if (phase == 0)
                ShowDialogue("Go again I suppose.");
        }
    }
}