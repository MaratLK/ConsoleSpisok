using static System.Runtime.InteropServices.JavaScript.JSType;

public class Nodes<T>
{
    public Nodes(T data)
    {
        Data = data;
    }
    public T Data { get; set; }
    public Nodes<T> Next { get; set; }
}

public class LinkedList<T>
{
    //Nodes<T> node = new Nodes<T>(Data); - если я ставлю его в общий список, то жалуется на Data. так и не разобрался почему
    Nodes<T> main;
    public void AddNodes(T Data)
    {
        Nodes<T> node = new Nodes<T>(Data);
        if (main == null)
        {
            main = node;
        }

        else
        {
            Nodes<T> i = main;

            while (i.Next != null)
            {
                i = i.Next;
            }
            i.Next = node;
        }
    }

    public void DelNodes(T Data)
    {
        Nodes<T> node = new Nodes<T>(Data);
        if (main == null)
        {
            return;
        }

        else if (node == main)
        {
            main = main.Next;
        }

        else
        {
            Nodes<T> i = main;
            while (i.Next != null)
            {
                if (i.Next.Data.Equals(Data))
                {
                    i.Next = i.Next.Next;
                }
                else
                {
                    i = i.Next;
                }
            }
        }
    }

    public void WriteList()
    {
        if (main == null)
        {
            Console.WriteLine("Список пуст");
            return;
        }
        else
        {
            Nodes<T> i = main;
            while (i != null)
            {
                Console.WriteLine(i.Data);
                i = i.Next;

            }

        }
    }
}


public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        LinkedList<string> list = new LinkedList<string>();

        list.AddNodes("one");
        list.AddNodes("two");
        list.AddNodes("three");

        Console.WriteLine("добавили");
        list.WriteList();

        list.DelNodes("two");

        Console.WriteLine("удалили");
        list.WriteList();
    }
}