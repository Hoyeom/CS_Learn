using System.Collections.Generic;

namespace CSharp_3
{

    public class Board
    {
        public int[] _data = new int[25]; // 배열
        public MyLinkedList<int> _data3 = new MyLinkedList<int>(); // 연결 리스트

        public void Initialize()
        {
            _data3.AddLast(101);
            _data3.AddLast(102);
            MyLinkedListNode<int> node = _data3.AddLast(103);
            _data3.AddLast(104);
            _data3.AddLast(105);
            
            _data3.Remove(node);
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
        get { return _data[index];}
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
        public MyLinkedListNode<T> Head = null;    // 첫번째
        public MyLinkedListNode<T> Tail = null;    // 마지막
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