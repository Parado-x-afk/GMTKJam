using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameObject player;               // Reference to the player
    public Transform playerSpawn;           // Where to respawn the player

    public static int resetCount = 0;       // Counter for resets (accessible from other scripts)

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Increment the reset counter
            resetCount++;

            // Respawn the player at the spawn point
            if (player != null && playerSpawn != null)
            {
                CharacterController controller = player.GetComponent<CharacterController>();
                if (controller != null) controller.enabled = false;

                player.transform.position = playerSpawn.position;
                player.transform.rotation = playerSpawn.rotation;

                if (controller != null) controller.enabled = true;
            }
        }
    }
}
