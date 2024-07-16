using System.Collections;
using UnityEngine;

public class Auth : EntryPattern
{
    private UserIdData _userIdData = new UserIdData();
    private ChangeScene _sceneManager = new ChangeScene();
    private string _result;

    protected override void EntryMethod()
    {
        StartCoroutine(EntryMethodCoroutine());    
    }

    private IEnumerator EntryMethodCoroutine()
    {

        _userPassword = _inputPassword.textComponent.text;
        _userEmail = _inputEmail.textComponent.text;

        yield return StartCoroutine(_request.GetRequest($"https://zetprime.pythonanywhere.com/game/api/login?email={_userEmail}&password={_userPassword}"));
        string result = _request.Uwr.downloadHandler.text;

        if (result.Equals("true"))
        {
            _result = _request.Uwr.downloadHandler.text;
            _userIdData.SaveUserId(_inputEmail.text);
            _sceneManager.ChangeSceneMethod(1);
        }
        else
        {
            Debug.Log("Error!!!");
        }

    }
}
