using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCreateManager : MonoBehaviour
{
    [SerializeField] private ObstacleObjListDataSO ObstacleList;

    public void CreateObstacleObj(Obstacle obstacle, Vector2 createPosition)
    {
        foreach (Obstacle item in ObstacleList.obstacles)
        {
            if (item == obstacle)
            {
                Instantiate(obstacle, createPosition,Quaternion.identity);
            }
        }
    }

}
