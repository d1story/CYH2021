using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public float intervalStart, intervalEnd, timeDay, interval;
    public AudioSource Noise;
    private float nextTime, soundLength;
    void Start()
    {
        soundLength = Noise.clip.length;
    }
    // Update is called once per frame
    void Update()
    {
        float temp = Time.time;
        if (temp > intervalStart && temp< intervalEnd&& nextTime < temp)
        {
            nextTime = temp + soundLength + interval;
            Noise.Play();
        }
    }
}
