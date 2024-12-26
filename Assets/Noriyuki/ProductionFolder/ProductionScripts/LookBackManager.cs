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
        textMesh.text = "以上でテストは終了です。GoogleFormの回答をお願いします。\nこの画面では設問";
        if(pagenum == 0)
        {
            textMesh.text += "1～5の回答結果が表示されています。\n右下の「次へ」を押すと6～10問目の回答が表示されます。\nそれぞれの設問を見返す事もできます。\nあなたのテスト番号は"+GameManager.Instance.TestNumber+"です。";
        }else{
            textMesh.text += "6～10の回答結果が表示されています。\n右下の「タイトルへ」を押すとタイトルに戻ります。\nそれぞれの設問を見返す事もできます。\nあなたのテスト番号は"+GameManager.Instance.TestNumber+"です。";
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
            NextTextMesh.text = "次へ";
        }
        else
        {
            NextTextMesh.text = "タイトルへ";
        }
    }

    private void LeftOrRight(TextMeshProUGUI text,int row, int pow)
    {
        if (GameManager.Instance.anserNum[row, pow] == 1)
        {
            text.text = "左";
            text.color = Color.red;
        }else if (GameManager.Instance.anserNum[row, pow] == 2)
        {
            text.text = "右";
            text.color = Color.blue;
        }
    }

    private void SetAnswer()
    {
        if(pagenum == 0)
        {
            TitleText1.text = "設問1";
            TitleText2.text = "設問2";
            TitleText3.text = "設問3";
            TitleText4.text = "設問4";
            TitleText5.text = "設問5";
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
            TitleText1.text = "設問6";
            TitleText2.text = "設問7";
            TitleText3.text = "設問8";
            TitleText4.text = "設問9";
            TitleText5.text = "設問10";
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
