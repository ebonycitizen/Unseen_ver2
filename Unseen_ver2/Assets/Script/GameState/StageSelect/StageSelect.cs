//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;
//using UnityEngine.UI;

//public class StageSelect : MonoBehaviour
//{
//    public const int stageNumMax = 20;
//    public enum StageNum
//    {
//        Stage1 = 1, Stage2, Stage3, Stage4, Stage5, Stage6, Stage7, Stage8, Stage9, Stage10,
//        Stage11, Stage12, Stage13, Stage14, Stage15, Stage16, Stage17, Stage18, Stage19, Stage20
//    };
//    public StageNum stageNum { get; private set; }

//    private enum ItaNum { Ita1 = 1, Ita2, Ita3, Ita4, Ita5, Ita6 };
//    private ItaNum itaNum;

//    private RotateCamera rotateCamera;

//    #region board texture
//    [SerializeField]
//    Texture pressIta;
//    [SerializeField]
//    Texture bedIta;
//    [SerializeField]
//    Texture clockIta;
//    [SerializeField]
//    Texture floorIta;
//    [SerializeField]
//    Texture mishinIta;
//    [SerializeField]
//    Texture extraIta;
//    [SerializeField]
//    Texture tutorialIta;
//    #endregion

//    GameObject[] ghostImg = new GameObject[6];

//    #region initialize
//    // Use this for initialization
//    void Start()
//    {
//        rotateCamera = Camera.main.GetComponent<RotateCamera>();

//        stageNum = StageNum.Stage1;
//        itaNum = ItaNum.Ita1;

//        Pauser.DestoryTarget();
//        //if (!SoundManager.IsPlayingBgm())
//        //    SoundManager.PlayBGM("titleBgm");
//        ///huyup
//        for (int i = 0; i < ghostImg.Length; i++)
//        {
//            ghostImg[i] = GameObject.Find("ghost" + (i + 1));
//        }

//    }
//    #endregion

//    // Update is called once per frame
//    private void Update()
//    {
//        UpdateInput();
//    }
//    void FixedUpdate()
//    {
//        ShowStage2ImgObj();
//        ShowClear();
//        ShowStage();
//    }

//    #region draw func
//    void ShowStage2ImgObj()
//    {
//        if (stageNum > StageNum.Stage9)
//            stage2.enabled = true;
//        else
//            stage2.enabled = false;
//    }
//    void ShowClear()
//    {
//        if (PlayerPrefs.HasKey(stageNum.ToString()))
//            clear.enabled = true;
//        else
//            clear.enabled = false;
//    }

//    void ChangeSprite(Image img, Sprite sprite)
//    {
//        img.sprite = sprite;
//    }
//    void ShowGhost(int ghostIndex, int DeadCount)
//    {
//        ghostIndex--;
//        SpriteRenderer oneDigitSprite = ghostImg[ghostIndex].transform.Find("num1").
//            GetComponent<SpriteRenderer>();

//        SpriteRenderer twoDigitSprite = ghostImg[ghostIndex].transform.Find("num2").
//    GetComponent<SpriteRenderer>();


//        if (PlayerPrefs.HasKey(stageNum.ToString()))
//        {
//            ghostImg[ghostIndex].GetComponent<SpriteRenderer>().enabled = true;

//            int oneDigitNum = 0;
//            int twoDigitNum = 0;

//            ChangeNum(DeadCount, ref oneDigitNum, ref twoDigitNum);

