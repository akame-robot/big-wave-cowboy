using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private bool invoking = true;
    private int timer;
    public GameObject enemy;

    public Transform playerPos;
    private float minDistanceToPlayer = 5f;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        if (playerPos == null)
        {
            Destroy(GameObject.FindWithTag("Enemy"));
        }
    }

    IEnumerator SpawnEnemy()
    {
        while(invoking)
        {
            timer = Random.Range(2, 3);
            yield return new WaitForSeconds(timer);
            float x = Random.Range(-8.9f, 10.9f);
            float y = Random.Range(-8.9f, 10.9f);
            Vector2 spawnEnemy = new Vector2(x,y);
            if (Vector3.Distance(spawnEnemy, playerPos.position) > minDistanceToPlayer)
            {
            Instantiate(enemy, spawnEnemy, Quaternion.identity);

            }

        }
    }
}
