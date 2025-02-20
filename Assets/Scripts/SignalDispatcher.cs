using System;
using System.Collections.Generic;
using UnityEngine;

public enum EventID
{
    None = 0,
    OnEnemyDeath,
    OnEnemySpawn,
    OnHelicopterDead,
    OnHelicopterEscaped,
}

public class SignalDispatcher
{
    private Dictionary<EventID, List<Action<object>>> dicEvents = new();

    // Register to listen for eventID, callback will be invoke when event with eventID be raise
    public void RegisterListener(EventID eventID, Action<object> callback)
    {
        if (!dicEvents.ContainsKey(eventID))
        {
            dicEvents.Add(eventID, new());
        }
        dicEvents[eventID].Add(callback);
    }

    // Post event, this will notify all listener which register to listen for eventID
    public void PostEvent(EventID eventID, object param = null)
    {
        foreach (Action<object> action in dicEvents[eventID])
        {
            action?.Invoke(param);
        }
    }

    // Use for Unregister, not listen for an event anymore.
    public void RemoveListener(EventID eventID, Action<object> callback)
    {
        dicEvents[eventID].Remove(callback);
    }
}

/// An Extension class, declare some "shortcut" for using EventDispatcher
public static class SignalDispatcherExtension
{
    private static SignalDispatcher _instance = new();

    /// Use for registering with EventDispatcher
    public static void RegisterListener(this MonoBehaviour listener, EventID eventID, Action<object> callback)
    {
        _instance.RegisterListener(eventID, callback);
    }

    public static void RemoveListener(this MonoBehaviour listener, EventID eventID, Action<object> callback)
    {
        _instance.RemoveListener(eventID, callback);
    }

    /// Post event with param
    public static void PostEvent(this MonoBehaviour listener, EventID eventID, object param)
    {
        _instance.PostEvent(eventID, param);
    }

    /// Post event with no param (param = null)
    public static void PostEvent(this MonoBehaviour listener, EventID eventID)
    {
        _instance.PostEvent(eventID, null);
    }
}