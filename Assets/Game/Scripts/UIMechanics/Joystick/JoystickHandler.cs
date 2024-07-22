using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class JoystickHandler : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] private Image _joystick;
    [SerializeField] private Image _backgroundJoystick;
    [SerializeField] private RectTransform _inputArea;
    [SerializeField] private Color _activeColor;
    [SerializeField] private Color _notActiveColor;

    protected Vector2 _inputVector;

    private void OnEnable()
    {
        _joystick.color = _notActiveColor;
        _backgroundJoystick.color = _notActiveColor;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        ChangeJoystickCondition(true);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        _joystick.rectTransform.anchoredPosition = Vector2.zero;
        _inputVector = Vector2.zero;

        ChangeJoystickCondition(false);
    }
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 joystickPosition;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_inputArea, eventData.position, Camera.main, out joystickPosition))
        {
            ChangeJoystickCondition(true);
            joystickPosition.x = (joystickPosition.x * 2 / _inputArea.sizeDelta.x);
            joystickPosition.y = (joystickPosition.y * 2 / _inputArea.sizeDelta.y);

            _inputVector = new Vector2(joystickPosition.x, joystickPosition.y);

            _inputVector = (_inputVector.magnitude > 1f) ? _inputVector.normalized : _inputVector;

            _joystick.rectTransform.anchoredPosition = new Vector2(_inputVector.x * (_inputArea.sizeDelta.x / 2), _inputVector.y * (_inputArea.sizeDelta.y / 2));
        }
    }

    private void ChangeJoystickCondition(bool isActive)
    {
        if (isActive)
        {
            _joystick.color = _activeColor;
            _backgroundJoystick.color = _activeColor;
        }
        else
        {
            _joystick.color = _notActiveColor;
            _backgroundJoystick.color = _notActiveColor;
        }


    }

}
