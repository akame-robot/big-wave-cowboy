using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullets;
    public Transform BulletOut1;
    public Transform BulletOut2;
    public float timeBetShoot;
    public AudioSource bulletSound;
    public AudioClip bulletClip;

    bool readyToShoot;

    void Start()
    {

    }

    private void Awake()
    {
        readyToShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        MousControll();
    }

    public void MousControll()
    {
        Vector3 cameraPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 screenPos = Input.mousePosition;
        Vector2 controll = new Vector2(screenPos.x - cameraPos.x, screenPos.y - cameraPos.y);
        float angle = Mathf.Atan2(controll.y, controll.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);

        if(Input.GetKey(KeyCode.Mouse0) && readyToShoot)
        {
            bulletSound.PlayOneShot(bulletClip);
            readyToShoot = false;
            Instantiate(bullets, BulletOut1.transform.position, Quaternion.identity);
            Instantiate(bullets, BulletOut2.transform.position, Quaternion.identity);
            Invoke("ResetShoot", timeBetShoot);
        }
    }
    public void ResetShoot ()
    {
        readyToShoot = true;        
    }
}
