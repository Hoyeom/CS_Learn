using System;
using System.Collections.Generic;

namespace CSharp_3
{
    public class Board
    {
        const char CIRCLE = '\u25cf';
        public TileType[,] Tile { get; private set; } // 배열
        public int Size { get; private set; }
        
        public int DestY { get; private set; }
        public int DestX { get; private set; }
        
        private Player _player;

        public enum TileType
        {
            Empty,
            Wall,
        }

        public void Initialize(int size, Player player)
        {
            if (size % 2 == 0)
                return;

            _player = player;

            Tile = new TileType[size, size];
            this.Size = size;

            DestY = Size - 2;
            DestX = Size - 2;

            // Mazes for Programmers 책이름
            // GenerateByBinaryTree();
            GenerateBySideWinder();
        }

        private void GenerateBySideWinder()
        {
            // 길을 메우는 작업
            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                        Tile[y, x] = TileType.Wall;
                    else
                        Tile[y, x] = TileType.Empty;
                }
            }

            // 랜덤으로 우측 혹은 아래로 길 뚫는 작업
            // Binary Tree Algorithm

            Random rand = new Random();
            for (int y = 0; y < Size; y++)
            {
                int count = 1;
                for (int x = 0; x < Size; x++)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                        continue;

                    if (y == Size - 2 && x == Size - 2)
                        continue;

                    if (y == Size - 2)
                    {
                        Tile[y, x + 1] = TileType.Empty;
                        continue;
                    }

                    if (x == Size - 2)
                    {
                        Tile[y + 1, x] = TileType.Empty;
                        continue;
                    }

                    if (rand.Next(0, 2) == 0)
                    {
                        Tile[y, x + 1] = TileType.Empty;
                        count++;
                    }
                    else
                    {
                        int randomIndex = rand.Next(0, count);
                        Tile[y + 1, x - randomIndex * 2] = TileType.Empty;
                        count = 1;
                    }
                }
            }
        }

        private void GenerateByBinaryTree()
        {
            // 길을 메우는 작업
            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                        Tile[y, x] = TileType.Wall;
                    else
                        Tile[y, x] = TileType.Empty;
                }
            }

            // 랜덤으로 우측 혹은 아래로 길 뚫는 작업
            // Binary Tree Algorithm

            Random rand = new Random();
            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                        continue;

                    if (y == Size - 2 && x == Size - 2)
                        continue;

                    if (y == Size - 2)
                    {
                        Tile[y, x + 1] = TileType.Empty;
                        continue;
                    }

                    if (x == Size - 2)
                    {
                        Tile[y + 1, x] = TileType.Empty;
                        continue;
                    }

                    if (rand.Next(0, 2) == 0)
                        Tile[y, x + 1] = TileType.Empty;
                    else
                        Tile[y + 1, x] = TileType.Empty;
                }
            }
        }

        public void Render()
        {
            ConsoleColor prevColor = Console.ForegroundColor;

            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
                {
                    // 플레이어 좌표를 가져와서 그 좌표가 y, x 가 일치하면 플레이어 표시
                    if (y == _player.PosY && x == _player.PosX)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    else if (y == DestY && x == DestX)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else
                    {
                        Console.ForegroundColor = GetTileColor(Tile[y, x]);
                    }

                    Console.Write(CIRCLE);
                }

                Console.WriteLine();
            }

            Console.ForegroundColor = prevColor;
        }

        ConsoleColor GetTileColor(TileType type)
        {
            switch (type)
            {
                case TileType.Empty:
                    return ConsoleColor.Green;
                case TileType.Wall:
                    return ConsoleColor.Red;
                default:
                    return ConsoleColor.White;
            }
        }
    }
}


#region MyList

public class MyList<T>
{
    private const int DEFAULT_SIZE = 1;
    private T[] _data = new T[DEFAULT_SIZE];

    public int Count = 0;

    public int Capacity
    {
        get { return _data.Length; }
    }

    // O(1) 예외 케이스 : 이사 비용 무시
    public void Add(T item)
    {
        // 1. 공간이 충분히 남아 있는지 확인
        if (Count >= Capacity)
        {
            // 공간을 다시 확보한다.
            T[] newArray = new T[Count * 2];
            for (int i = 0; i < Count; i++)
                newArray[i] = _data[i];
            _data = newArray;
        }

        // 2. 공간에다가 데이터를 넣어준다.
        _data[Count] = item;
        Count++;
    }

    // O(1)
    public T this[int index]
    {
        get { return _data[index]; }
        set { _data[index] = value; }
    }

    // O(N)
    public void RemoveAt(int index)
    {
        for (int i = index; i < Count - 1; i++)
            _data[i] = _data[i + 1];
        _data[Count - 1] = default(T);
        Count--;
    }
}

#endregion

#region MyLinkedList

public class MyLinkedListNode<T>
{
    public T Data;
    public MyLinkedListNode<T> Next;
    public MyLinkedListNode<T> Prev;
}

public class MyLinkedList<T>
{
    public MyLinkedListNode<T> Head = null; // 첫번째
    public MyLinkedListNode<T> Tail = null; // 마지막
    public int Count = 0;

    // O(1)
    public MyLinkedListNode<T> AddLast(T data)
    {
        MyLinkedListNode<T> newMyLinkedListNode = new MyLinkedListNode<T>();
        newMyLinkedListNode.Data = data;

        // 아직 방이 없었다면 추가한 방이 Head 이다
        if (Head == null)
            Head = newMyLinkedListNode;

        //  101 102 103
        // 마지막 방과 새로운 방을 연결해준다.
        if (Tail != null)
        {
            Tail.Next = newMyLinkedListNode;
            newMyLinkedListNode.Prev = Tail;
        }

        // 새로 추가된 방을 마지막 방으로 설정한다
        Tail = newMyLinkedListNode;
        Count++;
        return newMyLinkedListNode;
    }

    // O(1)
    public void Remove(MyLinkedListNode<T> myLinkedListNode)
    {
        // 첫번째 방의 다음 방을 첫번째 방으로 설정
        if (Head == myLinkedListNode)
            Head = Head.Next;

        // 마지막 방을 이전 방의 마지막 방으로 설정
        if (Tail == myLinkedListNode)
        {
            Tail = Tail.Prev;
        }

        if (myLinkedListNode.Prev != null)
            myLinkedListNode.Prev.Next = myLinkedListNode.Next;

        if (myLinkedListNode.Next != null)
            myLinkedListNode.Next.Prev = myLinkedListNode.Prev;

        Count--;
    }
}

#endregion