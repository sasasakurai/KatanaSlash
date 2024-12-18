using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ContinuedManager : MonoBehaviour
{
    [SerializeField] TMP_InputField NumIF; // TMP_InputFieldをシリアライズ
    public static int numNum;
    public int pageNum;
    [SerializeField] TextMeshProUGUI textMesh; // 画面に表示するテキスト
    [SerializeField] TextMeshProUGUI undertextMesh;

    // Start is called before the first frame update
    void Start()
    {
        pageNum = 0;
        undertextMesh.text = null;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeText();
    }

    private void ChangeText()
    {
        if (pageNum == 0)
        {
            textMesh.text = "前回のテスト番号を入力することで、\n同じアニメーションを見ることができます。";
        }
        else if (pageNum == 1)
        {
            ConfirmNum();
        }
    }

    public void InputText()
    {
        
        // TMP_InputFieldから直接テキストを取得し、数値変換
        if (int.TryParse(NumIF.text, out numNum))
        {
            undertextMesh.text = null;
        }
        else
        {
            undertextMesh.text="数値の変換に失敗しました。\n0～99の数値を半角で入力してください。";
        }
    }

    public void ConfirmNum()
    {
        if (string.IsNullOrEmpty(NumIF.text))
        {
            undertextMesh.text = "入力が空です。正しい番号を入力してください。";
            pageNum = 0;
        }
        else if (numNum >= 0 && numNum < 100)
        {
            GameManager.Instance.TestNumber = numNum;
            GameManager.Instance.WhenStateChanged(GameManager.GameState.InTest);
        }
        else
        {
            undertextMesh.text = "0～99の数値を半角で入力してください。";
            pageNum = 0;
        }
    }
}
