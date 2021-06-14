using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TodoApp
{
    public class AppListaDeTarefa
    {
        string fileLocation = "todo-items.txt";
        List<ItensLista> items = new List<ItensLista>();
        readonly string helpOutput = @"Options
    Add [item]               Adiciona tarefa a lista
    Feito + [Numero]          Completa uma tarefa da lista 
    Tarefas                  Mostra todas as tarefas 
    Ajuda                    Mostra todas as opcoes 
    Sair                     Sai da lista de tarefas ";



    public AppListaDeTarefa(){ LoadItems();}

    public void LoadItems(){ 
         if (File.Exists(fileLocation))
            {
                string[] lines = File.ReadAllLines(fileLocation);
                foreach (string line in lines)
                {
                    string text = line.Substring(1).Split(' ')[1];
                    int number = int.Parse(line.Substring(1).Split(' ')[0]);
                    ItensLista newItem = new ItensLista(text, number);
                    items.Add(newItem);
                }
            }
        }
     public void SaveItems(){
         List<string> allItems = new List<string>();
         foreach (ItensLista item in items)
         {
             allItems.Add(item.ToString());
         }
         File.WriteAllLines(fileLocation, allItems);
     }
     public void Add(string text)
        {
            int newNumber = 1;
            if (items.Count > 0)
            {
                newNumber = items.ElementAt(items.Count - 1).Number + 1;
            }

            ItensLista newItem = new ItensLista(text, newNumber);
            items.Add(newItem);
            Console.WriteLine(newItem);
            SaveItems();
        }
     public void Do(int number)
     {
         bool found = false;
         foreach (ItensLista item in items)
         {
             if (item.Number == number)
             {
                 Console.WriteLine(item + " Concluido");
                 found = true;

                 items.Remove(item);

                 SaveItems();
                 break;
             }
         }
         if(!found)
         {
             Console.WriteLine("Esse numero nao correponde a nenhuma tarefa");
         }
     }

     public void Print()
     {
         if(items.Count == 0)
         {
             Console.WriteLine("Lista Vazia");
         }else
         {
             foreach (ItensLista item in items)
             {
                 Console.WriteLine(item);
             }
         }
     }

  public void Help()
        {
            Console.WriteLine(helpOutput);
        }


    }
}