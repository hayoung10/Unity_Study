using System.Collections;
using UnityEngine;

// 총을 구현한다
public class Gun : MonoBehaviour {
    // 총의 상태를 표현하는데 사용할 타입을 선언한다
    public enum State {
        Ready, // 발사 준비됨
        Empty, // 탄창이 빔
        Reloading // 재장전 중
    }

    public State state { get; private set; } // 현재 총의 상태

    public Transform fireTransform; // 총알이 발사될 위치

    public ParticleSystem muzzleFlashEffect; // 총구 화염 효과
    public ParticleSystem shellEjectEffect; // 탄피 배출 효과

    private LineRenderer bulletLineRenderer; // 총알 궤적을 그리기 위한 렌더러

    private AudioSource gunAudioPlayer; // 총 소리 재생기
    public AudioClip shotClip; // 발사 소리
    public AudioClip reloadClip; // 재장전 소리

    public float damage = 25; // 공격력
    private float fireDistance = 50f; // 사정거리

    public int ammoRemain = 100; // 남은 전체 탄약
    public int magCapacity = 25; // 탄창 용량
    public int magAmmo; // 현재 탄창에 남아있는 탄약


    public float timeBetFire = 0.12f; // 총알 발사 간격
    public float reloadTime = 1.8f; // 재장전 소요 시간
    private float lastFireTime; // 총을 마지막으로 발사한 시점


    private void Awake() {
        gunAudioPlayer = GetComponent<AudioSource>();
        bulletLineRenderer = GetComponent<LineRenderer>();

        bulletLineRenderer.positionCount = 2; // 사용할 점을 두 개로 변경
        bulletLineRenderer.enabled = false; // 라인 렌더러를 비활성화
    }

    private void OnEnable() {
        magAmmo = magCapacity; // 현재 탄창을 가득 채우기
        state = State.Ready; // 총을 쏠 준비가 된 상태
        lastFireTime = 0; // 마지막으로 총을 쏜 시점 초기화
    }

    // 발사 시도
    public void Fire() {
        if(state == State.Ready && Time.time >= lastFireTime + timeBetFire)
        {
            lastFireTime = Time.time; // 마지막 총 발사 시점 갱신
            Shot(); // 실제 발사 처리 실행
        }
    }

    // 실제 발사 처리
    private void Shot() {
        RaycastHit hit; // 레이캐스트에 의해 충돌 정보를 저장하는 컨테이너
        Vector3 hitPosition = Vector3.zero; // 탄알이 맞은 곳을 저장할 변수

        if (Physics.Raycast(fireTransform.position, fireTransform.forward, out hit, fireDistance)) // 레이가 어떤 물체와 충돌한 경우
        {
            IDamageable target = hit.collider.GetComponent<IDamageable>();

            if (target != null)
                target.OnDamage(damage, hit.point, hit.normal); // 상대방에 대미지 주기

            hitPosition = hit.point; // 레이가 충돌한 위치 저장
        }
        else // 레이가 다른 물체와 충돌하지 않았다면
        {
            hitPosition = fireTransform.position + fireTransform.forward * fireDistance; // 탄알이 최대 사정거리까지 날아갔을 때의 위치를 충돌 위치로 사용
        }

        StartCoroutine(ShotEffect(hitPosition)); // 발사 이펙트 재생

        magAmmo--;
        if (magAmmo <= 0) // 탄창에 남은 탄알이 없다면
            state = State.Empty;
    }

    // 발사 이펙트와 소리를 재생하고 총알 궤적을 그린다
    private IEnumerator ShotEffect(Vector3 hitPosition) {
        muzzleFlashEffect.Play(); // 총구 화염 효과 재생
        shellEjectEffect.Play(); // 탄피 배출 효과 재생
        gunAudioPlayer.PlayOneShot(shotClip); // 총격 소리 재생

        bulletLineRenderer.SetPosition(0, fireTransform.position); // 선의 시작점은 총구의 위치
        bulletLineRenderer.SetPosition(1, hitPosition); // 선의 끝점은 입력으로 들어온 충돌 위치
        bulletLineRenderer.enabled = true; // 라인 렌더러 활성화 -> 탄알 궤적 그림

        yield return new WaitForSeconds(0.03f); // 0.03초 동안 잠시 처리를 대기

        bulletLineRenderer.enabled = false; // 라인 렌더러 비활성화 -> 탄알 궤적 지움
    }

    // 재장전 시도
    public bool Reload() {
        if (state == State.Reloading || ammoRemain <= 0 || magAmmo >= magCapacity)
            return false;

        StartCoroutine(ReloadRoutine()); // 재장전 처리 시작
        return true;
    }

    // 실제 재장전 처리를 진행
    private IEnumerator ReloadRoutine() {
        state = State.Reloading; // 현재 상태를 재장전 중 상태로 전환
        gunAudioPlayer.PlayOneShot(reloadClip); // 재장전 소리 재생

        yield return new WaitForSeconds(reloadTime); // 재장전 소요 시간 만큼 처리를 쉬기

        int ammoToFill = magCapacity - magAmmo; // 탄창에 채울 탄알 계산
        if (ammoRemain < ammoToFill) // 탄창에 채워야 할 탄알이 남은 탄알보다 많다면
            ammoToFill = ammoRemain; // 채워야할 탄알 수를 남은 탄알 수에 맞춰 줄임

        magAmmo += ammoToFill; // 탄창을 채움
        ammoRemain -= ammoToFill; // 남은 탄알에서 탄창에 채운만큼 탄알을 뺌
        
        state = State.Ready; // 총의 현재 상태를 발사 준비된 상태로 변경
    }
}