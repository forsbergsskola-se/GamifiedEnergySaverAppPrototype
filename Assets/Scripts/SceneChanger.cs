using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneChanger : MonoBehaviour
{
    public string SceneName;

    public void OpenScene()
    {
        if (SceneManager.GetActiveScene().name != SceneName)
            SceneManager.LoadScene(SceneName);
    }
}
