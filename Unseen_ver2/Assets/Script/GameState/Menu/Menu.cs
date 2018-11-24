using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using UnityEd

public class Menu : MonoBehaviour {
    enum MenuState { MenuState_Min, MenuState_SelectStage, MenuState_HowToPlay, MenuState_PV, MenuState_Exit, MenuState_Max };
    MenuState menuState;

    #region image
    [SerializeField]
    Image selectStage;
    [SerializeField]
    Image howToPlay;
    [SerializeField]
    Image pv;
    [SerializeField]
    Image exit;
    #endregion

    #region pos
    Vector2 selectStagePos;
    Vector2 howToPlayPos;
    Vector2 pvPos;
    Vector2 exitPos;
    Vector2 selectStageClickPos;
    Vector2 howToPlayClickPos;
    Vector2 pvClickPos;
    Vector2 exitClickPos;
    #endregion

    // Use this for initialization
    void Start () {
        InitializePos();
        menuState = MenuState.MenuState_SelectStage;
        Pauser.DestoryTarget();
    }

    void InitializePos()
    {
        selectStagePos = selectStage.rectTransform.anchoredPosition;
        howToPlayPos = howToPlay.rectTransform.anchoredPosition;
        pvPos = pv.rectTransform.anchoredPosition;
        exitPos = exit.rectTransform.anchoredPosition;

        selectStageClickPos = new Vector2(0, selectStagePos.y);
        howToPlayClickPos = new Vector2(0, howToPlayPos.y);
        pvClickPos = new Vector2(0, pvPos.y);
        exitClickPos = new Vector2(0, exitPos.y);
    }

    void Update()
    {
        if (SceneManager.sceneCount != 1)
            return;
        UpdateInput();
        DrawMenu();
    }

    #region 描画
    void DrawMenu()
    {
        switch (menuState)
        {
            case MenuState.MenuState_SelectStage:
                ShowSelectStage();
                break;
            case MenuState.MenuState_HowToPlay:
                ShowHowToPlay();
                break;
            case MenuState.MenuState_PV:
                ShowPv();
                break;
            case MenuState.MenuState_Exit:
                ShowExit();
                break;
        }
    }

    void ShowSelectStage()
    {
        selectStage.rectTransform.anchoredPosition = selectStageClickPos;
        howToPlay.rectTransform.anchoredPosition = howToPlayPos;
        pv.rectTransform.anchoredPosition = pvPos;
        exit.rectTransform.anchoredPosition = exitPos;
    }
    void ShowHowToPlay()
    {
        selectStage.rectTransform.anchoredPosition = selectStagePos;
        howToPlay.rectTransform.anchoredPosition = howToPlayClickPos;
        pv.rectTransform.anchoredPosition = pvPos;
        exit.rectTransform.anchoredPosition = exitPos;
    }
    void ShowPv()
    {
        selectStage.rectTransform.anchoredPosition = selectStagePos;
        howToPlay.rectTransform.anchoredPosition = howToPlayPos;
        pv.rectTransform.anchoredPosition = pvClickPos;
        exit.rectTransform.anchoredPosition = exitPos;
    }
    void ShowExit()
    {
        selectStage.rectTransform.anchoredPosition = selectStagePos;
        howToPlay.rectTransform.anchoredPosition = howToPlayPos;
        pv.rectTransform.anchoredPosition = pvPos;
        exit.rectTransform.anchoredPosition = exitClickPos;
    }
    #endregion

    #region 入力
    void UpdateInput()
    {
        Choose();
        Select();
    }

    void Choose()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
            menuState++;
        if (Input.GetKeyDown(KeyCode.UpArrow))
            menuState--;

        if (menuState >= MenuState.MenuState_Max)
            menuState = MenuState.MenuState_Min + 1;
        if (menuState <= MenuState.MenuState_Min)
            menuState = MenuState.MenuState_Max - 1;

        //SoundManager.PlayPlayerSe("cursorSe");
    }
    void Select()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene("Title", LoadSceneMode.Single);
        if (Input.GetKeyDown(KeyCode.Return))
        {
            //SoundManager.PlayPlayerSe("decisionSe");
            switch (menuState)
            {
                case MenuState.MenuState_SelectStage:
                    SceneManager.LoadScene("StageSelect", LoadSceneMode.Single);
                    break;
                case MenuState.MenuState_HowToPlay:
                    SceneManager.LoadScene("HowToPlay", LoadSceneMode.Additive);
                    break;
                case MenuState.MenuState_PV:
                    RecordOldScene.Instance.oldScene = "Menu";
                    SceneManager.LoadScene("PV", LoadSceneMode.Single);
                    break;
                case MenuState.MenuState_Exit:
                   // EditorApplication.isPlaying = false;
                    Application.Quit();
                    break;
            }
        }
    }
    #endregion
}
