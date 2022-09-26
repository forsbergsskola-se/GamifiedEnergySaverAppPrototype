using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public int index;

    public void OpenScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(index);
    }
}
