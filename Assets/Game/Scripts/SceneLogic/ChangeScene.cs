using UnityEngine.SceneManagement;

public class ChangeScene
{
    public void ChangeSceneMethod(int sceneId)
    {
        SceneManager.LoadScene(sceneId);
    }
}
