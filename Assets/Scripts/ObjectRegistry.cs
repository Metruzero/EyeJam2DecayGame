using System.Collections.Generic;
using UnityEngine;

public class ObjectRegistry : MonoBehaviour
{
    public static ObjectRegistry Instance;
    private Dictionary<string, GameObject> registry = new Dictionary<string, GameObject>();

    private void Awake() => Instance = this;

    public void Register(string id, GameObject obj)
    {
        if (registry.ContainsKey(id))
        {
            registry[id] = obj;
        }
        else
        {
            registry.Add(id, obj);
        }
    }

    public void SetObjectState(string id, bool isActive)
    {
        if (registry.ContainsKey(id))
        {
            registry[id].GetComponent<SpriteRenderer>().enabled = isActive;
            registry[id].GetComponent<Collider2D>().enabled = isActive;
        }
    }

    public GameObject GetObject(string id)
    {
        if (registry.ContainsKey(id)) return registry[id];
        return null;
    }
}
