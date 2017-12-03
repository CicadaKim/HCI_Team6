using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Post : MonoBehaviour {

    Collider2D c2d;
    bool isSelected = false;
    public Sprite postImage;
    // Use this for initialization
    void Start () {
        c2d = GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(1))
        {
            Vector2 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            bool contain = c2d.bounds.Contains(mp);
            if (contain)
            {
                isSelected = true;
            }
        }
        if (Input.GetMouseButton(1))
        {
            if (isSelected)
            {
                Vector2 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }

        if (Input.GetMouseButtonUp(1))
        {
            if (isSelected)
            {
                Vector2 mp = Input.mousePosition;
                isSelected = false;
                bool contain = c2d.bounds.Contains(Camera.main.ScreenToWorldPoint(mp));
                if(!contain)
                {
                    UserMenuManager.instance.createUM(mp, 1, 1,postImage);
                    gameObject.SetActive(false);
                }

            }

        }
    }
}
