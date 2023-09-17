using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class karakter : MonoBehaviour
{

    public float velocity = 1f;
    public Rigidbody2D rb2D;
    public GrCheck groundcheck;
    public Animator animator;
    public gameManager managergame;
    private gameManager gameManagerInstance;


    public bool isdead;
    public GameObject deadscreen;


    private void Start()
    {

        Time.timeScale = 1;
        gameManagerInstance = FindObjectOfType<gameManager>();
    }

     void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("zýplama", true);
            Jump();
           
        }
        if (Mathf.Approximately(rb2D.velocity.y, 0) && animator.GetBool("zýplama"))
        {
            animator.SetBool("zýplama", false);
        }
        

    }

    private void Jump()
    {
        if(groundcheck.isGrounded == true)
        {
            rb2D.AddForce(new Vector2(0f, velocity), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "DeadArea")
        {
       
            Time.timeScale = 0;
            isdead = true;
            deadscreen.SetActive(true);
            gameManagerInstance.UpdateHiscore(); 

        }
    }

}