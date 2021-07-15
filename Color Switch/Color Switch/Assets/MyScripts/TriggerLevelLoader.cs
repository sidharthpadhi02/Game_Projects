using UnityEngine.SceneManagement;
using UnityEngine;

public class TriggerLevelLoader : MonoBehaviour
{
    public string nameOfTheLevelToLoad ;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D finish)
    {
        if(finish.tag == "Player")
        {
            SceneManager.LoadScene(nameOfTheLevelToLoad);
        }
    }
}
