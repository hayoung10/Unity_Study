﻿using UnityEngine;

// 발판을 생성하고 주기적으로 재배치하는 스크립트
public class PlatformSpawner : MonoBehaviour {
    public GameObject platformPrefab; // 생성할 발판의 원본 프리팹
    public int count = 3; // 생성할 발판의 개수

    public float timeBetSpawnMin = 1.25f; // 다음 배치까지의 시간 간격 최솟값
    public float timeBetSpawnMax = 2.25f; // 다음 배치까지의 시간 간격 최댓값
    private float timeBetSpawn; // 다음 배치까지의 시간 간격

    public float yMin = -3.5f; // 배치할 위치의 최소 y값
    public float yMax = 1.5f; // 배치할 위치의 최대 y값
    private float xPos = 20f; // 배치할 위치의 x 값

    private GameObject[] platforms; // 미리 생성한 발판들
    private int currentIndex = 0; // 사용할 현재 순번의 발판

    private Vector2 poolPosition = new Vector2(0, -20); // 초반에 생성된 발판들을 화면 밖에 숨겨둘 위치
    private float lastSpawnTime; // 마지막 배치 시점


    void Start() {
        platforms = new GameObject[count]; // 새로운 발판 배열 생성

        // platformPrefab을 원본으로 새 발판을 poolPosition 위치에 복제 생성 & platforms 배열에 할당
        for (int i = 0; i < count; i++)
            platforms[i] = Instantiate(platformPrefab, poolPosition, Quaternion.identity);

        lastSpawnTime = 0f; // 마지막 배치 시점 초기화
        timeBetSpawn = 0f; // 다음번 배치까지의 시간 간격 초기화
    }

    void Update() {
        // 순서를 돌아가며 주기적으로 발판을 배치
        if (GameManager.instance.isGameover)
            return;

        if(Time.time >= lastSpawnTime + timeBetSpawn) // 마지막 배치 시점에서 timeBetSpawn 이상 시간이 흘렀다면
        {
            lastSpawnTime = Time.time; // 기록된 마지막 배치 시점을 현재 시점으로 갱신
            timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax); // 다음 배치까지의 시간 간격 설정
            float yPos = Random.Range(yMin, yMax); // 배치할 위치의 높이 설정

            // 발판 게임 오브젝트를 비활성화 -> 활성화 : 발판의 Platform 컴포넌트의 OnEnable 실행
            platforms[currentIndex].SetActive(false);
            platforms[currentIndex].SetActive(true);

            platforms[currentIndex].transform.position = new Vector2(xPos, yPos); // 현재 순번의 발판을 화면 오른쪽에 재배치
            currentIndex++;

            if (currentIndex >= count)
                currentIndex = 0; // 순번 리셋
        }
    }
}