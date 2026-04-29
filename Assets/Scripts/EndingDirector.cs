using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class EndingDirector : MonoBehaviour
{
    public Image backgroundImage;
    public TextMeshProUGUI dialogueText;
    public RectTransform textContainer;
    public CanvasGroup endingPanelGroup;

    public List<EndingSlide> endingSlides;
    public float typeSpeed = 0.04f;

    public void Start()
    {
        PlayEnding();
    }

    public void PlayEnding()
    {
        StartCoroutine(EndingSequenceRoutine());
    }

    private IEnumerator EndingSequenceRoutine()
    {
        endingPanelGroup.alpha = 1;

        foreach (var slide in endingSlides)
        {
            if (backgroundImage.sprite != slide.backgroundSprite)
            {
                backgroundImage.sprite = slide.backgroundSprite;
            }

            if (slide.backgroundSprite == null)
            {
                backgroundImage.sprite = null;
            }

            textContainer.anchoredPosition = slide.textAnchoredPosition;

            dialogueText.text = "";

            if (slide.fontAsset != null)
            {
                dialogueText.font = slide.fontAsset;
            }

            foreach (char letter in slide.paragraphText.ToCharArray())
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(typeSpeed);
            }

            yield return new WaitForSeconds(slide.delayAfterFinished);
        }

        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}