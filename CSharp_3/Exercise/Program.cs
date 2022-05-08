﻿using System;
using System.Collections.Generic;

namespace Exercise
{
    // [1] [2] [3] [4]
    
    // 스택: LIFO(후입선출 Lat In First Out)
    // 큐: FIFO(선입선출 First In First Out)


    class Graph
    {
        private int[,] adj = new int[6, 6]
        {
            {0, 1, 0, 1, 0, 0},
            {1, 0, 1, 1, 0, 0},
            {0, 1, 0, 0, 0, 0},
            {1, 1, 0, 0, 0, 0},
            {0, 1, 0, 0, 0, 1},
            {0, 1, 0, 0, 1, 0},
        };

        private List<int>[] adj2 = new List<int>[]
        {
            new List<int>() {1, 3},
            new List<int>() {0, 2, 3},
            new List<int>() {1},
            new List<int>() {0, 1},
            new List<int>() {5},
            new List<int>() {4},
        };


        private bool[] visited = new bool[6];
        // 1. now 부터 방문
        // 2. now와 연결된 정점 확인해서, 아직 미방문 상태라면 방문한다.
        public void DFS1(int now)
        {
            Console.WriteLine(now);
            visited[now] = true;

            for (int next = 0; next < 6; next++)
            {
                if (adj[now, next] == 0)    // 연결되어 있지 않으면 스킵 
                    continue;
                if(visited[next])           // 이미 방문 했으면 스킵
                    continue;
                DFS1(next);
            }
        }

        public void DFS2(int now)
        {
            Console.WriteLine(now);
            visited[now] = true;

            foreach (int next in adj2[now])
            {
                if(visited[next])
                    continue;
                DFS2(next);
            }
        }

        public void SearchAll()
        {
            visited = new bool[6];
            for (int now = 0; now < 6; now++)
            {
                if (visited[now] == false)
                    DFS1(now);
            }
        }
        
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            // DFS (Depth First Search 깊이 우선 탐색)
            // BFS (Breadth First Search 너비 우선 탐색)
            Graph graph = new Graph();
            graph.SearchAll();
        }
    }
}