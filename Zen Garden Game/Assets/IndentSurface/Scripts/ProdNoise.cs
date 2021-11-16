using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProdNoise : MonoBehaviour
{
    private float nextPlayed;
    public AudioSource Noise;
    public float rate;
    // Start is called before the first frame update
    void Start()
    {
        nextPlayed = -1f;
    }
    // Update is called once per frame
    public void playNoise()
    {
        if (!Noise.isPlaying && Time.time > nextPlayed)
        {
            nextPlayed = Time.time + rate;
            Noise.Play();
        }
    }
}
