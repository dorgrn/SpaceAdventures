using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ApplicationManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }

    public static void ExitApplication()
    {
        Application.Quit();
    }

    public static  void StartGame()
    {
        Debug.Log("start game");
        SceneManager.LoadScene("Game");
    }

    public static void ShowInstructions()
    {
        Debug.Log("show instructions");
        // TODO implement
    }
}
