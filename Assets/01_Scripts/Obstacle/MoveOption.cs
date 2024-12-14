using DG.Tweening;
using UnityEngine;

public class MoveOption : MonoBehaviour
{
    [SerializeField] private Vector2 _movePoint;
    private Vector2 _startPoint;
    public bool isCanMove = true;

    private void Start()
    {
        _startPoint = transform.localPosition;
    }


    public void Move(bool isCanBack)
    {
        //if(isCanMove == false) return;
        isCanMove = false;
        if (!isCanBack)
        {
            transform.DOLocalMove(_movePoint, 0.45f).OnComplete(() =>
            {
                isCanMove = true;
            });
        }
        else if (isCanBack)
        {
            transform.DOLocalMove(Vector3.zero, 0.45f).OnComplete(() =>
            {
                isCanMove = true;
            });
        }
    }
}
