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

            //Validación de las ruta de archivo
            bool isPathValid = false;
            string studentPath = "";
            string groupPath = "";
            string topicPath = "";
            if (args.Length == 3)
            {
                studentPath = $@"{args[0]}";
                groupPath = $@"{args[1]}";
                topicPath = $@"{args[2]}";
                if  (File.Exists(studentPath) && File.Exists(groupPath) && File.Exists(topicPath))
                    isPathValid = true;
            }
            if (isPathValid)
            {
                //Procede a la lectura de archivos de la ruta y guardar los datos en arreglos
                string[] students = File.ReadAllLines(studentPath);
                string[] groups = File.ReadAllLines(groupPath);
                string[] topics = File.ReadAllLines(topicPath);
                if ((students.Length >= groups.Length) && (topics.Length >= groups.Length))
                {

                    //Se crean listas
                        List<string> studentsList = new List<string>();
                        foreach (var est in students) //Recorre el arreglo de students
                        {
                            studentsList.Add(est); //Se añade en la lista de students
                        }
                        List<string> removableGroupList = new List<string>();
                        List<string> groupList = new List<string>();
                        foreach (var grp in groups)
                        {
                            removableGroupList.Add(grp);
                            groupList.Add(grp);
                        }

                        List<string> topicList = new List<string>();
                        foreach (var topic in topics)
                        {
                            topicList.Add(topic);
                        }


                        List<string> ExG = new List<string>(); //Se crea una lista de Estudiante por Grupo

                        int cantEstxGrupo = students.Length / groups.Length; //División entre los students y los groups


                        List<string> TxG = new List<string>(); //Se crea una lista de Temas por Grupo
                        var cantTemaxGrp = topics.Length / groups.Length; //División entre los topics y los groups


                        var random = new Random(); //Se declara una clase Aleatoria
                        while (removableGroupList.Count > 0) //Se cumple la condición siempre y cuando exista por lo menos un grupo
                        {
                            var RandomGroupIndex = random.Next(0, removableGroupList.Count); //Devuelve una posición aleatoria en la lista de groups
                            for (int i = 0; i < cantEstxGrupo; i++)
                            {
                                var RandomEstIndex = random.Next(0, studentsList.Count); //Devuelve una posición aleatoria en la lista de students
                                ExG.Add($"{studentsList[RandomEstIndex]} - {removableGroupList[RandomGroupIndex]}");
                                studentsList.RemoveAt(RandomEstIndex);
                            }
                            for (int j = 0; j < cantTemaxGrp; j++)
                            {
                                var RandomTemaIndex = random.Next(0, topicList.Count); //Devuelve una posición aleatoria en la lista de students
                                TxG.Add($"{topicList[RandomTemaIndex]} - {removableGroupList[RandomGroupIndex]}");
                                topicList.RemoveAt(RandomTemaIndex);
                            }
                            removableGroupList.RemoveAt(RandomGroupIndex);
                        }
                        while (studentsList.Count > 0)
                        {
                            var RandomEstIndex = random.Next(0, studentsList.Count);
                            var RandomGroupIndex = random.Next(0, groupList.Count); //Devuelve una posición aleatoria en la lista de groups
                            ExG.Add($"{studentsList[RandomEstIndex]} - {groupList[RandomGroupIndex]}");
                            studentsList.RemoveAt(RandomEstIndex);
                        }
                        while (topicList.Count > 0)
                        {
                            var RandomTemaIndex = random.Next(0, topicList.Count);
                            var RandomGroupIndex = random.Next(0, groupList.Count); //Devuelve una posición aleatoria en la lista de groups
                            TxG.Add($"{topicList[RandomTemaIndex]} - {groupList[RandomGroupIndex]}");
                            topicList.RemoveAt(RandomTemaIndex);
                        }

                 
                        foreach(var grp in groupList)
                        {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"\nGRUPO {grp}:");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"Temas del Grupo : Cantidad {TxG.Where(a => a.Contains(grp)).Count()}");
                        foreach (var sel in TxG.Where(a=> a.Contains(grp)))
                        {
                            Console.Write($"{sel.Replace($"- {grp}","")}, ");
                        }
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"\nEstudiantes del Grupo : Cantidad {ExG.Where(a => a.Contains(grp)).Count()}");
                        foreach (var sel in ExG.Where(a => a.Contains(grp)))
                        {
                            Console.Write($"{sel.Replace($"- {grp}","")}, ");
                        }
                    }
                   

                }
                else
                    Console.WriteLine("La cantidad de Grupos debe ser menor que la cantidad de students y/o topics");
            }
            else
                Console.WriteLine("Existe al menos una ruta que no es válida");
        }
    }
}
