using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private bool invoking = true;
    private int timer = 5;
    public GameObject enemy;

    public Transform playerPos;
    private float minDistanceToPlayer = 5f;
    private int enemyLeght = 5;
    private int enemyKilled = 0;
    public bool enemyDeath = false;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
        Debug.Log(timer);
    }

    void Update()
    {
        if (playerPos == null)
        {
            Destroy(GameObject.FindWithTag("Enemy"));
        }
        if (enemyKilled == enemyLeght)
        {
            Debug.Log("entrou no enemy;");
            enemyLeght += 5;
            timer--;
            enemyKilled = 0;
            if (timer <= 1)
            {
                timer = 1;
            }
        }

    }

    IEnumerator SpawnEnemy()
    {
        while (invoking)
        {

            yield return new WaitForSeconds(timer);
            float x = Random.Range(-8.9f, 10.9f);
            float y = Random.Range(-8.9f, 10.9f);
            Vector2 spawnEnemy = new Vector2(x, y);
            if (Vector3.Distance(spawnEnemy, playerPos.position) > minDistanceToPlayer)
            {
                Instantiate(enemy, spawnEnemy, Quaternion.identity);

            }
        }
    }
    public void EnemyDeafeated()
    {
        Debug.Log("entrou aqui");
        enemyDeath = true;
        if (enemyDeath == true)
        {
            Debug.Log("destruido");
            enemyKilled += 1;
            enemyDeath = false;
        }
    }
}
