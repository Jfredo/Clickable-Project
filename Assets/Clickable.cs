using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour
{

    public float minInterval, maxInterval;
    public AnimationSet[] animationSets;

    Animator myAnimator;
    bool isClickable;
    int index;
    float timeStamp;
    Score score;

    [System.Serializable]
    public class AnimationSet
    {
        public string birth, death;
        public int scorePoints, statPoints, statIndex;
    }

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!isClickable) //isClickable ==false
        {

            if (timeStamp == 0) //Randomly set new futrue timestamp
            {
                timeStamp = Random.Range(minInterval, maxInterval) + Time.time;
            }

            if (timeStamp <= Time.time) //Birth
            {
                isClickable = true;
                timeStamp = 0;

                index = Random.Range(0, animationSets.Length);

                myAnimator.Play(animationSets[index].birth, -1, 0);
            }
        }
    }
    private void OnMouseDown()
    {
        if (isClickable)
        {
            myAnimator.Play(animationSets[index].death, -1, 0);

            score.points += animationSets[index].scorePoints; //Score

            if (animationSets[index].statPoints != 0)//Stats
            {
                int i = animationSets[index].statIndex;
                score.stats[i].points += animationSets[index].statPoints;
            }

            isClickable = false;
        }
    }
    public void DeactivateClickable()
    {
        isClickable = false;
    }
}