using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TakeDamage : MonoBehaviour
{
    //[SerializeField] public int health;
    [SerializeField] private int health;
    private int curHealth;
    [SerializeField] private HealthBar healthBar;

    private int coins = 0;
    public AudioClip audioClip;
    private AudioSource audioSource;

    private float lastDamageTime = 0f;
    private float damageCooldown = 0.5f;

    //public CoinsScript coinsScript;// = GetComponent<CoinsScript>();
    public GameOverScreen gameOverScreen;

    public TextMeshProUGUI coinsTexts;
    public string sceneName;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        curHealth = health + 1;
        healthBar.UpdateHealthBar(health, curHealth);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            coins++;
            coinsTexts.text = coins.ToString();

            audioSource.PlayOneShot(audioClip);

            Debug.Log("Picked up coin");
            Destroy(collision.gameObject);

            if (coins >= 15)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                SceneManager.LoadScene(sceneName);
            }

        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy") && Time.time - lastDamageTime > damageCooldown)
        {
            lastDamageTime = Time.time;
            curHealth--;
            healthBar.UpdateHealthBar(health, curHealth);
            Debug.Log($"Health: {curHealth}/{health}");

            if (curHealth <= 1)
            {
                gameOverScreen.Setup(coins);
                Debug.Log("Player Dead");
            }
        }
    }
}
