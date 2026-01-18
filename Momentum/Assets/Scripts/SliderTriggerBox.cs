using UnityEngine;

public class SliderTriggerBox : MonoBehaviour
{
    public GameObject redDot;
    public GameObject yellowDotPrefab;

    bool activated = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (activated) return;

        // Compare by GameObject name
        if (collision.gameObject.name == "falling platform")
        {
            activated = true;
            Debug.Log("Activated");


            // Spawn yellow dot at red dot position
            Vector3 spawnPos = redDot.transform.position;
            Instantiate(yellowDotPrefab, spawnPos, Quaternion.identity);

            // Destroy red dot
            Destroy(redDot);
        }
    }
}
