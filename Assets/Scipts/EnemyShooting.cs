using UnityEngine;
using UnityEngine.InputSystem;
public class EnemyShooting : MonoBehaviour
{
    // A. Shooting references and range
    // The ray starts here, uses the input action, and stops at this distance
    public Transform shootingOrigin;
    public InputActionProperty shootAction;
    public float shootingDistance = 10f;
    // B. Verify the Enemy tag exists
    void Start()
        {
        // Catch a missing Enemy tag so the problem is visible in the Console
        try
            {
            GameObject.FindGameObjectsWithTag("Enemy");
            Debug.Log("ENEMY TAG EXISTS!");
            }
        catch (UnityException error)
            {
            Debug.LogError("ENEMY TAG ERROR: " + error.Message);
            }
        }
    // C. Check for a trigger press
    void Update()
    {
    // Only shoot when the action is set and pressed this frame
    if (shootAction.action != null &&
    shootAction.action.WasPressedThisFrame())
        {
        Shoot();
        }
    }
    // D. Raycast and destroy hit enemies
    void Shoot()
    {
    Debug.Log("TRIGGER PRESSED - SHOOTING!");
    // Aim a ray forward from the shooting origin
    Ray ray = new Ray(shootingOrigin.position,
    shootingOrigin.forward);
    // Draw the ray briefly in the Scene view for debugging
    Debug.DrawRay(ray.origin,
    ray.direction * shootingDistance,
    Color.red, 2f);
    // Check whether the ray hits an object within range
    if (Physics.Raycast(ray, out RaycastHit hit,
    shootingDistance))
        {
        Debug.Log("RAY HIT: " + hit.collider.gameObject.name);
        Debug.Log("HIT TAG: " + hit.collider.tag);
        // Remove the hit object only when it has the Enemy tag
        if (hit.collider.CompareTag("Enemy"))
            {
            Debug.Log("ENEMY DESTROYED!");
            Destroy(hit.collider.gameObject);
            }
        }
    else
        {
        Debug.Log("RAY MISSED EVERYTHING");
        }
    }
}