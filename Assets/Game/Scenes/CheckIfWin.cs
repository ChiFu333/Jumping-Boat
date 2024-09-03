using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfWin : MonoBehaviour
{
    public string winline, notWinLine;
    public void Check()
    {
        if(BoatController.inst.transform.position.x > 10000)
        {
            SceneLoader.inst.LoadScene(winline);
        }
        else
        {
            SceneLoader.inst.LoadScene(notWinLine);
        }
    }
}
