using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource sound;
    private float timer;
    private float life;
    void Start()
    {
        sound = gameObject.GetComponent<AudioSource>();
        life = sound.clip.length;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > life)
        {
            Destroy(gameObject);
        }

    }
}
