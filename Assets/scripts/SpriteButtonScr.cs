using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// 모든 sprite button의 상위 클래스. 
/// </summary>
public class SpriteButtonScr : MonoBehaviour
{
    public UnityEvent onTouchDown=null;
    public UnityEvent onTouchUp=null;

    public bool isActive;
    public bool isSelected;

    Collider2D c2d;

    private void Awake()
    {
        c2d = GetComponent<Collider2D>();
        isActive = true;
        isSelected = false;
    }

    public bool isIn(Vector2 position)
    {
        Debug.Log(position);
        return c2d.bounds.Contains(position);
    }

    public void TouchDown()
    {
        isSelected = true;
        if (onTouchDown != null)
            onTouchDown.Invoke();
    }

    public void TouchUp()
    {
        if (onTouchUp != null)
            onTouchUp.Invoke();
    }

        
}

