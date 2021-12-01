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
    [SerializeField] Transform muzzle;
    [SerializeField] GameObject projectilePrefab;

    [SerializeField] UnityEvent<int> OnFired;

    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed && context.ReadValueAsButton())
            Shoot();
    }

    private void Shoot()
    {
        Vector3 spawnPoint = muzzle.position;

        for (int i = 0; i < ProjectileCount; i++)
        {
            var projectileRotation = Quaternion.Euler(z: 0,
                    x: Random.Range(ProjectileMinAngle, ProjectileMaxAngle),
                    y: Random.Range(ProjectileMinAngle, ProjectileMaxAngle));

            Rigidbody projectile = Instantiate(projectilePrefab, spawnPoint, projectileRotation).GetComponent<Rigidbody>();
            projectile.velocity = projectile.transform.forward * ProjectileSpeed;
        }

        // play sound
        // particle

        OnFired?.Invoke(ProjectileCount);
    }

    private void OnDrawGizmosSelected() => Gizmos.DrawSphere(muzzle.position, .02f);
}
