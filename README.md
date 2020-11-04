## WRITER PROJECT
2020년 유니티 비주얼노벨 프로젝트 

###개발 일지 
* * * 
* 2020.02.12 첫 커밋  
기획: 황선영, 이정민  
프로그래밍: 김정현  
그래픽: 신재원, 우주현, 김명준  
* * *  

* 2020.02.16 첫 작업  
카메라 사이즈 조정 완료  
환경 설정이미지와 게임 종료이미지 구현 완료  
게임 종료 기능 구현 완료  
* * * 

* 2020.02.17  
게임 종료 기능 수정 대기창 생성  
갤러리 선택시 화면 이동 및 돌아오기 구현 완료  
시작하기 선택 시 새로 시작하기 화면 이동 및 팝업창 구현  
시작 화면에 모든 아이콘 구현
* * * 

* 2020.02.18  
시작 화면 UI 구성 및 인 게임 구현  
시작화면 불러오기, 설정하기 클릭 시 화면 이동 구현  
이미지, 사운드 리소스 파일 추가  
인게임 씬 구현 시작 및 추가  
인게임 대사 재생 효과 구현 중  
인게임 UI 일부 구현  
* * *  

* 2020.02.19  
인게임 UI 수정  
설정, 저장 돌아가기 만들기  
* * * 

* 2020.04.13  
인게임 대사 출력 방식 수정  
인게임 대사 출력 방식을 CSV 파일을 읽어와 출력하는 방식으로 변경  
추가적으로 코드 정리와 최적화는 하지 아니함  
* * * 

* 2020.04.22  
챕터 1까지 대사 출력 수정
CSV파일 이용시 빈칸은 공백으로 표시 필요 확인  
각 챕터별 파일 분리 결정  
* * * 

* 2020.05.29  
챕터 3까지 대사 출력 수정  
스크린 샷 작업 시작  
* * * 

* 2020.07.11  
스크린 샷을 통한 저장 기능 취소 및 클릭을 통한 저장 공간 구현으로 변경  
* * * 

* 2020.07.27  
챕터 3 대사 출력 수정  
설정 관련 UI 수정 및 저장 기능 구현해야함 
* * *  

* 2020.07.28  
설정 기능 변경, 저장 시스템 구현 시작
* * * 

* 2020.07.30  
조사 중 대사 창 없애는 기능 추가  
* * * 

* 2020.08.16  
UI 수정 및 추가 작업 진행 중  
사운드 관련 작업 시작  
배경 이미지 추가  
* * * 

* 2020.08.19  
UI 텍스트 창 수납 기능 추가  
* * * 

* 2020.08.20  
설정창 수납 기능 추가  
* * * 

* 2020.08.22  
설정창 UI 목록 변경  
환경 설정 패널 추가
* * * 

* 2020.08.24  
사건일지 및 갤러리 이미지 리소스 일부 적용  
사건일지 기획안대로 프로그래밍 적용 
* * * 
* 2020.08.25  
사건 일지 이미지 리소스 적용  
UI sorting 문제 해결  
Text 출력 방식 변경  
메뉴 이미지 리소스 적용  
* * * 
* 2020.08.28  
사건 일지 및 갤러리 테그 색깔 변경  
사건 일지 및 환경 설정 오픈 메뉴창 없어지도록 수정  
* * * 
* 2020.08.29  
안드로이드 빌드 세팅  
화면 비율 수정  
* * *  
* 2020.09.03  
  이미지 파일 추가  
  애니메이션 작업  
* * * 
* 2020.09.13  
  플래시 이펙트 생성  
  Fade In,Out 이펙트 생성  
* * * 
* 2020.09.21  
  대사 변경점 수정  
  이펙트 수정  
  캐릭터 변경 코드 추가  
* * * 
* 2020.09.22  
  챕터 1대사 파일 추가 수정  
  프롤로그 및 챕터 1 조사전까지 연출 적용  
* * * 
* 2020.09.27  
  챕터 1 조사 추가 및 연결  
  캐릭터 스폰 위치 변경  
  대사 출력 속도 수정  
  조사 시 다른 오브젝트 클릭 못하게 수정  
* * * 
* 2020.10.28  
  UI이미지 변경 중 - 사건파일 이미지 변경 플밍x  
  인게임 아이콘 및 텍스트 이미지 추가  
  메뉴 이미지 일부 변경
  메뉴를 열 때 텍스트 창이 열려 있으면 닫히도록 설정  
  ->텍스트 출력 창 여닫이 버튼 위치 및 글자 출력 선명도 결정 해야합니다.
* * *  
* 2020.11.05  
  챕터4 텍스트 파일 추가  
  메뉴창 최소화 시 터치 할 수 없도록 변경  
  사운드 바 이미지 추가 및 적용  
  텍스트 출력 창 크기 변경  
  저장 페이지 이미지 추가 및 적용  
  인게임 아이콘 및 창 이미지 추가  
* * * 
*  
   
  
#####문제점  
2020.02.16  
++캔버스의 렌더링 모드를 world space로 하지 않을 시 UI가 보이지 않음  
-> 해결
#####추가 요구 사항  
있을 시 기제 