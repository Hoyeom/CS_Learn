using System.Collections.Generic;

namespace CSharp_3
{
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

    public class Board
    {
        public int[] _data = new int[25]; // 배열
        public List<int> _data2 = new List<int>(); // 동적 배열
        public LinkedList<int> _data3 = new LinkedList<int>(); // 연결 리스트

        public MyList<int> _myData1 = new MyList<int>();

        public void Initialize()
        {
            _myData1.Add(101);
            _myData1.Add(102);
            _myData1.Add(103);
            _myData1.Add(104);
            _myData1.Add(105);

            int temp = _myData1[2];
            
            _myData1.RemoveAt(2);

        }
    }
}