using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnControll : MonoBehaviour
{
    public GameObject setObject, player;
    public AudioSource sound;
    public AudioClip clip;

    private bool soundControll = true;

    void Start()
    {
        soundControll = true;
        setObject.SetActive(false);
    }


    void Update()
    {
        Respawn();
        if (player == null && soundControll)
        {
            sound.PlayOneShot(clip);
            soundControll = false;
        }
    }

    void Respawn()
    {

        if (player == null)
        {
            setObject.SetActive(true);
          
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

}
