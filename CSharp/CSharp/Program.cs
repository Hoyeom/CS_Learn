using System;

namespace CSharp
{
    internal class Program
    {
        public enum ClassType
        {
            None = 0,
            Knight = 1,
            Archer = 2,
            Mage = 3,
        }

        enum MonsterType
        {
            None = 0,
            Slime = 1,
            Orc = 2,
            Skeleton = 3,
        }

        struct Player
        {
            public int hp;
            public int attack;
        }

        struct Monster
        {
            public int hp;
            public int attack;
        }

        static ClassType ChooseClass()
        {
            int enumLen = Enum.GetValues(typeof(ClassType)).Length;

            Console.WriteLine("직업을 선택하세요!");

            for (int i = 1; i < enumLen; i++)
                Console.WriteLine($"[{i.ToString()}] {((ClassType) i).ToString()}");


            int temp = Convert.ToInt32(Console.ReadLine());

            if (temp > 0 && temp < enumLen)
            {
                ClassType classType = (ClassType) temp;
                Console.WriteLine($"당신은 {classType.ToString()} 입니다~");
                return classType;
            }

            return ClassType.None;
        }

        static void CreatePlayer(ClassType choice, out Player player)
        {
            switch (choice)
            {
                case ClassType.Knight:
                    player.hp = 100;
                    player.attack = 10;
                    break;
                case ClassType.Archer:
                    player.hp = 75;
                    player.attack = 12;
                    break;
                case ClassType.Mage:
                    player.hp = 50;
                    player.attack = 15;
                    break;
                default:
                    player.hp = 0;
                    player.attack = 0;
                    break;
            }
        }

        static void CreateRandomMonster(out Monster monster)
        {
            Random rand = new Random();
            int randMonster = rand.Next(1, 4);

            switch (randMonster)
            {
                case (int) MonsterType.Slime:
                    Console.WriteLine("슬라임이 스폰되었습니다");
                    monster.hp = 20;
                    monster.attack = 2;
                    break;
                case (int) MonsterType.Orc:
                    Console.WriteLine("오크가 스폰되었습니다");
                    monster.hp = 40;
                    monster.attack = 4;
                    break;
                case (int) MonsterType.Skeleton:
                    Console.WriteLine("스켈레톤이 스폰되었습니다");
                    monster.hp = 30;
                    monster.attack = 3;
                    break;
                default:
                    monster.hp = 0;
                    monster.attack = 0;
                    break;
            }
        }

        static void Fight(ref Player player, ref Monster monster)
        {
            while (true)
            {
                // 플레이어가 몬스터 공격
                monster.hp -= player.attack;
                if (monster.hp <= 0)
                {
                    Console.WriteLine("승리했습니다!");
                    Console.WriteLine($"남은 체력{player.hp.ToString()}");
                    break;
                }

                // 몬스터 반격
                player.hp -= monster.attack;
                if (player.hp <= 0)
                {
                    Console.WriteLine("패배했습니다!");
                    break;
                }
            }
        }

        static void EnterField(ref Player player)
        {
            while (true)
            {
                Console.WriteLine("필드에 접속했습니다!");

                // 몬스터 생성
                Monster monster;
                // 랜덤으로 1~3 몬스터 중 하나를 리스폰
                CreateRandomMonster(out monster);

                Console.WriteLine("[1] 전투 모드로 돌입");
                Console.WriteLine("[2] 일정 확률로 마을로 도망");

                string input = Console.ReadLine();
                if (input == "1")
                {
                    Fight(ref player, ref monster);
                }
                else if (input == "2")
                {
                    // 33%
                    Random rand = new Random();
                    int randValue = rand.Next(0, 101);
                    if (randValue <= 33)
                    {
                        Console.WriteLine("도망치는데 성공했습니다!");
                        break;
                    }
                    else
                    {
                        Fight(ref player, ref monster);
                    }
                }
            }
        }

        static void EnterGame(ref Player player)
        {
            while (true)
            {
                Console.WriteLine("마을에 접속했습니다.");
                Console.WriteLine("[1] 필드로 간다");
                Console.WriteLine("[2] 로비로 돌아가기");

                string input = Console.ReadLine();

                if (input == "1")
                {
                    EnterField(ref player);
                }
                else if (input == "2")
                    break;
            }
        }

        public static void Main(string[] args)
        {
            while (true)
            {
                ClassType choice = ChooseClass();
                if (choice != ClassType.None)
                    continue;
                // 캐릭터 생성
                Player player;

                CreatePlayer(choice, out player);

                EnterGame(ref player);
                // 기사(100/10) 궁수(75/12) 법사(50/15)

                // 필드로 가서 몬스터랑 싸운다
            }
        }
    }
}

// int ret1 = Add(b: 3, a: 2, d: 5f);  // 이게...C#?... 좋다

#region Learn

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

#endregion