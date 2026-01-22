using UnityEngine;

public class BonusObjectScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        BoatMoveMentScript player = other.GetComponent<BoatMoveMentScript>();
        if (player != null)
        {
            player.ActivateSpeedBoost();
            Destroy(gameObject); // Ta bort livbojen efter att den plockats upp
        }
    }
}
