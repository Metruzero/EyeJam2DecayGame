using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class RoomManager : MonoBehaviour
{
    public static RoomManager Instance;

    public List<GameView> allViews;
    private GameView currentView;

    private void Awake() => Instance = this;

    private void Start()
    {
        currentView = allViews[0];
        TimeManager.OnPhaseChanged += UpdateRoomsForPhase;
        LoopResetManager.OnLoopReset += ResetRoomsForLoop;
    }

    public void SetView(string id)
    {
        foreach (var view in allViews)
        {
            if (view.viewID == id)
            {
                if (currentView != null) currentView.Hide();

                currentView = view;
                currentView.Show();
                return;
            }
        }
    }

    public void SnapToStartingRoom()
    {
        currentView.Hide();
        currentView = allViews[0];
        currentView.Show();
    }

    private void UpdateRoomsForPhase(int phase)
    {
        foreach (GameView view in allViews)
        {
            view.SetPhaseImage(phase);
        }
    }

    private void ResetRoomsForLoop()
    {
        foreach (GameView view in allViews)
        {
            view.ResetForLoop();
        }
        SnapToStartingRoom();
    }

    public void HideAllRooms()
    {
        currentView.Hide();
    }
}
