using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject pauseUI;
    private AudioSource audioSource;
    private float test;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(Time.timeScale == 1)
            {
                //stop
                Time.timeScale = 0;
                pauseUI.SetActive(true);
                audioSource.Pause();
            }
            else
            {
                //continue
                Time.timeScale = 1;
                pauseUI.SetActive(false);
                audioSource.UnPause();

            }
        }
    }
}
