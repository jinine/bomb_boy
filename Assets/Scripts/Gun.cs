using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    [SerializeField][Range(0.5f,1.5f)] private float fireRate =1;

    [SerializeField][Range(1,10)]private int damage =1;

    private float timer;

    [SerializeField] private Transform firePoint;
    
    void Update()
    {
        timer += Time.deltaTime;
        if(timer>=fireRate){
            if(Input.GetButton("Fire1")){
                timer = 0f;
                FireGun();
            }
        }
    }

    private void FireGun(){
        Debug.DrawRay(firePoint.position, firePoint.forward * 100, Color.red, 2f);
    }
}
