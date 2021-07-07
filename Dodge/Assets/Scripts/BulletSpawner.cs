using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab; // 탄알의 프리팹
    public float spawnRateMin = 0.5f; // 최소 생성 주기
    public float spawnRateMax = 3f; // 최대 생성 주기

    private Transform target; // 발사할 대상
    private float spawnRate; // 생성 주기 (대기 시간)
    private float timeAfterSpawn; // 최근 생성 시점에서 지난 시간 (타이머)

    void Start()
    {
        timeAfterSpawn = 0f; // 최근 생성 이후의 누적 시간을 0으로 초기화
        spawnRate = Random.Range(spawnRateMin, spawnRateMax); // 초기 생성 간격
        target = FindObjectOfType<PlayerController>().transform; // PlayerController 컴포넌트를 가진 게임 오브젝트 : 조준 대상
    }

    void Update()
    {
        timeAfterSpawn += Time.deltaTime; // 프레임 시간 간격 갱신

        if(timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f; // 누적 시간 리셋

            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation); // 복제본 생성
            bullet.transform.LookAt(target);
            spawnRate = Random.Range(spawnRateMin, spawnRateMax); // 다음 생성 간격
        }
    }
}
