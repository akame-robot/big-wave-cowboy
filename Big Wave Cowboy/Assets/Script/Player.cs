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
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            life -= 10;
        }
    }
}