//            switch (oneDigitNum)
//            {
//                case 0:
//                    oneDigitSprite.sprite = zeroSprite;
//                    break;
//                case 1:
//                    oneDigitSprite.sprite = oneSprite;
//                    break;
//                case 2:
//                    oneDigitSprite.sprite = twoSprite;
//                    break;
//                case 3:
//                    oneDigitSprite.sprite = threeSprite;
//                    break;
//                case 4:
//                    oneDigitSprite.sprite = fourSprite;
//                    break;
//                case 5:
//                    oneDigitSprite.sprite = fiveSprite;
//                    break;
//                case 6:
//                    oneDigitSprite.sprite = sixSprite;
//                    break;
//                case 7:
//                    oneDigitSprite.sprite = sevenSprite;
//                    break;
//                case 8:
//                    oneDigitSprite.sprite = eightSprite;
//                    break;
//                case 9:
//                    oneDigitSprite.sprite = nineSprite;
//                    break;
//            }
//            switch (twoDigitNum)
//            {
//                case 0:
//                    twoDigitSprite.sprite = zeroSprite;
//                    break;
//                case 1:
//                    twoDigitSprite.sprite = oneSprite;
//                    break;
//                case 2:
//                    twoDigitSprite.sprite = twoSprite;
//                    break;
//                case 3:
//                    twoDigitSprite.sprite = threeSprite;
//                    break;
//                case 4:
//                    twoDigitSprite.sprite = fourSprite;
//                    break;
//                case 5:
//                    twoDigitSprite.sprite = fiveSprite;
//                    break;
//                case 6:
//                    twoDigitSprite.sprite = sixSprite;
//                    break;
//                case 7:
//                    twoDigitSprite.sprite = sevenSprite;
//                    break;
//                case 8:
//                    twoDigitSprite.sprite = eightSprite;
//                    break;
//                case 9:
//                    twoDigitSprite.sprite = nineSprite;
//                    break;
//            }
//            oneDigitSprite.enabled = true;
//            twoDigitSprite.enabled = true;
//        }
//        else
//        {
//            ghostImg[ghostIndex].GetComponent<SpriteRenderer>().enabled = false;
//            oneDigitSprite.enabled = false;
//            twoDigitSprite.enabled = false;
//        }
//    }
//    void ChangeNum(int DeadCount, ref int _oneDigitNum, ref int _twoDigitNum)
//    {
//        if (DeadCount > 99)
//            DeadCount = 99;
//        _oneDigitNum = 0;
//        _twoDigitNum = 0;
//        if (DeadCount < 10)
//        {
//            _oneDigitNum = 0;
//            _twoDigitNum = DeadCount;
//        }
//        else
//        {
//            _oneDigitNum = DeadCount / 10;
//            _twoDigitNum = DeadCount % 10;
//        }

