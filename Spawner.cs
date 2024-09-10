using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    public GameObject[] Ball;
    public GameObject[] EnemyBall;
    float start;
    public int level = 1;
    public float ballonScale;

    [SerializeField]private float EdgeScrren;
    private playerMovement player;

   

    // Update is called once per frame
    void Update()
    {
        if (player.playerState == playerMovement.PlayerState.Playing)
        {
            start += Time.deltaTime;
            if (start >= 0.8f)
            {
                Invoke("Balls", 0);
                start = 0;
            }
        }
    }
    void Balls()
    {

        Vector3 posToSpawn = new Vector3(Random.Range(-EdgeScrren, EdgeScrren), transform.position.y, transform.position.z);

        switch (Random.Range(0,1))
        {
            case 0:
                Instantiate(Ball[Random.Range(0, Ball.Length)], posToSpawn, Quaternion.identity);
                break;
            case 1:
                Instantiate(EnemyBall[Random.Range(0, EnemyBall.Length)], posToSpawn, Quaternion.identity);
                break;
        }
    }

   
}
