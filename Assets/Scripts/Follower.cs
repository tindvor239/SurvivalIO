using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField]
    private Transform _target;
    [SerializeField]
    private float _speed = 10;

    private void Update()
    {
        Vector3 target = _target.position;
        target.y = transform.position.y;
        transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * _speed);
    }
}
