using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene: MonoBehaviour
{
    public void ChangeSceneMethod(int sceneId)
    {
        SceneManager.LoadScene(sceneId);
    }
}
