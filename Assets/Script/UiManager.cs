using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{

    public Text ScoreTxt;

    private void Update()
    {
        ScoreTxt.text = GameManager.instance.score.ToString();
    }
    public void RestartGame()
    {
         GameManager.instance.score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
