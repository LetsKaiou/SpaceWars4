using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{    
    // Heal�̉񕜗�
    [SerializeField] private int HealPoint;
    private Player py;

    public static Heal instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        py = GameObject.Find("Yamato").GetComponent<Player>();

    }

    // HP�� ID:10
    public void P_Heal()
    {
        Player.instance.hp_slider.value += HealPoint;
    }
}
