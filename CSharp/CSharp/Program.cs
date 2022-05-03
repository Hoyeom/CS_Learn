using System;

namespace CSharp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            
        }
        
        // int ret1 = Add(b: 3, a: 2, d: 5f);  // 이게...C#?... 좋다
        
        #region DATA

        // byte(1바이트 0~255), short(2바이트 -3만~3만), int(4바이트 -21억~21억), long(8바이트)
        // sbyte(1바이트 -128~127), short(2바이트 -0~6만), int(4바이트 0~43억), long(8바이트)

        // 10진수
        // 0 1 2 3 4 5 6 7 8 9
        // 10
        // 2진수
        // 0 1
        // 0b00 0b01 0b10 0b11 0b100
        // 0b 1000 1111 = 0x8F

        // 16진수
        // 0~9 a b c d e f
        // 0x00 0x01 0x02 .. 0x0F
        // 0x10 == 16
        // 16진수

        // 1바이트(참/거짓)
        // bool b;
        // b = true;
        // b = false;

        // 소수

        // 4바이트
        // float f = 3.14f;

        // 8바이트
        // double d = 3.14;
        //
        // char c = 'a';
        // string str = "Hello World!";
        //
        // Console.WriteLine(str);

        // 주석
        /* 주석 */

        // int hp = 100;
        // int level = 50;
        //
        // bool isAlive = hp > 0;
        // bool isHighLevel = (level >= 40);
        //
        //
        // bool a = isAlive && isHighLevel;
        //
        // bool b = isAlive || isHighLevel;

        // int id = 123;
        // int key = 401;
        //
        // 암호화
        // int a = id ^ key;
        // int b = a ^ key;
        //     
        // Console.WriteLine(a);
        // Console.WriteLine(b);

        #endregion

        #region 가위바위보

        /*Random rand = new Random();
            
        int aiChoice = rand.Next(0, 3);

        int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
        {
            case 0:
            Console.WriteLine("당신의 선택은 가위입니다.");
            break;
            case 1:
            Console.WriteLine("당신의 선택은 바위입니다.");
            break;
            case 2:
            Console.WriteLine("당신의 선택은 보입니다.");
            break;
        }
        switch (aiChoice)
        {
            case 0:
            Console.WriteLine("컴퓨터의 선택은 가위입니다.");
            break;
            case 1:
            Console.WriteLine("컴퓨터의 선택은 바위입니다.");
            break;
            case 2:
            Console.WriteLine("컴퓨터의 선택은 보입니다.");
            break;
        }
            
        // 승리 무승부 패배
        string answer = String.Empty;
            
            if (choice == aiChoice)
        answer = "무승부";
        else if ((choice + 1) % 3 == aiChoice)
        answer = "패배";
        else
        answer = "승리";
            
        Console.WriteLine(answer);*/

        #endregion

        #region Magic Mirror

        //  string answer = String.Empty;
        //      do
        //  {
        //      Console.WriteLine("강사님은 잘생기셨나요? (y/n) : ");
        //      answer = Console.ReadLine();
        //  } while (answer != "y");
        //      
        //   Console.WriteLine("정답입니다!");

        #endregion

        #region Prime

        /*int num = 1000002;

        bool isPrime = true;
        for (int i = 2; i < num; i++)
        {
        if (num % i == 0)
        {
            isPrime = false;
            break;
            }
        }

        Console.WriteLine(isPrime ? "소수에요!!" : "소수 아니에요!!");*/

        #endregion

        #region Continue

        // // cw + Tab Console.WriteLine....Me..Mo...메...모.
        // for (int i = 1; i <= 100; i++)
        // {
        //     if ((i % 3) != 0)
        //         continue;
        //     
        //     Console.WriteLine($"3으로 나뉘는 숫자 발견 {i.ToString()}");
        // }

        #endregion

        #region Method

        // static void Divide(int a, int b, out int resualt1,out int resualt2)
        // {
        //     resualt1 = a / b;
        //     resualt2 = a % b;
        // }
        
        // static void Swap(ref int a, ref int b)
        // {
        //     // 이게...스왑? C# 7
        //     (a, b) = (b, a);
        // }

        // static void AddOne(ref int number)
        // {
        //     number += 1;
        // }
        
        // static int AddOne(int nunber)
        // {
        //     return nunber + 1;
        // }

        // public static void Main(string[] args)
        // {
            // // 복사() 참조()
            // int num1 = 1;
            // int num2 = 3;
            //
            // int resualt1;
            // int resualt2;
            //
            // Divide(num1, num1, out resualt1, out resualt2);
            //
            // // 박싱 제거용 ToString 유효~!
            // Console.WriteLine($"{resualt1.ToString()} {resualt2.ToString()}");
        // }

        #endregion

        #region 재귀
        
        // static int Factorial(int n)
        // {
        //     return n == 1 ?
        //         n :
        //         n * Factorial(n - 1);
        // }
        
        #endregion
    }
}