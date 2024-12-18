using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LookBackManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMesh;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTextFirst()
    {
        textMesh.text = "以上でテストは終了です。\nアンケートの回答をお願いします。\nあなたのテスト番号は、"+GameManager.Instance.TestNumber+"です。\n「戻る」を押すと再度テスト画面に、\n「タイトルへ」を押すとタイトルに戻ります。";
    }

}
