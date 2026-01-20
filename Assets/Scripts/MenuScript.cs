using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    private void Start()
    {
        SceneManager.GetSceneByName("StartMenu"); // Initiera startscenen med play-knappen på (livbojen)
    }

    public void Play()
    {
        SceneManager.LoadScene("Greatlake"); // När spelaren trycker på play-knappen, ladda in spelscenen
    }
}
