using System;
using System.Collections.Generic;

namespace CSharp_3
{
    class Pos
    {
        public Pos(int y, int x) { Y = y; X = x; }
        public int Y;
        public int X;
    }
    
    public class Player
    {
        public int PosY { get; private set; }
        public int PosX { get; private set; }
        private Random _random = new Random();
        private Board _board;
        
        enum Dir
        {
            Up = 0,
            Left = 1,
            Down = 2,
            Right = 3,
        }

        private int _dir = (int) Dir.Up;
        private List<Pos> _point = new List<Pos>();

        public void Initialize(int posY, int posX, Board board)
        {
            PosY = posY;
            PosX = posX;
            _board = board;

            // 방향기준 목표 변화
			int[] frontY = new int[] { -1, 0, 1, 0 };
			int[] frontX = new int[] { 0, -1, 0, 1 };
			int[] rightY = new int[] { 0, -1, 0, 1 };
			int[] rightX = new int[] { 1, 0, -1, 0 };

            _point.Add(new Pos(PosY, PosX));
            // 목적지 도착 전까지 계속 실행
            while (PosY != board.DestY || PosX != board.DestX) 
            {
                // 1. 바라보는 방향 기준 오른쪽 가능한지 확인
                if (board.Tile[PosY + rightY[_dir], PosX + rightX[_dir]] == Board.TileType.Empty)
                {
                    // 오른쪽 방향 90도 회전
                    _dir = (_dir - 1 + 4) % 4;

                    // 앞으로 한 칸 전진
                    PosY = PosY + frontY[_dir];
                    PosX = PosX + frontX[_dir];
                    _point.Add(new Pos(PosY, PosX));
                }
                // 바라보는 방향으로 전진할 수 있는지 확인
                else if (board.Tile[PosY + frontY[_dir], PosX + frontX[_dir]] == Board.TileType.Empty) 
                {
                    // 앞으로 한칸 전진
                    PosY = PosY + frontY[_dir];
                    PosX = PosX + frontX[_dir];
                    _point.Add(new Pos(PosY, PosX));
                }
                else
                {
                    // 왼쪽 방향으로 90도 회전
                    _dir = (_dir + 1 + 4) % 4;
                }
            }
        }

        private const int MOVE_TICK = 100;
        private int _sumTick = 0;
        private int _lastIndex = 0;
        
        public void Update(int deltaTick)
        {
            if (_lastIndex >= _point.Count) return;
            _sumTick += deltaTick;
            if (_sumTick >= MOVE_TICK)
            {
                _sumTick = 0;

                PosY = _point[_lastIndex].Y;
                PosX = _point[_lastIndex].X;
                _lastIndex++;
            }
        }
    }
}