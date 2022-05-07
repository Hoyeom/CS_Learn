using System;

namespace CSharp_3
{
    public class Player
    {
        public int PosY { get; private set; }
        public int PosX { get; private set; }
        private Random _random = new Random();
        private Board _board;

        public void Initialize(int posY, int posX, int destY, int destX, Board board)
        {
            PosY = posY;
            PosX = posX;

            _board = board;
        }

        private const int MOVE_TICK = 100;
        private int _sumTick = 0;

        public void Update(int deltaTick)
        {
            _sumTick += deltaTick;
            if (_sumTick >= MOVE_TICK)
            {
                _sumTick = 0;

                // 아래에 0.1초마다 실행될 로직 넣어둔다
                int randValue = _random.Next(0, 5);
                switch (randValue)
                {
                    case 0:
                        if (PosY - 1 >= 0 && _board.Tile[PosY - 1, PosX] == Board.TileType.Empty)
                            PosY = PosY - 1;
                        break;
                    case 1:
                        if (PosY + 1 < _board.Size && _board.Tile[PosY + 1, PosX] == Board.TileType.Empty)
                            PosY = PosY + 1;
                        break;
                    case 2:
                        if (PosX - 1 >= 0 && _board.Tile[PosY, PosX - 1] == Board.TileType.Empty)
                            PosX = PosX - 1;
                        break;
                    case 3:
                        if (PosX + 1 < _board.Size && _board.Tile[PosY, PosX + 1] == Board.TileType.Empty)
                            PosX = PosX + 1;
                        break;
                }
            }
        }
    }
}