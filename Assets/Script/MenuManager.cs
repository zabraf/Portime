using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        if (PlayerPrefs.HasKey("level"))
        {
            button.SetActive(true);
        }
        else
        {
            button.SetActive(false);
        }
    }
    public void NewGame()
    {
        int level = SceneManager.GetActiveScene().buildIndex + 1;
        PlayerPrefs.SetInt("level", level);
        SceneManager.LoadScene(level);
    }
    public void Resume()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("level"));
    }
    public void Quit()
    {
        Application.Quit();
    }
}
