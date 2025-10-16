using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        if (animator == null)
        {
            Debug.LogError("Animator component not found on " + gameObject.name);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && animator != null) // Only the player triggers this
        {
            animator.SetTrigger("door-open");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && animator != null) // Only the player triggers this
        {
            animator.SetTrigger("door-close");
        }
    }
}