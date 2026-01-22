using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    void Start()
    {
        SceneManager.GetSceneByName("StartScene"); // Säkerställer att startscenen hämtas vid startögonblicket
    }

    public void Play()
    {
        SceneManager.LoadScene("GameScene"); // Vid klick på playknappen, byt till spelscenen
    }

    public void Quit()
    {
        Application.Quit(); // Vid klick på quitknappen, avsluta spelet. (OBS! Fungerar endast efter att vi har gjort en build av spelet)
        Debug.Log("Quit"); // Loggar "Quit" i konsolen för att verifiera att funktionen anropas
    }
}
