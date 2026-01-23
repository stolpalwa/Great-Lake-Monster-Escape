using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleScript : MonoBehaviour
{
    [Header("Inställningar för effekter")]
    public GameObject collisionEffect;
    public AudioClip collisionSound;
    public float hitForce = -1;


    // Vi byter OnCollisionEnter mot OnTriggerEnter
    private void OnTriggerEnter(Collider other)
    {
        // Vi kollar om objektet som åkte in i triggern har BoatMovementScript
        BoatMovementScript player = other.GetComponent<BoatMovementScript>();

        if (player != null)
        {
            Debug.Log($"Trigger aktiverad av: {LayerMask.LayerToName(gameObject.layer)}");

            // Spela effekter
            PlayEffects();

            int layer = gameObject.layer;

            if (layer == LayerMask.NameToLayer("Obstacle"))
            {
                // Flytta båten bakåt -1 i z-led
                player.transform.position += new Vector3(0, 0, hitForce);
                Destroy(gameObject);
            }
            else if (layer == LayerMask.NameToLayer("SpeedBoost"))
            {
                player.ActivateSpeedBoost();
                Destroy(gameObject);
            }
            else if (layer == LayerMask.NameToLayer("Kill"))
            {
                HandleKillCollision(player);
            }
            else if (layer == LayerMask.NameToLayer("Finish"))
            {
                // 1. Spela fanfaren och effekterna direkt vid krock
                PlayEffects();

                // 2. Stoppa båten så den inte fortsätter köra under fanfaren
                player.isMoving = false;

                // 3. Vänta 2 sekunder (så man hinner höra ljudet) innan scenen byts
                Invoke("FinishScene", 2.0f);
            }
        }
    }

    private void PlayEffects()
    {
        if (collisionEffect != null)
        {
            Instantiate(collisionEffect, transform.position, Quaternion.identity);
        }
        if (collisionSound != null)
        {
            AudioSource.PlayClipAtPoint(collisionSound, transform.position);
        }
    }

    private void HandleKillCollision(BoatMovementScript player)
    {
        player.health -= 1;
        Debug.Log("Liv kvar: " + player.health);

        if (player.health <= 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }

        Destroy(gameObject);
    }
}