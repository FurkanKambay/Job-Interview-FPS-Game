using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    public float ProjectileSpeed;
    public int ProjectileCount;

    public float ProjectileMinAngle;
    public float ProjectileMaxAngle;

    [SerializeField] Vector3 muzzlePoint;
    [SerializeField] GameObject projectilePrefab;

    [SerializeField] UnityEvent OnFired;

    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed && context.ReadValueAsButton())
            Fire();
    }

    private void Fire()
    {
        Vector3 spawnPoint = transform.position + muzzlePoint;
        Rigidbody projectile = Instantiate(projectilePrefab, spawnPoint, transform.rotation).GetComponent<Rigidbody>();
        projectile.velocity = projectile.transform.forward * ProjectileSpeed;
        // play sound
        // particle
        OnFired?.Invoke();
    }

    private void GetRandomRotation()
    {

    }

    private void OnDrawGizmosSelected() => Gizmos.DrawSphere(transform.position + muzzlePoint, .02f);
}
