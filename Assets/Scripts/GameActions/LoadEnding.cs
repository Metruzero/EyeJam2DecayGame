using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "LoadEnding", menuName = "GameActions/LoadEnding")]
public class LoadEnding : GameAction
{
    public override void Execute(InteractionContext context)
    {
        SceneManager.LoadSceneAsync("EndingScene");
    }
}
