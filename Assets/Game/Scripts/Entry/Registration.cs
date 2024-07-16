using System.Collections;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Registration : EntryPattern
{
    private string _userId;
    private UserIdData _userIdData = new UserIdData();
    private ChangeScene _sceneManager = new ChangeScene();
    protected override void EntryMethod()
    {
        StartCoroutine(EntryMethodCoroutine());
    }

    private IEnumerator EntryMethodCoroutine()
    {
        _userPassword = _inputPassword.textComponent.text;
        _userEmail = _inputEmail.textComponent.text;
        yield return StartCoroutine(_request.GetRequest($"https://zetprime.pythonanywhere.com/game/api/registration?email={_userEmail}&password={_userPassword}"));

        string result = _request.Uwr.downloadHandler.text;

        if (result.Equals("true"))
        {
            _userId = _request.Uwr.downloadHandler.text;
            _userIdData.SaveUserId(_inputEmail.text);
            _sceneManager.ChangeSceneMethod(1);
        }
        else
        {
            Debug.Log("Error!!!");
        }
    }

}
