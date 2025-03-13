using System;

public class Phone
{
	public string phoneNumber;
	public string operatorName;

	public Phone(string phoneNumber, string operatorName)
	{
		this.phoneNumber = phoneNumber;
		this.operatorName = operatorName;
	}
}

class Program
{
	static void Main()
	{
		List<Phone> phones = new List<Phone>()
		{
			new Phone("123", "мтс"),
			new Phone("456", "мтс"),
			new Phone("789", "vnc"),
		};

		Dictionary<string, int> operatorNumbers = new Dictionary<string, int>();

		foreach (var number in phones)
		{
			if (operatorNumbers.ContainsKey(number.operatorName))
			{
				operatorNumbers[number.operatorName]++;
			}
			else
			{
				operatorNumbers[number.operatorName] = 1;
			}
		}

		foreach (var operatorName in operatorNumbers)
		{
			Console.WriteLine($"{operatorName.Key}  -  {operatorName.Value}");
		}
	}
}