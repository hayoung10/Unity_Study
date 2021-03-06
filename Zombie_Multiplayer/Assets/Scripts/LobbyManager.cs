using Photon.Pun; // 유니티용 포톤 컴포넌트들
using Photon.Realtime; // 포톤 서비스 관련 라이브러리
using UnityEngine;
using UnityEngine.UI;

// 마스터(매치 메이킹) 서버와 룸 접속을 담당
public class LobbyManager : MonoBehaviourPunCallbacks {
    private string gameVersion = "1"; // 게임 버전

    public Text connectionInfoText; // 네트워크 정보를 표시할 텍스트
    public Button joinButton; // 룸 접속 버튼

    // 게임 실행과 동시에 마스터 서버 접속 시도
    private void Start() {
        PhotonNetwork.GameVersion = gameVersion; // 접속에 필요한 정보 설정
        PhotonNetwork.ConnectUsingSettings(); // 설정한 정보로 마스터 서버 접속 시도

        joinButton.interactable = false; // 룸 접속 버튼 잠시 비활성화
        connectionInfoText.text = "마스터 서버에 접속 중..."; // 접속 시도 중임을 텍스트로 표시
    }

    // 마스터 서버 접속 성공시 자동 실행
    public override void OnConnectedToMaster() {
        joinButton.interactable = true; // 룸 접속 버튼 비활성화
        connectionInfoText.text = "온라인 : 마스터 서버와 연결됨"; // 접속 정보 표시
    }

    // 마스터 서버 접속 실패시 자동 실행
    public override void OnDisconnected(DisconnectCause cause) {
        joinButton.interactable = false; // 룸 접속 버튼 비활성화
        connectionInfoText.text = "오프라인 : 마스터 서버와 연결되지 않음\n접속 재시도 중..."; // 접속 정보 표시

        PhotonNetwork.ConnectUsingSettings(); // 마스터 서버로의 재접속 시도
    }

    // (빈 무작위) 룸 접속 시도
    public void Connect() {
        joinButton.interactable = false; // 중복 접속 시도를 막기 위해 접속 버튼 잠시 비활성화

        if(PhotonNetwork.IsConnected) // 마스터 서버에 접속 중이라면
        {
            // 룸 접속 실행
            connectionInfoText.text = "룸에 접속...";
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            connectionInfoText.text = "오프라인 : 마스터 서버와 연결되지 않음\n접속 재시도 중..."; // 마스터 서버에 접속 중이 아니라면 마스터 서버에 접속 시도
            PhotonNetwork.ConnectUsingSettings(); // 마스터 서버로의 재접속 시도
        }
    }

    // (빈 방이 없어)랜덤 룸 참가에 실패한 경우 자동 실행
    public override void OnJoinRandomFailed(short returnCode, string message) {
        connectionInfoText.text = "빈 방이 없음, 새로운 방 생성..."; // 접속 상태 표시
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 4 }); // 최대 4명을 수용 가능한 빈 방 생성
    }

    // 룸에 참가 완료된 경우 자동 실행
    public override void OnJoinedRoom() { // (타 플레이어 준비시간을 기다리지 않고 실행)
        connectionInfoText.text = "방 참가 성공"; // 접속 상태 표시
        PhotonNetwork.LoadLevel("Main"); // 모든 룸 참가자가 Main 씬을 로드하게 함
    }
}