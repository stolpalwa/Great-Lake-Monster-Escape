using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    // Säkerställer att startscenen hämtas vid programstarten
    void Start()
    {
        SceneManager.GetSceneByName("StartScene");
    }

    // Vid klick på playknappen, byt till spelscenen
    public void Play()
    {
        SceneManager.LoadScene("GameScene");
    }

    // Vid klick på quitknappen, avsluta spelet. (OBS! Fungerar endast efter att vi har gjort en build av spelet)
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit"); // Loggar "Quit" i konsolen för att verifiera att funktionen anropas
    }
}
