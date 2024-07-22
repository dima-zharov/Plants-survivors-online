using UnityEngine;

[RequireComponent (typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    private Transform _playerTransform;
    private CharacterController _characterController;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _playerTransform = GetComponent<Transform>();
    }

    public void MovePlayer(Vector2 moveDirection)
    {
        AnimationEventManager.SendBoolParametrChanged(true, nameof(AnimParametersEnum.isRunning));
        moveDirection = moveDirection * _moveSpeed;
        CheckViewDirection(moveDirection);
        _characterController.Move(moveDirection);
    }

    private void CheckViewDirection(Vector2 moveDirection)
    {
        if (moveDirection.x < 0)
            RotateY(180);
        else if(moveDirection.x > 0)
            RotateY(0);
    }

    private void RotateY(int rotation)
    {
        _playerTransform.rotation = Quaternion.Euler(new Vector2(0, rotation));
    }
}
