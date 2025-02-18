using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public void OpenStartScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("StartLevel");
    }

    public void OpenMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("menu");
    }
    
}
