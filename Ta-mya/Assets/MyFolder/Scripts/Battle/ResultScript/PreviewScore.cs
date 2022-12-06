using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PreviewScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] DeveropmentText;
    private int[] DevelopNum = new int[3];
    public  int[] MultiDevelop = new int[3];
    [SerializeField] private int multiply;
    public static int Ind;
    public static int Com;
    public static int Agr;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < DeveropmentText.Length; i++)
        {
            DeveropmentText[i].SetText("Point : {0}", SliderControl.Now_value[i]);
            DevelopNum[i] = SliderControl.Now_value[i];
            MultiDevelop[i] = DevelopNum[i] * multiply;
            switch (i)
            {
                case 0:
                    Ind = MultiDevelop[0];
                    break;
                case 1:
                    Com = MultiDevelop[1];
                    break;
                case 2:
                    Agr = MultiDevelop[2];
                    break;
            }
        }
    }
}
