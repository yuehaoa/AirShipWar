using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class GameManager : MonoBehaviour
{
    static public AudioSource bgAudio;
    float _timer;
    bool pause = false;
    
    // Start is called before the first frame update
    void Start()
    {
        bgAudio = transform.GetComponent<AudioSource>();
        bgAudio.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeGameSpeed()
    {
        if (!pause)
        {
            Time.timeScale = 1;
            bgAudio = transform.GetComponent<AudioSource>();
            bgAudio.Play();
        }
        else
        {
            Time.timeScale = 0;
            bgAudio = transform.GetComponent<AudioSource>();
            bgAudio.Stop();
        }
        pause = !pause;
    }

    public void ChangeMusicState()
    {
        bgAudio = transform.GetComponent<AudioSource>();
        if (bgAudio.isPlaying)
        {
            bgAudio.Stop();
        }
        else
        {
            bgAudio.Play();
        }
    }
}
