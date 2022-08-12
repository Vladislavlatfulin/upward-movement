using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using DefaultNamespace;

public class Grid : MonoBehaviour
{
    [SerializeField] private LevelInfo levelInfo;

    public GridSlot[][] Slots { get; private set; }

    private int Rows { get; set; }

    private int Columns { get; set; }

    private float _offset = 1.2f;
    private readonly Vector2 _startPos = new Vector2(-1, 1);

    private void Awake()
    {
        Rows = levelInfo.gridRows.Count;
        Slots = new GridSlot[Rows][];
        Columns = GetMaxColumns();
        for (var i = 0; i < Rows; i++)
        {
            Slots[i] = new GridSlot[Columns];
            for (var j = 0; j < Columns; j++)
            {

                var position = new Vector2((_offset * i) + _startPos.x, (-_offset * j) + _startPos.y);

                var slot = new GridSlot(i, j, position);

                Slots[i][j] = slot;
            }
        }
    }

    private int GetMaxColumns()
    {
        var temp = levelInfo.gridRows[0].cells.Count;
        return levelInfo.gridRows.Select(t => t.cells.Count).Prepend(temp).Max();
    }

    public GridSlot GetFreeSlot(GridSlot slot)
    {
        var freeSlot = slot;
        var item = slot.Item.GetComponent<IDirectionMovable>();
        var direction = item.Direction;
        var dir = new Vector2Int(direction.x, direction.y);
        var slotCoordinates = new Vector2Int(slot.Row, slot.Column);
        _ = direction.x != 0 ? slotCoordinates += direction : slotCoordinates -= direction;


        while (slotCoordinates.x >= 0 && slotCoordinates.x < Rows && slotCoordinates.y >= 0 && slotCoordinates.y < Columns)
        {
            if (Slots[slotCoordinates.x][slotCoordinates.y].Item == null)
            {
                freeSlot = Slots[slotCoordinates.x][slotCoordinates.y];
            }

            else
            {
                break;
            }
            _ = direction.x != 0 ? slotCoordinates += direction : slotCoordinates -= direction;
            
        }

        return freeSlot;
    }

    public bool IsFreeAxis(GridSlot slot)
    {
        var item = slot.Item.GetComponent<IDirectionMovable>();
        var direction = new Vector2Int(item.Direction.x, item.Direction.y);
        var slotCoordinates = new Vector2Int(slot.Row, slot.Column);
        //slotCoordinates =DifferenceBetweenSlots(direction, slotCoordinates);
        _ = direction.x != 0 ? slotCoordinates += direction : slotCoordinates -= direction;
        
        while (slotCoordinates.x >= 0 && slotCoordinates.x < Rows && slotCoordinates.y >= 0 && slotCoordinates.y < Columns)
        {
            if (Slots[slotCoordinates.x][slotCoordinates.y].Item != null)
            {
                return false;
            }
            //slotCoordinates = DifferenceBetweenSlots(direction, slotCoordinates);
            _ = direction.x != 0 ? slotCoordinates += direction : slotCoordinates -= direction;

        }
        return true;
    }

    public GridSlot GetCurrentSlot(Transform hitObject)
    {
        GridSlot currentSlot = null;

        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                if (Slots[i][j].Position == (Vector2)hitObject.position)
                {
                    currentSlot = Slots[i][j];
                }
            }
        }

        return currentSlot;
    }
}
