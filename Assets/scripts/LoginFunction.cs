using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginFunction : MonoBehaviour {
    
    public void LoadLibraryScene()
    {
        Debug.Log("load library");
        SceneManager.LoadScene("HCI_Library");
    }

}
