using UnityEngine;

public class PlayerScript : MonoBehaviour
{   
    private Rigidbody playerRB; // Referens till spelarens (båtens) rigidbody-komponent (spelarens fysik)
    public float speed = 10.0f; // Hastigheten för spelarens (båtens) rörelse
    public bool moveFwd; // Variabel för att kontrollera framåtrörelse

    void Start()
    {
        playerRB = GetComponent<Rigidbody>(); // Hämta spelarens (båtens) rigidbody-komponent
    }

    void Update()
    {
        // Kollar om mellanslagstangenten trycks ned för att aktivera framåtrörelse
        if (Input.GetKeyDown(KeyCode.Space))
        {
            moveFwd = !moveFwd;
        }
        if (moveFwd) 
            transform.Translate(Vector3.back * Time.deltaTime);



        // Fungerar inte som tänkt ännu...
        // Kollar tangentbords-inmatningen för horisontell rörelse (vänster pil/A eller höger pil/D)
        //playerRB.linearVelocity = new Vector3 ((speed * Time.deltaTime) * Input.GetAxis("Horizontal"), 0, 0);
        playerRB.linearVelocity = new Vector3(speed * Input.GetAxis("Horizontal"), 0, 0);

        // 
        if (playerRB.linearVelocity.x > 0) // Vänster rörelse
        {
            transform.position = new Vector3(-2, 0, 0); // * Time.deltaTime;
        }
        //else
        if (playerRB.linearVelocity.x < 0) // Höger rörelse
        {
            transform.position = new Vector3(2, 0, 0); // * Time.deltaTime;
        }
        //else // Ingen rörelse
        //if (playerRB.linearVelocity.x == 0)
        //{
        //    transform.position += new Vector3(0, 0, 0) * Time.deltaTime;
        //}
    }
}
