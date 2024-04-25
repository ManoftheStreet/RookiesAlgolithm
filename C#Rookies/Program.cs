using System.Threading;
using System.Xml;

namespace C_Rookies
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            Player player = new Player();

            board.initialize(25, player);
            player.Initialize(1, 1, board);

            Console.CursorVisible = false;

            const int WAIT_TICK = 1000 / 30;

            int lastTick = 0;
            while (true)
            {
                //입력
                int currentTick = System.Environment.TickCount;
                if (currentTick - lastTick < WAIT_TICK)
                    continue;

                int deltaTick = currentTick - lastTick;
                lastTick = currentTick;

                //로직
                player.Update(deltaTick);
                //렌더링
                Console.SetCursorPosition(0, 0);
                board.Render();
            }
        }
    }
}