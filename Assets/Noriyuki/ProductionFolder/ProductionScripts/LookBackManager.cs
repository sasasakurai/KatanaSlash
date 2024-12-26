using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LookBackManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMesh;

    [SerializeField] GameObject NextButton;
    [SerializeField] GameObject BackButton;
    [SerializeField] TextMeshProUGUI NextTextMesh;


    [SerializeField] TextMeshProUGUI TitleText1;
    [SerializeField] TextMeshProUGUI TitleText2;
    [SerializeField] TextMeshProUGUI TitleText3;
    [SerializeField] TextMeshProUGUI TitleText4;
    [SerializeField] TextMeshProUGUI TitleText5;
    [SerializeField] TextMeshProUGUI LeftText1;
    [SerializeField] TextMeshProUGUI LeftText2;
    [SerializeField] TextMeshProUGUI LeftText3;
    [SerializeField] TextMeshProUGUI LeftText4;
    [SerializeField] TextMeshProUGUI LeftText5;
    [SerializeField] TextMeshProUGUI CenterText1;
    [SerializeField] TextMeshProUGUI CenterText2;
    [SerializeField] TextMeshProUGUI CenterText3;
    [SerializeField] TextMeshProUGUI CenterText4;
    [SerializeField] TextMeshProUGUI CenterText5;
    [SerializeField] TextMeshProUGUI RightText1;
    [SerializeField] TextMeshProUGUI RightText2;
    [SerializeField] TextMeshProUGUI RightText3;
    [SerializeField] TextMeshProUGUI RightText4;
    [SerializeField] TextMeshProUGUI RightText5;




    public int pagenum;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetFirst()
    {
        pagenum = 0;
        SetText();
    }


    private void SetText()
    {
        textMesh.text = "�ȏ�Ńe�X�g�͏I���ł��BGoogleForm�̉񓚂����肢���܂��B\n���̉�ʂł͐ݖ�";
        if(pagenum == 0)
        {
            textMesh.text += "1�`5�̉񓚌��ʂ��\������Ă��܂��B\n�E���́u���ցv��������6�`10��ڂ̉񓚂��\������܂��B\n���ꂼ��̐ݖ�����Ԃ������ł��܂��B\n���Ȃ��̃e�X�g�ԍ���"+GameManager.Instance.TestNumber+"�ł��B";
        }else{
            textMesh.text += "6�`10�̉񓚌��ʂ��\������Ă��܂��B\n�E���́u�^�C�g���ցv�������ƃ^�C�g���ɖ߂�܂��B\n���ꂼ��̐ݖ�����Ԃ������ł��܂��B\n���Ȃ��̃e�X�g�ԍ���"+GameManager.Instance.TestNumber+"�ł��B";
        }
        ShowBackButton();
        ShowNextButton();
        SetAnswer();
    }

    public void NextPage()
    {
        pagenum=1;
        SetText();
    }
    public void BackPage()
    {
        pagenum=0;
        SetText();
    }
    private void ShowBackButton()
    {
        if (pagenum == 0)
        {
            BackButton.SetActive(false);
        }
        else
        {
            BackButton.SetActive(true);
        }
        
    }

    private void ShowNextButton()
    {
        if (pagenum == 0) 
        {
            NextTextMesh.text = "����";
        }
        else
        {
            NextTextMesh.text = "�^�C�g����";
        }
    }

    private void LeftOrRight(TextMeshProUGUI text,int row, int pow)
    {
        if (GameManager.Instance.anserNum[row, pow] == 1)
        {
            text.text = "��";
            text.color = Color.red;
        }else if (GameManager.Instance.anserNum[row, pow] == 2)
        {
            text.text = "�E";
            text.color = Color.blue;
        }
    }

    private void SetAnswer()
    {
        if(pagenum == 0)
        {
            TitleText1.text = "�ݖ�1";
            TitleText2.text = "�ݖ�2";
            TitleText3.text = "�ݖ�3";
            TitleText4.text = "�ݖ�4";
            TitleText5.text = "�ݖ�5";
            LeftOrRight(LeftText1, 0, 0);
            LeftOrRight(LeftText2, 1, 0);
            LeftOrRight(LeftText3, 2, 0);
            LeftOrRight(LeftText4, 3, 0);
            LeftOrRight(LeftText5, 4, 0);
            LeftOrRight(CenterText1, 0, 1);
            LeftOrRight(CenterText2, 1, 1);
            LeftOrRight(CenterText3, 2, 1);
            LeftOrRight(CenterText4, 3, 1);
            LeftOrRight(CenterText5, 4, 1);
            LeftOrRight(RightText1, 0, 2);
            LeftOrRight(RightText2, 1, 2);
            LeftOrRight(RightText3, 2, 2);
            LeftOrRight(RightText4, 3, 2);
            LeftOrRight(RightText5, 4, 2);
        }else if (pagenum == 1)
        {
            TitleText1.text = "�ݖ�6";
            TitleText2.text = "�ݖ�7";
            TitleText3.text = "�ݖ�8";
            TitleText4.text = "�ݖ�9";
            TitleText5.text = "�ݖ�10";
            LeftOrRight(LeftText1, 5, 0);
            LeftOrRight(LeftText2, 6, 0);
            LeftOrRight(LeftText3, 7, 0);
            LeftOrRight(LeftText4, 8, 0);
            LeftOrRight(LeftText5, 9, 0);
            LeftOrRight(CenterText1, 5, 1);
            LeftOrRight(CenterText2, 6, 1);
            LeftOrRight(CenterText3, 7, 1);
            LeftOrRight(CenterText4, 8, 1);
            LeftOrRight(CenterText5, 9, 1);
            LeftOrRight(RightText1, 5, 2);
            LeftOrRight(RightText2, 6, 2);
            LeftOrRight(RightText3, 7, 2);
            LeftOrRight(RightText4, 8, 2);
            LeftOrRight(RightText5, 9, 2);
        }
    }


}
