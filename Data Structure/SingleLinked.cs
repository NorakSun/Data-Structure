using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    internal class SingleLinked
    {
        public class Node<T>
        {
            public T Data { get; set; }
            public Node<T> Next { get; set; }

            public Node(T data)
            {
                Data = data;
                Next = null;
            }
        }

        public class SinglyLinkedList<T>
        {
            private Node<T> head;

            public void InsertAtHead(T data)
            {
                Node<T> newNode = new Node<T>(data);
                if (head == null)
                {
                    head = newNode;
                }
                else
                {
                    newNode.Next = head;
                    head = newNode;
                }
            }

            public void InsertAtTail(T data)
            {
                Node<T> newNode = new Node<T>(data);
                if (head == null)
                {
                    head = newNode;
                }
                else
                {
                    Node<T> current = head;
                    while (current.Next != null)
                    {
                        current = current.Next;
                    }
                    current.Next = newNode;
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
                Node<T> prev = null;

                while (current != null)
                {
                    if (EqualityComparer<T>.Default.Equals(current.Data, data))
                    {
                        if (prev != null)
                        {
                            prev.Next = current.Next;
                        }
                        else
                        {
                            // If the node to be deleted is the head, update the head
                            head = current.Next;
                        }

                        // Optional: Free up resources by setting current's reference to null
                        current.Next = null;

                        // Exit the loop after deleting the node
                        break;
                    }

                    prev = current;
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
                    Console.Write($"{current.Data} -> ");
                    current = current.Next;
                }
                Console.WriteLine("null");
            }
        }
    }

 /*   class Program
    {
        static void Main()
        {
            // Create a new singly linked list of integers
            SingleLinked.SinglyLinkedList<int> singlyLinkedList = new SingleLinked.SinglyLinkedList<int>();

            // Insert elements at the head
            singlyLinkedList.InsertAtHead(3);
            singlyLinkedList.InsertAtHead(2);
            singlyLinkedList.InsertAtHead(1);

            // Insert elements at the tail
            singlyLinkedList.InsertAtTail(4);
            singlyLinkedList.InsertAtTail(5);

            // Insert element at a specific position
            singlyLinkedList.InsertAtPosition(10, 2);

            // Delete a node
            singlyLinkedList.DeleteNode(4);

            // Find a node
            SingleLinked.Node<int> foundNode = singlyLinkedList.Find(2);
            if (foundNode != null)
            {
                Console.WriteLine($"Found node with value: {foundNode.Data}");
            }
            else
            {
                Console.WriteLine("Node not found");
            }

            // Traverse and print the linked list
            Console.WriteLine("Linked List:");
            singlyLinkedList.Traverse();

            Console.ReadLine();
        }
    }*/
}
