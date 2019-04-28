using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Grade_Project_MenuLogic : MonoBehaviour
{
    public GameObject p1, p2, p3;
    public InputField numberTxt, instText;
    public void ActiveRoomNumber()
    {
        p1.SetActive(false);
        p3.SetActive(true);
    }
    public void ActiveInstaName()
    {
        p1.SetActive(false);
        p2.SetActive(true);
    }

    public void RoomNumberMapNameGenerate()
    {
        PlayerPrefs.SetString("mapname", numberTxt.text.ToString());
        PlayerPrefs.Save();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Home");
    }
    public void InstTextMapNameGenerate()
    {
        PlayerPrefs.SetString("mapname", instText.text.ToString());
        PlayerPrefs.Save();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Home");
    }

    public void OnClickBack1()
    {
        p1.SetActive(true);
        p2.SetActive(false);
        p3.SetActive(false);
    }
    public void OnClickBack2()
    {
        p1.SetActive(true);
        p2.SetActive(false);
        p3.SetActive(false);
    }
}
