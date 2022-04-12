using System;
public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите текст запроса для отправки. Для выхода введите /exit");
        string req = Console.ReadLine();

        while (req != "/exit")
        {
            List<string> argList = new List<string>();
                
            Console.WriteLine("Введите аргументы сообщения. Если аргументы не нужены - введите /end");
            string arg = Console.ReadLine();

            while (arg != "/end")
            {
                argList.Add(arg);

                Console.WriteLine("Введите следующий аргумент сообщения. Для окончания добавления аргументов введите /end");
                arg = Console.ReadLine();
            }

            ThreadPool.QueueUserWorkItem(state => { GetResp(req, argList); });

            Console.WriteLine("Введите текст запроса для отправки. Для выхода введите /exit");
            req = Console.ReadLine();
        }

        Console.WriteLine("Приложение завершает работу.");
    }

    static void GetResp(string req, List<string> argList)
    {
        Guid g = Guid.NewGuid();
        DummyRequestHandler d = new DummyRequestHandler();

        Console.WriteLine($"Было послано сообщение " + req + ". Присвоен идентификатор " + g);

        try
        {
            string res = d.HandleRequest(req, argList.ToArray());
            Console.WriteLine($"Сообщение с идентификатором " + g + " получило ответ - " + res + ".");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Сообщение с идентификатором " + g + " упало с ошибкой: " + e.Message + ".");
        }
    }
}