using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ContinuedManager : MonoBehaviour
{
    [SerializeField] TMP_InputField NumIF; // TMP_InputField���V���A���C�Y
    public static int numNum;
    public int pageNum;
    [SerializeField] TextMeshProUGUI textMesh; // ��ʂɕ\������e�L�X�g
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
            textMesh.text = "�O��̃e�X�g�ԍ�����͂��邱�ƂŁA\n�����A�j���[�V���������邱�Ƃ��ł��܂��B";
        }
        else if (pageNum == 1)
        {
            ConfirmNum();
        }
    }

    public void InputText()
    {
        
        // TMP_InputField���璼�ڃe�L�X�g���擾���A���l�ϊ�
        if (int.TryParse(NumIF.text, out numNum))
        {
            undertextMesh.text = null;
        }
        else
        {
            undertextMesh.text="���l�̕ϊ��Ɏ��s���܂����B\n0�`99�̐��l�𔼊p�œ��͂��Ă��������B";
        }
    }

    public void ConfirmNum()
    {
        if (string.IsNullOrEmpty(NumIF.text))
        {
            undertextMesh.text = "���͂���ł��B�������ԍ�����͂��Ă��������B";
            pageNum = 0;
        }
        else if (numNum >= 0 && numNum < 100)
        {
            GameManager.Instance.TestNumber = numNum;
            GameManager.Instance.WhenStateChanged(GameManager.GameState.InTest);
        }
        else
        {
            undertextMesh.text = "0�`99�̐��l�𔼊p�œ��͂��Ă��������B";
            pageNum = 0;
        }
    }
}
