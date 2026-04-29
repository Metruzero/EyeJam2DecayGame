using System;
using UnityEngine;
using System.Collections;

public enum DecayState
{
    Healthy,
    Weak,
    Monstrous
}

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance;

    public int totalPhases;

    public float timePerPhase;

    public bool runTimer = true;

    public float elapsedLoopTime = 0;
    private int currentPhase = 0;
    public int currentLoop = 0;

    public static event Action<int> OnPhaseChanged;
    public static event Action OnLoopStart;

    private void Awake() => Instance = this;
    void Start() => ResetLoop();

    void Update()
    {
        if (runTimer)
        {
            elapsedLoopTime += Time.deltaTime;
        }


        int calculatedPhase = Mathf.FloorToInt(elapsedLoopTime / timePerPhase);

        if (calculatedPhase != currentPhase)
        {
            if (calculatedPhase < totalPhases)
            {
                Debug.Log(name);
                currentPhase = calculatedPhase;
                OnPhaseChanged?.Invoke(currentPhase);
            }
            else
            {
                ResetLoop();
            }
        }
    }

    public void ResetLoop()
    {
        runTimer = false;
        LoopResetManager.Instance.StartResetSequence();

        ResetAllInteractables();
        currentLoop++;
        currentPhase = 0;
        elapsedLoopTime = 0;
        StartCoroutine(DelayPhaseReset(1f));
    }

    public void StartTimer()
    {
        runTimer = true;
        OnLoopStart?.Invoke();
    }

    public int GetCurrentPhase() => currentPhase;

    private void ResetAllInteractables()
    {
        foreach (var interactable in Interactable.AllInteractables)
        {
            interactable.ResetToStartingState();
        }
    }

    private IEnumerator DelayPhaseReset(float delay)
    {
        yield return new WaitForSeconds(delay);
        OnPhaseChanged?.Invoke(currentPhase);
    }
}

