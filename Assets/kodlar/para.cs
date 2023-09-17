using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class para : MonoBehaviour
{
    public gameManager managergame;

    private async void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {

            managergame.Updatepara();
            float x = Random.Range(5f, 10f);
            float y = Random.Range(-1f, -1.9f);
            transform.position = new Vector3(x, y);

        }

        if (collision.gameObject.tag == "isinlayici")
        {
            await Task.Delay(10000);
            float xpos = Random.Range(5f, 10f);
            float ypos = Random.Range(-1f, -1.9f);
            transform.position = new Vector2(xpos, ypos);
        }
    }

    private void Update()
    {
        transform.position += Vector3.left * gameManager.Instance.gameSpeed * Time.deltaTime;
    }

}
