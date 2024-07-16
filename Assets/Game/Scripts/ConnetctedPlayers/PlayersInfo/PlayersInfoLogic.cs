using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class PlayersInfoLogic : PlayersInfoPrefabData
{
    [SerializeField] protected string _playerPrefabsTag;
    [SerializeField] protected int _maxPlayersInRoom;
    [SerializeField] private Sprite _isConectedImage;
    [SerializeField] protected GameObject _spawnPlaceObject, _playerInfoPrefab;

    protected List<GameObject> _uniqueGameObjects = new List<GameObject>();
    protected int _requestPlayersCount;
    protected List<GameObject> _allGameObjects;
    protected Requests _requests = new Requests();

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinOrCreateRoom("MainRoom", new RoomOptions { MaxPlayers = _maxPlayersInRoom }, null);
    }

    public override void OnJoinedRoom()
    {
        string playerNickname = UserIdData.UserNickName;

        PhotonNetwork.LocalPlayer.NickName = playerNickname;

    }

    protected void UpdateListOfPlayers()
    {
        _allGameObjects = FindObjectsOfType<GameObject>().ToList();

        foreach (GameObject gameObject in _allGameObjects)
        {
            if (gameObject.tag == _playerPrefabsTag)
            {
                if (!_uniqueGameObjects.Contains(gameObject))
                {
                    _uniqueGameObjects.Add(gameObject);
                }
            }
        }

        UpdateData();
    }


    private void CheckPlayersMatch()
    {
        foreach (Player serverPlayer in PhotonNetwork.PlayerList)
        {
            Debug.Log(serverPlayer.NickName);
            foreach (GameObject networkPlayer in _uniqueGameObjects)
            {
                if (serverPlayer.NickName == networkPlayer.GetComponentInChildren<PlayersInfoPrefabData>().GetNickname())
                {
                    networkPlayer.GetComponentInChildren<Image>().sprite = _isConectedImage;
                }
            }
        }
    }

    private void UpdateData()
    {
        var requestData = GetRequestData("length");

        for (int i = 0; i < _uniqueGameObjects.Count; i++)
        {
            _uniqueGameObjects[i].GetComponentInChildren<TextMeshProUGUI>().text = requestData.nickNames[i];
            _uniqueGameObjects[i].GetComponentInChildren<PlayersInfoPrefabData>().SetNickname(requestData.nickNames[i]);
        }

        CheckPlayersMatch();
    }

    protected (int length, List<string> nickNames) GetRequestData(string parameter)
    {
        string symbols = _requests.Uwr.downloadHandler.text;
        var ids = new List<int>();
        var nickNames = new List<string>();

        string[] data = symbols.Split('/');
        int length = data.Length;

        foreach (var item in data)
        {
            string[] values = item.Replace("\"", "").Split(',');

            nickNames.Add(values[0]);
        }

        return (length, nickNames);
    }
}
