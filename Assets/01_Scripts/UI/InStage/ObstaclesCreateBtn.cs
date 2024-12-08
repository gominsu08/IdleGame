using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstaclesCreateBtn : MonoBehaviour
{
    [SerializeField] private Image _myImage;
    public Obstacle obstacle;

    public void Initialized(Obstacle obstacle)
    {
        this.obstacle = obstacle;
        _myImage.sprite = this.obstacle.obstacleData.obstacleImage;

    }

    public void CreateObstacle()
    {

    }
}