//    }
//    void ChangeIta(Texture tex)
//    {
//        GameObject obj = GameObject.Find(itaNum.ToString());
//        obj.GetComponent<Renderer>().material.SetTexture("_MainTex", tex);
//    }
//    #region stages
//    void ShowStage1()
//    {
//        ChangeSprite(stage1, oneSprite);
//        ChangeIta(tutorialIta);
//        ShowDifficulty1();
//        int ghostNum = (int)itaNum - 1;
//        //ghost1
//        if (PlayerPrefs.HasKey(stageNum.ToString() + "DeadCount"))
//            ShowGhost((int)itaNum, PlayerPrefs.GetInt(stageNum.ToString() + "DeadCount"));
//        else
//        {
//            ghostImg[ghostNum].GetComponent<SpriteRenderer>().enabled = false;
//            foreach (Transform imgchild in ghostImg[ghostNum].transform)
//            {
//                imgchild.GetComponent<SpriteRenderer>().enabled = false;
//            }
//        }
//    }
//    void ShowStage2()
//    {
//        ChangeSprite(stage1, twoSprite);
//        ChangeIta(pressIta);
//        ShowDifficulty1();
//        //ghost2
//        int ghostNum = (int)itaNum - 1;
//        //ghost1
//        if (PlayerPrefs.HasKey(stageNum.ToString() + "DeadCount"))
//            ShowGhost((int)itaNum, PlayerPrefs.GetInt(stageNum.ToString() + "DeadCount"));
//        else
//        {
//            ghostImg[ghostNum].GetComponent<SpriteRenderer>().enabled = false;
//            foreach (Transform imgchild in ghostImg[ghostNum].transform)
//            {
//                imgchild.GetComponent<SpriteRenderer>().enabled = false;
//            }
//        }
//    }
//    void ShowStage3()
//    {
//        ChangeSprite(stage1, threeSprite);
//        ChangeIta(mishinIta);
//        ShowDifficulty1();
//        //ghost3
//        int ghostNum = (int)itaNum - 1;
//        //ghost1
//        if (PlayerPrefs.HasKey(stageNum.ToString() + "DeadCount"))
//            ShowGhost((int)itaNum, PlayerPrefs.GetInt(stageNum.ToString() + "DeadCount"));
//        else
//        {
//            ghostImg[ghostNum].GetComponent<SpriteRenderer>().enabled = false;
//            foreach (Transform imgchild in ghostImg[ghostNum].transform)
//            {
//                imgchild.GetComponent<SpriteRenderer>().enabled = false;
//            }
//        }
//    }
//    void ShowStage4()
//    {
//        ChangeSprite(stage1, fourSprite);
//        ChangeIta(bedIta);
//        ShowDifficulty1();
//        //ghost4
//        int ghostNum = (int)itaNum - 1;
//        //ghost1
//        if (PlayerPrefs.HasKey(stageNum.ToString() + "DeadCount"))
//            ShowGhost((int)itaNum, PlayerPrefs.GetInt(stageNum.ToString() + "DeadCount"));
//        else
//        {
//            ghostImg[ghostNum].GetComponent<SpriteRenderer>().enabled = false;
//            foreach (Transform imgchild in ghostImg[ghostNum].transform)
//            {
//                imgchild.GetComponent<SpriteRenderer>().enabled = false;
//            }
//        }
//    }
//    void ShowStage5()
//    {
//        ChangeSprite(stage1, fiveSprite);
//        ChangeIta(floorIta);
//        ShowDifficulty1();
//        //ghost5
//        int ghostNum = (int)itaNum - 1;
//        //ghost1
//        if (PlayerPrefs.HasKey(stageNum.ToString() + "DeadCount"))
//            ShowGhost((int)itaNum, PlayerPrefs.GetInt(stageNum.ToString() + "DeadCount"));
//        else
//        {
//            ghostImg[ghostNum].GetComponent<SpriteRenderer>().enabled = false;
//            foreach (Transform imgchild in ghostImg[ghostNum].transform)
//            {
//                imgchild.GetComponent<SpriteRenderer>().enabled = false;
//            }
//        }
//    }
//    void ShowStage6()
//    {
//        ChangeSprite(stage1, sixSprite);
//        ChangeIta(clockIta);
//        ShowDifficulty1();
//        //ghost6
//        int ghostNum = (int)itaNum - 1;
//        //ghost1
//        if (PlayerPrefs.HasKey(stageNum.ToString() + "DeadCount"))
//            ShowGhost((int)itaNum, PlayerPrefs.GetInt(stageNum.ToString() + "DeadCount"));
//        else
//        {
//            ghostImg[ghostNum].GetComponent<SpriteRenderer>().enabled = false;
//            foreach (Transform imgchild in ghostImg[ghostNum].transform)
//            {
//                imgchild.GetComponent<SpriteRenderer>().enabled = false;
//            }
//        }
//    }
//    void ShowStage7()
//    {
//        ChangeSprite(stage1, sevenSprite);
//        ChangeIta(pressIta);
//        ShowDifficulty2();
//        //ghost1
//        int ghostNum = (int)itaNum - 1;
//        //ghost1
//        if (PlayerPrefs.HasKey(stageNum.ToString() + "DeadCount"))
//            ShowGhost((int)itaNum, PlayerPrefs.GetInt(stageNum.ToString() + "DeadCount"));
//        else
//        {
//            ghostImg[ghostNum].GetComponent<SpriteRenderer>().enabled = false;
//            foreach (Transform imgchild in ghostImg[ghostNum].transform)
//            {
//                imgchild.GetComponent<SpriteRenderer>().enabled = false;
//            }
//        }
//    }
//    void ShowStage8()
//    {
//        ChangeSprite(stage1, eightSprite);
//        ChangeIta(bedIta);
//        ShowDifficulty1();
//        //ghost2
//        int ghostNum = (int)itaNum - 1;
//        //ghost1
//        if (PlayerPrefs.HasKey(stageNum.ToString() + "DeadCount"))
//            ShowGhost((int)itaNum, PlayerPrefs.GetInt(stageNum.ToString() + "DeadCount"));
//        else
//        {
//            ghostImg[ghostNum].GetComponent<SpriteRenderer>().enabled = false;
//            foreach (Transform imgchild in ghostImg[ghostNum].transform)
//            {
//                imgchild.GetComponent<SpriteRenderer>().enabled = false;
//            }
//        }
//    }
//    void ShowStage9()
//    {
//        ChangeSprite(stage1, nineSprite);
//        ChangeIta(mishinIta);
//        ShowDifficulty1();
//        //ghost3
//        int ghostNum = (int)itaNum - 1;
//        //ghost1
//        if (PlayerPrefs.HasKey(stageNum.ToString() + "DeadCount"))
//            ShowGhost((int)itaNum, PlayerPrefs.GetInt(stageNum.ToString() + "DeadCount"));
//        else
//        {
//            ghostImg[ghostNum].GetComponent<SpriteRenderer>().enabled = false;
//            foreach (Transform imgchild in ghostImg[ghostNum].transform)
//            {
//                imgchild.GetComponent<SpriteRenderer>().enabled = false;
//            }
//        }
//    }
//    void ShowStage10()
//    {
//        ChangeSprite(stage1, oneSprite);
//        ChangeSprite(stage2, zeroSprite);
//        ChangeIta(floorIta);
//        ShowDifficulty2();
//        //ghost4
//        int ghostNum = (int)itaNum - 1;
//        //ghost1
//        if (PlayerPrefs.HasKey(stageNum.ToString() + "DeadCount"))
//            ShowGhost((int)itaNum, PlayerPrefs.GetInt(stageNum.ToString() + "DeadCount"));
//        else
//        {
//            ghostImg[ghostNum].GetComponent<SpriteRenderer>().enabled = false;
//            foreach (Transform imgchild in ghostImg[ghostNum].transform)
//            {
//                imgchild.GetComponent<SpriteRenderer>().enabled = false;
//            }
//        }
//    }
//    void ShowStage11()
//    {
//        ChangeSprite(stage1, oneSprite);
//        ChangeSprite(stage2, oneSprite);
//        ChangeIta(clockIta);
//        ShowDifficulty2();
//        //ghost5
//        int ghostNum = (int)itaNum - 1;
//        //ghost1
//        if (PlayerPrefs.HasKey(stageNum.ToString() + "DeadCount"))
//            ShowGhost((int)itaNum, PlayerPrefs.GetInt(stageNum.ToString() + "DeadCount"));
//        else
//        {
//            ghostImg[ghostNum].GetComponent<SpriteRenderer>().enabled = false;
//            foreach (Transform imgchild in ghostImg[ghostNum].transform)
//            {
//                imgchild.GetComponent<SpriteRenderer>().enabled = false;
//            }
//        }
//    }
//    void ShowStage12()
//    {
//        ChangeSprite(stage1, oneSprite);
//        ChangeSprite(stage2, twoSprite);
//        ChangeIta(bedIta);
//        ShowDifficulty2();
//        //ghost6
//        int ghostNum = (int)itaNum - 1;
//        //ghost1
//        if (PlayerPrefs.HasKey(stageNum.ToString() + "DeadCount"))
//            ShowGhost((int)itaNum, PlayerPrefs.GetInt(stageNum.ToString() + "DeadCount"));
//        else
//        {
//            ghostImg[ghostNum].GetComponent<SpriteRenderer>().enabled = false;
//            foreach (Transform imgchild in ghostImg[ghostNum].transform)
//            {
//                imgchild.GetComponent<SpriteRenderer>().enabled = false;
//            }
//        }
//    }
//    void ShowStage13()
//    {
//        ChangeSprite(stage1, oneSprite);
//        ChangeSprite(stage2, threeSprite);
//        ChangeIta(mishinIta);
//        ShowDifficulty3();
//        //ghost1
//        int ghostNum = (int)itaNum - 1;
//        //ghost1
//        if (PlayerPrefs.HasKey(stageNum.ToString() + "DeadCount"))
//            ShowGhost((int)itaNum, PlayerPrefs.GetInt(stageNum.ToString() + "DeadCount"));
//        else
//        {
//            ghostImg[ghostNum].GetComponent<SpriteRenderer>().enabled = false;
//            foreach (Transform imgchild in ghostImg[ghostNum].transform)
//            {
//                imgchild.GetComponent<SpriteRenderer>().enabled = false;
//            }
//        }
//    }
//    void ShowStage14()
//    {
//        ChangeSprite(stage1, oneSprite);
//        ChangeSprite(stage2, fourSprite);
//        ChangeIta(floorIta);
//        ShowDifficulty3();
//        //ghost2
//        int ghostNum = (int)itaNum - 1;
//        //ghost1
//        if (PlayerPrefs.HasKey(stageNum.ToString() + "DeadCount"))
//            ShowGhost((int)itaNum, PlayerPrefs.GetInt(stageNum.ToString() + "DeadCount"));
//        else
//        {
//            ghostImg[ghostNum].GetComponent<SpriteRenderer>().enabled = false;
//            foreach (Transform imgchild in ghostImg[ghostNum].transform)
//            {
//                imgchild.GetComponent<SpriteRenderer>().enabled = false;
//            }
//        }
//    }
//    void ShowStage15()
//    {
//        ChangeSprite(stage1, oneSprite);
//        ChangeSprite(stage2, fiveSprite);
//        ChangeIta(pressIta);
//        ShowDifficulty3();
//        //ghost3
//        int ghostNum = (int)itaNum - 1;
//        //ghost1
//        if (PlayerPrefs.HasKey(stageNum.ToString() + "DeadCount"))
//            ShowGhost((int)itaNum, PlayerPrefs.GetInt(stageNum.ToString() + "DeadCount"));
//        else
//        {
//            ghostImg[ghostNum].GetComponent<SpriteRenderer>().enabled = false;
//            foreach (Transform imgchild in ghostImg[ghostNum].transform)
//            {
//                imgchild.GetComponent<SpriteRenderer>().enabled = false;
//            }
//        }
//    }
//    void ShowStage16()
//    {
//        ChangeSprite(stage1, oneSprite);
//        ChangeSprite(stage2, sixSprite);
//        ChangeIta(clockIta);
//        ShowDifficulty3();
//        //ghost4
//        int ghostNum = (int)itaNum - 1;
//        //ghost1
//        if (PlayerPrefs.HasKey(stageNum.ToString() + "DeadCount"))
//            ShowGhost((int)itaNum, PlayerPrefs.GetInt(stageNum.ToString() + "DeadCount"));
//        else
//        {
//            ghostImg[ghostNum].GetComponent<SpriteRenderer>().enabled = false;
//            foreach (Transform imgchild in ghostImg[ghostNum].transform)
//            {
//                imgchild.GetComponent<SpriteRenderer>().enabled = false;
//            }
//        }
//    }
//    void ShowStage17()
//    {
//        ChangeSprite(stage1, oneSprite);
//        ChangeSprite(stage2, sevenSprite);
//        ChangeIta(floorIta);
//        ShowDifficulty3();
//        //ghost5
//        int ghostNum = (int)itaNum - 1;
//        //ghost1
//        if (PlayerPrefs.HasKey(stageNum.ToString() + "DeadCount"))
//            ShowGhost((int)itaNum, PlayerPrefs.GetInt(stageNum.ToString() + "DeadCount"));
//        else
//        {
//            ghostImg[ghostNum].GetComponent<SpriteRenderer>().enabled = false;
//            foreach (Transform imgchild in ghostImg[ghostNum].transform)
//            {
//                imgchild.GetComponent<SpriteRenderer>().enabled = false;
//            }
//        }
//    }
//    void ShowStage18()
//    {
//        ChangeSprite(stage1, oneSprite);
//        ChangeSprite(stage2, eightSprite);
//        ChangeIta(extraIta);
//        ShowDifficulty4();
//        //ghost6
//        int ghostNum = (int)itaNum - 1;
//        //ghost1
//        if (PlayerPrefs.HasKey(stageNum.ToString() + "DeadCount"))
//            ShowGhost((int)itaNum, PlayerPrefs.GetInt(stageNum.ToString() + "DeadCount"));
//        else
//        {
//            ghostImg[ghostNum].GetComponent<SpriteRenderer>().enabled = false;
//            foreach (Transform imgchild in ghostImg[ghostNum].transform)
//            {
//                imgchild.GetComponent<SpriteRenderer>().enabled = false;
//            }
//        }
//    }
//    void ShowStage19()
//    {
//        ChangeSprite(stage1, oneSprite);
//        ChangeSprite(stage2, nineSprite);
//        ChangeIta(extraIta);
//        ShowDifficulty4();
//        //ghost1
//        int ghostNum = (int)itaNum - 1;
//        //ghost1
//        if (PlayerPrefs.HasKey(stageNum.ToString() + "DeadCount"))
//            ShowGhost((int)itaNum, PlayerPrefs.GetInt(stageNum.ToString() + "DeadCount"));
//        else
//        {
//            ghostImg[ghostNum].GetComponent<SpriteRenderer>().enabled = false;
//            foreach (Transform imgchild in ghostImg[ghostNum].transform)
//            {
//                imgchild.GetComponent<SpriteRenderer>().enabled = false;
//            }
//        }
//    }
//    void ShowStage20()
//    {
//        ChangeSprite(stage1, twoSprite);
//        ChangeSprite(stage2, zeroSprite);
//        ChangeIta(extraIta);
//        ShowDifficulty5();
//        //ghost2
//        int ghostNum = (int)itaNum - 1;
//        //ghost1
//        if (PlayerPrefs.HasKey(stageNum.ToString() + "DeadCount"))
//            ShowGhost((int)itaNum, PlayerPrefs.GetInt(stageNum.ToString() + "DeadCount"));
//        else
//        {
//            ghostImg[ghostNum].GetComponent<SpriteRenderer>().enabled = false;
//            foreach (Transform imgchild in ghostImg[ghostNum].transform)
//            {
//                imgchild.GetComponent<SpriteRenderer>().enabled = false;
//            }
//        }
//    }
//    void ShowStage21()
//    {
//        ChangeSprite(stage1, twoSprite);
//        ChangeSprite(stage2, oneSprite);
//        ChangeIta(extraIta);
//        ShowDifficulty5();
//        //ghost3
//        int ghostNum = (int)itaNum - 1;
//        //ghost1
//        if (PlayerPrefs.HasKey(stageNum.ToString() + "DeadCount"))
//            ShowGhost((int)itaNum, PlayerPrefs.GetInt(stageNum.ToString() + "DeadCount"));
//        else
//        {
//            ghostImg[ghostNum].GetComponent<SpriteRenderer>().enabled = false;
//            foreach (Transform imgchild in ghostImg[ghostNum].transform)
//            {
//                imgchild.GetComponent<SpriteRenderer>().enabled = false;
//            }
//        }
//    }
//    void ShowStage22()
//    {
//        ChangeSprite(stage1, twoSprite);
//        ChangeSprite(stage2, twoSprite);
//        ChangeIta(extraIta);
//        ShowDifficulty6();
//        //ghost4
//        int ghostNum = (int)itaNum - 1;
//        //ghost1
//        if (PlayerPrefs.HasKey(stageNum.ToString() + "DeadCount"))
//            ShowGhost((int)itaNum, PlayerPrefs.GetInt(stageNum.ToString() + "DeadCount"));
//        else
//        {
//            ghostImg[ghostNum].GetComponent<SpriteRenderer>().enabled = false;
//            foreach (Transform imgchild in ghostImg[ghostNum].transform)
//            {
//                imgchild.GetComponent<SpriteRenderer>().enabled = false;
//            }
//        }
//    }
//    #endregion

