using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class MainGameLogic
{
    public GameObject boxObj;
    private GameBox myBox;

    private GameModel model;
    private List<GameBox> guestBox;

    int nextCellID = 0;
    int curCellID = 0;
    public void Start(){
        model = new GameModel();
        myBox.StartGameBox(9,19,1);
        

    }
    public void Update()
    {
        
    }

    private IEnumerator UpdateBoxContant()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            myBox.Draw();

        }
        yield break;
    }
}