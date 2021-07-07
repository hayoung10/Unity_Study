using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText; // ���ӿ��� �� Ȱ��ȭ
    public Text timeText; // ���� �ð� ǥ��
    public Text recordText; // �ְ� ��� ǥ��

    private float surviveTime; // ���� �ð�
    private bool isGameover; // ���ӿ��� ����

    void Start()
    {
        surviveTime = 0;
        isGameover = false;
    }

    void Update()
    {
        if (!isGameover)
        {
            surviveTime += Time.deltaTime; // �����ð� ����
            timeText.text = "Time: " + (int)surviveTime; // �����ð� ǥ��
        }
        else // ���ӿ���
        {
            if (Input.GetKeyDown(KeyCode.R)) // �����
                SceneManager.LoadScene("SampleScene"); // SampleScene �� �ε�
        }
    }

    public void EndGame() // ���ӿ��� ó��
    {
        isGameover = true; // ���� ���� : ���ӿ���
        gameoverText.SetActive(true); // Ȱ��ȭ

        float bestTime = PlayerPrefs.GetFloat("BestTime");

        if (surviveTime > bestTime) // �ְ� ��� ����
        {
            bestTime = surviveTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        recordText.text = "Best Time: " + (int)bestTime;
    }
}