//    #region show stages
//    void ShowStage()
//    {
//        switch (stageNum)
//        {
//            case StageNum.Stage1:
//                ShowStage1();
//                break;
//            case StageNum.Stage2:
//                ShowStage2();
//                break;
//            case StageNum.Stage3:
//                ShowStage3();
//                break;
//            case StageNum.Stage4:
//                ShowStage4();
//                break;
//            case StageNum.Stage5:
//                ShowStage5();
//                break;
//            case StageNum.Stage6:
//                ShowStage6();
//                break;
//            case StageNum.Stage7:
//                ShowStage7();
//                break;
//            case StageNum.Stage8:
//                ShowStage8();
//                break;
//            case StageNum.Stage9:
//                ShowStage9();
//                break;
//            case StageNum.Stage10:
//                ShowStage10();
//                break;
//            case StageNum.Stage11:
//                ShowStage11();
//                break;
//            case StageNum.Stage12:
//                ShowStage12();
//                break;
//            case StageNum.Stage13:
//                ShowStage13();
//                break;
//            case StageNum.Stage14:
//                ShowStage14();
//                break;
//            case StageNum.Stage15:
//                ShowStage15();
//                break;
//            case StageNum.Stage16:
//                ShowStage16();
//                break;
//            case StageNum.Stage17:
//                ShowStage17();
//                break;
//            case StageNum.Stage18:
//                ShowStage18();
//                break;
//            case StageNum.Stage19:
//                ShowStage19();
//                break;
//            case StageNum.Stage20:
//                ShowStage20();
//                break;
//            case StageNum.Stage21:
//                ShowStage21();
//                break;
//            case StageNum.Stage22:
//                ShowStage22();
//                break;
//        }
//    }
//    #endregion

