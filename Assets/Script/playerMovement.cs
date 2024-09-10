using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    Rigidbody rb;
    [SerializeField] float moveSpeed = 10;
    [SerializeField] Material[] materials;
    MeshRenderer mr;
    [SerializeField] GameObject gameOverUI, TapToPlay;
    [SerializeField] ParticleSystem particle;
    [SerializeField] Material material;
    public enum PlayerState
    {
        prepare,
        Playing,
        Finish,
        Dead
    }
    bool ChangeColor = false;
    int TimeToChangeColor = 5;

    [HideInInspector]
    public PlayerState playerState = PlayerState.prepare;
    // Start is called before the first frame update
    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        rb = GetComponent<Rigidbody>();

        switch (Random.Range(0, 3))
        {
            case 0:
                mr.material.color = Color.blue;
                gameObject.tag = "BlueBall";
                material.color = Color.blue;
                break;
            case 1:
                mr.material.color = Color.red;
                gameObject.tag = "RedBall";
                material.color = Color.red;
                break;
            case 2:
                mr.material.color = Color.green;
                gameObject.tag = "GreenBall";
                material.color = Color.green;
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerState == PlayerState.prepare)
        {
            if (Input.GetMouseButton(0))
            {
                playerState = PlayerState.Playing;
                TapToPlay.SetActive(false);
            }
        }
        if (playerState == PlayerState.Playing)
        {
            float movement = Input.GetAxis("Horizontal");
            rb.velocity = new Vector3(movement * moveSpeed, rb.velocity.y);

            if (GameManager.instance.score >= TimeToChangeColor)
            {
                ChangeColor = true;
                TimeToChangeColor += 5;
            }
            if (ChangeColor == true)
            {

                ChangeColor = false;

                if (gameObject.tag == "BlueBall")
                {
                    switch (Random.Range(0, 2))
                    {
                        case 0:
                            mr.material.color = Color.green;
                            gameObject.tag = "GreenBall";
                            material.color = Color.green;
                            break;
                        case 1:
                            mr.material.color = Color.red;
                            gameObject.tag = "RedBall";
                            material.color = Color.red;
                            break;
                    }
                }
                else if (gameObject.tag == "GreenBall")
                {
                    switch (Random.Range(0, 2))
                    {
                        case 0:
                            mr.material.color = Color.blue;
                            gameObject.tag = "BlueBall";
                            material.color = Color.blue;
                            break;
                        case 1:
                            mr.material.color = Color.red;
                            gameObject.tag = "RedBall";
                            material.color = Color.red;
                            break;
                    }
                }
                else if (gameObject.tag == "RedBall")
                {
                    switch (Random.Range(0, 2))
                    {
                        case 0:
                            mr.material.color = Color.green;
                            gameObject.tag = "GreenBall";
                            material.color = Color.green;
                            break;
                        case 1:
                            mr.material.color = Color.blue;
                            gameObject.tag = "BlueBall";
                            material.color = Color.blue;
                            break;
                    }
                }

            }
        }
        if (playerState == PlayerState.Dead)
        {
            gameObject.SetActive(false);
            gameOverUI.SetActive(true);
        }

    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "BlueBall" && gameObject.tag == "BlueBall")
        {
            GameManager.instance.score += 1;

            Destroy(other.gameObject, 0.05f);

        }
        else if (other.gameObject.tag == "RedBall" && gameObject.tag == "RedBall")
        {
            GameManager.instance.score += 1;
            Destroy(other.gameObject, 0.05f);

        }
        else if (other.gameObject.tag == "GreenBall" && gameObject.tag == "GreenBall")
        {
            GameManager.instance.score += 1;
            Destroy(other.gameObject, 0.05f);

        }

        else
        {
            playerState = PlayerState.Dead;
            Instantiate(particle, transform.position, Quaternion.identity);
        }
    }

}
