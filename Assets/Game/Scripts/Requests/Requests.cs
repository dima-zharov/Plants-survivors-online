using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;


public class Requests : MonoBehaviour
{
    [SerializeField] private int _secondsToShow = 5; 
    [SerializeField] private GameObject _errorMessage; 
    public UnityWebRequest Uwr { get; private set; }

    public void SpawnErrorMessage()
    {
        if (_errorMessage != null)
            StartCoroutine(SpawnErrorMessageCoroutine());
        else
            Debug.Log("Нет объекта");
    }
    public IEnumerator GetRequest(string uri)
    {

        Uwr = UnityWebRequest.Get(uri);
        yield return Uwr.SendWebRequest();

        if (Uwr.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log("Error While Sending: " + Uwr.error);
        }
        else
        {
            Debug.Log("Received: " + Uwr.downloadHandler.text);
        }
    }

    private IEnumerator SpawnErrorMessageCoroutine()
    {
        Instantiate(_errorMessage);
        _errorMessage.GetComponent<TextMeshProUGUI>().text = $"Error:{Uwr.downloadHandler.text}";
        yield return new WaitForSeconds(_secondsToShow);
        Destroy(_errorMessage.gameObject);
    }
}
