using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<Collider> onTriggerEnterCallBack;
    [Space]
    [SerializeField]
    private UnityEvent<Collider> onTriggerExitCallBack;

    public UnityEvent<Collider> OnTriggerEnterCallBack => onTriggerEnterCallBack;
    public UnityEvent<Collider> OnTriggerExitCallBack => onTriggerExitCallBack;

    private void OnTriggerEnter(Collider other)
    {
        onTriggerEnterCallBack?.Invoke(other);
    }

    private void OnTriggerExit(Collider other)
    {
        onTriggerExitCallBack?.Invoke(other);
    }
}
