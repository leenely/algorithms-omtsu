// using System;

// public class Calculator
// {
//   public int firstNumber;
//   public int secondNumber;

//   public Calculator(int firstNumber, int secondNumber)
//   {
//     this.firstNumber = firstNumber;
//     this.secondNumber = secondNumber;
//   }

//   public int Sum() 
//   {
//     return this.firstNumber + this.secondNumber;
//   }

//   public int Substract() 
//   {
//     return this.firstNumber - this.secondNumber;
//   }

//   public int Multiply() 
//   {
//     return this.firstNumber * this.secondNumber;
//   }

//   public int Divide()
//   {
//     if (this.secondNumber == 0) {
//       throw new DivideByZeroException();
//     }

//     return this.firstNumber / this.secondNumber;
//   }
// }

// public delegate int Operations(Calculator calculator);


// class Program
// {
//   static void Main() 
//   {
//     var calculator_1 = new Calculator(8, 2);

//     Operations operationsGroup_1 = calculator =>
//     {
//       int result = calculator.Sum();
//       result = calculator.Substract();
//       return calculator.Divide();
//     };

//     int result_1 = operationsGroup_1(calculator_1);
//     Console.WriteLine(result_1);


//     var calculator_2 = new Calculator(9, 2);

//     Operations operationsGroup_2 = calculator =>
//     {
//       int result = calculator.Multiply();
//       result = calculator.firstNumber + result;
//       return result;
//     };

//     int result_2 = operationsGroup_2(calculator_2);
//     Console.WriteLine(result_2);
//   }
// }

using System;
using System.Collections.Generic;

public class Car
{
	public string Year { get; set; }
	public string Name { get; set; }
	public string Owner { get; set; }
	public bool IsClean { get; set; }

	public Car(string year, string name, string owner, bool isClean)
	{
		Year = year;
		Name = name;
		Owner = owner;
		IsClean = isClean;
	}
}

public class Garage
{
	private List<Car> cars = new List<Car>();

	public void AddCar(Car car)
	{
		cars.Add(car);
	}

	public bool ContainsCar(Car car)
	{
		return cars.Contains(car);
	}
}

public delegate void WashingEventHandler(Car car);

public class CarWash
{
	public event WashingEventHandler OnWash;

	public void WashCar(Car car)
	{
		if (car.IsClean)
		{
			Console.WriteLine($"Машина {car.Name} уже чиста");
			return;
		}

		car.IsClean = true;
		Console.WriteLine($"Машина {car.Name} успешно помыта");

		OnWash?.Invoke(car);
	}
}

class Program
{
	static void Main()
	{
		Garage garage = new Garage();
		CarWash carWash = new CarWash();

		Car car = new Car("2020", "Toyota", "Geniy", false);
		garage.AddCar(car);

		carWash.OnWash += CarWash_WashingEvent;

		if (garage.ContainsCar(car))
		{
			carWash.WashCar(car);
		}
		else
		{
			Console.WriteLine("Машина не найдена в гараже");
		}
	}

	static void CarWash_WashingEvent(Car car)
	{
		Console.WriteLine($"Событие мытья машины: {car.Name}");
	}
}
