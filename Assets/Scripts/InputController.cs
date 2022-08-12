using System;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public event Action<Vector2> OnPointerDown;
    private void Update()
    {

        // if (Input.touchCount > 0)
        // {
        //     Touch touch = Input.GetTouch(0);
        //
        //     switch (touch.phase)
        //     {
        //         case TouchPhase.Began:
        //             OnPointerDown?.Invoke(touch.position);
        //             break;
        //     }
        // }

        if (Input.GetMouseButtonDown(0))
        {
            OnPointerDown?.Invoke(Input.mousePosition);
        }
            
    }
}
