using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private string sceneName;

    //This is a simple scenes management component
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}