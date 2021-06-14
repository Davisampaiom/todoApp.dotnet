using System;

namespace TodoApp
{
    class Program
{
        static void Main(string[] args)
        {
            AppListaDeTarefa app = new AppListaDeTarefa();

          Console.WriteLine("              Bem-Vindo !!!\n"+
                            " Add [item]               Adiciona tarefa a lista\n"+
                            " Feito + [Numero]          Completa uma tarefa da lista\n"+ 
                            " Tarefas                  Mostra todas as tarefas\n"+ 
                            " Ajuda                    Mostra todas as opcoes\n"+ 
                            " Sair                     Sai da lista de tarefas\n");

            Console.Write(">");

          string inputLine = Console.ReadLine();
            while (!inputLine.Equals("") && !inputLine.ToLower().Equals("sair"))
            {
                if (inputLine.StartsWith("add "))
                {
                    string text = inputLine.Split(new[] { "add " }, StringSplitOptions.None)[1];
                    app.Add(text);
                }
                else if (inputLine.StartsWith("feito"))
                {
                    try
                    {
                        int doNumber = int.Parse(inputLine.Split(new[] { "feito " }, StringSplitOptions.None)[1]);
                        app.Do(doNumber);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Esse numero nao correponde a nenhuma tarefa");
                    }
                }
                else if (inputLine.ToLower().Equals("tarefas"))
                {
                    app.Print();
                }
                else if (inputLine.ToLower().Equals("ajuda"))
                {
                    app.Help();
                }
                else
                {
                    Console.WriteLine("Comando nao encontra, digita ajuda para ver as opcoes");
                }

                Console.Write(">");

                // Read new input
                inputLine = Console.ReadLine();
            }
        }
    }
}