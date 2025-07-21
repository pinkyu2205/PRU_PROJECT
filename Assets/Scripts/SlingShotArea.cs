using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class SlingShotArea : MonoBehaviour
{
    [SerializeField] private LayerMask _slingshotAreaMask;

    public bool IsWithinSlingshotArea()
    {
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(InputManager.MousePosition);

        if (Physics2D.OverlapPoint(worldPosition, _slingshotAreaMask))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
