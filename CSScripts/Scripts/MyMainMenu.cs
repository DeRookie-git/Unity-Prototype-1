using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public interface IMenu 
{
    void MyPlay();
    void MyQuit();
    void MyHangar();
}

public class MyMainMenu : MonoBehaviour
{
    public void MyPlay() {
        SceneManager.LoadScene(1);
    }
    public void MyQuit() {
        Application.Quit();
    }
    public void MyHangar() {
        SceneManager.LoadScene(2);
    }
}

