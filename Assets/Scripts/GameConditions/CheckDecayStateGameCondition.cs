using UnityEngine;

[CreateAssetMenu(fileName = "CheckDecayStateGameCondition", menuName = "GameConditions/CheckDecayStateGameCondition")]
public class CheckDecayStateGameCondition : GameCondition
{
    public bool phase0, phase1, phase2;

    public override bool Check(InteractionContext context)
    {
        int phase = TimeManager.Instance.GetCurrentPhase();
        if (phase0 && phase == 0)
        {
            return true;
        }
        if (phase1 && phase == 1)
        {
            return true;
        }
        if (phase2 && phase == 2)
        {
            return true;
        }
        return false;
    }
}
