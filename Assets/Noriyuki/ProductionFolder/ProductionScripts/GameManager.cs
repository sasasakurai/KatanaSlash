using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    public enum GameState
    {
        Title,
        FromStart,
        FromContinued,
        InTest,
        LookBack
    }

    public int allAnimNum = 10;
    private int[] rnd0 = { 3, 2, 1, 4, 0 };
    private int[] rnd1 = { 4, 2, 1, 0, 3 };
    private int[] rnd2 = { 3, 0, 2, 1, 4 };
    private int[] rnd3 = { 4, 2, 3, 1, 0 };
    private int[] rnd4 = { 2, 4, 3, 1, 0 };
    private int[] rnd5 = { 4, 2, 0, 3, 1 };
    private int[] rnd6 = { 0, 1, 3, 2, 4 };
    private int[] rnd7 = { 0, 4, 2, 1, 3 };
    private int[] rnd8 = { 2, 0, 3, 4, 1 };
    private int[] rnd9 = { 1, 2, 4, 0, 3 };


    int[,] rnd10 = { { 0, 4 }, { 2, 3 }, { 0, 2 }, { 1, 4 }, { 1, 2 }, { 3, 4 }, { 0, 1 }, { 0, 3 }, { 2, 4 }, { 1, 3 } };
    int[,] rnd11 = { { 1, 4 }, { 0, 3 }, { 0, 2 }, { 2, 3 }, { 1, 3 }, { 3, 4 }, { 0, 1 }, { 2, 4 }, { 1, 2 }, { 0, 4 } };
    int[,] rnd12 = { { 2, 4 }, { 1, 2 }, { 0, 1 }, { 3, 4 }, { 0, 3 }, { 1, 4 }, { 0, 2 }, { 2, 3 }, { 1, 3 }, { 0, 4 } };
    int[,] rnd13 = { { 0, 4 }, { 1, 2 }, { 2, 3 }, { 0, 3 }, { 1, 4 }, { 3, 4 }, { 0, 1 }, { 1, 3 }, { 2, 4 }, { 0, 2 } };
    int[,] rnd14 = { { 1, 3 }, { 2, 3 }, { 1, 2 }, { 0, 3 }, { 3, 4 }, { 0, 1 }, { 2, 4 }, { 1, 4 }, { 0, 2 }, { 0, 4 } };
    int[,] rnd15 = { { 0, 1 }, { 0, 2 }, { 3, 4 }, { 2, 3 }, { 1, 4 }, { 0, 3 }, { 1, 2 }, { 0, 4 }, { 2, 4 }, { 1, 3 } };
    int[,] rnd16 = { { 1, 4 }, { 0, 2 }, { 3, 4 }, { 0, 3 }, { 0, 1 }, { 2, 4 }, { 2, 3 }, { 1, 2 }, { 1, 3 }, { 0, 4 } };
    int[,] rnd17 = { { 2, 4 }, { 0, 1 }, { 0, 3 }, { 1, 3 }, { 1, 4 }, { 2, 3 }, { 0, 2 }, { 3, 4 }, { 1, 2 }, { 0, 4 } };
    int[,] rnd18 = { { 1, 3 }, { 0, 4 }, { 0, 1 }, { 2, 4 }, { 1, 2 }, { 3, 4 }, { 2, 3 }, { 1, 4 }, { 0, 2 }, { 0, 3 } };
    int[,] rnd19 = { { 1, 2 }, { 0, 1 }, { 2, 3 }, { 0, 4 }, { 1, 4 }, { 0, 3 }, { 3, 4 }, { 1, 3 }, { 2, 4 }, { 0, 2 } };

    public float[] TopPoint = { 90.0f, 147.0f, 97.0f, 118.0f, 68.0f };



    public int[,] anserNum;
    public int highestNum;

    public bool IsFinish;

    public bool ShowDebug;


    public int TestNumber;
    public int AnimOrder;
    public GameState CurrentState;

    [SerializeField] GameObject TitleGroup;
    [SerializeField] GameObject FromStartGroup;
    [SerializeField] GameObject FromContinuedGroup;
    [SerializeField] GameObject InTestGroup;
    [SerializeField] GameObject LookBackGroup;
    [SerializeField] GameObject testManager;
    [SerializeField] GameObject lookBackManager;


    // Start is called before the first frame update
    void Start()
    {
        InitializationProcess();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitializationProcess()
    {
        TestNumber = 0;
        AnimOrder = 0;
        highestNum = 0;
        IsFinish = false;
        anserNum = new int[10, 3];
        WhenStateChanged(GameState.Title);
    }

    public void WhenStateChanged(GameState newGameState)
    {
        switch(newGameState)
        {
            case GameState.Title:
                TitleGroup.SetActive(true); 
                FromStartGroup.SetActive(false);
                FromContinuedGroup.SetActive(false);
                InTestGroup.SetActive(false);
                LookBackGroup.SetActive(false);
                CurrentState = newGameState;
                ChangedTitle();
                break;
            case GameState.FromStart:
                TitleGroup.SetActive(false);
                FromStartGroup.SetActive(true);
                FromContinuedGroup.SetActive(false);
                InTestGroup.SetActive(false);
                LookBackGroup.SetActive(false);
                CurrentState = newGameState;
                ChangedFromStart();
                break;
            case GameState.FromContinued:
                TitleGroup.SetActive(false);
                FromStartGroup.SetActive(false);
                FromContinuedGroup.SetActive(true);
                InTestGroup.SetActive(false);
                LookBackGroup.SetActive(false);
                CurrentState = newGameState;
                ChangedFromContinue();
                break;
            case GameState.InTest:
                TitleGroup.SetActive(false);
                FromStartGroup.SetActive(false);
                FromContinuedGroup.SetActive(false);
                InTestGroup.SetActive(true);
                LookBackGroup.SetActive(false);
                CurrentState = newGameState;
                ChangedInTest();
                break;
            case GameState.LookBack:
                TitleGroup.SetActive(false);
                FromStartGroup.SetActive(false);
                FromContinuedGroup.SetActive(false);
                InTestGroup.SetActive(false);
                LookBackGroup.SetActive(true);
                CurrentState = newGameState;
                ChangedLookBack();
                break;
        }
    }

    private void ChangedTitle()
    {

    }

    private void ChangedFromStart()
    {
        TestNumber = UnityEngine.Random.Range(10, 100);
    }
        
    private void ChangedFromContinue()
    {

    }

    private void ChangedInTest()
    {
        testManager.GetComponent<TestManager>().StartTest();
    }

    private void ChangedLookBack()
    {
        IsFinish = true;
        lookBackManager.GetComponent<LookBackManager>().SetFirst();
    }
    public int[] Getrnd0()
    {
        return rnd0;
    }
    public int[] Getrnd1()
    {
        return rnd1;
    }
    public int[] Getrnd2()
    {
        return rnd2;
    }
    public int[] Getrnd3()
    {
        return rnd3;
    }
    public int[] Getrnd4()
    {
        return rnd4;
    }
    public int[] Getrnd5()
    {
        return rnd5;
    }
    public int[] Getrnd6()
    {
        return rnd6;
    }
    public int[] Getrnd7()
    {
        return rnd7;
    }
    public int[] Getrnd8()
    {
        return rnd8;
    }
    public int[] Getrnd9()
    {
        return rnd9;
    }
    public int[,] Getrnd10()
    {
        return rnd10;
    }
    public int[,] Getrnd11()
    {
        return rnd11;
    }
    public int[,] Getrnd12()
    {
        return rnd12;
    }
    public int[,] Getrnd13()
    {
        return rnd13;
    }
    public int[,] Getrnd14()
    {
        return rnd14;
    }
    public int[,] Getrnd15()
    {
        return rnd15;
    }
    public int[,] Getrnd16()
    {
        return rnd16;
    }
    public int[,] Getrnd17()
    {
        return rnd17;
    }
    public int[,] Getrnd18()
    {
        return rnd18;
    }
    public int[,] Getrnd19()
    {
        return rnd19;
    }

}
