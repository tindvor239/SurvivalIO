using UnityEngine.Events;

public interface IDeathable
{
    public UnityEvent<IDeathable> OnDeath { get; }
}