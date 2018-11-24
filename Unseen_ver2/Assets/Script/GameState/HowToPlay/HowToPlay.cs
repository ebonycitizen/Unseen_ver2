using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToPlay : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Select();
    }

    void Select()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //SoundManager.PlayPlayerSe("cancelSe");
            SceneManager.UnloadSceneAsync("HowToPlay");
        }
    }
}
