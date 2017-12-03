using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateUM : MonoBehaviour {

    public GameObject userMenu;
    bool isCreating;
    bool isScreenDown;
    Vector2 startPos;

    Vector2 uSize;

	// Use this for initialization
	void Start () {
        isCreating = false;
        isScreenDown = false;

        uSize = userMenu.GetComponent<RectTransform>().sizeDelta;
	}
	
	void Update () {
		
        if(isCreating)
        {
            if(Input.GetMouseButtonDown(1))
                StopCreating();
            if(Input.GetMouseButtonDown(0))
            {
                startPos = Input.mousePosition;
                isScreenDown = true;
            }
            if(Input.GetMouseButtonUp(0))
            {
                Vector2 endPos =Input.mousePosition;
                if(isScreenDown)
                {
                    float width = Mathf.Abs(endPos.x - startPos.x);
                    float height = Mathf.Abs(endPos.y - startPos.y);

                    float sx = 1;
                    float sy = 1;

                    if (width > uSize.x)
                        sx = width / uSize.x;
                    if (height > uSize.y)
                        sy = height / uSize.y;

                    Vector2 dest = startPos;;
                    if(endPos.y < startPos.y)
                    {
                        if (endPos.x < startPos.x)
                            dest = new Vector2(endPos.x,startPos.y);
                    }
                    else
                    {
                        if (endPos.x < startPos.x)
                            dest = endPos;
                        else
                            dest = new Vector2(startPos.x,endPos.y);
                    }

                    UserMenuManager.instance.createUM(dest,sx,sy);
                    isCreating = false;
                }
                isScreenDown = false;
            }
            
        }
	}

    public void StartCreating()
    {
        isCreating = true;
    }

    public void StopCreating()
    {
        isCreating = false;
    }

}
