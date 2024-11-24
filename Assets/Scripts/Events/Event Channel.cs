using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "EventChannel", menuName = "Scriptable Objects/EventChannel")]
public abstract class EventChannel<T> : ScriptableObject
{
    private readonly HashSet<EventListener<T>> observers = new HashSet<EventListener<T>>();

    public void Invoke(T value){
        foreach (EventListener<T> observer in observers){
            observer.Raise(value);
        }
    }
    public void Register(EventListener<T> listener) => observers.Add(listener);
    public void DeRegister(EventListener<T> listener) => observers.Remove(listener);
}
