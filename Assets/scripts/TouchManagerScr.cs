using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TouchManagerScr : MonoBehaviour
{
    public UnityEvent onRemain = null; // 아무 버튼도 안눌렸을때
    public SpriteButtonScr[] buttonArr;

    SpriteButtonScr prev=null;

    void Awake()
    {
    }

    void Update()
    {
        CheckInput();
    }

    void CheckInput()
    {
        if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor)
        {
            Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Input.GetKeyDown(KeyCode.Space))
                occurRemain();

            if (Input.GetMouseButtonDown(0))
            {
                int i = 0;
                for(; i<buttonArr.Length; i++)
                {
                    SpriteButtonScr sb = buttonArr[i];
                    if( sb.isIn( mp ) )
                    {
                        prev = sb;
                        sb.TouchDown();
                        break;
                    }
                }
                if (i == buttonArr.Length)
                    occurRemain();
            }
            else if(Input.GetMouseButtonUp(0))
            {
                if(prev!=null)
                {
                    prev.isSelected = false;
                    if (prev.isIn(mp))
                    {
                        prev.TouchUp();
                    }
                    prev = null;
                }
            }

        }
        if (Input.touchCount <= 0) return;

        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);
            if (touch.phase == TouchPhase.Began)
            {
                break;
            }
        }
    }

    void occurRemain()
    {
        if (onRemain != null) onRemain.Invoke();
    }

}

