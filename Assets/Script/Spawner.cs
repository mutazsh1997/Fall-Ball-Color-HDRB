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
    private Vector3 screenBounds;
    private playerMovement player;

    private void Awake()
    {
        level = PlayerPrefs.GetInt("Level", 1);

        if (level <= 20)
            ballonScale = 0.8f;
        if (level > 20 && level <= 50)
            ballonScale = 0.9f;
        if (level > 50 && level <= 100)
            ballonScale = 1f;
        if (level > 100)
            ballonScale = 1.1f;

    }

    // Start is called before the first frame update
    void Start()
    {
        //screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        //EdgeScrren = screenBounds.x - 0.3f;
        player = FindObjectOfType<playerMovement>();
    }

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
