using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    #region フィールド    
    enum PauseState { PauseState_Min, PauseState_ReturnGame, PauseState_HowToPlay, PauseState_ReturnMenu, PauseState_Max };
    enum ReturnState { ReturnState_Min, ReturnState_Yes, ReturnState_No, ReturnState_Max };

    PauseState pauseState;
    ReturnState returnState;

    #region image
    [SerializeField]
    Image returnGame;
    [SerializeField]
    Image control;
    [SerializeField]
    Image returnMenu;

    [SerializeField]
    Image returnMenuBg;
    [SerializeField]
    Image returnYes;
    [SerializeField]
    Image returnNo;
    #endregion

    #region sprite
    [SerializeField]
    Sprite returnGameNonClick;
    [SerializeField]
    Sprite returnGameClick;
    [SerializeField]
    Sprite controlNonClick;
    [SerializeField]
    Sprite controlClick;
    [SerializeField]
    Sprite returnMenuNonClick;
    [SerializeField]
    Sprite returnMenuClick;

    [SerializeField]
    Sprite yesNonClick;
    [SerializeField]
    Sprite yesClick;
    [SerializeField]
    Sprite noNonClick;
    [SerializeField]
    Sprite noClick;
    #endregion

    bool isReturnMenuState;
    #endregion

    // Use this for initialization
    void Start()
    {
        pauseState = PauseState.PauseState_ReturnGame;
        returnState = ReturnState.ReturnState_Yes;
        isReturnMenuState = false;
    }

    private void Update()
    {
        if (SceneManager.sceneCount != 2)
            return;
        if (!isReturnMenuState)
        {
            UpdateButtonPause();
            ShowPauseState();
        }
        else
        {
            UpdateButtonReturnMenu();
            ShowReturnState();
        }
    }

    #region 描画
    void ShowPauseState()
    {
        SetPauseSpriteEnable();
        switch (pauseState)
        {
            case PauseState.PauseState_ReturnGame:
                ShowReturnGame();
                break;
            case PauseState.PauseState_HowToPlay:
                ShowHowToPlay();
                break;
            case PauseState.PauseState_ReturnMenu:
                ShowReturnMenu();
                break;
        }
    }
    void ShowReturnState()
    {
        SetReturnMenuSpriteEnable();
        switch (returnState)
        {
            case ReturnState.ReturnState_Yes:
                ShowReturnYes();
                break;
            case ReturnState.ReturnState_No:
                ShowReturnNo();
                break;
        }
    }

    void SetPauseSpriteEnable()
    {
        returnGame.enabled = true;
        control.enabled = true;
        returnMenu.enabled = true;
        returnMenuBg.enabled = false;
        returnYes.enabled = false;
        returnNo.enabled = false;
    }
    void SetReturnMenuSpriteEnable()
    {
        returnGame.enabled = false;
        control.enabled = false;
        returnMenu.enabled = false;
        returnMenuBg.enabled = true;
        returnYes.enabled = true;
        returnNo.enabled = true;
    }

    void ShowReturnGame()
    {
        ChangeSprite(returnGame, returnGameClick);
        ChangeSprite(control, controlNonClick);
        ChangeSprite(returnMenu, returnMenuNonClick);
    }
    void ShowHowToPlay()
    {
        ChangeSprite(returnGame, returnGameNonClick);
        ChangeSprite(control, controlClick);
        ChangeSprite(returnMenu, returnMenuNonClick);
    }
    void ShowReturnMenu()
    {
        ChangeSprite(returnGame, returnGameNonClick);
        ChangeSprite(control, controlNonClick);
        ChangeSprite(returnMenu, returnMenuClick);
    }
    void ShowReturnYes()
    {
        ChangeSprite(returnYes, yesClick);
        ChangeSprite(returnNo, noNonClick);
    }
    void ShowReturnNo()
    {
        ChangeSprite(returnYes, yesNonClick);
        ChangeSprite(returnNo, noClick);
    }

    void ChangeSprite(Image img, Sprite sprite)
    {
        img.sprite = sprite;
    }
    #endregion    

    #region 入力
    void UpdateButtonPause()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
            pauseState++;
        if (Input.GetKeyDown(KeyCode.UpArrow))
            pauseState--;

        if (pauseState >= PauseState.PauseState_Max)
            pauseState = PauseState.PauseState_Min + 1;
        if (pauseState <= PauseState.PauseState_Min)
            pauseState = PauseState.PauseState_Max - 1;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            //if (pauseState == PauseState.PauseState_ReturnGame)
            //    SoundManager.PlayPlayerSe("cancelSe");
            //else
            //    SoundManager.PlayPlayerSe("decisionSe");

            switch (pauseState)
            {
                case PauseState.PauseState_ReturnGame:
                    {
                        Pauser.Resume();
                        return;
                    }
                case PauseState.PauseState_HowToPlay:
                    SceneManager.LoadScene("HowToPlay", LoadSceneMode.Additive);
                    return;
                case PauseState.PauseState_ReturnMenu:
                    isReturnMenuState = true;
                    return;
            }
        }
    }
    void UpdateButtonReturnMenu()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
            returnState++;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            returnState--;

        if (returnState >= ReturnState.ReturnState_Max)
            returnState = ReturnState.ReturnState_Min + 1;
        if (returnState <= ReturnState.ReturnState_Min)
            returnState = ReturnState.ReturnState_Max - 1;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            //if (returnState == ReturnState.ReturnState_No)
            //    SoundManager.PlayPlayerSe("cancelSe");
            //else
            //    SoundManager.PlayPlayerSe("decisionSe");
            switch (returnState)
            {
                case ReturnState.ReturnState_Yes:
                    SceneManager.LoadScene("Menu");
                    return;
                case ReturnState.ReturnState_No:
                    isReturnMenuState = false;
                    return;
            }
        }
    }
    #endregion
}
