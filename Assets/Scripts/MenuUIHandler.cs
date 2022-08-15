using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
using TMPro;

public class MenuUIHandler : MonoBehaviour
{


    public TextMeshProUGUI scoreText;

    private void Start()
    {
        DisplayBestScore();
    }
    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void GetName()
    {
        GameObject inputField = GameObject.Find("NameInput");
        Singleton.Instance.CurrentName = inputField.GetComponent<TMP_InputField>().text;
    }

    public void DisplayBestScore()
    {
        scoreText.text = "Best Score :" + Singleton.Instance.BestName + " :" + Singleton.Instance.BestScore;  
    }

}
