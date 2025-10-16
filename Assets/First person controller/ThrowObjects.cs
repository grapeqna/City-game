using System.Collections;
using UnityEngine;

public class ThrowObjects : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileSpeed = 40f;
    public GameObject heldObject;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            heldObject.SetActive(false);

            GameObject projectile = Instantiate(projectilePrefab, transform.position + transform.forward * 1.5f + new Vector3(0, 1.5f, 0), transform.rotation);
           

            Rigidbody rb = projectile.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddForce(transform.forward * projectileSpeed, ForceMode.Impulse); // Apply force instead of setting velocity
            }
           
        StartCoroutine(ReactivateHeldObject());
        }
    }

    private IEnumerator ReactivateHeldObject()
    {
        // Wait for 1 second
        yield return new WaitForSeconds(0.25f);

        // Reactivate the heldObject
        heldObject.SetActive(true);
    }
    
}
