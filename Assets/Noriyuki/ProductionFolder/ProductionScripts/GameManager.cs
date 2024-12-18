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
    private int[] rnd0 = { 9, 7, 2, 3, 6, 1, 8, 0, 4, 5 };
    private int[] rnd1 = { 4, 5, 1, 6, 3, 2, 8, 0, 9, 7 };
    private int[] rnd2 = { 8, 1, 2, 7, 5, 4, 9, 6, 0, 3 };
    private int[] rnd3 = { 3, 0, 1, 9, 7, 6, 5, 4, 8, 2 };
    private int[] rnd4 = { 7, 3, 8, 0, 2, 5, 6, 4, 9, 1 };
    private int[] rnd5 = { 3, 5, 6, 4, 8, 7, 9, 2, 1, 0 };
    private int[] rnd6 = { 7, 3, 2, 6, 8, 4, 9, 1, 5, 0 };
    private int[] rnd7 = { 1, 4, 3, 7, 9, 8, 5, 6, 2, 0 };
    private int[] rnd8 = { 1, 2, 6, 9, 3, 8, 7, 0, 5, 4 };
    private int[] rnd9 = { 8, 6, 4, 1, 7, 0, 5, 9, 2, 3 };




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
        TestNumber = UnityEngine.Random.Range(0, 100);
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
        lookBackManager.GetComponent<LookBackManager>().SetTextFirst();
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

}
