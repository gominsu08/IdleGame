using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Obstacles
{
    public Obstacle obstacle;
    public int Ccount;
}

[CreateAssetMenu(menuName = "SO/Stage/StageData")]
public class StageDataSO : ScriptableObject
{
    public int stageNumber;
    public GameObject mapPrefabs;
    public List<Obstacles> usedObstacles = new List<Obstacles>();
}
