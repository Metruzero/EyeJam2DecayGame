using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class IntroDirector : MonoBehaviour
{
    public GameObject introPanel;
    public TextMeshProUGUI introText;
    public string gameSceneName = "GameScene";

    public float typeSpeed = 0.05f;
    [TextArea(10, 20)]
    public string fullStoryText;

    private bool isSkipped = false;
    private bool isFinished = false;
    private bool isPlaying = false;

    public void StartIntro()
    {
        if (isPlaying) return;
        isPlaying = true;
        introPanel.SetActive(true);
        StartCoroutine(PlayCrawl());
    }

    private IEnumerator PlayCrawl()
    {
        introText.text = "";

        foreach (char letter in fullStoryText.ToCharArray())
        {
            if (isSkipped) break;

            introText.text += letter;
            yield return new WaitForSeconds(typeSpeed);
        }

        introText.text = fullStoryText;
        isFinished = true;

        yield return new WaitForSeconds(2.0f);

        LoadGame();
    }

    public void SkipIntro()
    {
        if (!isFinished)
        {
            isSkipped = true;
        }
        else
        {
            LoadGame();
        }
    }

    private void LoadGame()
    {
        isPlaying = false;
        SceneManager.LoadScene(gameSceneName);
    }
}