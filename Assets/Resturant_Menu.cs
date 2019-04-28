using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Resturant_Menu : MonoBehaviour
{
    // Controlling Resturant Menu
    public void starbucks() { }
    public void Costa() { }
    public void Dankin() { }
    public void life() { }
    public void cafe() { }
    public void Back()
    {
        SceneManager.LoadScene(1);
    }
}
