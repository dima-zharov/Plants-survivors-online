using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private float _upBarrier;
    [SerializeField] private float _downBarrier;
    [SerializeField] private float _rightBarrier;
    [SerializeField] private float _leftBarrier;

    private Vector3 _targetPosition;


    private void FixedUpdate()
    {
        Move();
    }

    
    private void Move()
    {
        float playerX = _player.transform.position.x;
        float playerY = _player.transform.position.y;

        playerX =  Mathf.Clamp(playerX, _leftBarrier, _rightBarrier);
        playerY = Mathf.Clamp(playerY, _downBarrier, _upBarrier);

        _targetPosition = new Vector3(playerX, playerY, _player.transform.position.z - 10);
        transform.position = _targetPosition;
    }
}
