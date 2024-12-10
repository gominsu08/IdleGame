using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    [SerializeField] private StageDataListSO _stageDataListSO;
    [SerializeField] private Button _startBtn;
    [SerializeField] private ObstaclesCreateBtn _creatObstacleBtn;
    [SerializeField] private RectTransform _creatObstacleBtnPanel;
    public int stageNumber = 1;

    private StageDataSO _currentStageDataSO;

    private void Awake()
    {
        stageNumber = GameManager.Instance.currentStageNumber;
    }

    public void Start()
    {
        foreach (StageDataSO stage in _stageDataListSO.stageDataList)
        {
            if(stage.stageNumber == stageNumber)
            {
                Instantiate(stage.mapPrefabs,new Vector2(0,0),Quaternion.identity);
                _currentStageDataSO = stage;
            }
        }

        _startBtn.onClick.AddListener(() =>
        {
            _currentStageDataSO.mapPrefabs.GetComponentInChildren<CreatLight>().StartGame();
        });



        for (int i = 0; i < _currentStageDataSO.usedObstacles.Count;i++)
        {
            ObstaclesCreateBtn obsBtn = Instantiate(_creatObstacleBtn, _creatObstacleBtnPanel);
            obsBtn.Initialized(_currentStageDataSO.usedObstacles[i].obstacle);
        }

        _creatObstacleBtn.gameObject.SetActive(false);


    }


}
