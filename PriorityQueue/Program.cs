using System.Diagnostics.CodeAnalysis;

namespace PriorityQueue
{
    class PriorityQueue
    {
        List<int> _heap = new List<int>();

        public void Push(int data)
        {
            //힙의 맨 끝에 새로운 데이터 삽입
            _heap.Add(data);

            int now = _heap.Count - 1;


            //도장깨기 시작
            while (now > 0)
            {
                //도장깨기 시도
                int next = (now -1) / 2;
                if (_heap[now] < _heap[next])
                    break;//실패

                //값교환
                int temp = _heap[now];
                _heap[now] = _heap[next];
                _heap[next] = temp;

                //검사위치 이동
                now = next;
            }
        }

        public int Pop()
        {
            //반환할 데이터를 따로 저장
            int ret = _heap[0];

            //마지막 데이터를 루트로 이동
            int lastIndex = _heap.Count - 1;
            _heap[0] = _heap[lastIndex];
            _heap.RemoveAt(lastIndex);
            lastIndex--;

            int now = 0;
            while (true)
            {
                int left = 2 * now + 1;
                int right = 2 * now + 2;

                int next = now;

                //왼쪽값이 현재값보다 크면, 왼쪽으로 이동
                //left <= lastIndex는 왼쪽 자식 노드가 힙 배열 범위 내에 있는지 확인
                //_heap[next] < _heap[left]는 현재 노드(부모 노드)의 값이 왼쪽 자식 노드의 값보다 작은지 비교
                if (left <= lastIndex && _heap[next] < _heap[left])
                    next = left;

                //오른쪽값이 현재값보다 크면 오른쪽으로 이동
                if(right <= lastIndex && _heap[next] < _heap[right])
                    next = right;

                //왼쪽 오른쪽 모두 현재값보다 작으면 종료
                if (next == now)
                    break;

                //값교환
                int temp = _heap[now];
                _heap[now] = _heap[next];
                _heap[next] = temp;

                now = next;
            }

            return ret;

        }

        public int Count()
        {
            return _heap.Count;
        }
    }
    
    internal class Program
    {
        static void Main(string[] args)
        {
            PriorityQueue q = new PriorityQueue();
            q.Push(20);
            q.Push(10);
            q.Push(30);
            q.Push(90);
            q.Push(40);

            while(q.Count() > 0)
            {
                Console.WriteLine(q.Pop());
            }
        }
    }
}
