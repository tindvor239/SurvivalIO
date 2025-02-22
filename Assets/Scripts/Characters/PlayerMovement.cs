using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private CharacterController _characterController;
    [SerializeField]
    private Player _character;
    [SerializeField]
    private float _rotationSpeed;
    
    private InputAction _move;
    private float y = 0;

    private void Awake()
    {
        y = transform.position.y;
        _move = InputSystem.actions.FindAction("Move");
    }

    private void Update()
    {
        if (_move.IsPressed())
        {
            Vector2 moveValue = _move.ReadValue<Vector2>();
            Vector3 moveDirection = new Vector3(moveValue.x, 0, moveValue.y);
            float speed = _character.CurrentStats.movementSpeed;
            moveDirection.Normalize();
            #if !UNITY_EDITOR
            speed /= 10f;
            #endif
            Debug.Log($"Velocity {moveDirection * speed * Time.timeScale}");
            _characterController.Move(moveDirection * speed * Time.timeScale);
            transform.position = new Vector3(transform.position.x, y, transform.position.z);

            if (moveDirection != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, _rotationSpeed * Time.deltaTime);
            }
        }
    }
}
