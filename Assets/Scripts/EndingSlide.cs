using UnityEngine;

[System.Serializable]
public class EndingSlide
{
    [TextArea(3, 10)]
    public string paragraphText;
    public TMPro.TMP_FontAsset fontAsset;
    public Sprite backgroundSprite;
    public Vector2 textAnchoredPosition;
    public float delayAfterFinished = 2.0f;
}