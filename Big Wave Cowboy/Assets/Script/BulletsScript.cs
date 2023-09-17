using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;

public class BulletsScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 bulletFollow;

    public float velocity;
    public int damage;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bulletFollow = GameObject.Find("BulletEnd").transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        Bullet();
    }

    void Bullet()
    {
        transform.position = Vector2.MoveTowards(transform.position, bulletFollow, velocity * Time.deltaTime);
        Destroy(gameObject, 5);
    }
}
