using UnityEngine;

public class ProjectileTEST : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Animator>().enabled = false;
        }
    }
}
