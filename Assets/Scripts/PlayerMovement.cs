using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed;
    public Rigidbody player_obj;
    public float jumpForce;
    
    void Start()
    {
        player_obj = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        player_obj.velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, player_obj.velocity.y, Input.GetAxis("Vertical") * moveSpeed);

        if(Input.GetButtonDown("Jump")){
            player_obj.velocity = new Vector3(player_obj.velocity.x, jumpForce, player_obj.velocity.z);
        }
    }
}
