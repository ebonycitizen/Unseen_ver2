using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
[CreateAssetMenu(fileName = "StageDataBase", menuName = "CreateStageDataBase")]
public class StageDataBase : ScriptableObject {

    [SerializeField]
    private List<StageTable> stageList = new List<StageTable>();

    public List<StageTable> GetStageList()
    {
        return stageList;
    }
    public StageTable GetStage(string searchName)
    {
        return stageList.Find(stageName => stageName.GetStageName() == searchName);
    }
}
