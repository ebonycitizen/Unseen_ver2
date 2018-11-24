using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class Title : MonoBehaviour {
    const float fadeInterval = 2f;
    const float colorInterval = 0.01f;
    const float startPv = 2f;

    float logoColor;
    float buttonColor;

    float pvCount;

    Image logo;
    Image pressBtn;

    [SerializeField]
    private Sprite clickSprite;

	// Use this for initialization
	void Start () {
        logo = GameObject.Find("logo").GetComponent<Image>();
        pressBtn = GameObject.Find("pressAnyBtn").GetComponent<Image>();

        logoColor = 0;
        buttonColor = 0;
        pvCount = 0;
    }
    // Update is called once per frame
    void Update ()
    {
        if (GotoMenu())
            return;

        ShowPv();

        Showlogo();
        ShowPressAnyBtn();   
    }

    void Showlogo()
    {
        //skip animation
        if (RecieveInput())
            logoColor = 1f;

        if (logoColor != 1)
            logoColor = Mathf.Lerp(0, 1, Time.timeSinceLevelLoad);
        logo.color = new Color(logoColor, logoColor, logoColor, logoColor);
    }
    void ShowPressAnyBtn()
    {
        if (logoColor < 1 || pressBtn.sprite == clickSprite)
            return;

        buttonColor = Mathf.PingPong(Time.timeSinceLevelLoad - 1, 1);
        pressBtn.color = new Color(1, 1, 1, buttonColor);
    }
    void ShowPv()
    {
        if (logoColor == 1)
            pvCount += Time.fixedDeltaTime;

        if (pvCount >= startPv)
        {
            RecordOldScene.Instance.oldScene = "Title";
            SceneManager.LoadScene("PV", LoadSceneMode.Single);
        } 
    }

    bool GotoMenu()
    {
        if (logoColor == 1 && RecieveInput())
        {
            pressBtn.sprite = clickSprite;
            pressBtn.color = Color.white;

            //SoundManager.PlayPlayerSe("decisionSe");
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
            return true;
        }
        return false;
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
