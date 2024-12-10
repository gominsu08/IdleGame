using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Obstacles
{
    public Obstacle obstacle;
    public int count;
}

[CreateAssetMenu(menuName = "SO/Stage/StageData")]
public class StageDataSO : ScriptableObject
{
    public int stageNumber;
    public GameObject mapPrefabs;
    public List<Obstacles> usedObstacles = new List<Obstacles>();
}
