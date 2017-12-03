using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserMenuManager : MonoBehaviour {

    public static UserMenuManager instance = null;
    List<UserMenu> umList;

    public GameObject userMenu;
    public Canvas canvas;

	// Use this for initialization
	void Awake () {

        if (instance != null)
            Destroy(this);
        instance = this;
        umList = new List<UserMenu>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void createUM(Vector2 dest,float sx, float sy , Sprite content_image=null)
    {
        GameObject go = Instantiate(userMenu, (Vector2)(Camera.main.ScreenToWorldPoint(dest)), Quaternion.identity, canvas.transform);
        go.transform.localScale = new Vector3(sx, sy, 1);

        addUserMenu(go.GetComponent<UserMenu>());
        if(content_image!=null)
        {
            go.GetComponent<UserMenu>().content_image[0] = content_image;
            go.GetComponent<UserMenu>().showTap(1);
        }
        
    }

    public void addUserMenu(UserMenu um)
    {
        umList.Add(um);
    }

    public void deleteUserMenu(UserMenu um)
    {
        Destroy(um.gameObject);
        umList.Remove(um);
    }

    public UserMenu FindIn(UserMenu from,Vector2 pos)
    {
        foreach(UserMenu um in umList)
        {
            if (um == from) continue;
            if (um == null) continue;
            if (um.c2d.bounds.Contains(pos))
                return um;
        }
        return null;
    }

    public bool attachMenus(UserMenu from, UserMenu to)
    {
        if (from.sizeTap + to.sizeTap > 5) return false;

        int anchor = to.sizeTap;
        from.gameObject.SetActive(false);
        for (int i = 0; i < from.sizeTap; i++)
        {
            to.content_text[anchor+i] = from.content_text[i];
            to.content_image[anchor + i] = from.content_image[i];
            to.tap_title[anchor + i] = from.tap_title[i];
            to.addTap();
        }
        deleteUserMenu(from);
        return true;
    }
}
