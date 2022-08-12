using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class GridRow
{
     public List<GridCell> cells = new List<GridCell>();
}


[CreateAssetMenu(fileName = "Field", menuName = "Playing Field")]
public class LevelInfo : ScriptableObject
{
    public List<GridRow> gridRows = new List<GridRow>();
}
