using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    void Start()
    {
        SceneManager.GetSceneByName("StartScene"); // Se till att start scenen är laddad
    }

    public void Play()
    {
        SceneManager.LoadScene("GameScene"); // Vid klick på playknappen, byt till spel scenen
    }

    public void Quit()
    {
        Application.Quit(); // Vid klick på quitknappen, avsluta spelet. (OBS! Fungerar endast efter Build)
        Debug.Log("Quit"); // Logga "Quit" i konsolen för att verifiera att funktionen anropas
    }
}
