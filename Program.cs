using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace RandomProgram1
{
   class Program
    {
        static void Main(string[] args)
        {
            bool isPathValid = false;
            string studentPath = "";
            string groupPath = "";
            string topicPath = "";

            if (args.Length == 3)
            {
                studentPath = $@"{args[0]}";
                groupPath = $@"{args[1]}";
                topicPath = $@"{args[2]}";
                if (File.Exists(studentPath) && File.Exists(groupPath) && File.Exists(topicPath))
                    isPathValid = true;
            }
            if (isPathValid)
            {
                string[] students = File.ReadAllLines(studentPath);
                string[] groups = File.ReadAllLines(groupPath);
                string[] topics = File.ReadAllLines(topicPath);

                if ((students.Length >= groups.Length) && (topics.Length >= groups.Length))
                {
                    List<string> studentsList = new List<string>();
                    foreach (var est in students)
                    {
                        studentsList.Add(est);
                    }
                    List<string> removableGroupList = new List<string>();
                    List<string> groupList = new List<string>();
                    foreach (var grp in groups)
                    {
                        groupList.Add(grp);
                    }
                    List<string> topicList = new List<string>();
                    foreach (var topic in topics)
                    {
                        topicList.Add(topic);
                    }

                    List<string> ExG = new List<string>();
                    List<string> TxG = new List<string>();
                    var random = new Random();
                    int cantEstxGrupo = 0;
                    int cantTemaxGrp = 0;
                    algoritmo:
                    foreach (var grp in groups)
                    {
                        removableGroupList.Add(grp);
                    }
                    if (removableGroupList.Count() <= studentsList.Count() && studentsList.Count() > 0)
                        cantEstxGrupo = studentsList.Count / removableGroupList.Count;
                    else
                        cantEstxGrupo = removableGroupList.Count / studentsList.Count;
                
                    if (removableGroupList.Count() <= topicList.Count() && topicList.Count() > 0)
                        cantTemaxGrp = topicList.Count / removableGroupList.Count;
                    else
                        cantTemaxGrp = removableGroupList.Count / topicList.Count;

                    while (removableGroupList.Count > 0)
                    {
                        var RandomGroupIndex = random.Next(0, removableGroupList.Count);

                        for (int i = 0; i < cantEstxGrupo; i++)
                        {
                            if(studentsList.Count > 0)
                                if(studentsList.ElementAt(i) != null)
                                {
                                    var RandomEstIndex = random.Next(0, studentsList.Count);
                                    ExG.Add($"{studentsList[RandomEstIndex]} - {removableGroupList[RandomGroupIndex]}");
                                    studentsList.RemoveAt(RandomEstIndex);
                                }
                            
                        }

                        for (int j = 0; j < cantTemaxGrp; j++)
                        {
                            Console.WriteLine("Quedna " + topicList.Count + " temas");
                            if(topicList.Count > 0)
                                if(topicList.ElementAt(j) != null)
                                { 
                                    var RandomTemaIndex = random.Next(0, topicList.Count);
                                    TxG.Add($"{topicList[RandomTemaIndex]} - {removableGroupList[RandomGroupIndex]}");
                                    topicList.RemoveAt(RandomTemaIndex);
                                }   
                   
                        }
                        removableGroupList.RemoveAt(RandomGroupIndex);

                    }
                
                    if (studentsList.Count() > 0 || topicList.Count() > 0)
                        goto algoritmo;

                    //while (studentsList.Count > 0)
                    //{

                    //    var RandomEstIndx = random.Next(0, studentsList.Count);
                    //    var RanfomGroupIndex = random.Next(0, groupList.Count);
                    //    ExG.Add($"{studentsList[RandomEstIndx]} - {groupList[RanfomGroupIndex]}");
                    //    studentsList.RemoveAt(RandomEstIndx);
                    //}
                    //while (topicList.Count > 0)
                    //{
                    //    var RandonTemaIndex = random.Next(0, topicList.Count);
                    //    var RandomGroupIndex = random.Next(0, groupList.Count);
                    //    TxG.Add($"{topicList[RandonTemaIndex]} - {groupList[RandomGroupIndex]}");
                    //    topicList.RemoveAt(RandonTemaIndex);
                    //}

                    foreach (var grp in groupList)
                    {
                        Console.WriteLine($"\nGrupo {grp}:");
                        Console.WriteLine($"Temas del Grupo : Cantidad {TxG.Where(a => a.Contains(grp)).Count()}");
                        foreach (var sel in TxG.Where(a => a.Contains(grp)))
                        {
                            Console.Write($"{sel.Replace($"- {grp}", "")}, ");
                        }
                        Console.WriteLine($"\nEstudiantes del Grupo: Cantidad {ExG.Where(a => a.Contains(grp)).Count()}");
                        foreach (var sel in ExG.Where(a => a.Contains(grp)))
                        {
                            Console.Write($"{sel.Replace($"- {grp}", "")}, ");
                        }
                        Console.WriteLine("" );

                    }
                }
                else
                    Console.WriteLine("La cantidad de grupos debe ser menor que la cantidad de estudiantes y/o temas");

            }
            else
                Console.WriteLine("Existe al menos una ruta que no es valida");
        }
    }
}
