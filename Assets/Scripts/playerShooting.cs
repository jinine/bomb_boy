using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class playerShooting : MonoBehaviour
{

    [SerializeField] private CinemachineFreeLook aimCamera;
    public GameObject crosshair;
    private Animator animator;

    void Start(){
         animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        if(Input.GetButton("Aim")){
            animator.SetBool("aiming", true);
            aimCamera.gameObject.SetActive(true);
            crosshair.gameObject.SetActive(true);
        } else{
            animator.SetBool("aiming", false);
            aimCamera.gameObject.SetActive(false);
            crosshair.gameObject.SetActive(false);
        }
    }
}
