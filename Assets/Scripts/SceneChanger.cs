using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneChanger : MonoBehaviour
{
    public string SceneName;

    public void OpenScene()
    {
        Debug.Log("Changing Scene");
        SceneManager.LoadScene(SceneName);
    }
}
