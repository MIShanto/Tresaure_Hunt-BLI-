using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    public int targetNumber;
    public float score, noPenaltyTimeInSecond, maxTimeLimitInSecond;
    public void ProvideScore()
    {
        if (PlayerPrefs.GetFloat(targetNumber.ToString(), 0f) == 0f)
        {
            //give scrore based on elapsed time..
            if (Time.time > noPenaltyTimeInSecond && Time.time <= maxTimeLimitInSecond)
            {
                var penalty = (score / (maxTimeLimitInSecond - noPenaltyTimeInSecond)) * (Time.time - noPenaltyTimeInSecond);

                score -= penalty;
            }
            else if(Time.time > maxTimeLimitInSecond)
            {
                score = 0;
            }

            PlayerPrefs.SetFloat(targetNumber.ToString(), score);

            PlayerPrefs.SetFloat("ElapsedTime", Time.time);

            GameManager.instance.SetTotalScore(score);
        }
    }
}
