using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEditor;

[Serializable]
[CreateAssetMenu(fileName = "StageTable", menuName = "CreateStageTable")]
public class StageTable : ResettableScriptableObject {
    const int deadTimesMax = 99;

    [SerializeField]
    private String stageName;

    [SerializeField]
    private Sprite star1;
    [SerializeField]
    private Sprite star2;
    [SerializeField]
    private Sprite star3;

    [SerializeField]
    private Sprite stageDigit1;
    [SerializeField]
    private Sprite stageDigit2;

    [SerializeField]
    private bool hasClear;
    [SerializeField]
    private int deadTimes;

    [SerializeField]
    private Texture ita;

    private int ghost1;
    private int ghost2;
    private Sprite ghost1Sprite;
    private Sprite ghost2Sprite;

    public String GetStageName()
    {
        return stageName;
    }

    public Sprite GetStar1()
    {
        return star1;
    }
    public Sprite GetStar2()
    {
        return star2;
    }
    public Sprite GetStar3()
    {
        return star3;
    }

    public Sprite GetStageDigit1()
    {
        return stageDigit1;
    }
    public Sprite GetStageDigit2()
    {
        return stageDigit2;
    }
    public Sprite GetGhost1Sprite()
    {
        return ghost1Sprite;
    }
    public Sprite GetGhost2Sprite()
    {
        return ghost2Sprite;
    }

    public Texture GetIta()
    {
        return ita;
    }

    public bool GetHasClear()
    {
        return hasClear;
    }
    public int GetDeadTimes()
    {
        return deadTimes;
    }

    public void SetDeadTimes(int value)
    {
        if (value > deadTimesMax)
            value = deadTimesMax;
        deadTimes = value;

        SetDigits();
        ghost1Sprite = SetSpriteDigits(ghost1);
        ghost2Sprite = SetSpriteDigits(ghost2);
    }

    private void SetDigits()
    {
        ghost1 = deadTimes / 10;
        ghost2 = deadTimes % 10;
    }
    private Sprite SetSpriteDigits(int deadNum)
    {
        return AssetDatabase.LoadAssetAtPath<Sprite>("Assets/UI/StageSelect/" + deadNum.ToString() + ".png");
    }
}
