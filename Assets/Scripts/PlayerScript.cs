using UnityEngine;

public class PlayerScript : MonoBehaviour
{   
    public float moveSpeed = 10.0f; // Hastigheten för spelarens (båtens) rörelse
    public static Rigidbody playerRB; // Referens till spelarens (båtens) rigidbody-komponent (spelarens fysik)

    void Start()
    {
        playerRB = GetComponent<Rigidbody>(); // Hämta spelarens (båtens) rigidbody-komponent
    }

    void Update()
    {
        //Kollar tangentinmatningen inputGetAxis för horisontell rörelse (vänster och höger)
        playerRB.linearVelocity = new Vector3 ((moveSpeed * Time.deltaTime) * Input.GetAxis("Horizontal"), 0, 0);

        if (playerRB.linearVelocity.x < 0) // Höger rörelse
        {
            Debug.Log("Moving Right");
        }
        else if (playerRB.linearVelocity.x > 0) // Vänster rörelse
        {
            Debug.Log("Moving Left");
        }
    }
}
