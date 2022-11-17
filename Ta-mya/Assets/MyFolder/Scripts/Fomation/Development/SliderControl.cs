using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class SliderControl : MonoBehaviour
{

    // ���ꂼ��̓��̓{�^����������������̏ꏊ�ɂǂ̃X�e�[�^�X���㏸���邩�\�����鏈���̒ǉ�
    // ���U���g��ʂŊe�|�C���g�̒l���Q�Əo����悤�ɂ���

    // �X���C�_�[�̃I�u�W�F�N�g�i�[�p
    [SerializeField] private Slider[] SliderObj;
    // �X���C�_�[�̍ő�l�A���݂̓��͒l�i�[�p
    private float Max = 100;
    private int count;
    public static int[] Now_value = new int[3];
    private int check;
    private int data;
    // ���͂��ꂽ�f�[�^�i�[�p
    public TMP_InputField[] inputField;
    // �e�L�X�g�p
    [SerializeField] string IndText;
    [SerializeField] string ComText;
    [SerializeField] string AgrText;
    [SerializeField] TextMeshProUGUI Explanation;
    [SerializeField] TextMeshProUGUI Remaining;

    private void Start()
    {
        // '��'���͗p�R���|�[�l���g�擾
        for (int i = 0; i < inputField.Length; i++)
        {
            inputField[i] = inputField[i].GetComponent<TMP_InputField>();
        }
    }
    private void Update()
    {
        Remaining.SetText("Remaing : {0}", 100 - data);
    }

    // ���͂��ꂽ�����ɉ����ăX���C�_�[�𓮂�������
    public void SetData(int num)
    {
        int.TryParse(inputField[num].text, out check);
        // 100�ȏ�̒l����͂��ꂽ��0�ɂ���
        if (check > 100 )
        {
            
            inputField[num].text = "0";
        }

        // Now_value�ɓ��͂��ꂽ������ϊ�
        //Now_value[num] = int.Parse(inputField[num].text);
        int.TryParse(inputField[num].text, out Now_value[num]);
        // count�ɓ��͂��ꂽ�l�̍��v����
        count = Now_value.Sum();
        
        // ���͂����l�̍��v�l��100���z�����ꍇ0�ɂ���
        if (count > 100)
        {
            inputField[num].text = "0";
        }
        // ���͂��ꂽ�l�̍��v�l��100�ȉ��̏ꍇ�X���C�_�[��value�ɒl����
        else
        {
            data += Now_value[num];
            // �X���C�_�[�̒l�ɓ��͂��ꂽ�l����
            SliderObj[num].value = Now_value[num];
        }

    }

    // �������\������
    public void SetExplanation(int select)
    {
        Explanation.SetText("");
        switch (select)
        {
            case 0:
                Explanation.SetText(IndText);
                break;
            case 1:
                Explanation.SetText(ComText);
                break;
            case 2:
                Explanation.SetText(AgrText);
                break;
        }
    }
}
