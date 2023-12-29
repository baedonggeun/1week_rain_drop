using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    //간단한 방식의 싱글톤
    public static GameManager I;

    void Awake()
    {
        I = this;
    }

    //GameManager가 함수 등 코드에 따라 실행시킬 클래스들
    public GameObject rain;
    public GameObject potion;
    public GameObject panel;

    //text class
    public Text scoreText;
    public Text timeText;

    //GameManager 에서 사용될 변수들
    int totalScore = 0; //전체 점수
    float limit = 60f; //제한 시간


    // Start is called before the first frame update
    void Start()
    {
        initGame();
        InvokeRepeating("makeRain", 0, 0.5f); //반복해서 호출하는 함수
        InvokeRepeating("makePotion", 0, 1f); //makePotion 함수를 0.5초 단위로 반복해 호출
    }

    // Update is called once per frame
    void Update()
    {
        limit -= Time.deltaTime; //플레이 시, 시스템 상의 시간
        timeText.text = limit.ToString("N2");

        if(limit < 0)
        {
            Time.timeScale = 0.0f;
            limit = 0.0f;

            panel.SetActive(true); //panel 이라는 객체를 활성화(true)하는 명령어
        }

        timeText.text = limit.ToString("N2");
    }

    void makeRain()
    {
        //Debug.Log("makeRain");
        Instantiate(rain); //객체를 동적으로 생성하는 함수
    }

    void makePotion()
    {
        Instantiate(potion);
    }

    public void AddScore(int score)
    {
        totalScore += score;

        if (totalScore < 0)
        {
            totalScore = 0;
        }

        scoreText.text = totalScore.ToString();
    }

    public void retry()
    {
        SceneManager.LoadScene("SampleScene");
    }


    void initGame()
    {
        Time.timeScale = 1.0f; //시간 배속
        totalScore = 0;
        limit = 60f;
    }
}
