using System;
using System.Collections.Generic;
using System.IO;

class Employee
{
    public string Name { get; set; }
    public Employee DirectManager { get; set; }

    public Employee(string name, Employee directManager)
    {
        Name = name;
        DirectManager = directManager;
    }

    public bool TakeTask(string task, Employee assignee)
    {
        if (assignee == this || assignee.DirectManager == this)
        {
            Console.WriteLine($"{Name} дает задачу \"{task}\" {assignee.Name}");
            return true;
        }
        else
        {
            Console.WriteLine($"{Name} не может дать задачу {assignee.Name}");
            return false;
        }
    }
}

// Класс для генерального директора
class CEO : Employee
{
    public CEO(string name) : base(name, null) { }
}

// Класс для финансового директора
class CFO : Employee
{
    public CFO(string name, Employee directManager) : base(name, directManager) { }
}

// Класс для директора по автоматизации
class AutomationDirector : Employee
{
    public AutomationDirector(string name, Employee directManager) : base(name, directManager) { }
}

// Класс для главного бухгалтера
class ChiefAccountant : Employee
{
    public ChiefAccountant(string name, Employee directManager) : base(name, directManager) { }
}

// Класс для начальника отдела информационных технологий
class ITManager : Employee
{
    public ITManager(string name, Employee directManager) : base(name, directManager) { }
}

// Класс для заместителя начальника отдела информационных технологий
class ITDeputyManager : Employee
{
    public ITDeputyManager(string name, Employee directManager) : base(name, directManager) { }
}

// Класс для сотрудников отдела системщиков
class NetworkEngineer : Employee
{
    public NetworkEngineer(string name, Employee directManager) : base(name, directManager) { }
}

// Класс для сотрудников отдела разработчиков
class Developer : Employee
{
    public Developer(string name, Employee directManager) : base(name, directManager) { }
}
public class Song
{
    public string Name { get; set; }
    public string Author { get; set; }
    public Song Prev { get; set; }

    public Song(string name, string author, Song prev)
    {
        Name = name;
        Author = author;
        Prev = prev;
    }

    public string Title()
    {
        return Name + " ; " + Author;
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Song other = (Song)obj;
        return Name == other.Name && Author == other.Author;
    }
}

public class Example
{
    static void Main(string[] args)
    {
        List<Song> songs = new List<Song>();

        Song song1 = new Song("Она не твоя", "Григорий Лепс", null);
        Song song2 = new Song("Она не твоя", "Григорий Лепс", song1);
        Song song3 = new Song("Прсто друг", "Чвай вдвоем", song2);
        Song song4 = new Song("Я буду", "Лоя", song3);

        songs.Add(song1);
        songs.Add(song2);
        songs.Add(song3);
        songs.Add(song4);

        foreach (Song song in songs)
        {
            Console.WriteLine(song.Title());
        }

        if (song1.Equals(song2))
        {
            Console.WriteLine("Песни 1 и 2 одинаковы");
        }
        else
        {
            Console.WriteLine("Песни 1 и 2 разные");
        }

        // Создание иерархии сотрудников
        CEO semyon = new CEO("Семен");
        CFO rashid = new CFO("Рашид", semyon);
        AutomationDirector ilham = new AutomationDirector("О Ильхам", semyon);
        ChiefAccountant lukas = new ChiefAccountant("Лукас", rashid);
        ITManager orkadiy = new ITManager("Оркадий", ilham);
        ITDeputyManager volodya = new ITDeputyManager("Володя", ilham);
        NetworkEngineer ilshat = new NetworkEngineer("Ильшат", orkadiy);
        NetworkEngineer ivanych = new NetworkEngineer("Иваныч", orkadiy);
        Developer sergey = new Developer("Сергей", orkadiy);
        Developer lyaysan = new Developer("Ляйсан", orkadiy);
        NetworkEngineer ilya = new NetworkEngineer("Илья", ivanych);
        NetworkEngineer vitia = new NetworkEngineer("Витя", ivanych);
        NetworkEngineer zhenya = new NetworkEngineer("Женя", ivanych);
        Developer marat = new Developer("Марат", lyaysan);
        Developer dina = new Developer("Дина", lyaysan);
        Developer ildar = new Developer("Ильдар", lyaysan);
        Developer anton = new Developer("Антон", lyaysan);

        // Примеры назначения задач
        semyon.TakeTask("Задача 1", rashid);
        rashid.TakeTask("Задача 2", lukas);
        ilham.TakeTask("Задача 3", orkadiy);
        orkadiy.TakeTask("Задача 4", ilshat);
        lyaysan.TakeTask("Задача 5", marat);
        sergey.TakeTask("Задача 6", dina);

        //Задание 
        Console.WriteLine("Введите название файла");
        string nameFile = Console.ReadLine();
        string[] lines = File.ReadAllLines(nameFile);

        using (StreamWriter writer = new StreamWriter("output.txt"))
        {
            foreach (string line in lines)
            {
                string email = GetEmail(line);

                writer.WriteLine(email);
            }
        }

        Console.WriteLine("Готово!");
    }

    static string GetEmail(string line)
    {
        int separatorIndex = line.IndexOf('#');


        if (separatorIndex == -1)
            return "";


        string email = line.Substring(separatorIndex + 1).Trim();

        return email;

        Console.ReadKey();
    }

}







