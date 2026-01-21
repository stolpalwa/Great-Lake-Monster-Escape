using UnityEngine;

public class LifeBuoyPickupScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerMovement player = other.GetComponent<PlayerMovement>();
        if (player != null)
        {
            player.ActivateSpeedBoost();
            Destroy(gameObject); // Ta bort livbojen efter att den plockats upp
        }
    }
}
