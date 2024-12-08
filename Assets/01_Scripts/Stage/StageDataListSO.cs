using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Stage/StageDataList")]
public class StageDataListSO : ScriptableObject
{
    public List<StageDataSO> stageDataList = new List<StageDataSO>();

    
}
