using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartManager : MonoBehaviour
{

    public int pageNum;
    [SerializeField] TextMeshProUGUI textMesh;
    // Start is called before the first frame update
    void Start()
    {
        pageNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeText();
    }

    private void ChangeText()
    {
        if(pageNum == 0)
        {
            textMesh.text = "これは〇〇の目的のテストで、うんたらかんたら";
        }else if (pageNum == 1)
        {
            textMesh.text = "テスト番号がランダムで割り振られます。\nあなたのテスト番号は"+GameManager.Instance.TestNumber+"です。\nこの番号はアンケートでも確認するため覚えておいてください。";
        }else if(pageNum == 2)
        {
            textMesh.text = "次のページからテストが始まります。刀を振る人の動きをよく見てください。";
        }else if(pageNum==3)
        {
            GameManager.Instance.WhenStateChanged(GameManager.GameState.InTest);
        }
    }
}
