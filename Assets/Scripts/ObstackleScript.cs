using UnityEngine;
using UnityEngine.SceneManagement; // Krävs för att byta scen

public class ObstacleScript : MonoBehaviour
{
    [Header("Inställningar för effekter")]
    public GameObject collisionEffect; // Dra in en Particle System Prefab här
    public AudioClip collisionSound;   // Dra in en ljudfil här

    private void OnCollisionEnter(Collision collision)
    {
        // Försök hitta BoatMovementScript på det vi krockade med
        BoatMovementScript player = collision.gameObject.GetComponent<BoatMovementScript>();

        if (player != null)
        {
            Debug.Log($"Kollision med: {LayerMask.LayerToName(gameObject.layer)}");

            // 1. Spela upp ljud och effekt om de är tilldelade
            PlayEffects();

            // 2. Kolla vilket lager objektet (hindret) tillhör
            int layer = gameObject.layer;

            if (layer == LayerMask.NameToLayer("Obstacle"))
            {
                // Flytta båten bakåt -1 i z-led (relativt till nuvarande position)
                player.transform.position += new Vector3(0, 0, -1);
                Destroy(gameObject);
            }
            else if (layer == LayerMask.NameToLayer("SpeedBoost"))
            {
                // Aktivera speed boost (se till att metoden är public i BoatMovementScript)
                player.ActivateSpeedBoost();
                Destroy(gameObject);
            }
            else if (layer == LayerMask.NameToLayer("Kill"))
            {
                // Hantera liv och Game Over
                HandleKillCollision(player);
            }
        }
    }

    private void PlayEffects()
    {
        // Skapa partikeleffekt vid hindrets position
        if (collisionEffect != null)
        {
            Instantiate(collisionEffect, transform.position, Quaternion.identity);
        }

        // Spela ljud (AudioSource.PlayClipAtPoint skapar ett temporärt ljudobjekt i scenen)
        if (collisionSound != null)
        {
            AudioSource.PlayClipAtPoint(collisionSound, transform.position);
        }
    }

    private void HandleKillCollision(BoatMovementScript player)
    {
        // Här antar jag att du har en variabel 'health' i BoatMovementScript
        // Om inte, får du anpassa variabelnamnet nedan.
        player.health -= 1;

        if (player.health <= 0)
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene("GameOverScene"); // Ersätt med namnet på din Game Over-scen
        }

        // Förstör hindret även vid Kill? (Valfritt)
        Destroy(gameObject);
    }
}