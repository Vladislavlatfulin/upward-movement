using UnityEngine;

public class CreateLevel : MonoBehaviour
{
    [SerializeField] private LevelInfo levelInfo;
    [SerializeField] private Grid grid;
    [SerializeField] private GameObject prefab;

    private void Start()
    {
        for (int i = 0; i < levelInfo.gridRows.Count; i++)
        {      
            for (int j = 0; j < levelInfo.gridRows[i].cells.Count; j++)
            {
                var cell = levelInfo.gridRows[i].cells[j];

                GridSlot slot = grid.Slots[i][j];

                var item = Instantiate(prefab, slot.Position, Quaternion.identity);

                var squareViewComponent = item.GetComponent<SquareView>();
                if (squareViewComponent != null)
                {
                    squareViewComponent.SetItemInfo(cell.Color, cell.Direction);
                }

               

                //switch (cell.Direction)
                //{

                //    case Vector2Int down when down.Equals(Vector2.down):
                //        item.transform.rotation = Quaternion.Euler(0f, 0f, 180f);
                //        break;

                //    //case Vector2Int up when up.Equals(Vector2.up):
                //    //    break;

                //    case Vector2Int right when right.Equals(Vector2.right):
                //        break;


                //    case Vector2Int left when left.Equals(Vector2.left):
                //        break;


                    
                //}

                slot.Item = item;

            }
        }
    }
}
