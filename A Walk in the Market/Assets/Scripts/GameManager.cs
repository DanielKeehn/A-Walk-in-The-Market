using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public void goToNextDay() {
        DontDestroyOnLoad(GameObject.Find("StartMainMusic").GetComponent<AudioSource>());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void startGame() {
        Object.Destroy(GameObject.Find("StartAudio").GetComponent<AudioSource>());
        SceneManager.LoadScene("Day1");
    }

    public void goToAboutPage() {
        DontDestroyOnLoad(GameObject.Find("StartAudio").GetComponent<AudioSource>());
        SceneManager.LoadScene("About");
    }

    public void backToStart() {
        SceneManager.LoadScene("TitleScreen");
    }

    public void Quit() {
        Application.Quit();
    }

}
