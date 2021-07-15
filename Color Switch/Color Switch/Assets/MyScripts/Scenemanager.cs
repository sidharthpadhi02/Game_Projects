using UnityEngine.SceneManagement;
using UnityEngine;

public class Scenemanager : MonoBehaviour
{
    public void SceneChanger()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void sceneChanger()
    {
        SceneManager.LoadScene("Level2");
    }
}
