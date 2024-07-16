using Photon.Pun;
using UnityEngine;
public class PlayersInfoPrefabData : MonoBehaviourPunCallbacks
{
    [SerializeField] private string _nickName;

    protected void SetNicknamePrivate(string nickName)
    {
        _nickName = nickName;
    }

    protected string GetNicknamePrivate()
    {
        return _nickName;
    }

    public void SetNickname(string nickName)
    {
        SetNicknamePrivate(nickName);
    }

    public string GetNickname()
    {
        return GetNicknamePrivate();
    }
}