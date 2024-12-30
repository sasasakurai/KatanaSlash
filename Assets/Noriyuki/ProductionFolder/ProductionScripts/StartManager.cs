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

    public void Initialize()
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
            textMesh.text = "これは「斬撃表現」に関する卒業研究の一環として行う実験です。\nまた、実験終了後にGoogleFormでのアンケートを行います。\n個人情報などは集計していませんが、アンケートの結果は卒業研究のデータとして利用させていただきます。\nご了承の上、次に進んでください。";
        }else if (pageNum == 1)
        {
            textMesh.text = "テスト番号がランダムで割り振られます。\n \nあなたのテスト番号は「"+GameManager.Instance.TestNumber+"」です。\nこの番号は実験終了後に行うアンケートで回答するため覚えておいてください。\n設問は合計10問あります。";
        }else if(pageNum == 2)
        {
            textMesh.text = "次のページから実験が始まります。\n中央の「斬れ！」のボタンを押すと、左右のキャラクターが同時に刀を振ります。\n \n「よく斬れそうなのは？」「心地よさそうなのは？」「ダメージが大きそうなのは？」\nの3つの質問を行いますので、それぞれ左右どちらかを選んでください。\n \n3つとも回答すると、次の設問へ移行するボタンが右下に出現します。\n画面右にはゲーム速度を変化させられるボタンがあります。\n \n細かい違いを観察したいときに活用してください。";
        }else if(pageNum==3)
        {
            GameManager.Instance.WhenStateChanged(GameManager.GameState.InTest);
        }
    }
}
