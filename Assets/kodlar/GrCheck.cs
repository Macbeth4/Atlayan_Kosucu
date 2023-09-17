using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrCheck : MonoBehaviour
{
    public bool isGrounded;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("zemin"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("zemin"))
        {
            isGrounded = false;
        }
    }
}
