using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Controlling the main menu
    public void Home() { }
    public void Show_Tutorial() { }
    public void SelectFacility() {
        //loding the facility menu
        SceneManager.LoadScene(1);
    }
    public void Contact() { }

}
