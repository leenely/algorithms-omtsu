using System;
using System.Collections.Generic;

public unsafe struct StudentNode
{
    public int id;
    public fixed char userName[128];
    public StudentNode* left;
    public StudentNode* right;

    public StudentNode(int id, string name)
    {
        this.id = id;
        this.left = null;
        this.right = null;
        
        fixed (char* ptr = userName)
        {
            int i;
            for (i = 0; i < Math.Min(name.Length, 127); i++)
            {
                ptr[i] = name[i];
            }
            ptr[i] = ' ';
        }
    }

    public string GetName()
    {
        fixed (char* ptr = userName)
        {
            return new string(ptr);
        }
    }
}

public unsafe class StudentTree
{
    private StudentNode* root;
    private StudentNode[] list;
    private int index;

    public StudentTree(int capacity)
    {
        list = new StudentNode[capacity];
        index = 0;
        root = null;
    }

    public void Insert(int id, string name)
    {
        list[index] = new StudentNode(id, name);
        
        fixed (StudentNode* node = &list[index])
        {
            index++;
            
            if (root == null)
            {
                root = node;
                return;
            }
            
            StudentNode* current = root;
            while (true)
            {
                if (id < current->id)
                {
                    if (current->left == null)
                    {
                        current->left = node;
                        break;
                    }
                    current = current->left;
                }
                else
                {
                    if (current->right == null)
                    {
                        current->right = node;
                        break;
                    }
                    current = current->right;
                }
            }
        }
    }

    public void Print()
    {
        if (root == null)
        {
            Console.WriteLine("Дерево пустое");
            return;
        }

        int treeHeight = GetHeight(root);
        int targetLevel = treeHeight - 1;

        IntPtr[] nodePointers = new IntPtr[100];
        int[] levels = new int[100];
        int queueStart = 0;
        int queueEnd = 0;
        
        nodePointers[queueEnd] = new IntPtr(root);
        levels[queueEnd] = 0;
        queueEnd++;
        
        var lastLevelNodes = new List<string>();

        while (queueStart < queueEnd)
        {
            StudentNode* node = (StudentNode*)nodePointers[queueStart];
            int level = levels[queueStart];
            queueStart++;
            
            if (level == targetLevel)
            {
                lastLevelNodes.Add($"id: {node->id}, Имя: {node->GetName()}\n");
            }

            if (node->left != null)
            {
                nodePointers[queueEnd] = new IntPtr(node->left);
                levels[queueEnd] = level + 1;
                queueEnd++;
            }
            
            if (node->right != null)
            {
                nodePointers[queueEnd] = new IntPtr(node->right);
                levels[queueEnd] = level + 1;
                queueEnd++;
            }
        }

        Console.WriteLine($"Последний уровень ({targetLevel}):");
        Console.WriteLine(string.Join(" ", lastLevelNodes));
    }

    private int GetHeight(StudentNode* node)
    {
        if (node == null) 
            return 0;
        
        int leftHeight = GetHeight(node->left);
        int rightHeight = GetHeight(node->right);
        
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}

class Program
{
    static unsafe void Main()
    {
        var tree = new StudentTree(10);
        
        tree.Insert(2, "test1");
        tree.Insert(1, "test2");
        tree.Insert(0, "test3");
        tree.Insert(3, "test4");
        tree.Insert(4, "test5");
        tree.Print();
        
        Console.WriteLine("\nНажмите любую клавишу...");
        Console.ReadKey();
    }
}
