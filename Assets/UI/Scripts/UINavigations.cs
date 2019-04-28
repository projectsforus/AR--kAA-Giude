using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UINavigations : MonoBehaviour {

    public GameObject screen1, screen2, screen3;

	// Update is called once per frame
	void Update () {
       
        
    }

    public void NavigationRight()
    {
        screen1.SetActive(true);
        screen2.SetActive(false);
        screen3.SetActive(false);
    }
   
    
}
