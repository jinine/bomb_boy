using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int startingHealth = 100;
    private int currentHealth;

    public Healthbar healthbar;

    private void OnEnable() {
        currentHealth = startingHealth;
        healthbar.SetMaxHealth(startingHealth);
    }

    public void TakeDamage(int damage){
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
        if(currentHealth<=0){
            Die();
        }
    }

    private void Die(){
        gameObject.SetActive(false);
    }

}
