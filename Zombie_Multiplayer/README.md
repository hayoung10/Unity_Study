책 "레트로의 유니티 게임 프로그래밍 에센스"을 통한 Unity 공부
> 저자 : 이제민  
> Unity  
> C#

###### 4가지 게임 구현

## 4. 네트워크 협동 게임 : Zombie (Surviver) Multiplayer
<img src="https://user-images.githubusercontent.com/39071652/132123403-872eedbf-0219-44cd-b1bc-feb38cc13bf8.jpg" width="450"> <img src="https://user-images.githubusercontent.com/39071652/132123431-f474b95f-96e8-4ec8-ba7d-3e7f6d598c79.jpg" width="450">  
좀비 서바이버 게임을 포톤을 사용한 멀티플레이어 게임으로 포팅함  

##### 설명/동작/기능
  - 기본 게임 플레이 구성은 **Zombie (Surviver)** [[싱글플레이어 버전]](../Zombie) 과 같음
  - 싱글플레이어 게임을 최대 4인 멀티플레이어로 포팅하며, 사망한 플레이어는 5초 뒤에 다시 부활함
  - 매치메이킹 시스템을 지원하고, 로비에서 인터넷을 통해 자동으로 빈 룸을 찾아 다른 플레이어의 게임에 참가함

▼ 매치메이킹 로비  
<img src="https://user-images.githubusercontent.com/39071652/132123398-771c06e9-6586-4da5-b1d1-cbc9ab945e7c.jpg" width="350">  

##### 조작법
- 캐릭터 회전 : 키보드 좌우 방향키(←,→) 또는 A,D키
- 캐릭터 전진/후진 : 키보드 상하 방향키(↑,↓) 또는 W,S키
- (기관총) 발사 : 마우스 왼쪽 버튼
- (기관총) 재장전 : 키보드 R키
- 룸 나가기 : Esc키

###### 사용 프로그램
> Unity 2020.3.0f1  
> Visual Studio 2015
<br>

----------------

##### 배운점 Study
- 로컬과 리모트, 로컬 권한 검사
- 서버 Server, 클라이언트 Client, 호스트 Host
- 전용 서버 방식, 리슨 서버 방식, P2P 방식
- RPC 원격 프로시저 호출, PunRPC
- 포톤 Photon 룸
- 스트림 stream
