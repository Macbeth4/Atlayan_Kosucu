using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parasp : MonoBehaviour
{

    public gameManager managergame;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "coin")
        {
            managergame.Updatepara();
            float x = Random.Range(4f, 4f);
            float y = Random.Range(-2f, -1.5f);
            transform.position = new Vector3(x, y);
        }
    }
}

