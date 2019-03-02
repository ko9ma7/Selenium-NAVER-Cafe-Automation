# 개요
Selenium 학습 목적으로 Selenium의 ChromeDriver을 활용하여 네이버 카페의 일부 기능을 자동화하였습니다.

# 작성 언어
C#(.NET Framework 4.6.1) ConsoleApp

# 코멘트
- 사용 방법에 대해서는 질문을 받지 않고 있습니다.
- 이 프로그램은 수정 후 컴파일없이 실행하면 작동하지 않습니다.
- 네이버 로그인 시 계정 정보 입력을 단순히 SendKeys를 사용하면 봇으로 감지되는 것으로 예상되어 Clipboard를 활용하였습니다.
- 초기에 Repository 생성 시 ```.gitignore``` 선택란에 C#이 없었는데 https://gist.github.com/kmorcinek/2710267를 참고하였습니다.

# 주의
- 이 프로그램을 사용하여 발생하는 어떠한 문제도 책임지지 않습니다.
- 이 프로그램이 네이버의 정책을 위반하는지에 대한 여부는 확인하지 않았습니다.
- 이 프로그램에 네이버 계정 정보(특히 암호)를 기입할 때에는 각별한 주의를 요합니다.
- 이 프로그램은 Selenium의 라이선스인 Apache 2.0을 다릅니다.

# 설정
- ```.\ChromeAutomation\Program.cs:27``` 네이버 카페 고유 ID: 네이버 카페 카테고리 중 전체글보기를 우클릭하여 복사한 링크의  ```search.clubid``` 값입니다.
- ```.\ChromeAutomation\Program.cs:30``` 네이버 카페 URL: 네이버 카페의 URL입니다.
- ```.\ChromeAutomation\Program.cs:33``` 네이버 로그인 ID: 네이버 로그인 ID입니다.(로그인 ID를 다른 것으로 사용할 시 실제 ID 대신 로그인 ID를 입력하세요.)
- ```.\ChromeAutomation\Program.cs:36``` 네이버 ID: 네이버 ID입니다.(로그인 ID를 다른 것으로 사용할 시 실제 ID를 입력하세요.)
- ```.\ChromeAutomation\Program.cs:39``` 네이버 암호: 네이버 암호입니다.
- ```.\ChromeAutomation\Program.cs:42``` 업로드할 게시물 제목
- ```.\ChromeAutomation\Program.cs:45``` 업로드할 게시판
- ```.\ChromeAutomation\Program.cs:48``` 업로드할 게시물 내용
- ```.\ChromeAutomation\Program.cs:51``` 업로드할 사진 경로
