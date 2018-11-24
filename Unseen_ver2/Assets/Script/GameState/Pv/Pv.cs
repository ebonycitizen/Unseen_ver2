using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Pv : MonoBehaviour {
    const long allowInputFrame = 10;

    VideoPlayer videoPlayer;
    AudioSource audioSource;

	// Use this for initialization
	void Start () {
        videoPlayer = GameObject.Find("Plane").GetComponent<VideoPlayer>();
        audioSource = GameObject.Find("Plane").GetComponent<AudioSource>();
        audioSource.Play();
        videoPlayer.Play();
	}
	
    void Update()
    {
        if (videoPlayer.frame <= allowInputFrame)
            return;

        UnloadInput();
        UnloadEndPlay();
    }

    void UnloadEndPlay()
    {
        if ((ulong)videoPlayer.frame >= videoPlayer.frameCount)
            SceneManager.LoadScene(RecordOldScene.Instance.oldScene);
    }

    void UnloadInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //SoundManager.PlayPlayerSe("cancelSe");
            SceneManager.LoadScene(RecordOldScene.Instance.oldScene);
        }
    }
}
