using UnityEngine;
using System.Collections.Generic;

public class FlagManager : MonoBehaviour
{
    public List<BoolVariable> variables = new List<BoolVariable>();

    void Start()
    {
        LoopResetManager.OnLoopReset += ResetFlags;
    }

    private void ResetFlags()
    {
        foreach (var variable in variables)
        {
            variable.Reset();
        }
    }
}
