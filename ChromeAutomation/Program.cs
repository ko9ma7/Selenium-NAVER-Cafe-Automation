using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Keys = OpenQA.Selenium.Keys;

/*
        
        2019. 03. 03.
        (C) 2019 Yoo Donghoon.

        Blog: https://donghoon.me
        Github: https://github.com/donghoony1

        yoodonghoon01@gmail.com(yoodonghoon@icloud.com)

*/

namespace ChromeAutomation
{
    class Program
    {
        // 네이버 카페 고유 ID
        private static readonly string cafeId = "12345678";

        // 네이버 카페 주소
        private static readonly string cafeUrl = "http://cafe.naver.com/ABC";

        // 네이버 로그인 ID
        private static readonly string naverLoginId = "ID goes here";

        // 네이버 ID
        private static readonly string naverId = "ID goes here";

        // 네이버 암호
        private static readonly string naverPassword = "Password goes here";

        // 업로드할 게시물 제목
        private static readonly string articleTitle = "테스트";

        // 업로드할 게시판
        private static readonly string articleCategory = "자유게시판";

        // 업로드할 게시물 내용
        private static readonly string articleContent = "테스트";

        // 업로드할 사진 경로
        private static readonly string articleImagePath = @"C:\Users\Test\Desktop\Image.png";

        [STAThread]
        static void Main(string[] args)
        {
            // 네이버 로그인 페이지 접속
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://nid.naver.com/nidlogin.login");

            // 네이버 아이디 입력
            IWebElement naverAccID = driver.FindElement(By.CssSelector("[name=id]"));
            Clipboard.SetText(naverLoginId);
            naverAccID.SendKeys(Keys.LeftControl + "V");

            // 네이버 암호 입력
            IWebElement naverAccPass = driver.FindElement(By.CssSelector("[name=pw]"));
            Clipboard.SetText(naverPassword);
            naverAccPass.SendKeys(Keys.LeftControl + "V");

            // 로그인
            naverAccPass.SendKeys(Keys.Enter);

            // 기기 등록이 있는 경우 '등록안함' 클릭
            if (driver.Url == "https://nid.naver.com/nidlogin.login")
            {
                Thread.Sleep(1000);
                driver.FindElement(By.CssSelector(".btn_cancel a")).Click();
            }

            // 최근 게시물 1개 삭제
            driver.Navigate().GoToUrl("https://cafe.naver.com/CafeMemberNetworkView.nhn?m=view&clubid=" + cafeId + "&memberid=" + naverId + "&networkSearchKey=Article&networkSearchType=7");
            IWebElement naverCafeiframe = driver.FindElement(By.CssSelector("[name=cafe_main]"));
            driver.SwitchTo().Frame(naverCafeiframe);
            IWebElement naverCafeArticleiframe = driver.FindElement(By.CssSelector("[title=게시글보기]"));
            driver.SwitchTo().Frame(naverCafeArticleiframe);
            driver.FindElements(By.CssSelector("tbody")).ToList().First().FindElement(By.CssSelector("a")).Click();
            driver.SwitchTo().DefaultContent();
            driver.SwitchTo().Frame(naverCafeiframe);
            driver.FindElement(By.CssSelector(".delete._rosRestrict")).Click();
            SendKeys.SendWait(@"{Enter}");

            // 카페 접속
            driver.SwitchTo().DefaultContent();
            driver.Navigate().GoToUrl(cafeUrl);

            // 카페 글쓰기 클릭
            driver.FindElement(By.CssSelector(".cafe-write-btn ._rosRestrict")).Click();

            // 게시판 iframe 연결
            IWebElement naverCafeWriteiframe = driver.FindElement(By.CssSelector("[name=cafe_main]"));
            driver.SwitchTo().Frame(naverCafeWriteiframe);

            // 게시판 설정
            new SelectElement(driver.FindElement(By.CssSelector("[name=menuid]"))).SelectByText(articleCategory);

            // 게시물 제목 작성
            IWebElement naverCafeWriteTitle = driver.FindElement(By.CssSelector("[name=subject]"));
            naverCafeWriteTitle.SendKeys(Keys.Control + "A");
            naverCafeWriteTitle.SendKeys(Keys.Delete);
            naverCafeWriteTitle.SendKeys(articleTitle);

            // 게시물 내용 작성
            IWebElement naverCafeWriteContent = driver.FindElement(By.CssSelector("[title=글쓰기영역]"));
            driver.SwitchTo().Frame(naverCafeWriteContent);
            IWebElement naverCafeWriteContentBody = driver.FindElement(By.CssSelector("body"));
            naverCafeWriteContentBody.SendKeys(articleContent);
            driver.SwitchTo().DefaultContent();
            driver.SwitchTo().Frame(naverCafeWriteiframe);

            // 이미지 업로드
            IWebElement naverCafeWriteImageUploader = driver.FindElement(By.CssSelector("#iImage"));
            naverCafeWriteImageUploader.Click();
            Thread.Sleep(1000);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            driver.FindElement(By.CssSelector(".npe_alert_btn_close")).Click();
            driver.FindElement(By.CssSelector(".npu_btn_icon.npu_btn_mypc")).Click();
            Thread.Sleep(1000);
            SendKeys.SendWait(articleImagePath);
            SendKeys.SendWait("{Enter}");
            driver.FindElement(By.CssSelector(".npu_btn.npu_btn_submit")).Click();
            Thread.Sleep(2000);
            driver.SwitchTo().Window(driver.WindowHandles.First());
            driver.SwitchTo().DefaultContent();
            driver.SwitchTo().Frame(naverCafeWriteiframe);

            // 글 올리기
            IWebElement naverCafeWriteSubmit = driver.FindElement(By.CssSelector("#cafewritebtn"));
            naverCafeWriteSubmit.Click();

            Console.WriteLine("스크립트 종료");
            Console.ReadLine();
            Environment.Exit(0);
        }
    }
}