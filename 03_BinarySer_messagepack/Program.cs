using System;
using System.IO;
using MessagePack;

[MessagePackObject]
public class Person
{
	[Key(0)]
	public string Name { get; set; }
	[Key(1)]
	public int Age { get; set; }
}

class Program
{
	static void Main(string[] args)
	{
		Person person = new Person { Name = "Alice", Age = 10 };

		// Serialize the object
		byte[] serializedData = MessagePackSerializer.Serialize(person);

		// Save binary data to a file
		File.WriteAllBytes("person.bin", serializedData);

		// Read binary data from a file
		byte[] dataFromFile = File.ReadAllBytes("person.bin");

		// Deserialize the object
		Person deserializedPerson = MessagePackSerializer.Deserialize<Person>(dataFromFile);

		Console.WriteLine($"Deserialized Person: {deserializedPerson.Name}, {deserializedPerson.Age}");
	}
}
