using UnityEngine;
using System.Collections;
using TMPro;
using System;

public class LoopResetManager : MonoBehaviour
{
    public static LoopResetManager Instance;

    public CanvasGroup overlayGroup;
    public TextMeshProUGUI statusText;

    public AudioSource audioSource;
    public AudioClip explosionClip;

    public static event Action OnLoopReset;

    private void Awake() => Instance = this;

    public void StartResetSequence()
    {
        StartCoroutine(ResetSequenceRoutine());
    }

    private IEnumerator ResetSequenceRoutine()
    {
        if (TimeManager.Instance.currentLoop > 0)
        {
            audioSource.PlayOneShot(explosionClip, 0.2f);

            float timer = 0;
            float fadeDuration = 0.5f;
            while (timer < fadeDuration)
            {
                timer += Time.deltaTime;
                overlayGroup.alpha = timer / fadeDuration;
                yield return null;
            }

            yield return new WaitForSeconds(1.5f);

            RoomManager.Instance.SnapToStartingRoom();
            InventorySelectionManager.Instance.ClearHeldItem();
            OnLoopReset?.Invoke();

            timer = 0;
            while (timer < fadeDuration)
            {
                timer += Time.deltaTime;
                overlayGroup.alpha = 1 - (timer / fadeDuration);
                yield return null;
            }


            statusText.text = "";

        }
        TimeManager.Instance.StartTimer();

    }
}