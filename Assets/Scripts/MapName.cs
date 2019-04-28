using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapName : MonoBehaviour
{
    public void OnClickcosta()
    {
        PlayerPrefs.SetString("mapname", "costa");
        PlayerPrefs.Save();
        SceneManager.LoadScene("Home");
    }
    public void OnClickcafe()
    {
        PlayerPrefs.SetString("mapname", "cafe");
        PlayerPrefs.Save();
        SceneManager.LoadScene("Home");
    }
    public void OnClicklife()
    {
        PlayerPrefs.SetString("mapname", "life");
        PlayerPrefs.Save();
        SceneManager.LoadScene("Home");
    }
    public void OnClickstar()
    {
        PlayerPrefs.SetString("mapname", "star");
        PlayerPrefs.Save();
        SceneManager.LoadScene("Home");
    }
    public void OnClickdankin()
    {
        PlayerPrefs.SetString("mapname", "dankin");
        PlayerPrefs.Save();
        SceneManager.LoadScene("Home");
    }
    public void OnClickshawermar()
    {
        PlayerPrefs.SetString("mapname", "shawermar");
        PlayerPrefs.Save();
        SceneManager.LoadScene("Home");
    }
  


}
