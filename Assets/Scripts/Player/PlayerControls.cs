using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer), typeof(Animator))]

public class PlayerControls : MonoBehaviour
{
    public bool TestMode = false;

    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;

    [SerializeField] public float speed = 7.0f;
    [SerializeField] private float jumpForce = 300.0f;
    [SerializeField] public bool isGrounded;
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private LayerMask isGroundLayer;
    [SerializeField] private float groundCheckRadius = 0.02f;
    [SerializeField] private bool isPogoOut;

    [SerializeField] public bool hasPogo = false; //Toggled when player owns the pogo stick
    [SerializeField] public bool hasCrown = false; //Toggled when player owns the crown



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>(); 
        anim = GetComponent<Animator>();

        if (speed <= 0)
        {
            speed = 7.0f;
            if (TestMode) Debug.Log("speed has a default value of 7.0f" + gameObject.name);
        }



        if (GroundCheck == null)
        {
            GameObject obj = new GameObject();
            obj.transform.SetParent(gameObject.transform);
            obj.transform.localPosition = Vector3.zero;
            obj.name = "GroundCheck";
            GroundCheck = obj.transform;
            if (TestMode) Debug.Log("GroundCheck object is created" + obj.name);
        }

        if (groundCheckRadius <= 0)
        {
            groundCheckRadius = 0.02f;
            if (TestMode) Debug.Log("groundcheckradius was set to 0.02");
        }


    }

    // Update is called once per frame
    void Update()
    {
        //Move
        float xInput = Input.GetAxisRaw("Horizontal");

        //Jump
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, groundCheckRadius, isGroundLayer);
        rb.velocity = new Vector2(xInput * speed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        //Punch
        if(hasCrown == false)
        {
            if (Input.GetButtonDown("Fire2") && isGrounded)
            {

                anim.SetTrigger("Attack");

            }
        }
        else 
        {
            if (Input.GetButtonDown("Fire2") && isPogoOut == false)
                anim.SetTrigger("SpecialAttack");
          
        }

        if(hasPogo == true)
        {
            //Take out pogo 
            if (Input.GetKeyUp(KeyCode.B) && isPogoOut == false && isGrounded)
            {
                anim.SetBool("IsPogoOut", isPogoOut = true);
                anim.SetTrigger("SpecialItem");
                speed = 8f;
                jumpForce = 15f;

            }

            //Put away pogo
            else if (Input.GetKeyUp(KeyCode.B) && isPogoOut == true)
            {
                anim.SetBool("IsPogoOut", isPogoOut = false);
                anim.SetTrigger("SpecialItem");
                speed = 5f;
                jumpForce = 10.5f;
            }
        }

      
            


        //anim.SetBool("Punch", punch);
        anim.SetBool("IsGrounded", isGrounded);
        anim.SetFloat("Speed", Mathf.Abs(xInput));


        // sprite flipping
        if (xInput != 0) sr.flipX = xInput < 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //activates pogo controls
        if (collision.gameObject.tag == "Pogo")
        {
            Destroy(collision.gameObject);
            hasPogo = true;
        }

        //activates crown controls
        if (collision.gameObject.tag == "Crown")
        {
            Destroy(collision.gameObject);
            hasCrown = true;
        }
    }

  
}

