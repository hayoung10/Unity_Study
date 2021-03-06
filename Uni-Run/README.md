책 "레트로의 유니티 게임 프로그래밍 에센스"을 통한 Unity 공부
> 저자 : 이제민  
> Unity  
> C#

###### 4가지 게임 구현

## 2. 2D 러너 게임 : Uni-Run
<img src="./Screenshots/Screenshot1.jpg" width="400"> <img src="./Screenshots/Screenshot2.jpg" width="400">  
랜덤한 높이로 무한 생성되는 바닥을 점프하면서 앞으로 달려가는 러너 게임

##### 설명/동작/기능
- 무한 생성되는 발판 위에 1~3개의 장애물이 일정 확률로 배치
- 동작 : 점프(마우스 왼쪽 버튼 클릭), 이단 점프(마우스 왼쪽 버튼 2번 클릭), 높이 점프(마우스 왼쪽 버튼 오래 누리기)
- 새로운 발판에 착지할 때마다 점수가 추가

##### 조작법
- 점프 : 마우스 왼쪽 버튼
- (사망 후) 게임 재시작 : 마우스 왼쪽 버튼

###### 사용 프로그램
> Unity 2020.3.0f1  
> Visual Studio 2015
<br>

----------------

##### 배운점 Study
- 오디오 소스 컴포넌트, 오디오 리스너 컴포넌트
- 유한 상태 머신 Finite State Machine; FSM 모델
- 싱글턴 패턴 Singleton Pattern
- 오브젝트 풀링 Object Pooling
