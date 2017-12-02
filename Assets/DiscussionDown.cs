using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiscussionDown : MonoBehaviour {

    Collider2D c2d;
    public Button[] btns;
    bool isShow;
	// Use this for initialization
	void Start () {
        c2d = GetComponent<Collider2D>();
        isShow = false;
	}
	
	// Update is called once per frame
	void Update () {

        Vector2 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        bool contain = c2d.bounds.Contains(mp);
        if ( isShow==false &&  contain)
        {
            for (int i = 0; i < btns.Length; i++)
                btns[i].transform.gameObject.SetActive(true);
            isShow = true;
        }
        else if(isShow==true && !contain)
        {
            for (int i = 0; i < btns.Length; i++)
                btns[i].transform.gameObject.SetActive(false);
            isShow = false;
        }
		
	}
}
