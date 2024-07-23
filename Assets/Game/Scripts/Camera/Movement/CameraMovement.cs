using UnityEngine;

public class CameraMovement : BarrierData
{
    private GameObject _player;



    private Vector3 _targetPosition;

    private void Start()
    {
       _player = FindFirstObjectByType<PlayerMovement>().gameObject;
    }

    private void LateUpdate()
    {
        Move();
    }

    
    private void Move()
    {
        float playerX = _player.transform.position.x;
        float playerY = _player.transform.position.y;

        playerX =  Mathf.Clamp(playerX, _leftBarrier, _rightBarrier);
        playerY = Mathf.Clamp(playerY, _downBarrier, _upBarrier);

        _targetPosition = new Vector3(playerX, playerY + 0.8f, _player.transform.position.z - 10);
        transform.position = _targetPosition;
    }
}
