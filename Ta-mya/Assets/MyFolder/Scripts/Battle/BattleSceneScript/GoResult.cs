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

    [SerializeField]
    GameObject transitionPrefab;
    readonly float waitTime = 0.9f;
    private bool InLoad;

    public static GoResult instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        if (Enemy.instance.EnemyCount <= 0)
        {
            Player.instance.GetSocre_HP();
            isWin = true;
            DisplayResult();
            if (!InLoad)
            {
                Debug.Log("IN");
                InLoad = true;
                Invoke("Load", 3);
            }
        }
    }

    public void DisplayResult()
    {
        // Ÿ—˜‚¾‚Á‚½‚çWin‚ð•\Ž¦
        if (isWin)
        {
            WinPanel.SetActive(true);
        }
        // •‰‚¯‚½‚çGameOver‚ð•\Ž¦
        else
        {
            GameOverPanel.SetActive(true);
        }
    }

    private void Load()
    {
        Debug.Log("LoadIN");
        StartCoroutine(nameof(LoadScene));
    }

    IEnumerator LoadScene()
    {
        Instantiate(transitionPrefab);

        yield return new WaitForSeconds(waitTime);

        SceneManager.LoadScene("Result");
    }
}
