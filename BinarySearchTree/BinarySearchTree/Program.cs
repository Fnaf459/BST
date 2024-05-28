using System;

class BinarySearchTree
{
    class Node
    {
        public int Data;
        public Node Left;
        public Node Right;

        public Node(int data)
        {
            Data = data;
            Left = null;
            Right = null;
        }
    }

    private Node root;

    public BinarySearchTree()
    {
        root = null;
    }

    public void Insert(int data)
    {
        root = InsertRec(root, data);
    }

    private Node InsertRec(Node root, int data)
    {
        if (root == null)
        {
            root = new Node(data);
            return root;
        }

        if (data < root.Data)
            root.Left = InsertRec(root.Left, data);
        else if (data > root.Data)
            root.Right = InsertRec(root.Right, data);

        return root;
    }

    public void Delete(int data)
    {
        root = DeleteRec(root, data);
    }

    private Node DeleteRec(Node root, int data)
    {
        if (root == null)
            return root;

        if (data < root.Data)
            root.Left = DeleteRec(root.Left, data);
        else if (data > root.Data)
            root.Right = DeleteRec(root.Right, data);
        else
        {
            if (root.Left == null)
                return root.Right;
            else if (root.Right == null)
                return root.Left;

            root.Data = MinValue(root.Right);
            root.Right = DeleteRec(root.Right, root.Data);
        }

        return root;
    }

    private int MinValue(Node root)
    {
        int minValue = root.Data;
        while (root.Left != null)
        {
            minValue = root.Left.Data;
            root = root.Left;
        }
        return minValue;
    }

    public void Visualize()
    {
        VisualizeRec(root, "");
    }

    private void VisualizeRec(Node root, string prefix)
    {
        if (root != null)
        {
            Console.WriteLine(prefix + "└── " + root.Data);
            VisualizeRec(root.Left, prefix + "    │");
            VisualizeRec(root.Right, prefix + "    ");
        }
    }

    public void Display()
    {
        Console.WriteLine("Дерево:");
        Visualize();
    }

    static void Main()
    {
        BinarySearchTree bst = new BinarySearchTree();

        bst.Insert(50);
        bst.Insert(30);
        bst.Insert(20);
        bst.Insert(40);
        bst.Insert(70);
        bst.Insert(60);
        bst.Insert(80);

        bst.Display();

        bst.Delete(20);
        Console.WriteLine("\nДерево после удаления 20:");
        bst.Display();

        bst.Delete(30);
        Console.WriteLine("\nДерево после удаления 30:");
        bst.Display();

        bst.Delete(50);
        Console.WriteLine("\nДерево после удаления 50:");
        bst.Display();
    }
}
