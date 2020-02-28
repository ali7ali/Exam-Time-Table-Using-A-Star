using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAlgoProject
{
    class Program
    {
        static int n_Exam_Days;
        static string[,] table;

        static List<Day> days;
        static List<Duration_of_Day> durations;
        static List<Course> courses;
        static Queue<Exam_Hall> exam_Halls;

        static List<Exam_Hall> exam_hs;
        static List<Exam_Hall> close;
        static List<State> states;
        static List<Hall_Cost> hall_Costs;

        static List<Proctor_in_Hall> proctor_In_Halls;
        static List<Head_of_Hall> head_Of_Halls;

        static List<F_State> f_States;
        static List<P_Cost> p_Costs;
        static List<P_Cost> s_p_Costs;
        static List<H_Cost> h_Costs;

        static List<Proctor_in_Hall> closed_proctor;
        static List<Proctor_in_Hall> closed_secret;
        static List<Head_of_Hall> closed_head;


        public static void initialize()
        {
            //Cources
            courses = new List<Course>();
            courses.Add(new Course("Java", 30));
            courses.Add(new Course("Finance", 55));
            courses.Add(new Course("Calculus", 90));
            courses.Add(new Course("Physics", 100));
            courses.Add(new Course("Arabic", 110));
            courses.Add(new Course("Programming", 120));
            courses.Add(new Course("Networks", 135));
            courses.Add(new Course("Algo1", 290));
            courses.Add(new Course("Probability", 77));
            courses.Add(new Course("Math", 45));
            courses.Add(new Course("Web", 112));
            courses.Add(new Course("Algo2", 225));
            courses.Add(new Course("SmartAlgo", 10));
            courses.Add(new Course("Project1", 250));
            courses.Add(new Course("Prolog", 214));
            courses.Add(new Course("Automat", 140));
            courses.Add(new Course("Gebra", 188));
            courses.Add(new Course("Multimedia", 350));
            courses.Add(new Course("Engineering", 170));
            courses.Add(new Course("Graduation", 175));
            //Exam Hall
            exam_Halls = new Queue<Exam_Hall>();
            exam_Halls.Enqueue(new Exam_Hall("M1", 50, 2, 0));
            exam_Halls.Enqueue(new Exam_Hall("M2", 50, 2, 0));
            exam_Halls.Enqueue(new Exam_Hall("M3", 50, 2, 0));
            exam_Halls.Enqueue(new Exam_Hall("M12", 30, 1, 1));
            exam_Halls.Enqueue(new Exam_Hall("M14", 30, 1, 1));
            exam_Halls.Enqueue(new Exam_Hall("M16", 30, 1, 1));
            exam_Halls.Enqueue(new Exam_Hall("M21", 50, 2, 2));
            exam_Halls.Enqueue(new Exam_Hall("M23", 50, 2, 2));
            exam_Halls.Enqueue(new Exam_Hall("M25", 50, 2, 2));
            exam_Halls.Enqueue(new Exam_Hall("M27", 70, 4, 2));

            exam_hs = new List<Exam_Hall>();
            exam_hs = exam_Halls.ToList();

            int n = int.Parse(n_Exam_Days.ToString());
            table = new string[n * 4 + 1, 6];
            var values = Enum.GetNames(typeof(Days));
            days = new List<Day>();
            durations = new List<Duration_of_Day>();
            while (n > 0)
            {
                foreach (var v in values)
                {
                    Console.WriteLine(v);
                    //Exam Days
                    days.Add(new Day((Days)(Enum.Parse(typeof(Days), v))));
                    for (int i = 0; i < 3; i++)
                    {
                        //Exam Durations
                        durations.Add(new Duration_of_Day((Duration)i + 1));
                    }

                    n--;
                    if (n == 0)
                    {
                        break;
                    }
                }
            }
            Console.WriteLine("number of days is: " + days.Count);
            Console.WriteLine("number of durations is: " + durations.Count);

            states = new List<State>();
            hall_Costs = new List<Hall_Cost>();
            // Exam Proctors
            // i * 3 + 1 if we optain the day from user input
            proctor_In_Halls = new List<Proctor_in_Hall>();
            head_Of_Halls = new List<Head_of_Hall>();

            Head_of_Hall proctor1 = new Head_of_Hall("A", "d", Title.Dr, 1, 7);
            proctor1.Add_Available(days[0], new List<Duration_of_Day> { durations[0], durations[1] });
            proctor1.Add_Available(days[1], new List<Duration_of_Day> { durations[0], durations[1], durations[3] });
            proctor1.Add_Available(days[3], new List<Duration_of_Day> { durations[0], durations[1] });
            proctor1.Add_Available(days[4], new List<Duration_of_Day> { durations[0], durations[1], durations[3] });


            Head_of_Hall proctor2 = new Head_of_Hall("B", "d", Title.Dr, 2, 7);
            proctor2.Add_Available(days[0], new List<Duration_of_Day> { durations[0] });
            proctor2.Add_Available(days[1], new List<Duration_of_Day> { durations[0] });
            proctor2.Add_Available(days[2], new List<Duration_of_Day> { durations[0] });
            proctor2.Add_Available(days[3], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor2.Add_Available(days[4], new List<Duration_of_Day> { durations[1], durations[3] });

            Head_of_Hall proctor3 = new Head_of_Hall("C", "d", Title.Dr, 3, 7);
            proctor3.Add_Available(days[0], new List<Duration_of_Day> { durations[1] });
            proctor3.Add_Available(days[1], new List<Duration_of_Day> { durations[0] });
            proctor3.Add_Available(days[2], new List<Duration_of_Day> { durations[3] });
            proctor3.Add_Available(days[3], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor3.Add_Available(days[4], new List<Duration_of_Day> { durations[1], durations[3] });

            Head_of_Hall proctor4 = new Head_of_Hall("D", "d", Title.Dr, 4, 7);
            proctor4.Add_Available(days[0], new List<Duration_of_Day> { durations[1] });
            proctor4.Add_Available(days[1], new List<Duration_of_Day> { durations[0] });
            proctor4.Add_Available(days[2], new List<Duration_of_Day> { durations[3] });
            proctor4.Add_Available(days[3], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor4.Add_Available(days[4], new List<Duration_of_Day> { durations[1], durations[3] });

            Head_of_Hall proctor5 = new Head_of_Hall("E", "d", Title.Dr, 5, 7);
            proctor5.Add_Available(days[0], new List<Duration_of_Day> { durations[1] });
            proctor5.Add_Available(days[1], new List<Duration_of_Day> { durations[0] });
            proctor5.Add_Available(days[2], new List<Duration_of_Day> { durations[3] });
            proctor5.Add_Available(days[3], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor5.Add_Available(days[4], new List<Duration_of_Day> { durations[1], durations[3] });

            Head_of_Hall proctor6 = new Head_of_Hall("F", "d", Title.Dr, 6, 7);
            proctor6.Add_Available(days[0], new List<Duration_of_Day> { durations[1] });
            proctor6.Add_Available(days[1], new List<Duration_of_Day> { durations[0] });
            proctor6.Add_Available(days[2], new List<Duration_of_Day> { durations[3] });
            proctor6.Add_Available(days[3], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor6.Add_Available(days[4], new List<Duration_of_Day> { durations[1], durations[3] });

            Head_of_Hall proctor7 = new Head_of_Hall("G", "d", Title.Dr, 7, 7);
            proctor7.Add_Available(days[0], new List<Duration_of_Day> { durations[1] });
            proctor7.Add_Available(days[1], new List<Duration_of_Day> { durations[0] });
            proctor7.Add_Available(days[2], new List<Duration_of_Day> { durations[3] });
            proctor7.Add_Available(days[3], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor7.Add_Available(days[4], new List<Duration_of_Day> { durations[1], durations[3] });

            Head_of_Hall proctor8 = new Head_of_Hall("H", "d", Title.Dr, 8, 7);
            proctor8.Add_Available(days[0], new List<Duration_of_Day> { durations[1] });
            proctor8.Add_Available(days[1], new List<Duration_of_Day> { durations[0] });
            proctor8.Add_Available(days[2], new List<Duration_of_Day> { durations[3] });
            proctor8.Add_Available(days[3], new List<Duration_of_Day> { durations[1], durations[3] });
            proctor8.Add_Available(days[4], new List<Duration_of_Day> { durations[0], durations[3] });

            Head_of_Hall proctor9 = new Head_of_Hall("I", "d", Title.Dr, 9, 7);
            proctor9.Add_Available(days[0], new List<Duration_of_Day> { durations[1] });
            proctor9.Add_Available(days[1], new List<Duration_of_Day> { durations[0] });
            proctor9.Add_Available(days[2], new List<Duration_of_Day> { durations[3] });
            proctor9.Add_Available(days[3], new List<Duration_of_Day> { durations[0], durations[1] });
            proctor9.Add_Available(days[4], new List<Duration_of_Day> { durations[1], durations[3] });

            Head_of_Hall proctor10 = new Head_of_Hall("J", "d", Title.Dr, 10, 7);
            proctor10.Add_Available(days[0], new List<Duration_of_Day> { durations[1] });
            proctor10.Add_Available(days[1], new List<Duration_of_Day> { durations[0] });
            proctor10.Add_Available(days[2], new List<Duration_of_Day> { durations[1] });
            proctor10.Add_Available(days[3], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor10.Add_Available(days[4], new List<Duration_of_Day> { durations[1], durations[3] });

            Head_of_Hall proctor11 = new Head_of_Hall("K", "d", Title.Dr, 11, 7);
            proctor11.Add_Available(days[0], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor11.Add_Available(days[1], new List<Duration_of_Day> { durations[0], durations[1] });
            proctor11.Add_Available(days[2], new List<Duration_of_Day> { durations[3] });
            proctor11.Add_Available(days[3], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor11.Add_Available(days[4], new List<Duration_of_Day> { durations[1], durations[3] });

            Head_of_Hall proctor12 = new Head_of_Hall("A", "h", Title.Eng, 12, 12);
            proctor12.Add_Available(days[0], new List<Duration_of_Day> { durations[1], durations[3] });
            proctor12.Add_Available(days[1], new List<Duration_of_Day> { durations[0], durations[1] });
            proctor12.Add_Available(days[2], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor12.Add_Available(days[3], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor12.Add_Available(days[4], new List<Duration_of_Day> { durations[1], durations[3] });

            Head_of_Hall proctor13 = new Head_of_Hall("B", "h", Title.Eng, 13, 12);
            proctor13.Add_Available(days[0], new List<Duration_of_Day> { durations[1], durations[3] });
            proctor13.Add_Available(days[1], new List<Duration_of_Day> { durations[0], durations[1] });
            proctor13.Add_Available(days[2], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor13.Add_Available(days[3], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor13.Add_Available(days[4], new List<Duration_of_Day> { durations[1], durations[3] });

            Head_of_Hall proctor14 = new Head_of_Hall("C", "h", Title.Eng, 14, 12);
            proctor14.Add_Available(days[0], new List<Duration_of_Day> { durations[1], durations[3] });
            proctor14.Add_Available(days[1], new List<Duration_of_Day> { durations[0], durations[1] });
            proctor14.Add_Available(days[2], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor14.Add_Available(days[3], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor14.Add_Available(days[4], new List<Duration_of_Day> { durations[1], durations[3] });

            Head_of_Hall proctor15 = new Head_of_Hall("D", "h", Title.Eng, 15, 12);
            proctor15.Add_Available(days[0], new List<Duration_of_Day> { durations[1], durations[3] });
            proctor15.Add_Available(days[1], new List<Duration_of_Day> { durations[0], durations[1] });
            proctor15.Add_Available(days[2], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor15.Add_Available(days[3], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor15.Add_Available(days[4], new List<Duration_of_Day> { durations[1], durations[3] });

            Head_of_Hall proctor16 = new Head_of_Hall("E", "h", Title.Eng, 16, 12);
            proctor16.Add_Available(days[0], new List<Duration_of_Day> { durations[1], durations[3] });
            proctor16.Add_Available(days[1], new List<Duration_of_Day> { durations[0], durations[1] });
            proctor16.Add_Available(days[2], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor16.Add_Available(days[3], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor16.Add_Available(days[4], new List<Duration_of_Day> { durations[1], durations[3] });

            Head_of_Hall proctor17 = new Head_of_Hall("F", "h", Title.Eng, 17, 12);
            proctor17.Add_Available(days[0], new List<Duration_of_Day> { durations[1], durations[3] });
            proctor17.Add_Available(days[1], new List<Duration_of_Day> { durations[0], durations[1] });
            proctor17.Add_Available(days[2], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor17.Add_Available(days[3], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor17.Add_Available(days[4], new List<Duration_of_Day> { durations[1], durations[3] });

            Head_of_Hall proctor18 = new Head_of_Hall("G", "h", Title.Eng, 18, 12);
            proctor18.Add_Available(days[0], new List<Duration_of_Day> { durations[1], durations[3] });
            proctor18.Add_Available(days[1], new List<Duration_of_Day> { durations[0], durations[1] });
            proctor18.Add_Available(days[2], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor18.Add_Available(days[3], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor18.Add_Available(days[4], new List<Duration_of_Day> { durations[1], durations[3] });

            Head_of_Hall proctor19 = new Head_of_Hall("H", "h", Title.Eng, 19, 12);
            proctor19.Add_Available(days[0], new List<Duration_of_Day> { durations[1], durations[3] });
            proctor19.Add_Available(days[1], new List<Duration_of_Day> { durations[0], durations[1] });
            proctor19.Add_Available(days[2], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor19.Add_Available(days[3], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor19.Add_Available(days[4], new List<Duration_of_Day> { durations[1], durations[3] });

            Head_of_Hall proctor20 = new Head_of_Hall("I", "h", Title.Eng, 20, 12);
            proctor20.Add_Available(days[0], new List<Duration_of_Day> { durations[1], durations[3] });
            proctor20.Add_Available(days[1], new List<Duration_of_Day> { durations[0], durations[1] });
            proctor20.Add_Available(days[2], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor20.Add_Available(days[3], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor20.Add_Available(days[4], new List<Duration_of_Day> { durations[1], durations[3] });

            Head_of_Hall proctor21 = new Head_of_Hall("J", "h", Title.Eng, 21, 12);
            proctor21.Add_Available(days[0], new List<Duration_of_Day> { durations[1], durations[3] });
            proctor21.Add_Available(days[1], new List<Duration_of_Day> { durations[0], durations[1] });
            proctor21.Add_Available(days[2], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor21.Add_Available(days[3], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor21.Add_Available(days[4], new List<Duration_of_Day> { durations[1], durations[3] });

            Head_of_Hall proctor22 = new Head_of_Hall("K", "h", Title.Eng, 22, 12);
            proctor22.Add_Available(days[0], new List<Duration_of_Day> { durations[1], durations[3] });
            proctor22.Add_Available(days[1], new List<Duration_of_Day> { durations[0], durations[1] });
            proctor22.Add_Available(days[2], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor22.Add_Available(days[3], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor22.Add_Available(days[4], new List<Duration_of_Day> { durations[1], durations[3] });
            // Add to list
            head_Of_Halls.Add(proctor1);
            head_Of_Halls.Add(proctor2);
            head_Of_Halls.Add(proctor3);
            head_Of_Halls.Add(proctor4);
            head_Of_Halls.Add(proctor5);
            head_Of_Halls.Add(proctor6);
            head_Of_Halls.Add(proctor7);
            head_Of_Halls.Add(proctor8);
            head_Of_Halls.Add(proctor9);
            head_Of_Halls.Add(proctor10);
            head_Of_Halls.Add(proctor11);
            head_Of_Halls.Add(proctor12);
            head_Of_Halls.Add(proctor13);
            head_Of_Halls.Add(proctor14);
            head_Of_Halls.Add(proctor15);
            head_Of_Halls.Add(proctor16);
            head_Of_Halls.Add(proctor17);
            head_Of_Halls.Add(proctor18);
            head_Of_Halls.Add(proctor19);
            head_Of_Halls.Add(proctor20);
            head_Of_Halls.Add(proctor21);
            head_Of_Halls.Add(proctor22);


            Proctor_in_Hall proctor23 = new Proctor_in_Hall("A", "m", Rule.Master, 23, 6);
            proctor23.Add_Available(days[0], new List<Duration_of_Day> { durations[1], durations[3] });
            proctor23.Add_Available(days[1], new List<Duration_of_Day> { durations[0], durations[1] });
            proctor23.Add_Available(days[2], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor23.Add_Available(days[3], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor23.Add_Available(days[4], new List<Duration_of_Day> { durations[1], durations[3] });

            Proctor_in_Hall proctor24 = new Proctor_in_Hall("B", "m", Rule.Master, 24, 6);
            proctor24.Add_Available(days[0], new List<Duration_of_Day> { durations[1], durations[3] });
            proctor24.Add_Available(days[1], new List<Duration_of_Day> { durations[0], durations[1] });
            proctor24.Add_Available(days[2], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor24.Add_Available(days[3], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor24.Add_Available(days[4], new List<Duration_of_Day> { durations[1], durations[3] });

            Proctor_in_Hall proctor25 = new Proctor_in_Hall("C", "m", Rule.Master, 25, 6);
            proctor25.Add_Available(days[0], new List<Duration_of_Day> { durations[1], durations[3] });
            proctor25.Add_Available(days[1], new List<Duration_of_Day> { durations[0], durations[1] });
            proctor25.Add_Available(days[2], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor25.Add_Available(days[3], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor25.Add_Available(days[4], new List<Duration_of_Day> { durations[1], durations[3] });

            Proctor_in_Hall proctor26 = new Proctor_in_Hall("D", "m", Rule.Master, 26, 6);
            proctor26.Add_Available(days[0], new List<Duration_of_Day> { durations[1], durations[3] });
            proctor26.Add_Available(days[1], new List<Duration_of_Day> { durations[0], durations[1] });
            proctor26.Add_Available(days[2], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor26.Add_Available(days[3], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor26.Add_Available(days[4], new List<Duration_of_Day> { durations[1], durations[3] });

            Proctor_in_Hall proctor27 = new Proctor_in_Hall("E", "m", Rule.Master, 27, 6);
            proctor27.Add_Available(days[0], new List<Duration_of_Day> { durations[1], durations[3] });
            proctor27.Add_Available(days[1], new List<Duration_of_Day> { durations[0], durations[1] });
            proctor27.Add_Available(days[2], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor27.Add_Available(days[3], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor27.Add_Available(days[4], new List<Duration_of_Day> { durations[1], durations[3] });

            Proctor_in_Hall proctor28 = new Proctor_in_Hall("F", "m", Rule.Master, 28, 6);
            proctor28.Add_Available(days[0], new List<Duration_of_Day> { durations[1], durations[3] });
            proctor28.Add_Available(days[1], new List<Duration_of_Day> { durations[0], durations[1] });
            proctor28.Add_Available(days[2], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor28.Add_Available(days[3], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor28.Add_Available(days[4], new List<Duration_of_Day> { durations[1], durations[3] });

            Proctor_in_Hall proctor29 = new Proctor_in_Hall("G", "m", Rule.Master, 29, 6);
            proctor29.Add_Available(days[0], new List<Duration_of_Day> { durations[1], durations[3] });
            proctor29.Add_Available(days[1], new List<Duration_of_Day> { durations[0], durations[1] });
            proctor29.Add_Available(days[2], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor29.Add_Available(days[3], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor29.Add_Available(days[4], new List<Duration_of_Day> { durations[1], durations[3] });

            Proctor_in_Hall proctor30 = new Proctor_in_Hall("H", "m", Rule.Master, 30, 6);
            proctor30.Add_Available(days[0], new List<Duration_of_Day> { durations[1], durations[3] });
            proctor30.Add_Available(days[1], new List<Duration_of_Day> { durations[0], durations[1] });
            proctor30.Add_Available(days[2], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor30.Add_Available(days[3], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor30.Add_Available(days[4], new List<Duration_of_Day> { durations[1], durations[3] });

            Proctor_in_Hall proctor31 = new Proctor_in_Hall("I", "m", Rule.Master, 31, 6);
            proctor31.Add_Available(days[0], new List<Duration_of_Day> { durations[1], durations[3] });
            proctor31.Add_Available(days[1], new List<Duration_of_Day> { durations[0], durations[1] });
            proctor31.Add_Available(days[2], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor31.Add_Available(days[3], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor31.Add_Available(days[4], new List<Duration_of_Day> { durations[1], durations[3] });

            Proctor_in_Hall proctor32 = new Proctor_in_Hall("J", "m", Rule.Master, 32, 6);
            proctor32.Add_Available(days[0], new List<Duration_of_Day> { durations[1], durations[3] });
            proctor32.Add_Available(days[1], new List<Duration_of_Day> { durations[0], durations[1] });
            proctor32.Add_Available(days[2], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor32.Add_Available(days[3], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor32.Add_Available(days[4], new List<Duration_of_Day> { durations[1], durations[3] });

            Proctor_in_Hall proctor33 = new Proctor_in_Hall("K", "m", Rule.Master, 33, 6);
            proctor33.Add_Available(days[0], new List<Duration_of_Day> { durations[1], durations[3] });
            proctor33.Add_Available(days[1], new List<Duration_of_Day> { durations[0], durations[1] });
            proctor33.Add_Available(days[2], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor33.Add_Available(days[3], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor33.Add_Available(days[4], new List<Duration_of_Day> { durations[1], durations[3] });

            Proctor_in_Hall proctor34 = new Proctor_in_Hall("L", "m", Rule.Master, 34, 6);
            proctor34.Add_Available(days[0], new List<Duration_of_Day> { durations[1], durations[3] });
            proctor34.Add_Available(days[1], new List<Duration_of_Day> { durations[0], durations[1] });
            proctor34.Add_Available(days[2], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor34.Add_Available(days[3], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor34.Add_Available(days[4], new List<Duration_of_Day> { durations[1], durations[3] });

            Proctor_in_Hall proctor35 = new Proctor_in_Hall("M", "m", Rule.Master, 35, 6);
            proctor35.Add_Available(days[0], new List<Duration_of_Day> { durations[1], durations[3] });
            proctor35.Add_Available(days[1], new List<Duration_of_Day> { durations[0], durations[1] });
            proctor35.Add_Available(days[2], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor35.Add_Available(days[3], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor35.Add_Available(days[4], new List<Duration_of_Day> { durations[1], durations[3] });

            Proctor_in_Hall proctor36 = new Proctor_in_Hall("N", "m", Rule.Master, 36, 6);
            proctor36.Add_Available(days[0], new List<Duration_of_Day> { durations[1], durations[3] });
            proctor36.Add_Available(days[1], new List<Duration_of_Day> { durations[0], durations[1] });
            proctor36.Add_Available(days[2], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor36.Add_Available(days[3], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor36.Add_Available(days[4], new List<Duration_of_Day> { durations[1], durations[3] });

            Proctor_in_Hall proctor37 = new Proctor_in_Hall("O", "m", Rule.Master, 37, 6);
            proctor37.Add_Available(days[0], new List<Duration_of_Day> { durations[1], durations[3] });
            proctor37.Add_Available(days[1], new List<Duration_of_Day> { durations[0], durations[1] });
            proctor37.Add_Available(days[2], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor37.Add_Available(days[3], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor37.Add_Available(days[4], new List<Duration_of_Day> { durations[1], durations[3] });

            Proctor_in_Hall proctor38 = new Proctor_in_Hall("P", "m", Rule.Master, 38, 6);
            proctor38.Add_Available(days[0], new List<Duration_of_Day> { durations[1], durations[3] });
            proctor38.Add_Available(days[1], new List<Duration_of_Day> { durations[0], durations[1] });
            proctor38.Add_Available(days[2], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor38.Add_Available(days[3], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor38.Add_Available(days[4], new List<Duration_of_Day> { durations[1], durations[3] });


            Proctor_in_Hall proctor39 = new Proctor_in_Hall("A", "e", Rule.Emp, 39, 20);
            proctor39.Add_Available(days[0], new List<Duration_of_Day> { durations[1], durations[3] });
            proctor39.Add_Available(days[1], new List<Duration_of_Day> { durations[0], durations[1] });
            proctor39.Add_Available(days[2], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor39.Add_Available(days[3], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor39.Add_Available(days[4], new List<Duration_of_Day> { durations[1], durations[3] });

            Proctor_in_Hall proctor40 = new Proctor_in_Hall("B", "e", Rule.Emp, 40, 20);
            proctor40.Add_Available(days[0], new List<Duration_of_Day> { durations[1], durations[3] });
            proctor40.Add_Available(days[1], new List<Duration_of_Day> { durations[0], durations[1] });
            proctor40.Add_Available(days[2], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor40.Add_Available(days[3], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor40.Add_Available(days[4], new List<Duration_of_Day> { durations[1], durations[3] });

            Proctor_in_Hall proctor41 = new Proctor_in_Hall("C", "e", Rule.Emp, 41, 20);
            proctor41.Add_Available(days[0], new List<Duration_of_Day> { durations[1], durations[3] });
            proctor41.Add_Available(days[1], new List<Duration_of_Day> { durations[0], durations[1] });
            proctor41.Add_Available(days[2], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor41.Add_Available(days[3], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor41.Add_Available(days[4], new List<Duration_of_Day> { durations[1], durations[3] });

            Proctor_in_Hall proctor42 = new Proctor_in_Hall("D", "e", Rule.Emp, 42, 20);
            proctor42.Add_Available(days[0], new List<Duration_of_Day> { durations[1], durations[3] });
            proctor42.Add_Available(days[1], new List<Duration_of_Day> { durations[0], durations[1] });
            proctor42.Add_Available(days[2], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor42.Add_Available(days[3], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor42.Add_Available(days[4], new List<Duration_of_Day> { durations[1], durations[3] });

            Proctor_in_Hall proctor43 = new Proctor_in_Hall("E", "e", Rule.Emp, 43, 20);
            proctor43.Add_Available(days[0], new List<Duration_of_Day> { durations[1], durations[3] });
            proctor43.Add_Available(days[1], new List<Duration_of_Day> { durations[0], durations[1] });
            proctor43.Add_Available(days[2], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor43.Add_Available(days[3], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor43.Add_Available(days[4], new List<Duration_of_Day> { durations[1], durations[3] });

            Proctor_in_Hall proctor44 = new Proctor_in_Hall("F", "e", Rule.Emp, 44, 20);
            proctor44.Add_Available(days[0], new List<Duration_of_Day> { durations[1], durations[3] });
            proctor44.Add_Available(days[1], new List<Duration_of_Day> { durations[0], durations[1] });
            proctor44.Add_Available(days[2], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor44.Add_Available(days[3], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor44.Add_Available(days[4], new List<Duration_of_Day> { durations[1], durations[3] });

            Proctor_in_Hall proctor45 = new Proctor_in_Hall("G", "e", Rule.Emp, 45, 20);
            proctor45.Add_Available(days[0], new List<Duration_of_Day> { durations[1], durations[3] });
            proctor45.Add_Available(days[1], new List<Duration_of_Day> { durations[0], durations[1] });
            proctor45.Add_Available(days[2], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor45.Add_Available(days[3], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor45.Add_Available(days[4], new List<Duration_of_Day> { durations[1], durations[3] });

            Proctor_in_Hall proctor46 = new Proctor_in_Hall("H", "e", Rule.Emp, 46, 20);
            proctor46.Add_Available(days[0], new List<Duration_of_Day> { durations[1], durations[3] });
            proctor46.Add_Available(days[1], new List<Duration_of_Day> { durations[0], durations[1] });
            proctor46.Add_Available(days[2], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor46.Add_Available(days[3], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor46.Add_Available(days[4], new List<Duration_of_Day> { durations[1], durations[3] });

            Proctor_in_Hall proctor47 = new Proctor_in_Hall("I", "e", Rule.Emp, 47, 20);
            proctor47.Add_Available(days[0], new List<Duration_of_Day> { durations[1], durations[3] });
            proctor47.Add_Available(days[1], new List<Duration_of_Day> { durations[0], durations[1] });
            proctor47.Add_Available(days[2], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor47.Add_Available(days[3], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor47.Add_Available(days[4], new List<Duration_of_Day> { durations[1], durations[3] });

            Proctor_in_Hall proctor48 = new Proctor_in_Hall("J", "e", Rule.Emp, 48, 20);
            proctor48.Add_Available(days[0], new List<Duration_of_Day> { durations[1], durations[3] });
            proctor48.Add_Available(days[1], new List<Duration_of_Day> { durations[0], durations[1] });
            proctor48.Add_Available(days[2], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor48.Add_Available(days[3], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor48.Add_Available(days[4], new List<Duration_of_Day> { durations[1], durations[3] });

            Proctor_in_Hall proctor49 = new Proctor_in_Hall("K", "e", Rule.Emp, 49, 20);
            proctor49.Add_Available(days[0], new List<Duration_of_Day> { durations[1], durations[3] });
            proctor49.Add_Available(days[1], new List<Duration_of_Day> { durations[0], durations[1] });
            proctor49.Add_Available(days[2], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor49.Add_Available(days[3], new List<Duration_of_Day> { durations[0], durations[3] });
            proctor49.Add_Available(days[4], new List<Duration_of_Day> { durations[1], durations[3] });

            // Add to list
            proctor_In_Halls.Add(proctor23);
            proctor_In_Halls.Add(proctor24);
            proctor_In_Halls.Add(proctor25);
            proctor_In_Halls.Add(proctor26);
            proctor_In_Halls.Add(proctor27);
            proctor_In_Halls.Add(proctor28);
            proctor_In_Halls.Add(proctor29);
            proctor_In_Halls.Add(proctor30);
            proctor_In_Halls.Add(proctor31);
            proctor_In_Halls.Add(proctor32);
            proctor_In_Halls.Add(proctor33);
            proctor_In_Halls.Add(proctor34);
            proctor_In_Halls.Add(proctor35);
            proctor_In_Halls.Add(proctor36);
            proctor_In_Halls.Add(proctor37);
            proctor_In_Halls.Add(proctor38);
            proctor_In_Halls.Add(proctor39);
            proctor_In_Halls.Add(proctor40);
            proctor_In_Halls.Add(proctor41);
            proctor_In_Halls.Add(proctor42);
            proctor_In_Halls.Add(proctor43);
            proctor_In_Halls.Add(proctor44);
            proctor_In_Halls.Add(proctor45);
            proctor_In_Halls.Add(proctor46);
            proctor_In_Halls.Add(proctor47);
            proctor_In_Halls.Add(proctor48);
            proctor_In_Halls.Add(proctor49);



            f_States = new List<F_State>();
            p_Costs = new List<P_Cost>();
            s_p_Costs = new List<P_Cost>();
            h_Costs = new List<H_Cost>();

            closed_proctor = new List<Proctor_in_Hall>();
            closed_secret = new List<Proctor_in_Hall>();
            closed_head = new List<Head_of_Hall>();
        }
        public static Queue<Exam_Hall> clone(Queue<Exam_Hall> x)
        {
            Queue<Exam_Hall> halls = new Queue<Exam_Hall>();
            int c = x.Count;
            for (int i = 0; i < c; i++)
            {
                Exam_Hall _Hall = x.Dequeue();
                halls.Enqueue(_Hall);
                x.Enqueue(_Hall);
            }
            return halls;
        }
        public static void find_soution_Astar()
        {
            foreach (Course course in courses)
            {
                A_Star2(course);
            }
        }
        /*
        public static List<State> A_Star(Course course)
        {
            int count = 0;
         //   int last_added_cost = 999999;
            int previous_Cost = 0;
            int current_Cost = 0;
            int Min_cost = course.number;
            hall_Costs = new List<Hall_Cost>();
            Queue<Exam_Hall> halls = new Queue<Exam_Hall>();
            halls = clone(exam_Halls);

            Dictionary<Course, List<Exam_Hall>> keyValuePairs = new Dictionary<Course, List<Exam_Hall>>();
          //  List<float> vs = new List<float>();
            List<Exam_Hall> close = new List<Exam_Hall>();
            // List<int> heuristic = new List<int>();
            while (Min_cost > 0 && count < course.number)
            {
                Exam_Hall open = halls.Dequeue();

                previous_Cost = Math.Abs(Min_cost - open.Capacity);
                //   heuristic.Add(previous_Cost);
                close.Add(open);
                //  float fff =trimstring( open.Name.ToString());
                //  vs.Add(previous_Cost +fff );
                //  vs.Sort();
                hall_Costs.Add(new Hall_Cost() { HallName = open.Name, HallCost = previous_Cost });
                hall_Costs.Sort();

                // last_added_cost = 99999;

                //  current_Cost = 0;

                foreach (Exam_Hall exam in Children(open))
                {
                    count++;
                    if (previous_Cost == 0)
                    {
                        close.Clear();
                        close.Add(open);
                        halls.Clear();
                        keyValuePairs[course] = close;
                        states.Add(new State(keyValuePairs));
                        return states;
                    }
                    current_Cost = Math.Abs(Min_cost - exam.Capacity);
                    if (current_Cost == 0)
                    {
                        close.Clear();
                        close.Add(exam);
                        keyValuePairs[course] = close;
                        states.Add(new State(keyValuePairs));
                        hall_Costs.Add(new Hall_Cost() { HallName = exam.Name, HallCost = current_Cost });
                        hall_Costs.Sort();
                        return states;
                    }
                    else if (!halls.Contains(exam) && !close.Contains(exam))
                    {
                        halls.Enqueue(exam);
                        hall_Costs.Sort();
                    }
                    else if (halls.Contains(exam) && hall_Costs[0].HallCost > current_Cost)
                    {

                        previous_Cost = hall_Costs[0].HallCost;
                        close.Remove(find_item_index(hall_Costs[0].HallName, close));

                        close.Add(exam);
                        count += exam.Capacity;
                        hall_Costs.Add(new Hall_Cost() { HallName = exam.Name, HallCost = current_Cost });

                        hall_Costs.Sort();
                    }
                    else if (close.Contains(exam) && hall_Costs[0].HallCost > current_Cost)
                    {
                        previous_Cost = hall_Costs[0].HallCost;

                        close.Remove(find_item_index(hall_Costs[0].HallName, close));
                        close.Add(exam);
                        count += exam.Capacity;
                        hall_Costs.Add(new Hall_Cost() { HallName = open.Name, HallCost = current_Cost });
                        hall_Costs.Sort();

                    }

                }
                Min_cost = hall_Costs[0].HallCost;
            }
             keyValuePairs[course] = close;
             states.Add(new State(keyValuePairs));
            hall_Costs.Clear();
            return states;
        }*/
        public static List<State> A_Star(Course course)
        {
            int remaining = 0;
            int starting_Cost = 0;
            int current_Cost = 0;
            int Min_cost = course.number;
            bool succed = false;

            // Dictionary to store and add the states
            Dictionary<Course, List<Exam_Hall>> keyValuePairs = new Dictionary<Course, List<Exam_Hall>>();
            //  List to store the visited Halls
            List<Exam_Hall> close = new List<Exam_Hall>();
            close.Clear();
            // Getting the existing Halls
            Queue<Exam_Hall> halls = new Queue<Exam_Hall>();
            int count = 0;
            while (Min_cost > 0)
            {

                halls = clone(exam_Halls);
                succed = false;


                while (succed != true && halls.Count != 0)
                {
                    // Getting the first Hall
                    Exam_Hall open = halls.Dequeue();

                    starting_Cost = Math.Abs(Min_cost - open.Capacity);
                    // starting cost
                    if (Min_cost >= 70 || starting_Cost >= 70)
                    {
                        starting_Cost = Math.Abs(Min_cost - open.Capacity);
                    }
                    else if (starting_Cost != 0)
                    {
                        starting_Cost = chick_sol(Min_cost);
                        Min_cost = starting_Cost;
                    }

                    //  starting_Cost = chick_sol(starting_Cost);
                    // check if it's enough for the student then add it and break
                    if (starting_Cost == 0)
                    {
                        if (!close.Contains(open))
                            close.Add(open);
                        remaining = 0;
                        Min_cost = 0;
                        succed = true;
                        break;
                    }
                    // Adding the first Hall to the visited list
                    if (!close.Contains(open) && !hall_Costs.Contains(find_hall(open.Name)))
                    {
                        if (Min_cost > 70)
                        {
                            close.Add(open);
                            Min_cost -= open.Capacity;
                            remaining = Min_cost;
                            // Adding the cost for the visited Hall
                            //hall_Costs.Clear();
                        }
                        hall_Costs.Add(new Hall_Cost() { HallName = open.Name, HallCost = starting_Cost });

                    }
                    // Looping over each Exam Hall
                    foreach (Exam_Hall exam in Children(open))
                    {
                        if (!close.Contains(exam))
                        {
                            if (course.number < Hall_capacity(close))
                            {
                                succed = true;
                                Min_cost = 0;
                                remaining = 0;
                                break;
                            }
                            current_Cost = Math.Abs(Min_cost - exam.Capacity);
                            // Calculating the current Hall cost
                            if (current_Cost >= 70 || Min_cost >= 70)
                            {
                                current_Cost = Math.Abs(Min_cost - exam.Capacity);
                            }
                            else if (current_Cost != 0)
                            {
                                current_Cost = chick_sol(Min_cost);
                                Min_cost = current_Cost;
                            }
                            //current_Cost = Math.Abs(Min_cost - exam.Capacity);
                            //current_Cost = chick_sol(current_Cost);
                            // Check if the current Hall enough for the student then add it and break
                            if (current_Cost == 0)
                            {
                                // remove the previous one
                                if (course.number <= 70)
                                    close.Clear();
                                // add the newest
                                if (!close.Contains(exam))
                                    close.Add(exam);

                                hall_Costs.Clear();
                                succed = true;
                                remaining = 0;
                                Min_cost = 0;
                                break;
                            }
                            // if the Hall not existed in the queue or the visited list then add it
                            else if (!halls.Contains(exam) && !close.Contains(exam))
                            {
                                halls.Enqueue(exam);
                            }
                            else if (halls.Contains(exam) && hall_Costs[0].HallCost > current_Cost || (hall_Costs[0].HallCost == current_Cost && count > 7))
                            {
                                // remove the previous one
                                if (count <= 7 && course.number <= 130)
                                    close.Remove(find_item(hall_Costs[0].HallName, close));

                                //  Min_cost -= hall_Costs[0].HallCost;
                                //  hall_Costs.RemoveAt(0);
                                // add the new
                                if (!close.Contains(exam))
                                {
                                    close.Add(exam);
                                    // number of student remains 

                                    if (remaining <= 120)
                                        remaining = Min_cost + hall_Costs[0].HallCost;
                                    else
                                        remaining = Min_cost - exam.Capacity;
                                    hall_Costs.RemoveAt(0);
                                    hall_Costs.Add(new Hall_Cost() { HallName = exam.Name, HallCost = current_Cost });
                                    hall_Costs.Sort();
                                }

                            }
                            else if (close.Contains(exam) && hall_Costs[0].HallCost > current_Cost || (hall_Costs[0].HallCost == current_Cost && count > 7))
                            {
                                // remove the previous one
                                if (count <= 7 && course.number <= 130)
                                    close.Remove(find_item(hall_Costs[0].HallName, close));

                                //  Min_cost -= hall_Costs[0].HallCost;
                                //   
                                // add the new
                                if (!close.Contains(exam))
                                {
                                    close.Add(exam);
                                    // number of student remains 



                                    if (remaining <= 120)
                                        remaining = Min_cost + hall_Costs[0].HallCost;
                                    else
                                        remaining = Min_cost - exam.Capacity;
                                    hall_Costs.RemoveAt(0);
                                    hall_Costs.Add(new Hall_Cost() { HallName = exam.Name, HallCost = current_Cost });
                                    hall_Costs.Sort();
                                }

                            }
                        }
                    }
                    count++;
                    Min_cost = chick_sol(remaining);
                    if (Min_cost == 0 || Min_cost == 30 || Min_cost == 50 || Min_cost == 70)
                    {
                        succed = true;
                    }
                }

                keyValuePairs[course] = close;
                State statee = new State(keyValuePairs);
                if (!states.Contains(statee))
                    states.Add(statee);
            }
            keyValuePairs[course] = close;
            State state = new State(keyValuePairs);
            if (!states.Contains(state))
                states.Add(state);
            hall_Costs.Clear();
            //  
            return states;
        }
        public static List<State> A_Star2(Course course)
        {
            decimal remaining = course.number;
            bool succed = false;
            // Dictionary to store and add the states
            Dictionary<Course, List<Exam_Hall>> keyValuePairs = new Dictionary<Course, List<Exam_Hall>>();
            //  List to store the visited Halls
            List<Exam_Hall> close = new List<Exam_Hall>();
            close.Clear();
            List<Exam_Hall> OPEN = new List<Exam_Hall>();
            OPEN.Clear();
            // Getting the existing Halls
            Queue<Exam_Hall> halls = new Queue<Exam_Hall>();
            halls = clone(exam_Halls);
            OPEN = halls.ToList();

            while (succed != true && remaining > 0)
            {

                Calculate_Costs((int)(remaining), OPEN);
                hall_Costs.Sort();
                // Getting the first Hall
                string name = hall_Costs[0].HallName;

                close.Add(find_item(name, OPEN));

                // number of student remains 
                remaining = hall_Costs[0].HallCost;

                if (remaining <= 0)
                {
                    succed = true;
                    break;
                }
                // Simulating the queue behavior
                Exam_Hall open = find_item(name, OPEN);
                OPEN.Remove(find_item(name, OPEN));

                foreach (Exam_Hall exam in Children(open))
                {
                    // if the Hall not existed in the queue or the visited list then add it
                    if (!OPEN.Contains(exam) && !close.Contains(exam))
                    {
                        OPEN.Add(exam);
                    }
                    else if (OPEN.Contains(exam) && hall_Costs[0].HallCost > Math.Abs(exam.Capacity - course.number))
                    {
                        // remove the previous one
                        close.Remove(find_item(hall_Costs[0].HallName, close));
                        // add the new
                        close.Add(exam);

                        hall_Costs.RemoveAt(0);
                        hall_Costs.Add(new Hall_Cost() { HallName = exam.Name, HallCost = exam.Capacity - course.number });
                        hall_Costs.Sort();
                        // number of student remains 
                        remaining = remaining - hall_Costs[0].HallCost;
                    }
                    else if (close.Contains(exam) && hall_Costs[0].HallCost > Math.Abs(exam.Capacity - course.number))
                    {
                        // remove the previous one
                        close.Remove(find_item(hall_Costs[0].HallName, close));
                        // add the new
                        close.Add(exam);

                        hall_Costs.RemoveAt(0);
                        hall_Costs.Add(new Hall_Cost() { HallName = exam.Name, HallCost = exam.Capacity - course.number });
                        hall_Costs.Sort();
                        // number of student remains 
                        remaining = remaining - hall_Costs[0].HallCost;
                    }
                }

            }
            keyValuePairs[course] = close;
            State state = new State(keyValuePairs);
            if (!states.Contains(state))
                states.Add(state);

            return states;
        }

        private static void Calculate_Costs(int number, List<Exam_Hall> halls)
        {
            number = chick_sol(number);
            hall_Costs.Clear();
            foreach (Exam_Hall hh in halls)
            {
                hall_Costs.Add(new Hall_Cost() { HallName = hh.Name, HallCost = Math.Abs(hh.Capacity - number) });
            }
        }

        private static int Hall_capacity(List<Exam_Hall> halls)
        {
            int capacity = 0;
            foreach (Exam_Hall hh in halls)
            {
                capacity += hh.Capacity;
            }
            return capacity;
        }

        private static int chick_sol(int min_cost)
        {
            if (min_cost == 0)
            {
                return 0;
            }
            else if (min_cost <= 30)
            {
                return 30;
            }
            else if (min_cost <= 50)
            {
                return 50;
            }
            else if (min_cost <= 70)
            {
                return 70;
            }
            return min_cost;
        }

        private static Exam_Hall find_item(string hallName, List<Exam_Hall> close)
        {
            foreach (Exam_Hall hh in close)
            {
                if (hh != null && hh.Name == hallName)
                {
                    return hh;
                }
            }
            return null;
        }
        private static Hall_Cost find_hall(string close)
        {
            foreach (Hall_Cost hh in hall_Costs)
            {
                if (hh.HallName == close)
                {
                    return hh;
                }
            }
            return null;
        }

        private static void Print(List<State> states)
        {
            Console.WriteLine(states.Count);
            foreach (State stat in states)
            {
                foreach (Course kvp in stat.K.Keys)
                {
                    foreach (var listMember in stat.K[kvp])
                    {
                        Console.WriteLine("Key : " + kvp.name + " member :" + listMember.Name);
                    }
                }
            }
            // throw new NotImplementedException();
        }
        private static void FIX(List<State> states)
        {
            var dictionary = states.GroupBy(x => x.K)
                             .ToDictionary(g => g.Key, g => g.ToList());
          
            foreach (State stat in states)
            {
                
                foreach (Course kvp in stat.K.Keys)
                {
                    foreach (var listMember in stat.K[kvp])
                    {
                        Console.WriteLine("Key : " + kvp.name + " member :" + listMember.Name);
                    }
                }
            }
            
            // throw new NotImplementedException();
        }
        private static void Print_Price(List<Hall_Cost> costs)
        {
            Console.WriteLine(costs.Count);
            foreach (Hall_Cost cost in costs)
            {
                Console.WriteLine(cost.ToString());
            }
            // throw new NotImplementedException();
        }
        public static float trimstring(string s)
        {

            var ff = s.Trim(s[0]);
            var sss = float.Parse(ff);
            var ssss = sss * 0.1;
            float fff = (float)ssss;
            return fff;
        }
        public static List<Exam_Hall> Children(Exam_Hall _Hall)
        {
            List<Exam_Hall> children = new List<Exam_Hall>();
            children = exam_hs.ToList();
            children.Remove(_Hall);
            return children;
        }
        public static void Hall_Cost(Exam_Hall exam_Hall)
        {

        }
        public static void A_Star_FinalList(List<State> states)
        {
            List<Course> visited = new List<Course>();
            for (int i = 0; i < days.Count - 1; i++)
            {
                for (int j = 0; j < durations.Count - 1; j++)
                {
                    foreach (State stat in states)
                    {
                        int count = 0;
                        foreach (Course course in stat.K.Keys)
                        {
                            while (count < 3 && j<3 && !visited.Contains(course))
                            {
                                    visited.Add(course);
                                    count++;
                              
                                    foreach (var Hall in stat.K[course])
                                    {
                                        Calculate_P_H_Costs(days[i], durations[j], head_Of_Halls);
                                        Calculate_P_Costs(days[i], durations[j], proctor_In_Halls);

                                        h_Costs.Sort();

                                        closed_head.Add(find_Head(h_Costs[0].ProctorID));

                                        s_p_Costs.Sort();

                                        closed_secret.Add(find_Proctor(s_p_Costs[0].ProctorID));

                                        p_Costs.Sort();

                                        if (Hall.Capacity == 70)
                                        {
                                            List<Proctor_in_Hall> pih = new List<Proctor_in_Hall>();
                                            closed_proctor.Add(find_Proctor(p_Costs[0].ProctorID));
                                            closed_proctor.Add(find_Proctor(p_Costs[1].ProctorID));
                                            closed_proctor.Add(find_Proctor(p_Costs[2].ProctorID));
                                            closed_proctor.Add(find_Proctor(p_Costs[3].ProctorID));
                                            pih.Add(find_Proctor(p_Costs[0].ProctorID));
                                            pih.Add(find_Proctor(p_Costs[1].ProctorID));
                                            pih.Add(find_Proctor(p_Costs[2].ProctorID));
                                            pih.Add(find_Proctor(p_Costs[3].ProctorID));

                                            f_States.Add(new F_State(days[i], durations[j], course, Hall, find_Head(h_Costs[0].ProctorID), find_Proctor(s_p_Costs[0].ProctorID), pih));
                                        }
                                        else if (Hall.Capacity == 50)
                                        {
                                            List<Proctor_in_Hall> pih = new List<Proctor_in_Hall>();
                                            closed_proctor.Add(find_Proctor(p_Costs[0].ProctorID));
                                            closed_proctor.Add(find_Proctor(p_Costs[1].ProctorID));
                                            pih.Add(find_Proctor(p_Costs[0].ProctorID));
                                            pih.Add(find_Proctor(p_Costs[1].ProctorID));

                                            f_States.Add(new F_State(days[i], durations[j], course, Hall, find_Head(h_Costs[0].ProctorID), find_Proctor(s_p_Costs[0].ProctorID), pih));
                                        }
                                        else if (Hall.Capacity == 30)
                                        {
                                            List<Proctor_in_Hall> pih = new List<Proctor_in_Hall>();
                                            closed_proctor.Add(find_Proctor(p_Costs[0].ProctorID));
                                            pih.Add(find_Proctor(p_Costs[0].ProctorID));

                                            f_States.Add(new F_State(days[i], durations[j], course, Hall, find_Head(h_Costs[0].ProctorID), find_Proctor(s_p_Costs[0].ProctorID), pih));
                                        }
                                    j++;
                                }
                                
                            }
                                
                        }
                        if (count == 3)
                        {
                            i++;
                            break;
                        }
                    }
                }
            }
        }



        private static Head_of_Hall find_Head(int head_ID)
        {

            foreach (Head_of_Hall head_Of_Hall in head_Of_Halls)
            {
                if (head_Of_Hall.Id == head_ID)
                {
                    return head_Of_Hall;
                }
            }
            return null;
        }
        private static Proctor_in_Hall find_Proctor(int Proctor_ID)
        {

            foreach (Proctor_in_Hall proctor_In_Hall in proctor_In_Halls)
            {
                if (proctor_In_Hall.Id == Proctor_ID)
                {
                    return proctor_In_Hall;
                }
            }
            return null;
        }

        public static void Calculate_P_H_Costs(Day day, Duration_of_Day duration, List<Head_of_Hall> head_Of_Halls)
        {
            int cost = 0;
            h_Costs.Clear();

            foreach (Head_of_Hall proctor in head_Of_Halls)
            {
                if (proctor.Days.Keys.Contains(day))
                {
                    cost += 10;
                }
                else
                {
                    cost -= 100;
                }
                foreach (Day daay in proctor.days.Keys)
                {
                    foreach (Duration_of_Day duration_ in proctor.Days[daay])
                    {

                        if (duration_ == duration)
                        {
                            cost += 10;
                        }
                    }
                }
                h_Costs.Add(new H_Cost() { ProctorID = proctor.Id, ProctorCost = cost });
            }
        }
        public static void Calculate_P_Costs(Day day, Duration_of_Day duration, List<Proctor_in_Hall> proctor_In_Halls)
        {
            int cost = 0;
            p_Costs.Clear();

            foreach (Proctor_in_Hall proctor in proctor_In_Halls)
            {
                if (proctor.Days.Keys.Contains(day))
                {
                    cost += 10;
                }
                else
                {
                    cost -= 100;
                }
                foreach (Day daay in proctor.days.Keys)
                {
                    foreach (Duration_of_Day duration_ in proctor.Days[daay])
                    {

                        if (duration_ == duration)
                        {
                            cost += 10;
                        }
                    }
                }
                if (proctor.rule == Rule.Master)
                    p_Costs.Add(new P_Cost() { ProctorID = proctor.Id, ProctorCost = cost });
                else if (proctor.rule == Rule.Emp)
                    s_p_Costs.Add(new P_Cost() { ProctorID = proctor.Id, ProctorCost = cost });
            }
        }
        private static void Print_F(List<F_State> states)
        {
            Console.WriteLine(states.Count);
            foreach (F_State stat in states)
            {
                stat.ToString();
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Number of Exam Days:");
            n_Exam_Days = int.Parse(Console.ReadLine());
            initialize();
            find_soution_Astar();
            Print(states);
           // A_Star_FinalList(states);
           // Print_F(f_States);

            Console.ReadKey();


        }


    }
}
