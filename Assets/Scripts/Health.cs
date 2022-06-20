using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int startingHealth = 5;
    private int currentHealth;

    private void OnEnable() {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int damage){
        currentHealth -= damage;
        if(currentHealth<=0){
            Die();
        }
    }

    private void Die(){

    }

    void Update()
    {
        gameObject.SetActive(false);
    }
}
