using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TestManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI upperRightTextMesh;
    [SerializeField] TextMeshProUGUI upperLeftTextMesh;
    [SerializeField] TextMeshProUGUI timeTextMesh;
    [SerializeField] Image upperFrontImage;
    [SerializeField] TextMeshProUGUI upperFrontTextMesh;
    [SerializeField] Animator rightAnimator;
    [SerializeField] Animator leftAnimator;
    [SerializeField] GameObject centerButton;
    //[SerializeField] GameObject mitsurugi;
    [SerializeField] TextMeshProUGUI rightDebugTextMesh;
    [SerializeField] TextMeshProUGUI leftDebugTextMesh;
    [SerializeField] GameObject leftButton1;
    [SerializeField] GameObject leftButton2;
    [SerializeField] GameObject leftButton3;
    [SerializeField] GameObject leftButton4;
    [SerializeField] GameObject leftButton5;
    [SerializeField] GameObject leftButton6;
    [SerializeField] GameObject leftButton7;
    [SerializeField] GameObject leftButton8;
    [SerializeField] GameObject leftButton9;
    [SerializeField] GameObject leftButton10;
    [SerializeField] GameObject rightButton1;
    [SerializeField] GameObject rightButton2;
    [SerializeField] GameObject rightButton3;
    [SerializeField] GameObject rightButton4;
    [SerializeField] GameObject rightButton5;
    [SerializeField] GameObject rightButton6;
    [SerializeField] GameObject rightButton7;
    [SerializeField] GameObject rightButton8;
    [SerializeField] GameObject rightButton9;
    [SerializeField] GameObject rightButton10;

    [SerializeField] GameObject nextButton;
    [SerializeField] GameObject backButton;
    [SerializeField] GameObject lookBackButton;

    [SerializeField] GameObject OneLeftButton;
    [SerializeField] GameObject OneRightButton;
    [SerializeField] GameObject TwoLeftButton;
    [SerializeField] GameObject TwoRightButton;
    [SerializeField] GameObject ThreeLeftButton;
    [SerializeField] GameObject ThreeRightButton;

    [SerializeField] GameObject TimeButton1;
    [SerializeField] GameObject TimeButton05;
    [SerializeField] GameObject TimeButton02;

    [SerializeField] AudioSource slashSound1;
    [SerializeField] AudioSource slashSound2;


    [SerializeField] Slider timeSlider;

    public int numberOfOrder;//1~10
    private int rndNum;//0~9
    private int[] rndOrders;//0~9

    public int isFinishWantNum;


    private int[,] rndNewOrders;

    public int canSlash = 0;//0yes.1no

    public int leftNum;
    public int rightNum;
    private float waittime;

    private Vector3 leftPosition = new Vector3(-3.0f, 0, 0); // 左
    private Vector3 rightPosition = new Vector3(3.0f, 0, 0); // 右

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
        if (GameManager.Instance.ShowDebug)
        {
            ShowCurrentAnimName();
        }

        
    }
    public void StartTest()
    {
        numberOfOrder = 1;
        if (GameManager.Instance.IsFinish) { numberOfOrder = isFinishWantNum; }
        rndNum = FindRnd();
        //rndOrders = GetFindRnd();
        rndNewOrders=GetFindNewRnd();
        //rightNum = 2;
        //leftNum = 1;
        waittime = 1.0f;
        //ChangeOrder();
        SetDefaultSlider();
        //ChangeOrder2();
        ChangeOrder3();
    }
    private void SetUpperRightText()
    {
        upperRightTextMesh.text = "現在の設問："+numberOfOrder + "番";
    }
    private void SetUpperLeftText()
    {
        upperLeftTextMesh.text = "あなたのテスト番号："+GameManager.Instance.TestNumber;
    }
    //public void ChangeOrder()
    //{
    //    SetUpperLeftText();
    //    SetUpperRightText();
    //    SetUpperFlontImage();
    //    rightAnimator.SetInteger("AnimAnimOrder", rndOrders[numberOfOrder-1]);
    //    leftAnimator.SetInteger("AnimAnimOrder", rndOrders[numberOfOrder==10?0:numberOfOrder]);
    //}

    public void ChangeOrder2()
    {
        ChangeButttonStatas();
        SetUpperLeftText();
        SetUpperFlontImage();
        rightAnimator.SetInteger("AnimAnimOrder", rndOrders[rightNum - 1]);
        leftAnimator.SetInteger("AnimAnimOrder", rndOrders[leftNum - 1]);
    }

    public void ChangeOrder3()
    {
        ChangeButtonColor();
        CheckHighest();
        ShowNextButton();
        ShowLookBackButton();
        SetUpperLeftText();
        SetUpperRightText();
        SetUpperFlontImage();
        rightAnimator.SetInteger("AnimAnimOrder", rndNewOrders[numberOfOrder - 1, 1]);
        leftAnimator.SetInteger("AnimAnimOrder", rndNewOrders[numberOfOrder - 1, 0]);
    }

    private void PlaySound()
    {
        PlayLeftSound();
        PlayRightSound();
    }
    private void PlayLeftSound()
    {
        float wait;
        wait = ConvertFramesToSeconds(GameManager.Instance.TopPoint[rndNewOrders[numberOfOrder - 1, 0]]);
        //Debug.Log("左"+rndNewOrders[numberOfOrder - 1, 0]+"秒数"+ GameManager.Instance.TopPoint[rndNewOrders[numberOfOrder - 1, 0]]);
        StartCoroutine(WaitForSecondsCoroutine(wait,0));
    }

    private void PlayRightSound()
    {
        float wait;
        wait = ConvertFramesToSeconds(GameManager.Instance.TopPoint[rndNewOrders[numberOfOrder - 1, 1]]);
        //Debug.Log("右" + rndNewOrders[numberOfOrder - 1, 1]+"秒数"+ GameManager.Instance.TopPoint[rndNewOrders[numberOfOrder - 1, 1]]);
        StartCoroutine(WaitForSecondsCoroutine(wait, 1));
    }
    float ConvertFramesToSeconds(float frameValue)
    {
        // フレーム数を秒に変換
        //Debug.Log(frameValue / 600.0f) ;
        return (frameValue / 600.0f);

    }

    IEnumerator WaitForSecondsCoroutine(float seconds, int leftOrRight)
    {
        yield return new WaitForSeconds(seconds);
        //Debug.Log(seconds + " seconds have passed (timeScale = 0.5)");
        if(leftOrRight == 0)
        {
            slashSound1.transform.position = leftPosition;
            slashSound1.panStereo = -1.0f; // -1.0で左、1.0で右
            slashSound1.Play(); // 音を再生
        }else if (leftOrRight == 1)
        {
            slashSound2.transform.position = rightPosition;
            slashSound2.panStereo = 1.0f; // -1.0で左、1.0で右
            slashSound2.Play(); // 音を再生
        }
    }



    private void SetDefaultSlider()
    {
        timeSlider.minValue = 0.1f;
        timeSlider.maxValue = 1.0f;
        timeSlider.value = 1.0f;
        timeSlider.onValueChanged.AddListener(OnTimeScaleChanged);
        SetTimeText(1.0f);
    }


    public void ClickTimeChangeButton(float newtime)
    {
        Time.timeScale = newtime;
        timeSlider.value = newtime;
        rightAnimator.speed = newtime;
        leftAnimator.speed = newtime;
        //Debug.Log($"Time Scale Set to: {Time.timeScale}");
    }
    private void OnTimeScaleChanged(float value)
    {
        float roundedValue = Mathf.Round(value * 10f)/10f;

        // 時間スケールを適用
        Time.timeScale = roundedValue;
        rightAnimator.speed = roundedValue;
        leftAnimator.speed = roundedValue;
        timeSlider.value = roundedValue;
        waittime = 1f/roundedValue;

        SetTimeText(roundedValue);
        //Debug.Log($"Time Scale Set to: {roundedValue}");
    }

    private void CheckHighest()
    {
        if (GameManager.Instance.anserNum[Mathf.Min(GameManager.Instance.highestNum,9),0] > 0&& GameManager.Instance.anserNum[Mathf.Min(GameManager.Instance.highestNum, 9), 1] > 0&& GameManager.Instance.anserNum[Mathf.Min(GameManager.Instance.highestNum, 9), 2] > 0) 
        {
            if (GameManager.Instance.highestNum < 10)
            {
                GameManager.Instance.highestNum++;
                //Debug.Log(GameManager.Instance.highestNum);
            }
            
        }
    }
    private void ShowNextButton()
    {
        if (numberOfOrder <= GameManager.Instance.highestNum)
        {
            nextButton.SetActive(true);
        }
        else
        {
            nextButton.SetActive(false);
        }
    }

    private void ShowLookBackButton()
    {
        if (GameManager.Instance.IsFinish)
        {
            lookBackButton.SetActive(true);
        }
        else
        {
            lookBackButton.SetActive(false);
        }
    }



    public void ChangeAnserNum(int row,int num)//rowに心地よさとかを0~2、numに左か右かを1~2で。
    {
        GameManager.Instance.anserNum[numberOfOrder - 1,row] = num;
        ChangeOrder3();
        
    }

    private void ChangeButtonColor()
    {
        if (GameManager.Instance.anserNum[numberOfOrder-1,0] == 0)
        {
            OneLeftButton.GetComponent<Image>().color = Color.white;
            OneRightButton.GetComponent<Image>().color = Color.white;
            OneLeftButton.GetComponent<Outline>().effectColor = Color.red;
            OneRightButton.GetComponent<Outline>().effectColor = Color.red;
        }
        else if (GameManager.Instance.anserNum[numberOfOrder - 1, 0] == 1)
        {
            OneLeftButton.GetComponent<Image>().color = Color.green;
            OneRightButton.GetComponent<Image>().color = Color.white;
            OneLeftButton.GetComponent<Outline>().effectColor = Color.black;
            OneRightButton.GetComponent<Outline>().effectColor = Color.black;
        }
        else if (GameManager.Instance.anserNum[numberOfOrder - 1, 0] == 2)
        {
            OneLeftButton.GetComponent<Image>().color = Color.white;
            OneRightButton.GetComponent<Image>().color = Color.green;
            OneLeftButton.GetComponent<Outline>().effectColor = Color.black;
            OneRightButton.GetComponent<Outline>().effectColor = Color.black;
        }
        if (GameManager.Instance.anserNum[numberOfOrder - 1, 1] == 0)
        {
            TwoLeftButton.GetComponent<Image>().color = Color.white;
            TwoRightButton.GetComponent<Image>().color = Color.white;
            TwoLeftButton.GetComponent<Outline>().effectColor = Color.red;
            TwoRightButton.GetComponent<Outline>().effectColor = Color.red;
        }
        else if (GameManager.Instance.anserNum[numberOfOrder - 1, 1] == 1)
        {
            TwoLeftButton.GetComponent<Image>().color = Color.green;
            TwoRightButton.GetComponent<Image>().color = Color.white;
            TwoLeftButton.GetComponent<Outline>().effectColor = Color.black;
            TwoRightButton.GetComponent<Outline>().effectColor = Color.black;
        }
        else if (GameManager.Instance.anserNum[numberOfOrder - 1, 1] == 2)
        {
            TwoLeftButton.GetComponent<Image>().color = Color.white;
            TwoRightButton.GetComponent<Image>().color = Color.green;
            TwoLeftButton.GetComponent<Outline>().effectColor = Color.black;
            TwoRightButton.GetComponent<Outline>().effectColor = Color.black;
        }
        if (GameManager.Instance.anserNum[numberOfOrder - 1, 2] == 0)
        {
            ThreeLeftButton.GetComponent<Image>().color = Color.white;
            ThreeRightButton.GetComponent<Image>().color = Color.white;
            ThreeLeftButton.GetComponent<Outline>().effectColor = Color.red;
            ThreeRightButton.GetComponent<Outline>().effectColor = Color.red;
        }
        else if (GameManager.Instance.anserNum[numberOfOrder - 1, 2] == 1)
        {
            ThreeLeftButton.GetComponent<Image>().color = Color.green;
            ThreeRightButton.GetComponent<Image>().color = Color.white;
            ThreeLeftButton.GetComponent<Outline>().effectColor = Color.black;
            ThreeRightButton.GetComponent<Outline>().effectColor = Color.black;
        }
        else if (GameManager.Instance.anserNum[numberOfOrder - 1, 2] == 2)
        {
            ThreeLeftButton.GetComponent<Image>().color = Color.white;
            ThreeRightButton.GetComponent<Image>().color = Color.green;
            ThreeLeftButton.GetComponent<Outline>().effectColor = Color.black;
            ThreeRightButton.GetComponent<Outline>().effectColor = Color.black;
        }
    }







    private void ChangeButttonStatas()
    {
        rightButton1.GetComponent<Image>().color = Color.white;
        leftButton1.GetComponent<Image>().color = Color.white;
        rightButton2.GetComponent<Image>().color = Color.white;
        leftButton2.GetComponent<Image>().color = Color.white;
        rightButton3.GetComponent<Image>().color = Color.white;
        leftButton3.GetComponent<Image>().color = Color.white;
        rightButton4.GetComponent<Image>().color = Color.white;
        leftButton4.GetComponent<Image>().color = Color.white;
        rightButton5.GetComponent<Image>().color = Color.white;
        leftButton5.GetComponent<Image>().color = Color.white;
        rightButton6.GetComponent<Image>().color = Color.white;
        leftButton6.GetComponent<Image>().color = Color.white;
        rightButton7.GetComponent<Image>().color = Color.white;
        leftButton7.GetComponent<Image>().color = Color.white;
        rightButton8.GetComponent<Image>().color = Color.white;
        leftButton8.GetComponent<Image>().color = Color.white;
        rightButton9.GetComponent<Image>().color = Color.white;
        leftButton9.GetComponent<Image>().color = Color.white;
        rightButton10.GetComponent<Image>().color = Color.white;
        leftButton10.GetComponent<Image>().color = Color.white;

        if (rightNum == 1)
        {
            rightButton1.GetComponent<Image>().color = Color.green;
            leftButton1.GetComponent<Image>().color = Color.gray;
        }else if(rightNum == 2)
        {
            rightButton2.GetComponent<Image>().color = Color.green;
            leftButton2.GetComponent<Image>().color = Color.gray;
        }else if(rightNum == 3)
        {
            rightButton3.GetComponent<Image>().color = Color.green;
            leftButton3.GetComponent<Image>().color = Color.gray;
        }else if (rightNum == 4)
        {
            rightButton4.GetComponent<Image>().color = Color.green;
            leftButton4.GetComponent<Image>().color = Color.gray;
        }else if(rightNum == 5)
        {
            rightButton5.GetComponent<Image>().color = Color.green;
            leftButton5.GetComponent<Image>().color = Color.gray;
        }else if (rightNum == 6)
        {
            rightButton6.GetComponent<Image>().color = Color.green;
            leftButton6.GetComponent<Image>().color = Color.gray;
        }else if(rightNum == 7)
        {
            rightButton7.GetComponent<Image>().color = Color.green;
            leftButton7.GetComponent<Image>().color = Color.gray;
        }else if(rightNum == 8)
        {
            rightButton8.GetComponent<Image>().color = Color.green;
            leftButton8.GetComponent<Image>().color = Color.gray;
        }else if(rightNum == 9){
            rightButton9.GetComponent<Image>().color = Color.green;
            leftButton9.GetComponent<Image>().color = Color.gray;
        }else if(rightNum == 10)
        {
            rightButton10.GetComponent<Image>().color = Color.green;
            leftButton10.GetComponent<Image>().color = Color.gray;
        }

        if(leftNum == 1) 
        {
            rightButton1.GetComponent<Image>().color = Color.gray;
            leftButton1.GetComponent<Image>().color = Color.green;
        }else if (leftNum == 2)
        {
            rightButton2.GetComponent<Image>().color = Color.gray;
            leftButton2.GetComponent<Image>().color = Color.green;
        }else if (leftNum == 3)
        {
            rightButton3.GetComponent<Image>().color = Color.gray;
            leftButton3.GetComponent<Image>().color = Color.green;
        }else if (leftNum == 4)
        {
            rightButton4.GetComponent<Image>().color = Color.gray;
            leftButton4.GetComponent<Image>().color = Color.green;
        }
        else if (leftNum == 5)
        {
            rightButton5.GetComponent<Image>().color = Color.gray;
            leftButton5.GetComponent<Image>().color = Color.green;
        }
        else if (leftNum == 6)
        {
            rightButton6.GetComponent<Image>().color = Color.gray;
            leftButton6.GetComponent<Image>().color = Color.green;
        }
        else if (leftNum == 7)
        {
            rightButton7.GetComponent<Image>().color = Color.gray;
            leftButton7.GetComponent<Image>().color = Color.green;
        }
        else if (leftNum == 8)
        {
            rightButton8.GetComponent<Image>().color = Color.gray;
            leftButton8.GetComponent<Image>().color = Color.green;
        }
        else if (leftNum == 9)
        {
            rightButton9.GetComponent<Image>().color = Color.gray;
            leftButton9.GetComponent<Image>().color = Color.green;
        }
        else if (leftNum == 10)
        {
            rightButton10.GetComponent<Image>().color = Color.gray;
            leftButton10.GetComponent<Image>().color = Color.green;
        }
    }


    public void TryToChangeRightNum(int nextNum)
    {
        if(rightNum == nextNum || leftNum == nextNum)
        {

        }
        else
        {
            rightNum = nextNum;
            ChangeOrder2();
        }

    }
    public void TryToChangeLeftNum(int nextNum)
    {
        if (rightNum == nextNum || leftNum == nextNum)
        {

        }
        else
        {
            leftNum = nextNum;
            ChangeOrder2();
        }

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

    private int[,] GetFindNewRnd()
    {
        if (rndNum == 0)
        {
            return GameManager.Instance.Getrnd10();
        }
        else if (rndNum == 1)
        {
            return GameManager.Instance.Getrnd11();
        }
        else if (rndNum == 2)
        {
            return GameManager.Instance.Getrnd12();
        }
        else if (rndNum == 3)
        {
            return GameManager.Instance.Getrnd13();
        }
        else if (rndNum == 4)
        {
            return GameManager.Instance.Getrnd14();
        }
        else if (rndNum == 5)
        {
            return GameManager.Instance.Getrnd15();
        }
        else if (rndNum == 6)
        {
            return GameManager.Instance.Getrnd16();
        }
        else if (rndNum == 7)
        {
            return GameManager.Instance.Getrnd17();
        }
        else if (rndNum == 8)
        {
            return GameManager.Instance.Getrnd18();
        }
        else
        {
            return GameManager.Instance.Getrnd19();
        }
    }


    private IEnumerator WaitAndExecute()
    {
        SetUpperFlontImage();
        yield return new WaitForSecondsRealtime(waittime);
        canSlash = 0;
        SetUpperFlontImage();
    }

    public void Slash()
    {
        if (canSlash == 0)
        {
            canSlash = 1;
            rightAnimator.SetTrigger("AnimAnimStartTg");

            leftAnimator.SetTrigger("AnimAnimStartTg");
            PlaySound();
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
            upperFrontTextMesh.text = "Stay... Stay... Stay...";
            centerButton.SetActive(false);
        }
    }

    private void SetTimeText(float timeF)
    {
        timeTextMesh.text = "現在のゲーム速度:"+timeF+"倍速";
    }

    private void ShowCurrentAnimName()
    {
        if (rightAnimator != null && rightDebugTextMesh != null)
        {
            // 現在再生中のステート情報を取得
            AnimatorStateInfo stateInfo = rightAnimator.GetCurrentAnimatorStateInfo(0);

            // アニメーション名を取得
            string animationName = rightAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name;

            // TextMeshPro UIに表示
            rightDebugTextMesh.text = $"Animation: {animationName}";
        }
        if (leftAnimator != null && leftDebugTextMesh != null)
        {
            // 現在再生中のステート情報を取得
            AnimatorStateInfo stateInfo = leftAnimator.GetCurrentAnimatorStateInfo(0);

            // アニメーション名を取得
            string animationName = leftAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name;

            // TextMeshPro UIに表示
            leftDebugTextMesh.text = $"Animation: {animationName}";
        }
    }
}
