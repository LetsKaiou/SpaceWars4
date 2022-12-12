using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    private GameObject save;
    private Save savecs;


    // �V�[���J�ڏ���(�^�C�g�����)
    
    // �V�[���J�ڏ���(�X)

    // �V�[���J�ڏ���(�Ґ����)
    public void OnClickSelectShipButton()
    {
        SceneManager.LoadScene("Formation");
    }

    public void OnClickDevelopmentButton()
    {
        SceneManager.LoadScene("Development");
    }

    public void OnClickSelectSpecialAttackButton()
    {
        SceneManager.LoadScene("SpecialAttack");
    }

    public void OnclickBaseButton()
    {
        SceneManager.LoadScene("BaseCityScene");
    }

    public void OnclickHenseiButton()
    {
        SceneManager.LoadScene("SelectScenes");
    }

    public void OnclickTapToStartButton()
    {
        SceneManager.LoadScene("BaseCityScene");
    }

    public void OnclickBattleSelectButton()
    {
        save = GameObject.Find("GameObject");
        savecs = save.GetComponent<Save>();
        savecs.SetStatus();
        SceneManager.LoadScene("BattleSelectScene");
    }

    public void OnclickBattle()
    {
        SceneManager.LoadScene("demo");
    }

    public void OnclickResult()
    {
        SceneManager.LoadScene("Result");
    }


    public void OnClickBackButton(int Num)
    {
        switch (Num)
        {
            case 0:
                SceneManager.LoadScene("BaseCityScene");
                break;
            case 1:
                SceneManager.LoadScene("SelectScenes");
                break;
            case 2:
                SceneManager.LoadScene("Formation");
                break;
            case 3:
                SceneManager.LoadScene("SpecialAttack");
                break;
            case 4:
                SceneManager.LoadScene("Development");
                break;
            default:
                break;
        }
               
    }

    // �V�[���J�ڏ���(�o�g��)
}
