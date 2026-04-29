using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeypadController : MonoBehaviour
{
    public string id;

    public string correctCode = "9461";
    public TextMeshPro displayMesh;
    public float timeBeforeClear;

    public List<GameAction> onSuccessActions;
    public List<GameAction> onFailActions;

    private int codeLength;

    private string currentInput = "";

    private void Awake()
    {
        codeLength = correctCode.Length;
    }

    public void AddNumber(string number)
    {
        Debug.Log(number);
        if (currentInput.Length < codeLength)
        {
            currentInput += number;
            UpdateDisplay();
        }
        if (currentInput.Length == codeLength)
        {
            Submit();
        }
    }

    public void Clear()
    {
        currentInput = "";
        UpdateDisplay();
    }

    private IEnumerator WaitBeforeClear()
    {
        displayMesh.color = Color.red;
        yield return new WaitForSeconds(timeBeforeClear);
        Clear();
        displayMesh.color = Color.red;
    }

    public void Submit()
    {
        if (currentInput == correctCode)
        {
            ExecuteActions(onSuccessActions);
            Clear();
        }
        else
        {
            ExecuteActions(onFailActions);
            StartCoroutine(WaitBeforeClear());
            
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

    private void UpdateDisplay() => displayMesh.text = currentInput;
}
