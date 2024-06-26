using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public float pVelocity;
    public int life, maxLife;


    private Vector2 playerVelocity;

    
    void Start()
    {
        life = maxLife;
        rb = GetComponent<Rigidbody2D>();   
    }

   
    void FixedUpdate()
    {
        PlayerWalk();
        PLayerLife();
        PlayerOffCamera();
    }

    public void PlayerWalk()
    {
        Vector2 pWalk = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        playerVelocity = pWalk.normalized * pVelocity;
        rb.MovePosition(rb.position +  playerVelocity * Time.fixedDeltaTime);
    }
    
    void PLayerLife()
    {
        if (life <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            life -= 10;
        }
    }

    void PlayerOffCamera()
    {
        if (transform.position.x >= 7.46f)
        {
            transform.position = new Vector3(7.46f, transform.position.y, transform.position.z);
        }
        if (transform.position.x <= -7.46f)
        {
            transform.position = new Vector3(-7.46f, transform.position.y, transform.position.z);
        }
        if (transform.position.y >= 4.5f)
        {
            transform.position = new Vector3(transform.position.x, 4.5f, transform.position.z);
        }
        if (transform.position.y <= -4.5f)
        {
            transform.position = new Vector3(transform.position.x, -4.5f, transform.position.z);
        }
    }
}
