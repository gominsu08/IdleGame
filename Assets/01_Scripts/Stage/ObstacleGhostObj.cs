using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class ObstacleGhostObj : MonoSinglton<ObstacleGhostObj>
{
    [SerializeField] private ContactFilter2D contactFilter;
    private SpriteRenderer _spriteRenderer;
    private Vector3 _mousePos;
    private List<RaycastHit2D> rayObj = new List<RaycastHit2D>();

    public Color _defaulteColor, _redColor;


    [HideInInspector] public Grid grid;
    public bool isCanCreateObstacle;


    private Obstacle _obstacle;
    private ObstaclesCreateBtn _createBtn;

    public UnityEvent<Obstacle, Vector2> OnCreatObstacleEvent;


    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }



    private void Update()
    {
        _mousePos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
        Vector3Int cellPos = grid.WorldToCell(_mousePos);

        Vector2 ghostPos = grid.GetCellCenterWorld(cellPos);

        GhostObjPosSet(ghostPos);

        if (Input.GetMouseButtonDown(0) && isCanCreateObstacle && _createBtn.Count > 0)
        {
            OnCreatObstacleEvent?.Invoke(_obstacle, ghostPos);
            _createBtn.isCreateObj = true;
            _createBtn.CountTextSet(_createBtn.Count - 1);
        }
    }

    private void GhostObjPosSet(Vector2 ghostPos)
    {

        if (grid == null) return;

        int i = Physics2D.Raycast(ghostPos, new Vector3(0.15f, 0), contactFilter, rayObj, 0.15f);


        if (i > 0 || rayObj.Count() > 0)
        {
            _spriteRenderer.color = _redColor;
            isCanCreateObstacle = false;
            rayObj.Clear();
            Debug.Log("설치 불가지역");
        }
        else
        {
            _spriteRenderer.color = _defaulteColor;
            isCanCreateObstacle = true;
        }

        transform.position = ghostPos;
    }

    public void Show(Sprite image, Obstacle obstacle, ObstaclesCreateBtn createBtn)
    {
        _spriteRenderer.sprite = image;
        _obstacle = obstacle;
        gameObject.SetActive(true);
        _createBtn = createBtn;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
