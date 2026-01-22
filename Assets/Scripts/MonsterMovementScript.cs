using UnityEngine;

public class MonsterMovementScript : MonoBehaviour
{
    [Header("Referenser")]
    public Transform playerTransform; // Dra in båten här i Inspectorn
    private BoatMovementScript playerScript;

    [Header("Positionering")]
    public float distanceBehind = 10f; // Hur långt bakom båten monstret ligger
    public float depthUnderWater = -2f; // Hur djupt under ytan det börjar
    public float surfaceY = 0.5f;       // Vilken höjd det har när det dykt upp

    [Header("Aktivering")]
    public float activationZ = 50f;     // Vid vilket Z-värde monstret dyker upp
    public float riseSpeed = 2f;        // Hur snabbt det rör sig uppåt

    private bool hasRisen = false;

    void Start()
    {
        if (playerTransform != null)
        {
            playerScript = playerTransform.GetComponent<BoatMovementScript>();

            // Startposition: bakom spelaren och under vatten
            Vector3 startPos = playerTransform.position;
            startPos.z -= distanceBehind;
            startPos.y = depthUnderWater;
            transform.position = startPos;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("MonsterMovementScript: Space pressed");
        }


        if (playerTransform == null || playerScript == null) return;

        // 1. Följ spelarens hastighet och rörelse
        // Vi kopierar spelarens X (bana) och rör oss i samma takt i Z
        float targetX = playerTransform.position.x;
        float targetZ = playerTransform.position.z - distanceBehind;
        float targetY = transform.position.y;

        // 2. Kolla om vi ska dyka upp
        if (playerTransform.position.z >= activationZ)
        {
            hasRisen = true;
        }

        // 3. Hantera Y-positionen (dyka upp eller stanna under vatten)
        if (hasRisen)
        {
            // Rör sig mjukt upp till ytan
            targetY = Mathf.MoveTowards(transform.position.y, surfaceY, riseSpeed * Time.deltaTime);
        }
        else
        {
            targetY = depthUnderWater;
        }

        // 4. Applicera positionen
        // Vi använder MoveTowards på hela vektorn för att få samma följsamma rörelse i sidled som båten
        Vector3 newPosition = new Vector3(targetX, targetY, targetZ);

        // Vi matchar båtens hastighet genom att använda MoveTowards med en hög multiplikator 
        // eller direkt sätta positionen baserat på båtens framfart.
        transform.position = newPosition;
    }
}