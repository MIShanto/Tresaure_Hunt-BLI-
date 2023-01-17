using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI elapsedTimeText;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void SetTotalScore(float score)
    {
        PlayerPrefs.SetFloat("TotalScore", score);
    }
    void UpdateUI()
    {
        scoreText.text = PlayerPrefs.GetFloat("TotalScore", 0).ToString();
        elapsedTimeText.text = PlayerPrefs.GetFloat("ElapsedTime", 0).ToString();
    }
    public void OnExitButtonClick()
    {
        Application.Quit();
    }
    public void OnInstructionButtonClick()
    {
    }
    public void OnScoreButtonClick()
    {
        UpdateUI();
    }
}
