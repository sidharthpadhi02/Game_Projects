using UnityEngine;
using UnityEngine.SceneManagement;
public class Play : MonoBehaviour
{
   
    public void LoadLevel()
    {
        SceneManager.LoadScene("Level1");
    }
}
