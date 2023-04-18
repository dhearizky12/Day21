using System;
using System.IO;
using System.Xml.Serialization;
using System.Diagnostics;

public class Employee
{  
    public int? id {get; set;}
    public string? name {get; set;}
    public string? address {get; set;}
}

class XMLSerializationTry
{
    static void Main(string[] args)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();

        Employee employee = new Employee { id = 100001, name = "Shekh Ali", address= "Belgia" };

        // Serialize the object
        XmlSerializer serializer = new XmlSerializer(typeof(Employee));
        using (StreamWriter writer = new StreamWriter("employee.xml"))
        {
            serializer.Serialize(writer, employee);
        }

        // Deserialize the object
        Employee deserializedEmployee;
        using (StreamReader reader = new StreamReader("employee.xml"))
        {
            deserializedEmployee = (Employee)serializer.Deserialize(reader);
        }

        Console.WriteLine($"Deserialized Employee Id: {deserializedEmployee.id} Name: {deserializedEmployee.name} Address: {deserializedEmployee.address}");

        stopwatch.Stop();
        Console.WriteLine("===========================================");
        Console.WriteLine($"Program complete. Elapsed time: {stopwatch.ElapsedMilliseconds}ms");
        Console.WriteLine("===========================================");
    

    }
}
