//tri XML Serialization

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
public class XMLSerializationTry
{
    public static void Main(string[] args)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        // membuat objek dari class employee
        Employee employee = new Employee { id = 100001, name = "Shekh Ali", address = "Belgia" };

        XmlInstance(employee);

        Deserialized();

        stopwatch.Stop();
        Console.WriteLine("===========================================");
        Console.WriteLine($"Program complete. Elapsed time: {stopwatch.ElapsedMilliseconds}ms");
        Console.WriteLine("===========================================");

    }
    private static void XmlInstance(Employee employee)
    {
        // membuatinstance dari XmlSerializer untuk menerima tipe objek sebagai parameter
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Employee));

        using (TextWriter txtWriter = new StreamWriter(@"Employee.xml"))
        {
            xmlSerializer.Serialize(txtWriter, employee);
        }
    }
    private static void Deserialized()
    {
        //membuka file untuk membaca XML data
        FileStream fs = new FileStream(@"Employee.xml", FileMode.Open);
        XmlSerializer serializer = new XmlSerializer(typeof(Employee));

        //Memanggil Deseirialize () untuk melakukan deserialize data dari file
        Employee emp = (Employee)serializer.Deserialize(fs);
        Console.WriteLine($"Deserialized Employee Id: {emp.id} Name: {emp.name} Address: {emp.address}");
    }

    
}