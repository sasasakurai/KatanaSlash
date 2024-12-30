using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] GameObject startManager;
    [SerializeField] GameObject continuedManager;
    [SerializeField] GameObject testManager;
    [SerializeField] GameObject lookBackManager;
    [SerializeField] private string googleFormURL;

    [SerializeField] AudioSource BSound1;
    [SerializeField] AudioSource BSound2;
    [SerializeField] AudioSource BSound3;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCLickTitleStart()
    {
        playS2();
        GameManager.Instance.WhenStateChanged(GameManager.GameState.FromStart);
    }
    public void OnCLickTitleContinued()
    {
        playS2();
        GameManager.Instance.WhenStateChanged(GameManager.GameState.FromContinued);
    }
    public void OnClickStartNext()
    {
        playS2();
        startManager.GetComponent<StartManager>().pageNum++;
    }
    public void OnClickStartBack()
    {
        if (startManager.GetComponent<StartManager>().pageNum > 0)
        {
            playS2();
            startManager.GetComponent<StartManager>().pageNum = startManager.GetComponent<StartManager>().pageNum -1;
        }
        else
        {
            playS2();
            GameManager.Instance.WhenStateChanged(GameManager.GameState.Title);
        }
        
    }

    public void OnClickContinuedNext()
    {
        continuedManager.GetComponent<ContinuedManager>().pageNum++;
        playS2();
    }
    public void OnClickContinuedBack()
    {
        if (continuedManager.GetComponent<ContinuedManager>().pageNum > 0)
        {
            continuedManager.GetComponent<ContinuedManager>().pageNum = continuedManager.GetComponent<ContinuedManager>().pageNum - 1;
            playS2();
        }
        else
        {
            playS2();
            GameManager.Instance.WhenStateChanged(GameManager.GameState.Title);
        }
    }

    public void OnClickTestNext()
    {
        if (testManager.GetComponent<TestManager>().numberOfOrder + 1 > GameManager.Instance.allAnimNum)
        {
            playS2();
            GameManager.Instance.WhenStateChanged(GameManager.GameState.LookBack);
        }
        else
        {
            testManager.GetComponent<TestManager>().numberOfOrder++;
            playS3();
            testManager.GetComponent<TestManager>().ChangeOrder3();
        }

    }
    public void OnClickTestBack()
    {
        if (testManager.GetComponent<TestManager>().numberOfOrder > 1)
        {
            testManager.GetComponent<TestManager>().numberOfOrder = testManager.GetComponent<TestManager>().numberOfOrder - 1;
            playS3();
            testManager.GetComponent<TestManager>().ChangeOrder3();
        }
        else
        {

        }
    }

    public void OnClickTestCenter()
    {
        testManager.GetComponent<TestManager>().Slash();
    }

    public void OnCLickTestRightNum(int num)
    {
        testManager.GetComponent<TestManager>().TryToChangeRightNum(num);
    }
    public void OnCLickTestLeftNum(int num)
    {
        testManager.GetComponent<TestManager>().TryToChangeLeftNum(num);
    }

    public void OnClickTestNewLeft(int num)
    {
        playS1();
        testManager.GetComponent<TestManager>().ChangeAnserNum(num, 1);
    }
    public void OnClickTestNewRight(int num)
    {
        playS1();
        testManager.GetComponent<TestManager>().ChangeAnserNum(num, 2);
    }

    public void OnClickTestTime(float f)
    {
        playS2();
        testManager.GetComponent<TestManager>().ClickTimeChangeButton(f);
    }

    public void OnClickTestLookBack()
    {
        playS3();
        GameManager.Instance.WhenStateChanged(GameManager.GameState.LookBack);
    }




    public void OnClickLookBackNext()
    {
        if (lookBackManager.GetComponent<LookBackManager>().pagenum == 0)
        {
            playS2();
            lookBackManager.GetComponent<LookBackManager>().NextPage();
        }
        else
        {
            playS2();
            lookBackManager.GetComponent<LookBackManager>().last = 1;
            lookBackManager.GetComponent<LookBackManager>().ShowLast();

        }
        
    }
    public void OnClickLookBackBack()
    {
        playS2();
        lookBackManager.GetComponent<LookBackManager>().BackPage();
    }

    public void OnClickLookBackTestBack(int num)
    {
        playS3();
        testManager.GetComponent<TestManager>().isFinishWantNum = lookBackManager.GetComponent<LookBackManager>().pagenum == 0? num:num+5;
        GameManager.Instance.WhenStateChanged(GameManager.GameState.InTest);
    }

    public void OnClickLookBackLastNext()
    {
        playS2();
        GameManager.Instance.WhenStateChanged(GameManager.GameState.Title);
    }

    public void OnClickLookBackLastBack()
    {
        playS2();
        lookBackManager.GetComponent<LookBackManager>().last = 0;
        lookBackManager.GetComponent<LookBackManager>().ShowLast();
    }


    public void OnclickLookBackURL()
    {
        Application.OpenURL(googleFormURL);
    }




    private void playS1()
    {
        BSound1.Play();
    }
    private void playS2()
    {
        BSound2.Play();
    }
    private void playS3()
    {
        BSound3.Play();
    }



}
