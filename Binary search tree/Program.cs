using System;

public class Node
{
    public int data;
    public Node left, right;

    public Node(int item)
    {
        data = item;
        left = right = null;
    }
}

public class BinarySearchTree
{
    private Node root;

    public BinarySearchTree()
    {
        root = null;
    }

    public void Insert(int key)
    {
        root = InsertRec(root, key);
    }

    private Node InsertRec(Node root, int key)
    {
        if (root == null)
        {
            root = new Node(key);
            return root;
        }

        if (key < root.data)
            root.left = InsertRec(root.left, key);
        else if (key > root.data)
            root.right = InsertRec(root.right, key);

        return root;
    }

    public void Delete(int key)
    {
        root = DeleteRec(root, key);
    }

    private Node DeleteRec(Node root, int key)
    {
        if (root == null)
            return root;

        if (key < root.data)
            root.left = DeleteRec(root.left, key);
        else if (key > root.data)
            root.right = DeleteRec(root.right, key);
        else
        {
            if (root.left == null)
                return root.right;
            else if (root.right == null)
                return root.left;

            root.data = MinValue(root.right);

            root.right = DeleteRec(root.right, root.data);
        }
        return root;
    }

    private int MinValue(Node root)
    {
        int minValue = root.data;
        while (root.left != null)
        {
            minValue = root.left.data;
            root = root.left;
        }
        return minValue;
    }

    public void Display()
    {
        Console.WriteLine("Binary Search Tree:");
        Inorder(root);
        Console.WriteLine();
    }

    private void Inorder(Node root)
    {
        if (root != null)
        {
            Inorder(root.left);
            Console.Write(root.data + " ");
            Inorder(root.right);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        BinarySearchTree bst = new BinarySearchTree();

        // Insertion
        bst.Insert(50);
        bst.Insert(30);
        bst.Insert(20);
        bst.Insert(40);
        bst.Insert(70);
        bst.Insert(60);
        bst.Insert(80);

        // Display
        bst.Display();

        // Deletion
        Console.WriteLine("Deleting 20:");
        bst.Delete(20);
        bst.Display();

        Console.WriteLine("Deleting 30:");
        bst.Delete(30);
        bst.Display();
    }     
}
