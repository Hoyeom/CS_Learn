using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise
{
    // [1] [2] [3] [4]
    
    // 스택: LIFO(후입선출 Lat In First Out)
    // 큐: FIFO(선입선출 First In First Out)


    class Graph
    {
        private int[,] adj = new int[6, 6]
        {
            {-1, 15, -1, 35, -1, -1},
            {15, -1, 05, 10, -1, -1},
            {-1, 05, -1, -1, -1, -1},
            {35, 10, -1, -1, 05, -1},
            {-1, -1, -1, 05, -1, 05},
            {-1, -1, -1, -1, 05, -1},
        };

        public void Dijikstra(int start)
        {
            bool[] visited = new bool[6];
            int[] distance = new int[6];
            int[] parent = new int[6];
            distance = Enumerable.Repeat(Int32.MaxValue, distance.Length).ToArray();
            
            distance[start] = 0;
            parent[start] = start;

            while (true)
            {
                // 제일 좋은 후보를 찾는다 ( 가장 가까이 있는 )
                
                // 가장 유력한 후보 거리와 번호 저장
                int closest = Int32.MaxValue;
                int now = -1;
                for (int i = 0; i < 6; i++)
                {
                    // 이미 좋은 후보인 정점은 스킵
                    if(visited[i])
                        continue;
                    // 아직 발견(예약)된 적 없거나, 기존 후보보다 멀면 스킵
                    if(distance[i] == Int32.MaxValue || distance[i] >= closest)
                        continue;
                    // 발견한 가장 좋은 후보 정보 갱신
                    closest = distance[i];
                    now = i;
                }

                // 후보가 하나도 없다
                if (now == -1) 
                    break;
                
                // 제일 좋은 후보 발견 방문
                visited[now] = true;
                
                // 방문한 정점과 인접한 정점 조사하여
                // 상황에 따라 발견한 최단거리 갱신
                for (int next = 0; next < 6; next++)
                {
                    // 연결 없다면 스킵
                    if(adj[now,next] == -1)
                        continue;
                    // 이미 방문한 정점은 스킵
                    if(visited[next])
                        continue;
                    
                    // 새로 조사된 정점의 최단거리 계산
                    int nextDist = distance[now] + adj[now, next];
                    // 만약 기존 발견한 최단거리가 새로 조사된 최단 거리 보다 크면 갱신
                    if (nextDist < distance[next])
                    {
                        distance[next] = nextDist;
                        parent[next] = now;
                    }
                }
                
            }
        }

        #region BFS

        

        public void BFS(int start)
        {
            bool[] found = new bool[6];
            int[] parent = new int[6];
            int[] distance = new int[6];

            Queue<int> q = new Queue<int>();
            q.Enqueue(start);
            found[start] = true;
            parent[start] = start;
            distance[start] = 0;

            while (q.Count > 0)
            {
                int now = q.Dequeue();
                Console.WriteLine(now);

                for (int next = 0; next < 6; next++)
                {
                    if (adj[now, next] == 0)    // 인접하지 않았으면 스킵
                        continue;
                    if(found[next])             // 이미 발견했다면 스킵
                        continue;
                    q.Enqueue(next);
                    found[next] = true;
                    parent[next] = now;
                    distance[next] = distance[now] + 1;
                }
            }
        }
        #endregion
        
        #region DFS

        private List<int>[] adj2 = new List<int>[]
        {
            new List<int>() {1, 3},
            new List<int>() {0, 2, 3},
            new List<int>() {1},
            new List<int>() {0, 1, 4},
            new List<int>() {3, 5},
            new List<int>() {4},
        };
        
        // 1. now 부터 방문
        // 2. now와 연결된 정점 확인해서, 아직 미방문 상태라면 방문한다.
        public void DFS1(int now, bool[] visited)
        {
            Console.WriteLine(now);
            visited[now] = true;

            for (int next = 0; next < 6; next++)
            {
                if (adj[now, next] == 0)    // 연결되어 있지 않으면 스킵 
                    continue;
                if(visited[next])           // 이미 방문 했으면 스킵
                    continue;
                DFS1(next, visited);
            }
        }
        public void DFS2(int now,bool[] visited)
        {
            Console.WriteLine(now);
            visited[now] = true;

            foreach (int next in adj2[now])
            {
                if(visited[next])
                    continue;
                DFS2(next, visited);
            }
        }

        public void SearchAll1()
        {
            bool[] visited = new bool[6];
            for (int now = 0; now < 6; now++)
            {
                if (visited[now] == false)
                    DFS1(now, visited);
            }
        }

        #endregion
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            // DFS (Depth First Search 깊이 우선 탐색)
            // BFS (Breadth First Search 너비 우선 탐색)
            Graph graph = new Graph();
            graph.Dijikstra(0);
        }
    }
}