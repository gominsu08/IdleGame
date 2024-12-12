using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "SO/Obstacle/ObstacleDataList")]
public class ObstacleObjListDataSO : ScriptableObject
{
    public List<Obstacle> obstacles = new List<Obstacle>();
}