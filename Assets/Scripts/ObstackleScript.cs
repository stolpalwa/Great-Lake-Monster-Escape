using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleScript : MonoBehaviour
{
    [Header("Inställningar för effekter")]
    public GameObject collisionEffect;
    public AudioClip collisionSound;

    private bool isFinished = false; // För att hindra att målgången triggas flera gånger

    private void OnTriggerEnter(Collider other)
    {
        BoatMovementScript player = other.GetComponent<BoatMovementScript>();

        if (player != null && !isFinished)
        {
            int layer = gameObject.layer;

            if (layer == LayerMask.NameToLayer("Obstacle"))
            {
                PlayEffects();
                player.transform.position += new Vector3(0, 0, -1);
                Destroy(gameObject);
            }
            else if (layer == LayerMask.NameToLayer("SpeedBoost"))
            {
                PlayEffects();
                player.ActivateSpeedBoost();
                Destroy(gameObject);
            }
            else if (layer == LayerMask.NameToLayer("Kill"))
            {
                PlayEffects();
                HandleKillCollision(player);
            }
            else if (layer == LayerMask.NameToLayer("Finish"))
            {
                isFinished = true;
                PlayEffects();
                player.isMoving = false; // Stoppa båten
                Invoke("LoadFinishScene", 2.5f); // Vänta på fanfaren
            }
        }
    }

    private void LoadFinishScene()
    {
        SceneManager.LoadScene("FinishScene");
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
        if (player.health <= 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }
        Destroy(gameObject);
    }
}
