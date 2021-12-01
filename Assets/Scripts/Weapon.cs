using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    public UnityEvent OnFired;

    [SerializeField] Vector3 muzzlePoint;
    [SerializeField] GameObject projectilePrefab;

    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed && context.ReadValueAsButton())
            Fire();
    }

    private void Fire()
    {
        Vector3 spawnPoint = transform.position + muzzlePoint;
        GameObject projectile = Instantiate(projectilePrefab, spawnPoint, Quaternion.identity);
        
        // play sound
        // particle
        OnFired?.Invoke();
    }

    private void OnDrawGizmosSelected() => Gizmos.DrawSphere(transform.position + muzzlePoint, .05f);
}
