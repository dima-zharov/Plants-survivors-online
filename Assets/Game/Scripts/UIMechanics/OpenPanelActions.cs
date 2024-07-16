using UnityEngine;
public class InventoryActions : MonoBehaviour
{
    [SerializeField] private GameObject _objectNeedToShow;
    private bool _isActive = true;

    public void Action()
    {
       _objectNeedToShow.SetActive(_isActive);
        _isActive = !_isActive;
    }
}
