using System.Collections;
using UnityEngine;

public class PlayersInfoSpawner : PlayersInfoLogic
{

    public void SpawnPlayerInfo()
    {
        StartCoroutine(SpawnPlayerInfoCoroutine());
    }

    private IEnumerator SpawnPlayerInfoCoroutine()
    {
        yield return StartCoroutine(_requests.GetRequest("https://zetprime.pythonanywhere.com/game/api/players"));

        _requestPlayersCount = GetRequestData("length").length;
        UpdateListOfPlayers();

        for (int i = 0; i < _requestPlayersCount; i++)
        {
            if (_requestPlayersCount > _uniqueGameObjects.Count)
            {
                Instantiate(_playerInfoPrefab, _spawnPlaceObject.transform.position, Quaternion.identity, _spawnPlaceObject.transform);
                UpdateListOfPlayers();
            }
            else
                break;    
        }
    }
}
