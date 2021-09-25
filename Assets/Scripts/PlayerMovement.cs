using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public CharacterController controller;
    //movement
    public float speed = 10f;
    private Rigidbody rigidBody;
    

    //gravity
    public float gravity = -9.81f;
    Vector3 velocity;

    //ground check
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded = true;


    //jump
    public float jumpHeight = 13f;
    public float VerticalVelocity;

    //camera
    private Camera playerCamera;





    // Start is called before the first frame update
    void Start()
    {
      playerCamera = transform.Find("Camera").GetComponent<Camera>();
      rigidBody = GetComponent<Rigidbody>();
    }//start

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0){
            velocity.y = -2f;

        }

      //movement
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * y;

        if(move != Vector3.zero){
            controller.Move(move * speed * Time.deltaTime);
        }
        //else{}
         
    }//update
    private void FixedUpdate() {
        jump();
    }
/* 
    private void FixedUpdate() {
        
        if(controller.isGrounded){
            VerticalVelocity = gravity * Time.deltaTime;

            if(Input.GetButtonDown("Jump")){
                VerticalVelocity = jumpHeight;
            }
        }else{
            VerticalVelocity += gravity * Time.deltaTime;
          

        }
          velocity = new Vector3(0f, VerticalVelocity, 0f);
            controller.Move(velocity * Time.deltaTime);
        


    }//fixedupdate */

    void jump(){
        if(Input.GetButtonDown("Jump") && isGrounded){
            isGrounded = false;
            rigidBody.AddForce(new Vector3(0f, jumpHeight, 0f), ForceMode.Impulse);

        }
    }


}
