using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FacilityMenu : MonoBehaviour
{
    // Controlling Facility Menu
    public void currencyexch() { }
    public void restaurants() {
        SceneManager.LoadScene(2);
    }
    public void mosque() { }
    public void ATM() { }
    public void Waiting() { }
    public void toilet() { }
    public void Back() {
        SceneManager.LoadScene(0);
    }



}
