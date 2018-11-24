using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour {
    const int doorNumMax = 6;

    [SerializeField]
    private StageDataBase stageDataBase;
    [SerializeField]
    private RotateCamera rotateCamera;

    #region image
    [SerializeField]
    private Image star1;
    [SerializeField]
    private Image star2;
    [SerializeField]
    private Image star3;

    [SerializeField]
    private Image stageDigit1;
    [SerializeField]
    private Image stageDigit2;
    #endregion

    #region sprite
    [SerializeField]
    Sprite zeroSprite;
    [SerializeField]
    Sprite oneSprite;
    [SerializeField]
    Sprite twoSprite;
    [SerializeField]
    Sprite threeSprite;
    [SerializeField]
    Sprite fourSprite;
    [SerializeField]
    Sprite fiveSprite;
    [SerializeField]
    Sprite sixSprite;
    [SerializeField]
    Sprite sevenSprite;
    [SerializeField]
    Sprite eightSprite;
    [SerializeField]
    Sprite nineSprite;

    [SerializeField]
    Sprite ghostSprite;
    #endregion

    [SerializeField]
    private GameObject clear;

    private int stageNumMax;
    private int nowStageNum;
    private int nowDoorNum;

    private string itaName = "Ita";
    private string ghostName = "GhostNum";

    private IEnumerator rotateCoroutine;
    private IEnumerator enterCoroutine;

    // Use this for initialization
    void Start () {
        stageNumMax = stageDataBase.GetStageList().Count;
        nowStageNum = 1;
        nowDoorNum = 1;
    }
	
	// Update is called once per frame
	void Update () {
        if (rotateCamera == null)
            return;

        InputHandle();
        SetStageTable();
    }

    private void InputHandle()
    {
        UpdateStage();
        ChangeScene();
    }

    //左、右キー押した時のアニメーションやStageNumの管理
    private void UpdateStage()
    {
        if (rotateCamera.IsRotating)
            return;

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            nowStageNum++;
            nowDoorNum++;

            rotateCoroutine = rotateCamera.StartRotateAnimation(-rotateCamera.GetRotateSpeed());
            StartCoroutine(rotateCoroutine);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            nowStageNum--;
            nowDoorNum--;

            rotateCoroutine = rotateCamera.StartRotateAnimation(rotateCamera.GetRotateSpeed());
            StartCoroutine(rotateCoroutine);
        }
        Restriction();
    }
    private void Restriction()
    {
        if (nowStageNum < 1)
            nowStageNum = stageNumMax;
        if (nowStageNum > stageNumMax)
            nowStageNum = 1;

        if (nowDoorNum < 1)
            nowDoorNum = doorNumMax;
        if (nowDoorNum > doorNumMax)
            nowDoorNum = 1;
    }

    //Enterキー押したら、ステージシーンへ
    private void ChangeScene()
    {
        if (rotateCamera.IsRotating)
            return;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            Vector3 doorTargetPos = GameObject.Find("DoorTarget" + nowDoorNum.ToString()).transform.position;
            enterCoroutine = rotateCamera.GoInsideDoor(doorTargetPos);
            StartCoroutine(enterCoroutine);
        }
    }

    private void SetStageTable()
    {
        StageTable stage = stageDataBase.GetStageList()[nowStageNum - 1];

        star1.sprite = stage.GetStar1();
        star2.sprite = stage.GetStar2();
        star3.sprite = stage.GetStar3();

        stageDigit1.sprite = stage.GetStageDigit1();
        stageDigit2.sprite = stage.GetStageDigit2();

        ChangeIta(stage);
        ShowGhost(stage);

        if (stage.GetHasClear())
            clear.SetActive(true);
        else
            clear.SetActive(false);
    }

    private void ChangeIta(StageTable stage)
    {
        GameObject obj = GameObject.Find(itaName + nowDoorNum.ToString());
        obj.GetComponent<Renderer>().material.SetTexture("_MainTex", stage.GetIta());
    }
    private void ShowGhost(StageTable stage)
    {
        GameObject obj = GameObject.Find(ghostName + nowDoorNum.ToString());
        SpriteRenderer[] ghost = obj.GetComponentsInChildren<SpriteRenderer>();

        /* [0]:ghost [1]:digit1 [2]:digit2*/
        if (stage.GetHasClear())
        {
            ghost[0].sprite = ghostSprite;
            ghost[1].sprite = stage.GetGhost1Sprite();
            ghost[2].sprite = stage.GetGhost2Sprite();
        }
        else
        {
            foreach (SpriteRenderer s in ghost)
                s.sprite = null;
        }
    }
}
