using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public int index;

    public void OpenScene()
    {
        Debug.Log("Changing Scene");
        UnityEngine.SceneManagement.SceneManager.LoadScene(index);
    }
}
