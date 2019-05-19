using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rigid;
    public Animator animator;
    public Vector2 movement;
    public float movementSpeed = 1f; 
    public float rollSpeed = 18f;
    private bool canRoll = true;
    private bool canAttack = true;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if(movement != Vector2.zero)
        {
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
        }
        
        animator.SetFloat("Magnitude", movement.magnitude);

        Move();

        if (Input.GetKeyUp("w"))
        {
            animator.SetTrigger("IdleUp");
        }

        if (Input.GetKeyDown("space"))
        {
            if (canAttack)
            {
                animator.SetTrigger("Attack");
                canAttack = false;

            }
            canAttack = true;
        }
        if (Input.GetButtonDown("Roll"))
        {
 
                animator.SetTrigger("Roll");
                Roll();
                canRoll = false;

        }


    }

    void Move()
    {
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if(movement.magnitude > 1f)
        {
            movement.Normalize();
        }
        rigid.velocity = movement * movementSpeed;


    }
    void Roll()
    {
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        
        rigid.velocity = movement * rollSpeed;
        
        
    }

}
