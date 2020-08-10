using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
namespace RandomProgram1
{
    class Program 
    {
        static void Main(string[] args)
        {

            //Validación de las ruta de archivo
            bool isPathValid = false;
            string pathEstudiantes = "";
            string PathGrupos = "";
            string PathTemas = "";
            if (args.Length == 3)
            {
                pathEstudiantes = $@"{args[0]}";
                PathGrupos = $@"{args[1]}";
                PathTemas = $@"{args[2]}";
                if  (File.Exists(pathEstudiantes) && File.Exists(PathGrupos) && File.Exists(PathTemas))
                    isPathValid = true;
            }
            if (isPathValid)
            {
                //Procede a la lectura de archivos de la ruta y guardar los datos en arreglos
                string[] estudiantes = File.ReadAllLines(pathEstudiantes);
                string[] grupos = File.ReadAllLines(PathGrupos);
                string[] temas = File.ReadAllLines(PathTemas);
                if ((estudiantes.Length > grupos.Length) && (temas.Length > grupos.Length))
                {



                    //Se crean listas
                        List<string> listEstudiantes = new List<string>();
                        foreach (var est in estudiantes) //Recorre el arreglo de estudiantes
                        {
                            listEstudiantes.Add(est); //Se añade en la lista de estudiantes
                        }
                        List<string> listGruposRemovibles = new List<string>();
                        List<string> listGrupos = new List<string>();
                        foreach (var grp in grupos)
                        {
                            listGruposRemovibles.Add(grp);
                            listGrupos.Add(grp);
                        }

                        List<string> listTemas = new List<string>();
                        foreach (var tema in temas)
                        {
                            listTemas.Add(tema);
                        }


                        List<string> ExG = new List<string>(); //Se crea una lista de Estudiante por Grupo

                        int cantEstxGrupo = estudiantes.Length / grupos.Length; //División entre los estudiantes y los grupos


                        List<string> TxG = new List<string>(); //Se crea una lista de Temas por Grupo
                        var cantTemaxGrp = temas.Length / grupos.Length; //División entre los temas y los grupos


                        var random = new Random(); //Se declara una clase Aleatoria
                        while (listGruposRemovibles.Count > 0) //Se cumple la condición siempre y cuando exista por lo menos un grupo
                        {
                            var RandomGroupIndex = random.Next(0, listGruposRemovibles.Count); //Devuelve una posición aleatoria en la lista de grupos
                            for (int i = 0; i < cantEstxGrupo; i++)
                            {
                                var RandomEstIndex = random.Next(0, listEstudiantes.Count); //Devuelve una posición aleatoria en la lista de estudiantes
                                ExG.Add($"{listEstudiantes[RandomEstIndex]} - {listGruposRemovibles[RandomGroupIndex]}");
                                listEstudiantes.RemoveAt(RandomEstIndex);
                            }
                            for (int j = 0; j < cantTemaxGrp; j++)
                            {
                                var RandomTemaIndex = random.Next(0, listTemas.Count); //Devuelve una posición aleatoria en la lista de estudiantes
                                TxG.Add($"{listTemas[RandomTemaIndex]} - {listGruposRemovibles[RandomGroupIndex]}");
                                listTemas.RemoveAt(RandomTemaIndex);
                            }
                            listGruposRemovibles.RemoveAt(RandomGroupIndex);
                        }
                        while (listEstudiantes.Count > 0)
                        {
                            var RandomEstIndex = random.Next(0, listEstudiantes.Count);
                            var RandomGroupIndex = random.Next(0, listGrupos.Count); //Devuelve una posición aleatoria en la lista de grupos
                            ExG.Add($"{listEstudiantes[RandomEstIndex]} - {listGrupos[RandomGroupIndex]}");
                            listEstudiantes.RemoveAt(RandomEstIndex);
                        }
                        while (listTemas.Count > 0)
                        {
                            var RandomTemaIndex = random.Next(0, listTemas.Count);
                            var RandomGroupIndex = random.Next(0, listGrupos.Count); //Devuelve una posición aleatoria en la lista de grupos
                            TxG.Add($"{listTemas[RandomTemaIndex]} - {listGrupos[RandomGroupIndex]}");
                            listTemas.RemoveAt(RandomTemaIndex);
                        }

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nESTUDIANTES POR GRUPO:\n");
                        foreach (var sel in ExG)
                        {
                            Console.WriteLine(sel);
                        }

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\nTEMAS POR GRUPO:\n");
                        foreach (var sel in TxG)
                        {
                            Console.WriteLine(sel);
                        }

                }
                else
                    Console.WriteLine("La cantidad de Grupos debe ser menor que la cantidad de estudiantes y/o temas");
            }
            else
                Console.WriteLine("Existe al menos una ruta que no es válida");
        }
    }
}
