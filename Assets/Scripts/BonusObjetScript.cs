using UnityEngine;

public class BonusObjectScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Bonus objekt triggat");
        BoatMovementScript player = other.GetComponent<BoatMovementScript>();
        if (player != null)
        {
            player.ActivateSpeedBoost();
            Destroy(gameObject); // Ta bort livbojen efter att den plockats upp
        }
    }
}