using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    string SaveScore = "SaveScore";
    string SaveHeightScore = "SaveHeightScore";

    [Header("�C���̰�����")]
    public Text HeightScoreText;
    [Header("�C������")]
    public Text ScoreText;

    private void Awake()
    {
        if (PlayerPrefs.HasKey(SaveHeightScore))
        {
            if (PlayerPrefs.GetInt(SaveScore) > PlayerPrefs.GetInt(SaveHeightScore))
            {

                PlayerPrefs.SetInt(SaveHeightScore, PlayerPrefs.GetInt(SaveScore));
                HeightScoreText.text = "HeightScore:" + PlayerPrefs.GetInt(SaveScore);
                ScoreText.text = "Score:" + PlayerPrefs.GetInt(SaveScore);
            }
            else
            {
                HeightScoreText.text = "HeightScore:" + PlayerPrefs.GetInt(SaveHeightScore);
                ScoreText.text = "Score:" + PlayerPrefs.GetInt(SaveScore);
            }
        }
        else
        {
            PlayerPrefs.SetInt(SaveHeightScore, PlayerPrefs.GetInt(SaveScore));
            HeightScoreText.text = "HeightScore:" + PlayerPrefs.GetInt(SaveScore);
            ScoreText.text = "Score:" + PlayerPrefs.GetInt(SaveScore);
        }



    }
}
