using DefaultNamespace;
using DG.Tweening;
using UnityEngine;


public class SquareView : MonoBehaviour, IDirectionMovable
{
    
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Camera _camera;

    public Vector2Int Direction { get; private set; }
    
    private void Awake()
    {
        _camera = Camera.main;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    public void Move(Vector2 targetPos)
    {
        transform.DOMove(targetPos, 1).OnComplete(DestroyGameObject);
    }

    public void SetItemInfo(Color color, Vector2Int direction)
    {
        Direction = direction;
        _spriteRenderer.color = color;

    }

    private void DestroyGameObject()
    {
        if (Mathf.Abs(transform.position.y) >= _camera!.orthographicSize || Mathf.Abs(transform.position.x) >= Camera.main.aspect * Camera.main.orthographicSize)
        {
            Destroy(gameObject);
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Square"))
    //    {
    //        _animator.SetTrigger("Collision");
    //    }
    //}


    
}
