using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public int id;

    public void cambiarNivelString(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void cambiarNivelInt(int id)
    {
        SceneManager.LoadScene(id);
    }

    public void JugarTutorial()
    {
        SceneManager.LoadScene("basicTutorial");
    }

    public void Jugar()
    {
        SceneManager.LoadScene("tutorialLevel");
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }



}
