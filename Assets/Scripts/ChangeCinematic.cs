using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeCinematic : MonoBehaviour
{
    public void LoadScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}
