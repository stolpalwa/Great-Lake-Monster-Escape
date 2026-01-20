using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    private string sceneName;

    private void Start()
    {
        //SceneManager.GetSceneByName("StartMenu"); //Initiera startscenen (0) med play-knappen på (livbojen)
        sceneName = SceneManager.GetActiveScene().name;
        Debug.Log("Current Scene: " + sceneName);
    }

    public void Play()
    {
        //SceneManager.LoadScene("Greatlake"); //När spelaren trycker på play-knappen, ladda in spelscenen (1)
        SceneManager.LoadScene(1); //Alternativt sätt att ladda in scenen via dess index
    }

    public void Finish()
    {
        SceneManager.LoadScene(0); //Byt till Startsidan
    }

    public void Quit()
    {
        Application.Quit(); //Stäng ned spelet
        Debug.Log("Quit"); //Log för att bekräfta att funktionen anropades, OBS!! tas bort innan build
    }
}
