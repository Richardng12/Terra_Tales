using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Publisher : MonoBehaviour
{
    private Dictionary<string, UnityEvent> eventDictionary;

    private static Publisher publisher;

    // singleton only allowing one instance of publisher
    public static Publisher instance
    {
        get
        {
            if (!publisher)
            {
                publisher = FindObjectOfType(typeof(Publisher)) as Publisher;

                if (!publisher)
                {
                    Debug.LogError("There needs to be one active EventManger script on a GameObject in your scene.");
                }
                else
                {
                    publisher.Init();
                }
            }

            return publisher;
        }
    }

    // initialises the event dictionary
    void Init()
    {
        if (eventDictionary == null)
        {
            eventDictionary = new Dictionary<string, UnityEvent>();
        }
    }

    // adds the trigger string and event to dictionary
    public static void StartListening(string eventName, UnityAction listener)
    {
        UnityEvent thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            instance.eventDictionary.Add(eventName, thisEvent);
        }
    }

    // removes trigger string and event from dictionary
    public static void StopListening(string eventName, UnityAction listener)
    {
        if (publisher == null) return;
        UnityEvent thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    // searches for event in dictionary and dispatches the UnityEvent
    public static void TriggerEvent(string eventName)
    {
        UnityEvent thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.Invoke();
        }
    }
}
