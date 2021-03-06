using System;
using System.Collections.Generic;
public class Test
{
    public static void Main()
    {
        int Q = int.Parse(Console.ReadLine());
        Queue<int> courses = new Queue<int>();
        List<Queue<int>> student = new List<Queue<int>>();
        for (int i = 0; i < 4; i++)
        {
            student.Add(new Queue<int>());
        }

        for (int i = 0; i < Q; i++)
        {
            string[] input = Console.ReadLine().Split(' ');
            if (input[0] == "E")
            {
                int course = int.Parse(input[1]);
                int roll = int.Parse(input[2]);

                if (courses.Contains(course))
                {
                    student[course - 1].Enqueue(roll);
                }
                else
                {
                    courses.Enqueue(course);
                    student[course - 1].Enqueue(roll);
                }
            }
            else
            {
                int course = courses.Peek();
                int roll = student[course - 1].Dequeue();
                if (student[course - 1].Count == 0)
                {
                    courses.Dequeue();
                }
                Console.WriteLine(course + " " + roll);
            }
        }
    }
}
