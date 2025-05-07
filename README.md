# 메타버스 미니게임 프로젝트

이 프로젝트는 플레이어가 여러 미니게임을 즐길 수 있는 프로젝트입니다.

![image](https://github.com/user-attachments/assets/452bec9f-b1c6-4975-9528-9680665009a7)



## 🕹 미니게임 종류

이 프로젝트에는 두 가지 미니게임이 있습니다.

### 1. **배를 타고 멀리 !!** 🌊
*Flappy Bird*와 같은 게임으로, 플레이어는 배를 조종하여 장애물을 피하면서 멀리 나아가야 합니다.

![image](https://github.com/user-attachments/assets/2d349162-9f1d-4ef3-9352-0695bf877b33)

![JangTaBus - MainScene - Windows, Mac, Linux - Unity 2022 3 17f1 _DX11_ 2025-05-07 15-27-09](https://github.com/user-attachments/assets/5c1050d2-2880-45df-a746-0410deb1a757)


### 2. **농작물을 받아라 !!** 🌾
하늘에서 떨어지는 농작물을 받아 점수를 얻는 게임입니다. 로컬로 1P, 2P로 플레이합니다.

![image](https://github.com/user-attachments/assets/0853676b-ae13-427c-bdee-7ad1ff2c0fef)

![JangTaBus - MainScene - Windows, Mac, Linux - Unity 2022 3 17f1 _DX11_ 2025-05-07 14-35-30 (1)](https://github.com/user-attachments/assets/ed5c24f0-c0db-4648-9cea-bd6af259974f)




## 🛠 프로젝트 구조

이 프로젝트는 핵심 게임 플레이, UI, 사운드 관리 및 씬 전환을 효율적으로 관리할 수 있도록 구조화되어 있습니다. 주요 구성 요소는 다음과 같습니다:

### 핵심 구성 요소

- **GameManager**: 전체 게임 상태, 점수 관리 및 게임 로직을 처리합니다.
- **UIManager**: 점수, 타이머, 게임 오버 화면 등 게임 내 UI 요소를 관리합니다.
- **SoundManager**: 배경 음악(BGM)과 사운드 효과(SFX)를 처리합니다.
- **MiniGameManager**: 각 미니게임을 관리하는 기본 클래스입니다. 게임 시작, 업데이트 및 종료 기능을 제공합니다.

### 미니게임 관리

각 미니게임은 `MiniGameManager` 클래스를 상속받은 별도의 매니저에 의해 관리됩니다. 이 매니저들은 `UIManager`와 `GameManager`와 상호작용하여 게임 상태를 업데이트하고 관련 정보를 플레이어에게 표시합니다.

### 사운드 관리

`SoundManager`는 배경 음악과 사운드 효과를 정확히 재생하며, 볼륨 및 피치 변화를 조정할 수 있습니다.

### 씬 로딩

`SceneLoadManager`를 사용하여 씬을 비동기적으로 로드하며, 다른 씬으로 부드럽게 전환할 수 있습니다.
