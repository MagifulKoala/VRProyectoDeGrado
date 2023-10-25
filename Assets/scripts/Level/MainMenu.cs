using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void JugarTutorial()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Jugar()
    {
        SceneManager.LoadScene("tutorialLevel");
    }



}
