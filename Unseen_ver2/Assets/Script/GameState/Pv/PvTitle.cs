using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using System;

public class PvTitle : MonoBehaviour {
    VideoPlayer videoPlayer;
    AudioSource audioSource;
    // Use this for initialization
    void Start()
    {
        videoPlayer = GameObject.Find("Plane").GetComponent<VideoPlayer>();
        audioSource = GameObject.Find("Plane").GetComponent<AudioSource>();
        audioSource.Play();
        videoPlayer.Play();
    }

    void Update()
    {
        ReturnTitle();
    }

    void ReturnTitle()
    {
        if (RecieveInput())
            SceneManager.LoadScene("Title", LoadSceneMode.Single);
    }

    bool RecieveInput()
    {
        foreach (KeyCode key in Enum.GetValues(typeof(KeyCode)))
        {
            if (key == KeyCode.Mouse0 || key == KeyCode.Mouse1 || key == KeyCode.Mouse2 ||
                key == KeyCode.Mouse3 || key == KeyCode.Mouse4 || key == KeyCode.Mouse5 || key == KeyCode.Mouse6)
                continue;
            if (Input.GetKeyDown(key))
                return true;
        }
        return false;
    }
}
