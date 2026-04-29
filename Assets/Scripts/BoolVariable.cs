using UnityEngine;

[CreateAssetMenu(fileName = "BoolVariable", menuName = "Scriptable Objects/BoolVariable")]
[System.Serializable]
public class BoolVariable : ScriptableObject
{
    public bool initial;

    public bool value;

    public void OnEnable()
    {
        value = initial;
    }

    public void Reset()
    {
        value = initial;
    }
}
