using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
        internal class DoubleLinked
        {
            public class Node<T>
            {
                public T Data { get; set; }
                public Node<T> Next { get; set; }
                public Node<T> Prev { get; set; }

                public Node(T data)
                {
                    Data = data;
                    Next = null;
                    Prev = null;
                }
            }

            public class DoublyLinkedList<T>
            {
                private Node<T> head;
                private Node<T> tail;

                public void InsertAtHead(T data)
                {
                    Node<T> newNode = new Node<T>(data);
                    if (head == null)
                    {
                        head = newNode;
                        tail = newNode;
                    }
                    else
                    {
                        newNode.Next = head;
                        head.Prev = newNode;
                        head = newNode;
                    }
                }

                public void InsertAtTail(T data)
                {
                    Node<T> newNode = new Node<T>(data);
                    if (tail == null)
                    {
                        head = newNode;
                        tail = newNode;
                    }
                    else
                    {
                        newNode.Prev = tail;
                        tail.Next = newNode;
                        tail = newNode;
                    }
                }

                public void InsertAtPosition(T data, int position)
                {
                    Node<T> newNode = new Node<T>(data);
                    if (position == 0)
                    {
                        InsertAtHead(data);
                    }
                    else
                    {
                        Node<T> current = head;
                        for (int i = 0; i < position - 1 && current != null; i++)
                        {
                            current = current.Next;
                        }

                        if (current != null)
                        {
                            newNode.Next = current.Next;
                            newNode.Prev = current;
                            if (current.Next != null)
                            {
                                current.Next.Prev = newNode;
                            }
                            current.Next = newNode;
                        }
                        else
                        {
                            // Handle case where position is greater than the number of elements
                            // This could be an exception or another handling mechanism
                            Console.WriteLine("Invalid position");
                        }
                    }
                }

                public void DeleteNode(T data)
                {
                    Node<T> current = head;
                    while (current != null)
                    {
                        if (EqualityComparer<T>.Default.Equals(current.Data, data))
                        {
                            if (current.Prev != null)
                            {
                                current.Prev.Next = current.Next;
                            }
                            else
                            {
                                // If the node to be deleted is the head, update the head
                                head = current.Next;
                            }

                            if (current.Next != null)
                            {
                                current.Next.Prev = current.Prev;
                            }
                            else
                            {
                                // If the node to be deleted is the tail, update the tail
                                tail = current.Prev;
                            }

                            // Optional: Free up resources by setting current's references to null
                            current.Prev = null;
                            current.Next = null;

                            // Exit the loop after deleting the node
                            break;
                        }

                        current = current.Next;
                    }
                }

                public Node<T> Find(T data)
                {
                    Node<T> current = head;
                    while (current != null)
                    {
                        if (EqualityComparer<T>.Default.Equals(current.Data, data))
                        {
                            return current;
                        }
                        current = current.Next;
                    }
                    return null;
                }

                public void Traverse()
                {
                    Node<T> current = head;
                    while (current != null)
                    {
                        Console.Write($"{current.Data} <-> ");
                        current = current.Next;
                    }
                    Console.WriteLine("null");
                }
            }
        }
    }
/*class program
{
    static void Main()
    {
        DoublyLinkedList<int> myList = new DoublyLinkedList<int>();

        myList.InsertAtTail(1);
        myList.InsertAtTail(2);
        myList.InsertAtTail(3);
        myList.InsertAtTail(4);
        myList.InsertAtTail(5);

        Console.WriteLine("Before Deletion:");
        myList.Traverse();

        // Assuming you want to delete the node with data 3
        myList.DeleteNode(3);

        Console.WriteLine("After Deletion:");
        myList.Traverse();

        // Example of finding a node
        Node<int> nodeToFind = myList.Find(2);
        Console.WriteLine($"Node found: {nodeToFind.Data}");

        // Example of inserting at a specific position
        myList.InsertAtPosition(10, 2);
        Console.WriteLine("After Insertion at Position 2:");
        myList.Traverse();
    }
}*/
