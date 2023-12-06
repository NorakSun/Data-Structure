using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Testing
{
    
    public class UnitTest1
    {
        public class Student : IComparable<Student>
        {
            public string Name { get; set; }
            public int Id { get; set; }


            // You need to implement the IComparable interface to use Bubble Sort
            public int CompareTo(Student other)
            {
                return string.Compare(this.Name, other.Name);
            }

        }

        [TestClass]
        public class SortingAndSearchingTests
        {
            public int LinearSearch(Student[] students, Student target)
            {
                for (int i = 0; i < students.Length; i++)
                {
                    if (students[i].Equals(target))
                    {
                        return i;
                    }
                }
                return -1;
            }

            public int BinarySearch(Student[] students, Student target)
            {
                int left = 0, right = students.Length - 1;

                while (left <= right)
                {
                    int middle = (left + right) / 2;
                    int comparisonResult = string.Compare(students[middle].Name, target.Name);

                    if (comparisonResult == 0)
                    {
                        return middle;
                    }
                    else if (comparisonResult < 0)
                    {
                        left = middle + 1;
                    }
                    else
                    {
                        right = middle - 1;
                    }
                }

                return -1;
            }

            public void BubbleSort(Student[] students)
            {
                int n = students.Length;
                bool swapped;
                do
                {
                    swapped = false;
                    for (int i = 1; i < n; i++)
                    {
                        if (students[i - 1].CompareTo(students[i]) > 0) // Fix: Use > instead of <
                        {
                            // Swap elements
                            Student temp = students[i - 1];
                            students[i - 1] = students[i];
                            students[i] = temp;
                            swapped = true;
                        }
                    }
                    n--;
                } while (swapped);
            }


            public Student[] CreateTestStudents()
            {
                return new[]
                {
                    new Student { Id = 1, Name = "Alice" },
                    new Student { Id = 2, Name = "Bob" },
                    new Student { Id = 3, Name = "Charlie" },
                    new Student { Id = 4, Name = "David" },
                    new Student { Id = 5, Name = "Eva" },
                    new Student { Id = 6, Name = "Frank" },
                    new Student { Id = 7, Name = "Grace" },
                    new Student { Id = 8, Name = "Hank" },
                    new Student { Id = 9, Name = "Ivy" },
                    new Student { Id = 10, Name = "Jack" }
                };
            }

            [TestMethod]
            public void TestLinearSearch()
            {
                // Arrange
                var students = CreateTestStudents();
                var targetStudent = students[3]; // Assume the target student is at index 3

                try
                {
                    // Act
                    var resultIndex = LinearSearch(students, targetStudent);

                    // Assert
                    Assert.AreEqual(3, resultIndex);
                    Console.WriteLine("Test Passed: The result index is correct.");
                    
                }
                catch (Exception ex)
                {
                    Assert.Fail($"Exception thrown: {ex.Message}");
                   
                }
            }

            [TestMethod]
            public void TestBinarySearch()
            {
                // Arrange
                var students = CreateTestStudents();
                var targetStudent = students[3]; // Assume the target student is at index 3

                try
                {
                    // Act
                    Array.Sort(students, (s1, s2) => s1.Name.CompareTo(s2.Name));
                    var resultIndex = BinarySearch(students, targetStudent);

                    // Assert
                    Assert.AreEqual(3, resultIndex);
                    Console.WriteLine("Test Passed: The result index is correct.");
                }
                catch (Exception ex)
                {
                    Assert.Fail($"Exception thrown: {ex.Message}");
                }
            }

            [TestMethod]
            public void TestBubbleSort()
            {
                // Arrange
                var students = CreateTestStudents();
                var ascendingOrderStudents = students.OrderByDescending(student => student.Id).ToArray();

                try
                {
                    // Act
                    BubbleSort(ascendingOrderStudents);

                    // Assert
                    var sortedStudents = new List<Student>(ascendingOrderStudents);
                    sortedStudents.Sort(); 
                    CollectionAssert.AreEqual(sortedStudents, ascendingOrderStudents);
                }
                catch (Exception ex)
                {
                    Assert.Fail($"Exception thrown: {ex.Message}");
                }
                
            }
        }

        // Singly Linked List Node
        public class SinglyListNode
        {
            public Student Data { get; set; }
            public SinglyListNode Next { get; set; }
        }

        // Singly Linked List
        public class SinglyLinkedList
        {
            public SinglyListNode Head { get; set; }

            public void AddToHead(Student student)
            {
                var newNode = new SinglyListNode { Data = student, Next = Head };
                Head = newNode;
            }

            public void AddToTail(Student student)
            {
                var newNode = new SinglyListNode { Data = student };

                if (Head == null)
                {
                    Head = newNode;
                    return;
                }

                var current = Head;
                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = newNode;
            }

            public bool Contains(Student student)
            {
                var current = Head;

                while (current != null)
                {
                    if (current.Data.Equals(student))
                    {
                        return true;
                    }

                    current = current.Next;
                }

                return false;
            }

            public void RemoveFromHead()
            {
                if (Head != null)
                {
                    Head = Head.Next;
                }
            }

            public void RemoveFromTail()
            {
                if (Head == null || Head.Next == null)
                {
                    Head = null;
                    return;
                }

                var current = Head;
                while (current.Next.Next != null)
                {
                    current = current.Next;
                }

                current.Next = null;
            }
        }

        [TestClass]
        public class SinglyLinkedListTests
        {
            [TestMethod]
            public void TestSinglyLinkedAddToHead()
            {
                // Arrange
                var list = new SinglyLinkedList();
                var student = new Student { Id = 1, Name = "Alice" };

                // Act
                list.AddToHead(student);

                // Assert
                Assert.AreEqual(student, list.Head.Data , "AddToHead should set the added student as the head of the list.");
                Console.WriteLine("TestSinglyLinkedAddToHead passed successfully.");
            }

            [TestMethod]
            public void TestSinglyLinkedAddToTail()
            {
                // Arrange
                var list = new SinglyLinkedList();
                var initialHead = new Student { Id = 0, Name = "Initial Head" };
                list.AddToHead(initialHead);  // Add an initial head for testing purposes
                var student = new Student { Id = 1, Name = "Alice" };

                // Act
                list.AddToTail(student);

                // Assert
                Assert.AreEqual(initialHead, list.Head.Data, "The head should remain the same.");
                Assert.AreEqual(student, list.Head.Next.Data, "The student should be added to the tail.");
                Console.WriteLine("TestSinglyLinkedAddToTail passed successfully.");
            }


            [TestMethod]
            public void TestSinglyLinkedContains()
            {
                // Arrange
                var list = new SinglyLinkedList();
                var student = new Student { Id = 2, Name = "Bob" };
                list.AddToHead(student);

                // Act
                var differentStudent = new Student {Id = 2, Name = "Alice" };
                var containsStudent = list.Contains(student);

                // Assert
                Assert.IsTrue(containsStudent, "Contains should return true for a student that is in the list.");
                Console.WriteLine("TestSinglyLinkedContains passed successfully.");
            }

            [TestMethod]
            public void TestSinglyLinkedRemoveFromHead()
            {
                // Arrange
                var list = new SinglyLinkedList();
                var student = new Student { Id = 1, Name = "Alice" };
                list.AddToHead(student);

                // Act
                list.RemoveFromHead();

                // Assert
                Assert.IsNull(list.Head, "RemoveFromHead should set the head to null when the list is empty.");
                Console.WriteLine("TestSinglyLinkedRemoveFromHead passed successfully.");
            }

            [TestMethod]
            public void TestSinglyLinkedRemoveFromTail()
            {
                // Arrange
                var list = new SinglyLinkedList();
                var student = new Student { Id = 1, Name = "Alice" };
                list.AddToHead(student);

                // Act
                list.RemoveFromTail();

                // Assert
                Assert.IsNull(list.Head, "RemoveFromTail should set the head to null when the list is empty.");
                Console.WriteLine("TestSinglyLinkedRemoveFromTail passed successfully.");
            }
        }

        // Doubly Linked List Node
        public class DoublyListNode
        {
            public Student Data { get; set; }
            public DoublyListNode Next { get; set; }
            public DoublyListNode Previous { get; set; }
        }

        // Doubly Linked List
        public class DoublyLinkedList
        {
            public DoublyListNode Head { get; set; }
            public DoublyListNode Tail { get; set; }

            public void AddToHead(Student student)
            {
                var newNode = new DoublyListNode { Data = student, Next = Head };
                if (Head != null)
                    Head.Previous = newNode;
                Head = newNode;

                if (Tail == null)
                    Tail = Head;
            }

            public void AddToTail(Student student)
            {
                var newNode = new DoublyListNode { Data = student, Previous = Tail };
                if (Tail != null)
                    Tail.Next = newNode;
                Tail = newNode;

                if (Head == null)
                    Head = Tail;
            }

            public bool Contains(Student student)
            {
                var current = Head;

                while (current != null)
                {
                    if (current.Data.Equals(student))
                    {
                        return true;
                    }

                    current = current.Next;
                }

                return false;
            }

            public void RemoveFromHead()
            {
                if (Head != null)
                {
                    Head = Head.Next;
                    if (Head != null)
                        Head.Previous = null;
                }

                if (Head == null)
                    Tail = null;
            }

            public void RemoveFromTail()
            {
                if (Tail != null)
                {
                    Tail = Tail.Previous;
                    if (Tail != null)
                        Tail.Next = null;
                }

                if (Tail == null)
                    Head = null;
            }
        }

            [TestClass]
            public class DoublyLinkedListTests
            {
                [TestMethod]
                public void TestDoublyAddToHead()
                {
                    // Arrange
                    var list = new DoublyLinkedList();
                    var student = new Student { Id = 1, Name = "Alice" };

                    // Act
                    list.AddToHead(student);

                    // Assert
                    Assert.AreEqual(student, list.Head.Data, "Head should be the added student");
                    Assert.AreEqual(student, list.Tail.Data, "Tail should be the added student");
                    Console.WriteLine("TestDoublyAddToHead passed successfully.");
            }

            [TestMethod]
                public void TestDoublyAddToTail()
                {
                    // Arrange
                    var list = new DoublyLinkedList();
                    var student = new Student { Id = 1, Name = "Alice" };

                    // Act
                    list.AddToTail(student);

                    // Assert
                    Assert.AreEqual(student, list.Head.Data, "Head should be the added student");
                    Assert.AreEqual(student, list.Tail.Data, "Tail should be the added student");
                    Console.WriteLine("TestDoublyAddToTail passed successfully.");
            }

                [TestMethod]
                public void TestDoublyContains()
                {
                    // Arrange
                    var list = new DoublyLinkedList();
                    var student = new Student { Id = 1, Name = "Alice" };
                    list.AddToHead(student);

                    // Act
                    var containsStudent = list.Contains(student);

                    // Assert
                    Assert.IsTrue(containsStudent, "The list should contain the added student");
                    Console.WriteLine("TestDoublyContains passed successfully.");
            }

                [TestMethod]
                public void TestDoublyRemoveFromHead()
                {
                    // Arrange
                    var list = new DoublyLinkedList();
                    var student = new Student { Id = 1, Name = "Alice" };
                    list.AddToHead(student);

                    // Act
                    list.RemoveFromHead();

                    // Assert
                    Assert.IsNull(list.Head, "Head should be null after removal");
                    Assert.IsNull(list.Tail, "Tail should be null after removal");
                    Console.WriteLine("TestDoublyRemoveFromHead passed successfully.");
            }

                [TestMethod]
                public void TestDoublyRemoveFromTail()
                {
                    // Arrange
                    var list = new DoublyLinkedList();
                    var student = new Student { Id = 1, Name = "Alice" };
                    list.AddToHead(student);

                    // Act
                    list.RemoveFromTail();

                    // Assert
                    Assert.IsNull(list.Head, "Head should be null after removal");
                    Assert.IsNull(list.Tail, "Tail should be null after removal");
                    Console.WriteLine("TestDoublyRemoveFromTail passed successfully.");
            }
            }


            // BTree Node
            public class BTreeNode
        {
            public Student Data { get; set; }
            public BTreeNode Left { get; set; }
            public BTreeNode Right { get; set; }

            public BTreeNode(Student student)
            {
                Data = student;
                Left = null;
                Right = null;
            }
        }

        // BTree
        public class BTree
        {
            public BTreeNode Root { get; set; }

            public void Insert(Student student)
            {
                Root = InsertRecursive(Root, student);
            }

            private BTreeNode InsertRecursive(BTreeNode root, Student student)
            {
                if (root == null)
                {
                    return new BTreeNode(student);
                }

                if (student.Id < root.Data.Id)
                {
                    root.Left = InsertRecursive(root.Left, student);
                }
                else if (student.Id > root.Data.Id)
                {
                    root.Right = InsertRecursive(root.Right, student);
                }

                return root;
            }
        }

        [TestClass]
        public class BinaryTreeTests
        {
            [TestMethod]
            public void TestBTreeInsert()
            {
                // Arrange
                var bTree = new BTree();

                // Act
                bTree.Insert(new Student { Name = "Alice", Id = 101 });
                bTree.Insert(new Student { Name = "Bob", Id = 72 });
                bTree.Insert(new Student { Name = "Charlie", Id = 128 });
                bTree.Insert(new Student { Name = "David", Id = 50 });
                bTree.Insert(new Student { Name = "Eva", Id = 90 });

                // Assert
                Assert.IsNotNull(bTree.Root, "Root should not be null");
                Assert.AreEqual("Alice", bTree.Root.Data.Name, "Root data should be Alice");
                Assert.IsNotNull(bTree.Root.Left, "Root left child should not be null");
                Assert.AreEqual("Bob", bTree.Root.Left.Data.Name, "Root left child data should be Bob");
                Assert.IsNotNull(bTree.Root.Right, "Root right child should not be null");
                Assert.AreEqual("Charlie", bTree.Root.Right.Data.Name, "Root right child data should be Charlie");
                Console.WriteLine("TestBTreeInsert passed successfully.");
            }

        }

    }

}
