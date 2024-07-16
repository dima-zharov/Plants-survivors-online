using TMPro;
using UnityEngine;

public abstract class EntryPattern : MonoBehaviour
{
    [SerializeField] protected TMP_InputField _inputEmail;
    [SerializeField] protected TMP_InputField _inputPassword;


    protected Requests _request = new Requests();

    protected string _userEmail;
    protected string _userPassword;


    public void EnterField()
    {
        if (_inputPassword.textComponent.text != null && _inputEmail.textComponent.text != null)
            EntryMethod();
    }

    protected abstract void EntryMethod();
}
