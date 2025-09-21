using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    internal class Program
    {
            struct Member
            {
                public int ID;
                public string Name;
                public int Tasks;

                public Member(int id, string name, int tasks)
                {
                    ID = id; Name = name; Tasks = tasks;
                }

                public override string ToString()
                {
                    return $"ID: {ID}, Name: {Name}, Tasks: {Tasks}";
                }
            }

            static void Main(string[] args)
            {
                // Jagged array: 3 groups
                Member[][] groups = new Member[3][];
                groups[0] = new Member[5];
                groups[1] = new Member[3];
                groups[2] = new Member[6];

                // Menu
                int choice;
                do
                {
                    Console.WriteLine("\n=== Company Menu ===");
                    Console.WriteLine("1. Initialize members");
                    Console.WriteLine("2. Print all members");
                    Console.WriteLine("3. Search by ID");
                    Console.WriteLine("4. Member with most tasks");
                    Console.WriteLine("0. Exit");
                    Console.Write("Choice: ");
                    choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Initialize(groups);
                            break;
                        case 2:
                            PrintAll(groups);
                            break;
                        case 3:
                            Console.Write("Enter ID to search: ");
                            int id = int.Parse(Console.ReadLine());
                            SearchByID(groups, id);
                            break;
                        case 4:
                            PrintMaxTasks(groups);
                            break;
                    }
                } while (choice != 0);
            }

            static void Initialize(Member[][] groups)
            {
                Random rand = new Random();
                for (int i = 0; i < groups.Length; i++)
                {
                    for (int j = 0; j < groups[i].Length; j++)
                    {
                        int id = i * 100 + j + 1;
                        string name = $"Member_{i}{j}";
                        int tasks = rand.Next(1, 50);
                        groups[i][j] = new Member(id, name, tasks);
                    }
                }
                Console.WriteLine("Members initialized!");
            }

            static void PrintAll(Member[][] groups)
            {
                for (int i = 0; i < groups.Length; i++)
                {
                    Console.WriteLine($"-- Group {i + 1} --");
                    foreach (var m in groups[i])
                    {
                        Console.WriteLine(m);
                    }
                }
            }

            static void SearchByID(Member[][] groups, int id)
            {
                foreach (var group in groups)
                {
                    foreach (var m in group)
                    {
                        if (m.ID == id)
                        {
                            Console.WriteLine("Found: " + m);
                            return;
                        }
                    }
                }
                Console.WriteLine("ID not found.");
            }

            static void PrintMaxTasks(Member[][] groups)
            {
                Member maxMember = groups[0][0];
                foreach (var group in groups)
                {
                    foreach (var m in group)
                    {
                        if (m.Tasks > maxMember.Tasks) maxMember = m;
                    }
                }
                Console.WriteLine("Member with most tasks: " + maxMember);
            }
        }
    }