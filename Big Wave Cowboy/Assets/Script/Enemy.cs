using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform playerPos;
    private Rigidbody2D rb;

    public float enemyVelocity;
    public int life, maxLife;
    // Start is called before the first frame update
    void Start()
    {
        life = maxLife;
        rb = GetComponent<Rigidbody2D>();
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerPos.transform.position, enemyVelocity * Time.fixedDeltaTime);
        EnemyLife();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullets")
        {
            life -= 10;
        }
    }

    void EnemyLife()
    {
        if(life <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
