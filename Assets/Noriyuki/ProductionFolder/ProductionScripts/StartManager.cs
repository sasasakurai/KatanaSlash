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
            textMesh.text = "����́Z�Z�̖ړI�̃e�X�g�ŁA���񂽂炩�񂽂�";
        }else if (pageNum == 1)
        {
            textMesh.text = "�e�X�g�ԍ��������_���Ŋ���U���܂��B\n���Ȃ��̃e�X�g�ԍ���"+GameManager.Instance.TestNumber+"�ł��B\n���̔ԍ��̓A���P�[�g�ł��m�F���邽�ߊo���Ă����Ă��������B";
        }else if(pageNum == 2)
        {
            textMesh.text = "���̃y�[�W����e�X�g���n�܂�܂��B����U��l�̓������悭���Ă��������B";
        }else if(pageNum==3)
        {
            GameManager.Instance.WhenStateChanged(GameManager.GameState.InTest);
        }
    }
}
