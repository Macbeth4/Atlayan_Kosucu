using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class gameManager : MonoBehaviour
{
    public static gameManager Instance { get; private set; }

    public float initialGameSpeed = 5f;
    public float gameSpeedIncrease = 0.1f;
    public float gameSpeed { get; private set; }

    public gameManager managergame;
 

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI hiscoreText;
    public TextMeshProUGUI paratext;
    private float score;
    public int para1;

    public bool isdead;
    public GameObject deadscreen;

    private void Awake()
    {

        if (Instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }
    private void Start()
    {
        NewGame();
        para1 = PlayerPrefs.GetInt("para", para1);

    }

    public void NewGame()
    {
        score = 0f;
        gameSpeed = initialGameSpeed;
        UpdateHiscore();

    }
    public void Update()
    { 
        gameSpeed += gameSpeedIncrease * Time.deltaTime;
        score += gameSpeed * Time.deltaTime;
        scoreText.text = Mathf.FloorToInt(score).ToString();

        paratext.text = para1.ToString();
        PlayerPrefs.SetInt("para",para1);
        PlayerPrefs.Save();

    }

    public void Updatepara()
    {
        para1++;
        paratext.text = para1.ToString();
        PlayerPrefs.SetInt("para", para1);
        PlayerPrefs.Save();
    }


    public void UpdateHiscore()
    {
        float hiscore = PlayerPrefs.GetFloat("hiscore", 0);

        if (score > hiscore)
        {
            hiscore = score;
            PlayerPrefs.SetFloat("hiscore", hiscore);
        }

        hiscoreText.text = Mathf.FloorToInt(hiscore).ToString();
    }
        

    
}
