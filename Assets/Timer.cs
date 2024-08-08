using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{ 
    public TMP_Text timer;
    public float duration;
    public Animator gameOverAnimator;
    public string gameOverClipName;

    bool gameOver;

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            duration -= Time.deltaTime;
            duration = Mathf.Clamp(duration, 0, Mathf.Infinity);
            timer.text = Mathf.Ceil(duration) + "";

            if (duration == 0)
            {
                gameOverAnimator.Play(gameOverClipName);
                gameOver = true;
            }
        }
    }
}
