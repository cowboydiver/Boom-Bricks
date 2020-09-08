using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    List<Ball> balls = new List<Ball>(); //Yes, I called this list "balls" on purpose!
    List<Brick> bricks = new List<Brick>();

    [SerializeField]
    Ball ballPrefab;
    [SerializeField]
    LevelSpawner levelSpawner;
    [SerializeField]
    MainMenu mainMenu;
    [SerializeField]
    RetryButton retryButton;

    private GameState currentState;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else if(Instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        OpenMainMenu();
    }

    private void Update()
    {

    }

    public void SpawnBall(Vector3 position)
    {
        Ball newBall = Instantiate(ballPrefab, position, Quaternion.identity);
    }

    public void StartGame()
    {
        StartCoroutine(SetState(new PlayingState(balls, bricks)));
    }

    public void WinGame()
    {
        StartCoroutine(SetState(new WinGameState()));
    }

    public void LooseGame()
    {
        StartCoroutine(SetState(new LooseGameState(retryButton)));
    }

    public void OpenMainMenu()
    {
        StartCoroutine(SetState(new MenuState(mainMenu, levelSpawner)));
    }

    public IEnumerator SetState(GameState newState)
    {
        if(currentState != null)
            yield return currentState.StateExit();

        

        currentState = newState;

        yield return currentState.StateEnter();

        yield break;
    }

    public void CheckBalls() //This never gets old
    {
        if (balls.Count == 0)
        {
            LooseGame();
        }
    }

    public void CheckBricks()
    {
        if(bricks.Count == 0)
        {
            LooseGame();
        }
    }

    public void AddBall(Ball ball)
    {
        balls.Add(ball);
    }
    public void RemoveBall(Ball ball) //og god I love this reference
    {
        balls.Remove(ball);
        CheckBalls();
    }

    public void AddBrick(Brick brick)
    {
        bricks.Add(brick);
    }
    public void RemoveBrick(Brick brick)
    {
        bricks.Remove(brick);
        CheckBricks();
    }

}
