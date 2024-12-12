using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ObstaclesCreateBtn : MonoBehaviour
{
    [SerializeField] private Image _myImage;
    [SerializeField] private TextMeshProUGUI _myCountText;

    private ObstacleGhostObj _ghostObj;

    private Obstacles myObstacle;

    public UnityEvent OnSelectEvent;
    public UnityEvent OnUnSelectEvent;
    public Obstacle obstacle;
    public int Count { get; set; }
    public bool isSelect;
    public bool isCreateObj;



    public void Initialized(Obstacles obstacle, ObstacleGhostObj ghostobj)
    {
        this.obstacle = obstacle.obstacle;
        _myImage.sprite = this.obstacle.obstacleData.obstacleImage;
        CountTextSet(obstacle.count);
        myObstacle = obstacle;
        _ghostObj = ghostobj;
    }

    public void CountTextSet(int count)
    {
        _myCountText.SetText(count.ToString());
        Count = count;
    }

    public void CreateObstacle()
    {
        if (isSelect)
        {
            _ghostObj.Hide();
                

            OnUnSelectEvent?.Invoke();
            isCreateObj = false;
        }
        else if (!isSelect)
        {

            foreach (ObstaclesCreateBtn item in StageManager.OCBDC.obstaclesCreateBtns)
            {
                if (item.isSelect)
                {
                    item.CreateObstacle();
                }
            }


            _ghostObj.Show(obstacle.obstacleData.obstacleImage, obstacle,this);
            OnSelectEvent?.Invoke();
        }


        isSelect = !isSelect;

    }
}
