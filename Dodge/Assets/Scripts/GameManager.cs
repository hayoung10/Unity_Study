using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText; // 게임오버 시 활성화
    public Text timeText; // 생존 시간 표시
    public Text recordText; // 최고 기록 표시

    private float surviveTime; // 생존 시간
    private bool isGameover; // 게임오버 상태

    void Start()
    {
        surviveTime = 0;
        isGameover = false;
    }

    void Update()
    {
        if (!isGameover)
        {
            surviveTime += Time.deltaTime; // 생존시간 갱신
            timeText.text = "Time: " + (int)surviveTime; // 생존시간 표시
        }
        else // 게임오버
        {
            if (Input.GetKeyDown(KeyCode.R)) // 재시작
                SceneManager.LoadScene("SampleScene"); // SampleScene 씬 로드
        }
    }

    public void EndGame() // 게임오버 처리
    {
        isGameover = true; // 현재 상태 : 게임오버
        gameoverText.SetActive(true); // 활성화

        float bestTime = PlayerPrefs.GetFloat("BestTime");

        if (surviveTime > bestTime) // 최고 기록 갱신
        {
            bestTime = surviveTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        recordText.text = "Best Time: " + (int)bestTime;
    }
}
