using UnityEngine;

[CreateAssetMenu(fileName = "PlaySoundGameAction", menuName = "GameActions/PlaySoundGameAction")]
public class PlaySoundGameAction : GameAction
{
    public AudioClip clip;
    [Range(0f, 1f)] public float volume;

    public override void Execute(InteractionContext context)
    {
        if (clip == null) return;

        AudioSource source = context.Target.GetComponent<AudioSource>();

        if (source == null)
        {
            source = context.Interactor.GetComponent<AudioSource>();
        }

        if (source != null)
        {
            source.PlayOneShot(clip, volume);
        }
        else
        {
            Debug.LogWarning("No AudioSource Found");
        }
    }
}
