using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class GameManager : MonoBehaviour
 
{
    #region

    public static GameManager Instance;


    //awake happens before start. Set the Gamemanager to whatever this script is attached too
    public void Awake()
    {
        if (Instance == null) Instance = this;
    }



    #endregion

    public float currentScore = 0f;

    public bool isPlaying = false;

    public string ScoreDisplay()
    {
        return Mathf.RoundToInt(currentScore).ToString();
    }

   

    private void Update()
    {
        if(isPlaying == true)
        {
            currentScore += Time.deltaTime;
        }

        if (Input.GetKeyDown("p"))
        {
            isPlaying = true;
        }

      //  if (Input.Button)
       // {
       //     isPlaying = true;
       //     Destroy button;
       // }


        //need to have a final score desplay when you die

    }

}