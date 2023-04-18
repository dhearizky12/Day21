using System.Runtime.Serialization.Json;
using System;
using System.IO;
using System.Text.Json;
using System.Diagnostics;

public class Employee
{
    public int? id {get;set;}
    public string? name { get; set; }
    public int? age { get; set; }
    public string? address {get; set;}
}

class JSONSerializationTtry
{
    static void Main(string[] args)
    {
        
        var stopwatch = new Stopwatch();
        stopwatch.Start();


        Employee employee = new Employee { id = 100001, name = "Shekh Ali", age= 30, address= "Belgia" };

        // melakukan serializationdari object
        var jsonString = JsonSerializer.Serialize(employee);
        
    
        // Menyimpan JSON ke file
        File.WriteAllText("employee.json", jsonString);
       // File.WriteAllLines("employee2.json", jsonString);

        // Membaca JSON dari sebuah file
        string jsonFromFile = File.ReadAllText("employee.json");
        //string.jsonFromFile2 = File.ReadAllLines ("employee.json");
        

        // Melakukan Deserialize dari sebuah object
        Employee deserializedEmployee = JsonSerializer.Deserialize<Employee>(jsonFromFile);
       // Employee deserializedEmployee2 = JsonSerialzer.Deseirialize<Employee>(jsonFromFile2);
     

        Console.WriteLine($"Deserialized Employee Id: {deserializedEmployee.id} Name: {deserializedEmployee.name} Age : {deserializedEmployee.age} Address: {deserializedEmployee.address}");
      //  Console.WriteLine($"Deserialized Employee Id: {deserializedEmployee2.id} Name: {deserializedEmployee2.name} Age : {deserializedEmployee2.age} Address: {deserializedEmployee2.address}");


        stopwatch.Stop();
        Console.WriteLine("===========================================");
        Console.WriteLine($"Program complete. Elapsed time: {stopwatch.ElapsedMilliseconds}ms");
        Console.WriteLine("===========================================");
    }
}
