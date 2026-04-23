using UnityEngine;

[CreateAssetMenu(fileName = "BoolVariable", menuName = "Scriptable Objects/BoolVariable")]
public class BoolVariable : ScriptableObject
{
    public bool initial;

    public bool value;

    public void Reset()
    {
        value = initial;
    }
}
