using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // A. Movement settings: player target, speed, and stopping distance
    public Transform playerHead;
    public float moveSpeed = 0.5f;
    public float stopDistance = 1f;

    // Runs once per frame to update the enemy's position
    void Update()
    {
        // B. Confirm the player target
        if (playerHead == null) return;

        // C. Measure the distance between the enemy and player
        float distance = Vector3.Distance(
            transform.position,
            playerHead.position
        );

        // D. Move toward player when far enough
        if (distance > stopDistance)
        {
            // Move a small step toward the player based on speed and frame time
            transform.position = Vector3.MoveTowards(
                transform.position,
                playerHead.position,
                moveSpeed * Time.deltaTime
            );
        }
    }
}