//    #region difficulty
//    void ShowDifficulty0()
//    {
//        ChangeSprite(difficulty1, grayStarSprite);
//        ChangeSprite(difficulty2, grayStarSprite);
//        ChangeSprite(difficulty3, grayStarSprite);
//    }
//    void ShowDifficulty1()
//    {
//        ChangeSprite(difficulty1, yellowStarSprite);
//        ChangeSprite(difficulty2, grayStarSprite);
//        ChangeSprite(difficulty3, grayStarSprite);
//    }
//    void ShowDifficulty2()
//    {
//        ChangeSprite(difficulty1, yellowStarSprite);
//        ChangeSprite(difficulty2, yellowStarSprite);
//        ChangeSprite(difficulty3, grayStarSprite);
//    }
//    void ShowDifficulty3()
//    {
//        ChangeSprite(difficulty1, yellowStarSprite);
//        ChangeSprite(difficulty2, yellowStarSprite);
//        ChangeSprite(difficulty3, yellowStarSprite);
//    }
//    void ShowDifficulty4()
//    {
//        ChangeSprite(difficulty1, redStarSprite);
//        ChangeSprite(difficulty2, yellowStarSprite);
//        ChangeSprite(difficulty3, yellowStarSprite);
//    }
//    void ShowDifficulty5()
//    {
//        ChangeSprite(difficulty1, redStarSprite);
//        ChangeSprite(difficulty2, redStarSprite);
//        ChangeSprite(difficulty3, yellowStarSprite);
//    }
//    void ShowDifficulty6()
//    {
//        ChangeSprite(difficulty1, redStarSprite);
//        ChangeSprite(difficulty2, redStarSprite);
//        ChangeSprite(difficulty3, redStarSprite);
//    }
//    #endregion

