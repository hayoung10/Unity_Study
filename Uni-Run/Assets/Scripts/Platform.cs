using UnityEngine;

// 발판으로서 필요한 동작을 담은 스크립트
public class Platform : MonoBehaviour {
    public GameObject[] obstacles; // 장애물 오브젝트들
    private bool stepped = false; // 플레이어 캐릭터가 밟았었는가

    // 발판을 리셋하는 처리
    private void OnEnable() {
        stepped = false; // 밟힘 상태를 리셋

        for(int i = 0; i < obstacles.Length;i++)
        {
            if (Random.Range(0, 3) == 0)
                obstacles[i].SetActive(true);
            else
                obstacles[i].SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        // 플레이어 캐릭터가 자신을 밟았을때 점수를 추가하는 처리
        if(collision.collider.tag == "Player" && !stepped)
        {
            stepped = true;
            GameManager.instance.AddScore(1);
        }
    }
}