using UnityEngine;
namespace DefaultNamespace
{
    public interface IDirectionMovable
    {
        void Move(Vector2 vector2);
        Vector2Int Direction { get; }
    }
}