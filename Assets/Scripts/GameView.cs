using UnityEngine;

public class GameView : MonoBehaviour
{
    public string viewID;

    public Sprite Phase0, Phase1, Phase2;

    public SpriteRenderer background;

    public void SetPhaseImage(int phase)
    {
        if (phase == 0 && Phase0 != null)
        {
            background.sprite = Phase0;
        }
        else if (phase == 1 && Phase1 != null)
        {
            background.sprite = Phase1;
        }
        else if (phase == 2 && Phase2 != null)
        {
            background.sprite = Phase2;
        }
    }

    public void ResetForLoop()
    {
        SetPhaseImage(0);
    }

    public void Show() => gameObject.SetActive(true);
    public void Hide() => gameObject.SetActive(false);
}
