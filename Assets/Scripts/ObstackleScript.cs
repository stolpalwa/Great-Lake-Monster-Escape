using UnityEngine;

public class ObstackleScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        BoatMovementScript player = collision.gameObject.GetComponent<BoatMovementScript>();
        if (player != null)
        {
            
            Debug.Log("Båten har kolliderat med ett hinder!");

            // Vill ha kod för att kolla vilken typ av hinder båten kolliderar med (Layer),
            // samt spela upp ett ljud och en effekt vid kollision med ett hinder
            // OM Lager = "Obstacle" förflytta båten bakåt 1 position, (z = nuvarande position - 1)
            // OM Lager = "SpeedBoost" aktivera speed boost-funktionen i BoatMovementScript,
            // OM Lager = "Kill" minska spelarens liv med 1, när liv = 0, växla till game over scenen.
            
        }
    }
}
