using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CannonProjectile : MonoBehaviour
{
    [SerializeField] private Rigidbody cannonBall;
    [SerializeField] private float velocity;

    private void Update()
    {
        ShootCannonBall();
    }

    private void ShootCannonBall()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Rigidbody projectile = Instantiate(cannonBall, transform.position, Quaternion.identity);

            projectile.AddForce(Vector3.forward * velocity, ForceMode.Impulse);
        }   
    }
}
