using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : BarrierData
{
    [SerializeField] private float _moveSpeed;
    private Transform _playerTransform;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerTransform = GetComponent<Transform>();
    }

    public void MovePlayer(Vector2 moveDirection)
    {
        AnimationEventManager.SendBoolParametrChanged(true, nameof(AnimParametersEnum.isRunning));
        Vector2 offset = moveDirection * _moveSpeed * Time.fixedDeltaTime;
        CheckViewDirection(moveDirection);
        _rigidbody.MovePosition(_rigidbody.position + offset);
    }

    private void CheckViewDirection(Vector2 moveDirection)
    {
        if (moveDirection.x < 0)
            RotateY(180);
        else if (moveDirection.x > 0)
            RotateY(0);
    }

    private void RotateY(int rotation)
    {
        _playerTransform.rotation = Quaternion.Euler(new Vector2(0, rotation));
    }

}
