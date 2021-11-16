using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public float intervalStart, intervalEnd, timeDay, interval;
    //Allan's comments here for you
    //timeDay = length of day in seconds
    //intervalStart and End are the interval that the sound can start and end.
    //make sure to give it a decent amount of time so it doesn't miss the queue.
    //interval is the time inbetween each sound.
    public AudioSource Noise;//drag the noise into the references
    //make more here for each new noise. Name them not shittly.


    private float nextTime, soundLength;
    private Animator sozuAnimation;
    [SerializeField] private GameObject sozu;
    private float TimeOfDay;
    void Start()
    {
        soundLength = Noise.clip.length;
    }
    // Update is called once per frame
    void Update()
    {

        float temp = Time.time % timeDay;
        //temp is how many seconds you are into a new day.

        //template for noise:
        if (temp > intervalStart && temp < intervalEnd && nextTime < temp)
        {
            if (!Noise.isPlaying)
            {
                nextTime = (temp + soundLength + interval) % timeDay;
                Noise.Play();
            }

        }


    }
}
