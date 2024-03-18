using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Properties;
using System;
using TMPro.EditorUtilities;

public class UI_Manager : MonoBehaviour

    
{

    [SerializeField] private TextMeshProUGUI scoreDisplay;
  //  [SerializeField] private ImageConversion[] _livesImg;

    GameManager gameManager;
    private UI_Manager ui_Manager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        ui_Manager = GameObject.Find("Canvas").GetComponent<UI_Manager>();
       // _livesImg[0].gameObject.SetActive(true);
      //  _livesImg[1].gameObject.SetActive(true);
      //  _livesImg[2].gameObject.SetActive(true);
    }

    private void OnGUI()
    {
        scoreDisplay.text = ("score ") + gameManager.ScoreDisplay();
    }

}
