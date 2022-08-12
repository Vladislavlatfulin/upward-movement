using System;
using DefaultNamespace;
using UnityEngine;

public class SquaresMovementManager : MonoBehaviour
{
    [SerializeField] private InputController inputController;
    [SerializeField] private Grid grid;

    private void Awake()
    {        
        inputController.OnPointerDown += HandleOnPointerDown;
    }

    private void HandleOnPointerDown(Vector2 position)
    {
        var worldPosition = Camera.main!.ScreenToWorldPoint(position);

        var hitInfo = Physics2D.OverlapPoint(worldPosition);

        if (hitInfo != null)
        {
            var movable = hitInfo.gameObject.GetComponent<IDirectionMovable>();
            if (movable != null)
            {

                var movableSlot = grid.GetCurrentSlot(hitInfo.transform);
                Vector2 borderPosition;

                if (grid.IsFreeAxis(movableSlot))
                {
                    borderPosition = new Vector2((20 * movable.Direction.x) + movableSlot.Position.x,
                       (20 * movable.Direction.y) + movableSlot.Position.y);                    
                }

                else
                {
                    var nextSlot = grid.GetFreeSlot(movableSlot);
                    if (movableSlot.Position != nextSlot.Position)
                    {
                        nextSlot.Item = movableSlot.Item;
                        movableSlot.Item = null;
                    }
                    borderPosition = nextSlot.Position;

                }

                movable.Move(borderPosition);

            }
        }
    }
}
