using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab; // ź���� ������
    public float spawnRateMin = 0.5f; // �ּ� ���� �ֱ�
    public float spawnRateMax = 3f; // �ִ� ���� �ֱ�

    private Transform target; // �߻��� ���
    private float spawnRate; // ���� �ֱ� (��� �ð�)
    private float timeAfterSpawn; // �ֱ� ���� �������� ���� �ð� (Ÿ�̸�)

    void Start()
    {
        timeAfterSpawn = 0f; // �ֱ� ���� ������ ���� �ð��� 0���� �ʱ�ȭ
        spawnRate = Random.Range(spawnRateMin, spawnRateMax); // �ʱ� ���� ����
        target = FindObjectOfType<PlayerController>().transform; // PlayerController ������Ʈ�� ���� ���� ������Ʈ : ���� ���
    }

    void Update()
    {
        timeAfterSpawn += Time.deltaTime; // ������ �ð� ���� ����

        if(timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f; // ���� �ð� ����

            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation); // ������ ����
            bullet.transform.LookAt(target);
            spawnRate = Random.Range(spawnRateMin, spawnRateMax); // ���� ���� ����
        }
    }
}
