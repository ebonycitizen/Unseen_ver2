//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class StageSelectUI : MonoBehaviour {
//    #region image
//    [SerializeField]
//    Image digit1;
//    [SerializeField]
//    Image digit2;

//    [SerializeField]
//    Image difficulty1;
//    [SerializeField]
//    Image difficulty2;
//    [SerializeField]
//    Image difficulty3;

//    [SerializeField]
//    Image clear;
//    #endregion

//    #region sprite
//    [SerializeField]
//    Sprite zeroSprite;
//    [SerializeField]
//    Sprite oneSprite;
//    [SerializeField]
//    Sprite twoSprite;
//    [SerializeField]
//    Sprite threeSprite;
//    [SerializeField]
//    Sprite fourSprite;
//    [SerializeField]
//    Sprite fiveSprite;
//    [SerializeField]
//    Sprite sixSprite;
//    [SerializeField]
//    Sprite sevenSprite;
//    [SerializeField]
//    Sprite eightSprite;
//    [SerializeField]
//    Sprite nineSprite;
//    [SerializeField]
//    Sprite grayStarSprite;
//    [SerializeField]
//    Sprite yellowStarSprite;
//    [SerializeField]
//    Sprite redStarSprite;
//    [SerializeField]
//    Sprite clearSprite;
//    #endregion

//	// Use this for initialization
//	void Start () {
//        clear.enabled = false;
//    }
	
//	// Update is called once per frame
//	void Update () {
//        SetDifficulty();
//        SetStageNum();
//    }

//    private void ChangeSprite(Image img, Sprite sprite)
//    {
//        img.sprite = sprite;
//    }

//    #region difficulty
//    void Difficulty0()
//    {
//        ChangeSprite(difficulty1, grayStarSprite);
//        ChangeSprite(difficulty2, grayStarSprite);
//        ChangeSprite(difficulty3, grayStarSprite);
//    }
//    void Difficulty1()
//    {
//        ChangeSprite(difficulty1, yellowStarSprite);
//        ChangeSprite(difficulty2, grayStarSprite);
//        ChangeSprite(difficulty3, grayStarSprite);
//    }
//    void Difficulty2()
//    {
//        ChangeSprite(difficulty1, yellowStarSprite);
//        ChangeSprite(difficulty2, yellowStarSprite);
//        ChangeSprite(difficulty3, grayStarSprite);
//    }
//    void Difficulty3()
//    {
//        ChangeSprite(difficulty1, yellowStarSprite);
//        ChangeSprite(difficulty2, yellowStarSprite);
//        ChangeSprite(difficulty3, yellowStarSprite);
//    }
//    void Difficulty4()
//    {
//        ChangeSprite(difficulty1, redStarSprite);
//        ChangeSprite(difficulty2, yellowStarSprite);
//        ChangeSprite(difficulty3, yellowStarSprite);
//    }
//    void Difficulty5()
//    {
//        ChangeSprite(difficulty1, redStarSprite);
//        ChangeSprite(difficulty2, redStarSprite);
//        ChangeSprite(difficulty3, yellowStarSprite);
//    }
//    void Difficulty6()
//    {
//        ChangeSprite(difficulty1, redStarSprite);
//        ChangeSprite(difficulty2, redStarSprite);
//        ChangeSprite(difficulty3, redStarSprite);
//    }
//    #endregion
//    private void SetDifficulty()
//    {
//        switch ((int)GetComponent<StageSelect>().stageNum)
//        {
//            case 1:case 2:case 3:
//            case 4:case 5:case 6:
//                Difficulty1();
//                break;
//            case 7:case 8:case 9:
//            case 10:case 11:case 12:
//                Difficulty2();
//                break;
//            case 13:case 14:case 15:
//            case 16:case 17:
//                Difficulty3();
//                break;
//            case 18:
//                Difficulty4();
//                break;
//            case 19:
//                Difficulty5();
//                break;
//            case 20:
//                Difficulty6();
//                break;
//        }
//    }

//    #region stage num
//    private void DigitOne_1()
//    {
//        ChangeSprite(digit1, oneSprite);
//    }
//    private void DigitOne_2()
//    {
//        ChangeSprite(digit1, twoSprite);
//    }
//    private void DigitOne_3()
//    {
//        ChangeSprite(digit1, threeSprite);
//    }
//    private void DigitOne_4()
//    {
//        ChangeSprite(digit1, fourSprite);
//    }
//    private void DigitOne_5()
//    {
//        ChangeSprite(digit1, fiveSprite);
//    }
//    private void DigitOne_6()
//    {
//        ChangeSprite(digit1, sixSprite);
//    }
//    private void DigitOne_7()
//    {
//        ChangeSprite(digit1, sevenSprite);
//    }
//    private void DigitOne_8()
//    {
//        ChangeSprite(digit1, eightSprite);
//    }
//    private void DigitOne_9()
//    {
//        ChangeSprite(digit1, nineSprite);
//    }
//    private void DigitOne_0()
//    {
//        ChangeSprite(digit1, zeroSprite);
//    }

//    private void DigitTwo_1()
//    {
//        ChangeSprite(digit2, oneSprite);
//    }
//    private void DigitTwo_2()
//    {
//        ChangeSprite(digit2, twoSprite);
//    }
//    #endregion
//    private void SetStageNum()
//    {
//        switch ((int)GetComponent<StageSelect>().stageNum % 10)
//        {
//            case 0: DigitOne_0(); break;
//            case 1: DigitOne_1(); break;
//            case 2: DigitOne_2(); break;
//            case 3: DigitOne_3(); break;
//            case 4: DigitOne_4(); break;
//            case 5: DigitOne_5(); break;
//            case 6: DigitOne_6(); break;
//            case 7: DigitOne_7(); break;
//            case 8: DigitOne_8(); break;
//            case 9: DigitOne_9(); break;

//        }
//        switch ((int)GetComponent<StageSelect>().stageNum / 10)
//        {
//            case 1: DigitTwo_1(); break;
//            case 2: DigitTwo_2(); break;
//        }
//    }
//}
