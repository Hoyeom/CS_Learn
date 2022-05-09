using System;
using System.Collections.Generic;

namespace GraphExercise
{
    class TreeNode<T>
    {
        public T Data { get; set; }
        public List<TreeNode<T>> Childern { get; set; } = new List<TreeNode<T>>();
    }

    internal class Program
    {
        static TreeNode<string> MakeTree()
        {
            TreeNode<string> root = new TreeNode<string>() {Data = "R1 개발실"};
            {
                {
                    TreeNode<string> node = new TreeNode<string>() {Data = "디자인팀"};
                    node.Childern.Add(new TreeNode<string>() {Data = "전투"});
                    node.Childern.Add(new TreeNode<string>() {Data = "경제"});
                    node.Childern.Add(new TreeNode<string>() {Data = "스토리"});
                    root.Childern.Add(node);
                }
                {
                    TreeNode<string> node = new TreeNode<string>() {Data = "프로그래밍팀"};
                    node.Childern.Add(new TreeNode<string>() {Data = "서버"});
                    node.Childern.Add(new TreeNode<string>() {Data = "클라"});
                    node.Childern.Add(new TreeNode<string>() {Data = "엔진"});
                    root.Childern.Add(node);
                }
                {
                    TreeNode<string> node = new TreeNode<string>() {Data = "아트팀"};
                    node.Childern.Add(new TreeNode<string>() {Data = "배경"});
                    node.Childern.Add(new TreeNode<string>() {Data = "캐릭터"});
                    root.Childern.Add(node);
                }
            }
            return root;
        }

        static void PrintTree(TreeNode<string> root)
        {
            Console.WriteLine(root.Data);
            foreach (TreeNode<string> child in root.Childern)
                PrintTree(child);
        }

        static int GetHeight(TreeNode<string> root)
        {
            int height = 0;

            foreach (TreeNode<string> child in root.Childern)
            {
                int newHeight = GetHeight(child) + 1;
                height = Math.Max(height, newHeight);
            }
            
            return height;
        }

        public static void Main(string[] args)
        {
            TreeNode<string> root = MakeTree();
            
            Console.WriteLine(GetHeight(root));
        }
    }
}