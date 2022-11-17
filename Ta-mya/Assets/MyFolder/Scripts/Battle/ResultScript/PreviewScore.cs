using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PreviewScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] DeveropmentText;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < DeveropmentText.Length; i++)
        {
            DeveropmentText[i].SetText("Point : {0}", SliderControl.Now_value[i]);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
