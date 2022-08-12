using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GridSlot
{
    public readonly Vector2 Position;
    public readonly int Row;
    public readonly int Column;

    public GameObject Item;

    public GridSlot(int rows, int columns, Vector2 position)
    {
        Row = rows;
        Column = columns;
        Position = position;
    }
}