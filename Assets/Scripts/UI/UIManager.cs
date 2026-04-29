using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject humanSprite, weakenedSprite, mutatedSprite;

    private void Start()
    {
        TimeManager.OnPhaseChanged += HandleTransformation;
        LoopResetManager.OnLoopReset += HandleTransformOnLoopReset;
    }

    private void HandleTransformOnLoopReset()
    {
        HandleTransformation(0);
    }

    void HandleTransformation(int phase)
    {
        humanSprite.SetActive(phase == 0);
        weakenedSprite.SetActive(phase == 1);
        mutatedSprite.SetActive(phase >= 2);
    }
}
