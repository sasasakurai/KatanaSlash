using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TestManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI upperRightTextMesh;
    [SerializeField] TextMeshProUGUI upperLeftTextMesh;
    [SerializeField] Image upperFrontImage;
    [SerializeField] TextMeshProUGUI upperFrontTextMesh;
    [SerializeField] Animator animator;
    [SerializeField] Animator animator2;
    [SerializeField] GameObject centerButton;
    //[SerializeField] GameObject mitsurugi;
    [SerializeField] TextMeshProUGUI debugTextMesh;
    [SerializeField] TextMeshProUGUI debugTextMesh2;
    public int numberOfOrder;//1~10
    private int rndNum;//0~9
    private int[] rndOrders;//0~9
    public int canSlash = 0;//0yes.1no




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    Slash();
        //}
        ShowCurrentAnimName();
    }
    public void StartTest()
    {
        numberOfOrder = 1;
        rndNum = FindRnd();
        rndOrders = GetFindRnd();
        ChangeOrder();
    }
    private void SetUpperRightText()
    {
        upperRightTextMesh.text = numberOfOrder+"�Ԗ�";
    }
    private void SetUpperLeftText()
    {
        upperLeftTextMesh.text = "�e�X�g�ԍ��F"+GameManager.Instance.TestNumber;
    }
    public void ChangeOrder()
    {
        SetUpperLeftText();
        SetUpperRightText();
        SetUpperFlontImage();
        animator.SetInteger("AnimAnimOrder", rndOrders[numberOfOrder-1]);
        animator2.SetInteger("AnimAnimOrder", rndOrders[numberOfOrder==10?0:numberOfOrder]);
    }

    private int FindRnd()
    {
        return GameManager.Instance.TestNumber%10;
    }
    private int[] GetFindRnd()
    {
        if (rndNum == 0)
        {
            return GameManager.Instance.Getrnd0();
        }else if (rndNum == 1)
        {
            return GameManager.Instance.Getrnd1();
        }else if (rndNum == 2)
        {
            return GameManager.Instance.Getrnd2();
        }else if (rndNum == 3)
        {
            return GameManager.Instance.Getrnd3();
        }else if (rndNum == 4)
        {
            return GameManager.Instance.Getrnd4();
        }else if (rndNum == 5)
        {
            return GameManager.Instance.Getrnd5();
        }else if (rndNum == 6)
        {
            return GameManager.Instance.Getrnd6();
        }else if (rndNum == 7)
        {
            return GameManager.Instance.Getrnd7();
        }else if(rndNum == 8)
        {
            return GameManager.Instance.Getrnd8();
        }
        else
        {
            return GameManager.Instance.Getrnd9();
        }
    }
    private IEnumerator WaitAndExecute()
    {
        SetUpperFlontImage();
        yield return new WaitForSeconds(2f);
        canSlash = 0;
        SetUpperFlontImage();
    }

    public void Slash()
    {
        if (canSlash == 0)
        {
            canSlash = 1;
            animator.SetTrigger("AnimAnimStartTg");

            animator2.SetTrigger("AnimAnimStartTg");

            StartCoroutine(WaitAndExecute());
            
        }
        else{

        }
    }
    private void SetUpperFlontImage()
    {
        if(canSlash == 0)
        {
            upperFrontImage.color = Color.green;
            upperFrontTextMesh.text = "GO! GO! GO!";
            centerButton.SetActive (true);
        }
        else
        {
            upperFrontImage.color = Color.red;
            upperFrontTextMesh.text = "Stay...Stay...Stay...";
            centerButton.SetActive(false);
        }
    }
    private void ShowCurrentAnimName()
    {
        if (animator != null && debugTextMesh != null)
        {
            // ���ݍĐ����̃X�e�[�g�����擾
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

            // �A�j���[�V���������擾
            string animationName = animator.GetCurrentAnimatorClipInfo(0)[0].clip.name;

            // TextMeshPro UI�ɕ\��
            debugTextMesh.text = $"Animation: {animationName}";
        }
        if (animator2 != null && debugTextMesh2 != null)
        {
            // ���ݍĐ����̃X�e�[�g�����擾
            AnimatorStateInfo stateInfo = animator2.GetCurrentAnimatorStateInfo(0);

            // �A�j���[�V���������擾
            string animationName = animator2.GetCurrentAnimatorClipInfo(0)[0].clip.name;

            // TextMeshPro UI�ɕ\��
            debugTextMesh2.text = $"Animation: {animationName}";
        }
    }
}
