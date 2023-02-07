using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoResult : MonoBehaviour
{
    public static bool isWin;

    [SerializeField] private GameObject WinPanel;
    [SerializeField] private GameObject GameOverPanel;

    public static GoResult instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void DisplayResult()
    {
        // Ÿ—˜‚¾‚Á‚½‚çWin‚ğ•\¦
        if (isWin)
        {
            WinPanel.SetActive(true);
        }
        // •‰‚¯‚½‚çGameOver‚ğ•\¦
        else
        {
            GameOverPanel.SetActive(true);
        }
    }

}
