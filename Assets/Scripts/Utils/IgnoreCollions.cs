using UnityEngine;

public class IgnoreCollions : MonoBehaviour
{
    [SerializeField] private Collider thisCollider;
    [SerializeField] private Collider[] colliderToIgnore;

    private void Start()
    {
        foreach (Collider item in colliderToIgnore)
        {
            Physics.IgnoreCollision(thisCollider, item, true);
        }
    }
}
