using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShowStageNum : MonoBehaviour {
    [SerializeField]
    private StageDataBase stageDataBase;

    [SerializeField]
    private Image star1;
    [SerializeField]
    private Image star2;
    [SerializeField]
    private Image star3;
    [SerializeField]
    private Text stageNum;

    private StageTable currentStage;

    RectTransform stageNumUI;
    Vector2 fromPos;
    Vector2 toPos;

    float curTime;

    // Use this for initialization
    void Start () {
        string currScene = SceneManager.GetActiveScene().name;
        currentStage = stageDataBase.GetStage(currScene);
        stageNum.text = currentStage.GetStageName().Remove(0,5);
        SetDifficulty();

        stageNumUI = GameObject.Find("StageNumUI").GetComponent<Image>().rectTransform;
        fromPos = stageNumUI.anchoredPosition;
        toPos = new Vector2(fromPos.x - stageNumUI.sizeDelta.x, fromPos.y);
        curTime = 0f;
    }

    // Update is called once per frame
    void Update () {
        Invoke("Move", 1);
	}

    private void SetDifficulty()
    {
        star1.sprite = currentStage.GetStar1();
        star2.sprite = currentStage.GetStar2();
        star3.sprite = currentStage.GetStar3();
    }
    private void Move()
    {
        if (curTime >= 1)
            return;
        curTime += Time.fixedDeltaTime;
        stageNumUI.anchoredPosition = Vector2.Lerp(fromPos, toPos, curTime);
    }
}
