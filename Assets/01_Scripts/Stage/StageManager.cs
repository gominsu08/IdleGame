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

    /// <summary>
    /// ObstaclesCreateBtnDataContainer
    /// </summary>
    public static ObstaclesCreateBtnDataContainer OCBDC { get; private set; }

    private void Awake()
    {
        stageNumber = GameManager.Instance.currentStageNumber;
        OCBDC = new ObstaclesCreateBtnDataContainer();
    }

    public void Start()
    {


        foreach (StageDataSO stage in _stageDataListSO.stageDataList)
        {
            if (stage.stageNumber == stageNumber)
            {
                Instantiate(stage.mapPrefabs, new Vector2(0, 0), Quaternion.identity);
                _currentStageDataSO = stage;
                ObstacleGhostObj.Instance.grid = _currentStageDataSO.mapPrefabs.GetComponentInChildren<Grid>();

            }
        }

        _startBtn.onClick.AddListener(() =>
        {
            _currentStageDataSO.mapPrefabs.GetComponentInChildren<CreatLight>().StartGame();
            _creatObstacleBtnPanel.gameObject.SetActive(false);
            foreach (ObstaclesCreateBtn item in OCBDC.obstaclesCreateBtns)
            {
                if (item.isSelect)
                {
                    item.CreateObstacle();
                }
            }
        });



        for (int i = 0; i < _currentStageDataSO.usedObstacles.Count; i++)
        {
            ObstaclesCreateBtn obsBtn = Instantiate(_creatObstacleBtn, _creatObstacleBtnPanel);
            obsBtn.Initialized(_currentStageDataSO.usedObstacles[i], ObstacleGhostObj.Instance);
            OCBDC.obstaclesCreateBtns.Add(obsBtn);
        }
        ObstacleGhostObj.Instance.Hide();
        _creatObstacleBtn.gameObject.SetActive(false);


    }


}
