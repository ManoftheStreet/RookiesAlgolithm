using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Rookies
{
    class Player
    {
        public int PosY { get; private set; }
        public int PosX { get; private set; }

        Board _board;
        Random _random = new Random();

        public void Initialize(int posY, int posX, int dsxtY, int destX, Board board)
        {
            PosY = posY;
            PosX = posX;

            _board = board;
        }

        const int MOVE_TICK = 100;
        int _sumTick = 0;

        public void Update(int deltaTick)
        {
            _sumTick += deltaTick;
            if (_sumTick >= MOVE_TICK)
            {
                _sumTick = 0;

                int randValue = _random.Next(0, 5);
                switch (randValue)
                {
                    case 0://상
                        if (PosY - 1 >= 0 &&_board.Tile[PosY - 1, PosX] == Board.TileType.Empty)
                            PosY = PosY - 1;
                        break;
                    case 1://하
                        if (PosY + 1 <= _board.Size && _board.Tile[PosY + 1, PosX] == Board.TileType.Empty)
                            PosY = PosY + 1;
                        break;
                    case 2://좌
                        if (PosX - 1 >= 0 && _board.Tile[PosY, PosX - 1] == Board.TileType.Empty)
                            PosX = PosX - 1;
                        break;
                    case 3://우
                        if (PosX + 1 <= _board.Size && _board.Tile[PosY, PosX + 1] == Board.TileType.Empty)
                            PosX = PosX + 1;
                        break;
                }
            }
        }
    }
}
