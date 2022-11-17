using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    [SerializeField] private Animator[] animator;
    private GameObject Select;
    private int num;
    // Start is called before the first frame update
    void Start()
    {

        //Debug.Log("++‘O‚Ì" + animator[Select.GetComponent<SelectShip>().Count]);
    }

    // Update is called once per frame
    public void Update()
    {

        //animator[num].SetBool("Special", true);
        //animator[Select.GetComponent<SelectShip>().Count].SetBool("select", true);
        //Debug.Log(Select.GetComponent<SelectShip>().Count);
        //Debug.Log("animation" + animator[Select.GetComponent<SelectShip>().Count]);
    }


    public void ShipAnimStart()
    {
        animator[num].SetBool("select", true);
    }

    public void ShipAnimStop()
    {
        animator[num].SetBool("select", false);

        num++;

        if (num >= 4)
        {
            num = 0;
        }
    }

    public void SpAnimStart()
    {
        animator[num].SetBool("Special", true);
    }

    public void SpAnimStop()
    {
        animator[num].SetBool("Special", false);

        num++;

        if (num >= 4)
        {
            num = 0;
        }
    }
}
