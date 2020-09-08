using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuState : GameState
{
    MainMenu mainMenu;

    LevelSpawner levelSpawner;

    public MenuState(MainMenu mainMenu, LevelSpawner levelSpawner)
    {
        this.mainMenu = mainMenu;
        this.levelSpawner = levelSpawner;
    }

    public override IEnumerator StateEnter()
    {
        Debug.Log("Change state to MenuState");

        levelSpawner.SpawnLevel();

        mainMenu.Init();

        yield break;
    }

    public override IEnumerator StateExit()
    {
        //mainMenu.gameObject.SetActive(false);
        mainMenu.Close();

        yield break;
    }
}
