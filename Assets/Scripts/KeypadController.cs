using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeypadController : MonoBehaviour
{
    [Header("RegistryID")]
    public string id;

    [Header("Settings")]
    public string correctCode = "1234";
    public TextMeshPro displayMesh;

    [Header("Success/Fail Actions")]
    public List<GameAction> onSuccessActions;
    public List<GameAction> onFailActions;

    private string _currentInput = "";

    private void Awake()
    {
        
    }

    public void AddNumber(string number)
    {
        Debug.Log(number);
        if (_currentInput.Length < 4)
        {
            _currentInput += number;
            UpdateDisplay();
        }
    }

    public void Clear()
    {
        _currentInput = "";
        UpdateDisplay();
    }

    public void Submit()
    {
        if (_currentInput == correctCode)
        {
            Debug.Log("Access Granted");
            ExecuteActions(onSuccessActions);
        }
        else
        {
            Debug.Log("Access Denied");
            ExecuteActions(onFailActions);
            Clear();
        }
    }

    private void ExecuteActions(List<GameAction> actions)
    {
        InteractionContext context = new InteractionContext
        {
            Target = this.gameObject,
        };

        foreach (var action in actions) action.Execute(context);
    }

    private void UpdateDisplay() => displayMesh.text = _currentInput;
}