//    #endregion

//    #region input
//    void UpdateInput()
//    {
//        if (rotateCamera.IsMoving || rotateCamera.CanZoomIn)
//            return;

//        nowh = Input.GetAxis("Horizontal");

//        if (oldh == 0 && nowh != 0)
//        {
//            //SoundManager.PlayPlayerSe("cursorSe");
//            if (Input.GetAxis("Horizontal") > 0)
//            {
//                stageNum++;
//                itaNum++;
//            }
//            if (Input.GetAxis("Horizontal") < 0)
//            {
//                stageNum--;
//                itaNum--;
//            }
//            if (stageNum > (StageNum)stageNumMax)
//                stageNum = StageNum.Stage1;
//            if (stageNum < StageNum.Stage1)
//                stageNum = (StageNum)stageNumMax;
//            if (itaNum > ItaNum.Ita6)
//                itaNum = ItaNum.Ita1;
//            if (itaNum < ItaNum.Ita1)
//                itaNum = ItaNum.Ita6;
//        }

//        oldh = Input.GetAxis("Horizontal");
//        UpdateButton();
//    }

//    void UpdateButton()
//    {
//        if (Input.GetKeyDown(KeyCode.JoystickButton1))
//        {
//            //SoundManager.PlayPlayerSe("cancelSe");
//            SceneManager.LoadScene("Menu");
//        }
//        if (Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.Space))
//        {
//            //SoundManager.PlayPlayerSe("decisionSe");
//            //if (SoundManager.IsPlayingBgm())
//            //    SoundManager.StopBGM();
//            rotateCamera.doorTargetPos = GameObject.Find("Door" + ((int)itaNum).ToString()).transform.position;
//            rotateCamera.CanZoomIn = true;
//        }
//    }
//    #endregion
//}
