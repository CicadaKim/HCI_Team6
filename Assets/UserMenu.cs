using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserMenu : MonoBehaviour {

    int currentTap = 1;
    public int sizeTap = 1;
    public Button[] taps;
    public Button addButton;

    public Text contentText;
    public Image contentImage;
    public Text[] tapText;

    public string[] content_text;
    public Sprite[] content_image;
    public string[] tap_title;


    public Collider2D c2d;

    bool isSelected = false;
        

	// Use this for initialization
	void Awake () {
        c2d = GetComponent<Collider2D>();
        content_text = new string[5];
        tap_title = new string[5];
        content_image = new Sprite[5];

        for(int i=1; i<=5; i++)
        {
            content_image[i-1] = null;
            content_text[i-1] = "content about tap"+i;
            tap_title[i-1] = "taps" + i;
        }

        showTap(1);
	}
    
	// Update is called once per frame
	void Update () {
		
        if(Input.GetMouseButtonDown(1))
        {
            Vector2 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            bool contain = c2d.bounds.Contains(mp);
            if (contain)
            {
                isSelected = true;
            }
        }
        if(Input.GetMouseButton(1))
        {
            if(isSelected)
            {
                Vector2 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                gameObject.transform.position = mp;
            }
        }

        if(Input.GetMouseButtonUp(1))
        {
            if(isSelected)
            {
                Vector2 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                isSelected = false;
                UserMenu to = UserMenuManager.instance.FindIn(this, mp);
                Debug.Log(to);
                if (to == null) return;
                UserMenuManager.instance.attachMenus(this, to);
            }
            
        }
	}

    public void showTap(int i)
    {
        if (content_image[i - 1] != null)
            contentImage.sprite = content_image[i - 1];
        if (content_text[i - 1] != null)
            contentText.text = content_text[i-1];
        currentTap = i;
    }

    public void moveAddButton()
    {
        if(sizeTap==5)
        {
            addButton.gameObject.SetActive(false);
            return;
        }
        addButton.gameObject.SetActive(true);
        Vector3 next = taps[sizeTap - 1].transform.GetComponent<RectTransform>().localPosition;
        next.x += addButton.GetComponent<RectTransform>().sizeDelta.x / 2 + taps[sizeTap - 1].transform.GetComponent<RectTransform>().sizeDelta.x/2;

        addButton.GetComponent<RectTransform>().localPosition = next;
    }

    public void addTap()
    {
        if (sizeTap > 4) return;

        taps[sizeTap].gameObject.SetActive(true);
        tapText[sizeTap].text =  tap_title[sizeTap];
        sizeTap++;
        moveAddButton();

    }

    public void deleteTap()
    {
        if (sizeTap < 1) return;
        if (sizeTap == 1)
        {
            UserMenuManager.instance.deleteUserMenu(this);
            return;
        }
        taps[--sizeTap].gameObject.SetActive(false);
        moveAddButton();
    }
}
