using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class RagdollController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private ConfigurableJoint _mainJoint;
    [SerializeField] private Animator _animator;

    [Header("Settings")]
    [SerializeField] private float _movementSpeed = 10f;
    [SerializeField] private float _rotationSmoothTime = 5f;

    private int _speedAnimation = Animator.StringToHash("Speed");

    private SyncPhysics[] syncPhysics;

    private Vector2 direction;

    private void Awake()
    {
        syncPhysics = GetComponentsInChildren<SyncPhysics>();
    }

    private void FixedUpdate()
    {
        Rotate();
        UpdateJoinsRotation();
        if (_rb != null)
            Move();
        else
            Debug.LogWarning("Rigidbody reference is missing on RagdollController.");
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        direction = ctx.ReadValue<Vector2>();
    }

    private void Move()
    {
        Vector3 movement = new Vector3(direction.x, 0, direction.y);
        _rb.AddForce(movement * _movementSpeed, ForceMode.Acceleration);
        _animator.SetFloat(_speedAnimation, movement.magnitude);
    }

    private void Rotate()
    {
        if(direction != Vector2.zero)
        {
            Vector3 inputDirection = new Vector3(-direction.x, 0, direction.y).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(inputDirection, Vector3.up);

            _mainJoint.targetRotation = Quaternion.RotateTowards(_mainJoint.targetRotation, targetRotation, _rotationSmoothTime * Time.fixedDeltaTime);
        }
    }

    private void UpdateJoinsRotation()
    {
        for (int i = 0; i < syncPhysics.Length; i++)
        {
            syncPhysics[i].UpdateJoinFromAnimation();
        }
    }
}
