using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GoToTargetPos : MonoBehaviour
{
    public int health = 3;
    public int currHealth;

    //public Animator zombieAnim;
    Transform target;
    private Animator enemyAnimator;
    [SerializeField] float speed;//set in Unity
    [SerializeField] private HealthBar _healthBar;
  
    public AudioClip audioClip;
    private AudioSource audioSource;
  
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        currHealth = health;
        _healthBar.UpdateHealthBar(health, currHealth);

        target = GameObject.FindGameObjectWithTag("Player").transform;
        Vector3 direction = target.position - transform.position;
        //calculate
        Debug.Log(direction);

        enemyAnimator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {

        Vector3 direction = new Vector3(target.position.x - transform.position.x,
        0, target.position.z - transform.position.z);

        direction = direction.normalized;
        transform.position += direction * speed * Time.deltaTime;

        //transform.LookAt(direction);
        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f); // Smooth rotation
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Attack"))
        {
            //audioSource.PlayOneShot(audioClip);

            currHealth--;
            Debug.Log("Enemy hitted");
            _healthBar.UpdateHealthBar(health, currHealth);


            if (enemyAnimator != null)
            {
                enemyAnimator.SetTrigger("Hit"); 
            }

            Destroy(other.gameObject);
          TransitionToWalkingAfterHit();

            if (currHealth <= 0)
            {
                Debug.Log("Enemy destryed");
                Destroy(gameObject);
            }
        }
    }

    private void TransitionToWalkingAfterHit()
    {
        // Wait for the duration of the "Hit" animation
        // Adjust the wait time based on the length of the "Hit" animation
       // yield return new WaitForSeconds(1f); // Assuming the hit animation takes 1 second. Adjust as needed.

        if (enemyAnimator != null)
        {
            // Trigger the "Walk" animation after the hit animation finishes
            enemyAnimator.SetTrigger("Walk");
        }
    }

}
