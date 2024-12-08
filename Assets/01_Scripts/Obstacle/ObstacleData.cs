using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Obstacle/ObstacleData")]
public class ObstacleData : ScriptableObject
{
    public Sprite obstacleImage;
    public string obstacleName;
    public string obstacleDesc;
}
