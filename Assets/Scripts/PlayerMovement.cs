using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 5f;
    public float gravity = -100;
    public float jumpHeight = 3f;
    public float speedBoost = 10f;

    Vector3 velocity;

    public Animator animator;

    float walkingV;
    
    float running;
   
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float waterDistance = 0.4f;
    public LayerMask waterMask;
    bool isGrounded;
    bool isWatered;

    public Crafting crafting;

    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
     //   isWatered = Physics.CheckSphere(groundCheck.position, waterDistance, waterMask);
        
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

     /*   if (isWatered && crafting.boatCrafted)
        {
            Debug.Log("You Win!");
        }
     */

        float x = Input.GetAxis("Horizontal");
        //float z = Input.GetAxis("Vertical");


        running = Input.GetAxis("Vertical");
        
        //animator.SetFloat("Running", Mathf.Abs(running));

        walkingV = Input.GetAxis("Vertical");

        animator.SetFloat("Walking", Mathf.Abs(walkingV));

        
        //animator.SetFloat("Walking", walking);

        Vector3 move = transform.right * x + transform.forward * walkingV;
        controller.Move(move * speed * Time.deltaTime);



        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            animator.SetFloat("Running", running);
            speed += speedBoost;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {

            animator.SetFloat("Running", 0f);
            speed -= speedBoost;
        }

        
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);        
    }

  /*  public void deployBoat()
    {
        Debug.Log("Boat Deployed");
    }
  */
}
