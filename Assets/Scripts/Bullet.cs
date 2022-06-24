using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject explosion;
    public LayerMask whatIsEnemies;

    [Range(0f, 1f)]public float bounciness;
    public bool useGravity;

    public int explosionDamage;
    public float explosionRange;

    public int maxCollisions;
    public float maxLifetime;
    public bool explodeOnTouch = true;

    int collisions;

    PhysicMaterial physics_mat;

    private void Start(){
        Setup();
    }

    private void Update(){
        if(collisions> maxCollisions) Explode();

        maxLifetime -= Time.deltaTime;
        if(maxLifetime <= 0) Explode();
    }

    private void Explode(){
        if(explosion != null) Instantiate(explosion, transform.position, Quaternion.identity);

        Collider[] enemies = Physics.OverlapSphere(transform.position, explosionRange, whatIsEnemies);

        for(int i=0;i<enemies.Length; i++){
            enemies[i].GetComponent<Health>().TakeDamage(explosionDamage);
        }

        Invoke("Delay", 0.05f);
    }

    private void Delay(){
       Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.collider.CompareTag("Bullet")) return;

        collisions++;

        if(collision.collider.CompareTag("Enemy") && explodeOnTouch) Explode();
    }

    private void Setup(){
        physics_mat = new PhysicMaterial();
        physics_mat.bounciness = bounciness;
        physics_mat.frictionCombine = PhysicMaterialCombine.Minimum;
        physics_mat.bounceCombine = PhysicMaterialCombine.Maximum;

        GetComponent<SphereCollider>().material = physics_mat;

        rb.useGravity = useGravity;
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRange);
    }

}
