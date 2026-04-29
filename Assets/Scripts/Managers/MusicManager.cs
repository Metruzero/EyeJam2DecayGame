using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource bgmSource;

    private void Start() => TimeManager.OnLoopStart += RestartMusic;

    private void RestartMusic()
    {
        if (bgmSource != null)
        {
            bgmSource.Stop();
            bgmSource.Play();
        }
    }
}