using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public float pVelocity;

    private Vector2 playerVelocity;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

   
    void FixedUpdate()
    {
        PlayerWalk();
    }

    public void PlayerWalk()
    {
        Vector2 pWalk = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        playerVelocity = pWalk.normalized * pVelocity;
        rb.MovePosition(rb.position +  playerVelocity * Time.fixedDeltaTime);
    }
}
