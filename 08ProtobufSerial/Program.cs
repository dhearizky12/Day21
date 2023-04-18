using System.Runtime.Serialization;
using System;
using System.IO;
using ProtoBuf;
using System.Diagnostics;

[ProtoContract]
public class Employee {
    
    [ProtoMember(1)]
    public int id {get; set;}
    
    [ProtoMember(2)]
    public string? name {get; set;}

    [ProtoMember(3)]
    public int age {get; set;}

    [ProtoMember(4)]
    public string? address {get; set;}
}

class Program
{
    static void Main (string[] args){
        var stopwatch = new Stopwatch();
        stopwatch.Start();

        Employee employee = new Employee {id=100001 , name="Shekh Ali", age= 30, address="Belgia"};

        // Melakukan Serialize 
        using (FileStream stream = new FileStream("employee.bin",FileMode.Create))
        {
            Serializer.Serialize(stream,employee);
        }

        //Melakukan Deserialize sebauh object
        Employee deserializedEmployee;
        using (FileStream stream = new FileStream ("employee.bin",FileMode.Open))
        {
            deserializedEmployee= Serializer.Deserialize <Employee>(stream);
        }


         Console.WriteLine($"Deserialized Employee Id: {deserializedEmployee.id} Name: {deserializedEmployee.name} Address: {deserializedEmployee.address}");

        stopwatch.Stop();
        Console.WriteLine("===========================================");
        Console.WriteLine($"Program complete. Elapsed time: {stopwatch.ElapsedMilliseconds}ms");
        Console.WriteLine("===========================================");
    
    }


}