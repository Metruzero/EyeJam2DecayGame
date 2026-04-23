using UnityEngine;

public class GameView : MonoBehaviour
{
    public string viewID;

    public SpriteRenderer background;

    public void Show() => gameObject.SetActive(true);
    public void Hide() => gameObject.SetActive(false);
}
