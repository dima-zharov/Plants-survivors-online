using UnityEngine;

public class MovementAnimation : MonoBehaviour
{
    //Спрайты для игрока при движении влеов, вправо, вверх и вниз
    [SerializeField] private Sprite _front;
    [SerializeField] private Sprite _back;
    [SerializeField] private Sprite _left;
    [SerializeField] private Sprite _right;

    //Текущий спрайт игрока
    private SpriteRenderer _curentSprite;

    //Находим компонент SpriteRenderer на игроке
    private void Start()
    {
        _curentSprite = GetComponent<SpriteRenderer>();
    }

    //Логика обновления спрайтов при перемещении
    public void MoveAnimation(Rigidbody2D player)
    {
        if (player.velocity.x > 0)
            _curentSprite.sprite = _right;
        else if (player.velocity.x < 0)
            _curentSprite.sprite = _left;
        else if (player.velocity.y > 0)
            _curentSprite.sprite = _back;
        else
            _curentSprite.sprite = _front;
    }
}
