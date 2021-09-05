책 "레트로의 유니티 게임 프로그래밍 에센스"을 통한 Unity 공부
> 저자 : 이제민  
> Unity  
> C#

###### 4가지 게임 구현

## 3. 탑 다운 슈터 게임 : Zombie (Surviver)
<img src="https://user-images.githubusercontent.com/39071652/132122937-1cc70e15-9a39-48de-83d6-04d1fab2d157.jpg" width="450"> <img src="https://user-images.githubusercontent.com/39071652/132122955-c4ef16e8-27f0-439c-9239-34b2b780676b.jpg" width="450">  
끊임없이 나타나는 좀비들로부터 최대한 오래 살아남는 탑 다운 슈터 게임  

##### 설명/동작/기능
- 좀비는 일정 주기로 생성되며, 시간이 지날수록 한 번에 생성되는 좀비 수가 늘어남
- 좀비는 플레이어를 추적하며 다가오고, 좀비의 이동 속도와 공격력, 체력은 랜덤으로 지정됨 (강하고 빠른 좀비일수록 피부 색깔이 붉음)
- 플레이어의 체력은 캐릭터를 따라다니는 원형바로 확인 가능
- 맵에 기관총 탄알 아이템과 캐릭터 체력 아이템이 주기적으로 플레이어 근처에 랜덤한 주기와 위치로 배치됨/생성됨

▼ 붉은 좀비  
<img src="https://user-images.githubusercontent.com/39071652/132123024-eb320995-d0c4-414f-a2ef-4cd8ac79ba76.jpg" width="350">  

▼ 아이템  
<img src="https://user-images.githubusercontent.com/39071652/132123015-511d1a0e-ae2e-4e99-9718-2360afa03b2d.jpg" width="350"> <img src="https://user-images.githubusercontent.com/39071652/132123018-b11690f0-438b-4409-ab5e-68bfe83b919f.jpg" width="350">  

##### 조작법
- 캐릭터 회전 : 키보드 좌우 방향키(←,→) 또는 A,D키
- 캐릭터 전진/후진 : 키보드 상하 방향키(↑,↓) 또는 W,S키
- (기관총) 발사 : 마우스 왼쪽 버튼
- (기관총) 재장전 : 키보드 R키

###### 사용 프로그램
> Unity 2020.3.0f1  
> Visual Studio 2015
<br>

----------------

##### 배운점 Study
14-17
- 패키지 Package / 패키지 매니저
- 라이팅 Lighting / 라이팅 데이터 에셋 / 라이트맵 Lightmap
- 글로벌 일루미네이션 Global Illumination; GI
- 시네머신 Cinemachine
- 코루틴 Coroutine 메서드
- 레이캐스트 Raycast
- 델리게이트 delegate =대리자
- 이벤트 Event / 이벤트 리스너 Event Listener
- 내비게이션 Navigation 시스템
- 포스트 프로세싱 Post Process =후처리
