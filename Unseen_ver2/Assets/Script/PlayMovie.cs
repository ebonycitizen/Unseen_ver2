using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class PlayMovie : MonoBehaviour
{
    VideoPlayer movie;
    AudioSource audioSource;
    bool startPlay;

    StageSequenceMachine stageStateMachine;

    void Start()
    {
        movie = GetComponent<VideoPlayer>();
        movie.Play();
        movie.Pause();
        startPlay = false;

        stageStateMachine = GameObject.Find("StageStateMachine").GetComponent<StageSequenceMachine>();
    }

    void Update()
    {
        if (!startPlay && stageStateMachine.currentState == StageSequenceMachine.State_StageSequence.PLAY)
            StartPlayMovie();

        //pause
        if (SceneManager.GetSceneByName("Pause").isLoaded)
            movie.Pause();
        else
            movie.Play();
    }

    void StartPlayMovie()
    {
        movie.Play();
        startPlay = true;
    }
}