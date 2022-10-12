using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject OptionsCanvas;

    public void Play()
    {
        SceneManager.LoadScene(2);
    }

    public void Load()
    {
        //Тут кароче я хз чо надо
    }

    public void Options()
    {
        OptionsCanvas.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}