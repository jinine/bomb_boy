using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private int startingHealth = 100;
    private int currentHealth;

    public Healthbar healthbar;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable() {
        currentHealth = startingHealth;
        healthbar.SetMaxHealth(startingHealth);
    }

    public void TakeDamage(int damage){
        currentHealth -= damage;
         animator.SetBool("takeDamage", true);
        healthbar.SetHealth(currentHealth);
        if(currentHealth<=0){
            Die();
        }
    }

    private void Die(){
        animator.SetBool("dying", true);
       
        if(gameObject.tag == "player"){
            Application.LoadLevel(0);
        } else{
            gameObject.SetActive(false);
        }
    }

    private void Update() {
        if(gameObject.transform.position.y < -30){
            Die();
        }
        
    }

}
