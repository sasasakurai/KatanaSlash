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
        textMesh.text = "�ȏ�Ńe�X�g�͏I���ł��B\n�A���P�[�g�̉񓚂����肢���܂��B\n���Ȃ��̃e�X�g�ԍ��́A"+GameManager.Instance.TestNumber+"�ł��B\n�u�߂�v�������ƍēx�e�X�g��ʂɁA\n�u�^�C�g���ցv�������ƃ^�C�g���ɖ߂�܂��B";
    }

}
