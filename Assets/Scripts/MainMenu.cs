using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Level1(){
        SceneManager.LoadScene("Level 1");
    }

    public void Level2(){
        SceneManager.LoadScene("Level 2");
    }

    public void Level3(){
        SceneManager.LoadScene("Level 3");
    }

    public void Level4(){
        SceneManager.LoadScene("Level 4");
    }
    
    public void LevelSelect(){
        SceneManager.LoadScene("LevelSelect");
    }

    public void MainMenu1(){
        SceneManager.LoadScene("MainMenu");
    }

    public void Options(){
        SceneManager.LoadScene("Options");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
}
