using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] GameObject startManager;
    [SerializeField] GameObject continuedManager;
    [SerializeField] GameObject testManager;
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
        GameManager.Instance.WhenStateChanged(GameManager.GameState.FromStart);
    }
    public void OnCLickTitleContinued()
    {
        GameManager.Instance.WhenStateChanged(GameManager.GameState.FromContinued);
    }
    public void OnClickStartNext()
    {
        startManager.GetComponent<StartManager>().pageNum++;
    }
    public void OnClickStartBack()
    {
        if (startManager.GetComponent<StartManager>().pageNum > 0)
        {
            startManager.GetComponent<StartManager>().pageNum = startManager.GetComponent<StartManager>().pageNum -1;
        }
        else
        {
            GameManager.Instance.WhenStateChanged(GameManager.GameState.Title);
        }
        
    }

    public void OnClickContinuedNext()
    {
        continuedManager.GetComponent<ContinuedManager>().pageNum++;
    }
    public void OnClickContinuedBack()
    {
        if (continuedManager.GetComponent<ContinuedManager>().pageNum > 0)
        {
            continuedManager.GetComponent<ContinuedManager>().pageNum = continuedManager.GetComponent<ContinuedManager>().pageNum - 1;
        }
        else
        {
            GameManager.Instance.WhenStateChanged(GameManager.GameState.Title);
        }
    }

    //public void OnClickTestNext()
    //{
    //    if (testManager.GetComponent<TestManager>().numberOfOrder + 1 > GameManager.Instance.allAnimNum)
    //    {
    //        GameManager.Instance.WhenStateChanged(GameManager.GameState.LookBack);
    //    }
    //    else
    //    {
    //        testManager.GetComponent<TestManager>().numberOfOrder++;
    //        testManager.GetComponent<TestManager>().ChangeOrder();
    //    }
        
    //}
    //public void OnClickTestBack()
    //{
    //    if (testManager.GetComponent<TestManager>().numberOfOrder > 1)
    //    {
    //        testManager.GetComponent<TestManager>().numberOfOrder = testManager.GetComponent<TestManager>().numberOfOrder - 1;
    //        testManager.GetComponent<TestManager>().ChangeOrder();
    //    }
    //    else
    //    {

    //    }
    //}

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


    public void OnClickLookBackNext()
    {
        GameManager.Instance.WhenStateChanged(GameManager.GameState.Title);
    }
    public void OnClickLookBackBack()
    {
        GameManager.Instance.WhenStateChanged(GameManager.GameState.InTest);
    }




}
