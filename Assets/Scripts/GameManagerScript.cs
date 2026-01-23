using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    //private string sceneName;

    void Start()
    {
        //sceneName = SceneManager.GetActiveScene().name;
        SceneManager.GetSceneByName ("StartScene");
    }

    public void Play()
    {
        SceneManager.LoadScene("GameScene"); // Byt till level 1
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
