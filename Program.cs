public class Node<Type> // класс в котором Node(узел) имеет универсальный тип данных(Type или T)
{
    public Node(Type data) // свойство узла для обработки данных универсального типа
    {
        Data = data; // свойству Данные присваеваем данные
    }

    public Type Data { get; set; } //свойство для принятия и хранения данных
    public Node<Type>? NextNode { get; set; } // свойство для перехода между данными
}

public class LinkedList<Type> // класс для управления списком
{
    private Node<Type>? _headNode; // переменная первого узла
    private Node<Type>? _tailNode; //переменная последнего узла
    private int _count; // переменная количества

    public void Add(Type data) // метод для добавления параметра
        {
            Node<Type> node = new Node<Type>(data); // создаем новый узел с данными data и ссылкой на следующий узел

        if (_headNode == null) //если список пуст, то узел становится и головой, и хвостом
        {
            _headNode = node;
            _tailNode = node;
        }
        else
        { 
            _tailNode.NextNode = node; //связываем последний узел с новым
            _tailNode = node; //новый узел теперь последний
        }
        _count++; //увеличиваем количество узлов
        }

    public bool Remove(Type data) 
    {
        if (_headNode == null) //проверяем список на данные
        {
            return false;
        }
        if (Equals(_headNode.Data, data)) //Если удаляем начальный узел
        {
            _headNode = _headNode.NextNode; //переназначаем начальный узел на след. узел
            if (_tailNode != null) //если список пуст, то обновляем хвост
            {
                _tailNode = null;
            }
            _count--; //уменьшаем узлы
            return true;
        }

        Node<Type>? currentNode = _headNode; //начинаем с начального узла списка
        while (currentNode.NextNode != null) //перебор узлов 
        {
            if (Equals(currentNode.NextNode.Data, data)) //если нашли узел с нужными данными
            {
                currentNode.NextNode = currentNode.NextNode.NextNode; //указываем на ссылку на удаляемый узел, а затем ссылку на тот, который будет после удаленного
                if (currentNode.NextNode == null) //обновляем последний узел, если он удален
                {
                    _tailNode = currentNode;
                }
                _count-- ;// уменьшаем узлы
                return true;
            }
            currentNode = currentNode.NextNode; //слудующий узел
        }
        return false;
    }

    public void Clear() //очищаем список
    {
        _headNode = null;
        _tailNode = null;
        _count = 0;
    }

    public void PrintNodes() // метод вывода параметров
    {
        Node<Type> currentNode = _headNode; //Обрабатываем переменные начиная м первого узла. (current(текщий))

        while (currentNode != null) //перебираем узлы на наличие данных
        {
            Console.WriteLine(currentNode.Data); //выводим
            currentNode = currentNode.NextNode; // переходим к следующим
        }
    }
}

public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        LinkedList<string> list = new LinkedList<string>();

        list.Add("one");
        list.Add("two");
        list.Add("three");

        Console.WriteLine("До удаления:");
        list.PrintNodes();

        list.Remove("two");

        Console.WriteLine("После удаления:");
        list.PrintNodes();

        list.Clear();

        Console.WriteLine("После очистки:");
        list.PrintNodes();
    }
}
