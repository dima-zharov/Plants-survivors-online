using UnityEngine;
public class UserIdData
{
    public static string UserNickName { get; private set; }

    public void SaveUserId(string userId)
    {
        UserNickName = userId;
        PlayerPrefs.SetString("playerId", UserNickName);
        PlayerPrefs.Save();
    }
}
