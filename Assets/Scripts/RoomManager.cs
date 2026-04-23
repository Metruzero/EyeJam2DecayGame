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
    }

    public void SetView(string id)
    {

        Debug.Log(id);
        foreach (var view in allViews)
        {
            if (view.viewID == id)
            {
                Debug.Log("FoundID");
                if (currentView != null) currentView.Hide();

                currentView = view;
                currentView.Show();
                return;
            }
        }
        Debug.LogError($"View ID {id} not found;");
    }
}
