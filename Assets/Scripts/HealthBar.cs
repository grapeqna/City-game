using UnityEngine;
using UnityEngine.UI; // Added this to recognize 'Image'

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _healthbarSprite; // Ensure it's assigned in Inspector

    public void UpdateHealthBar(float maxHealth, float currentHealth)
    {
        if (_healthbarSprite != null) 
        {
            _healthbarSprite.fillAmount = Mathf.Clamp01(currentHealth / maxHealth);
           // _healthbarSprite.fillAmount = currentHealth / maxHealth;
        }
        else
        {
            Debug.LogError("HealthBar Image is not assigned in the Inspector!");
        }
    }
}