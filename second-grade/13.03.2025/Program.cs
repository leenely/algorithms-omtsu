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

public class Car
{
	public string year;
	public string name;
	public string owner;
	public bool isClean;

	public Car(string year, string name, string owner, bool isClean)
	{
		this.year = year;
		this.name = name;
		this.owner = owner;
		this.isClean = isClean;
	}
}


public class Garage
{
	List<Car> cars = new List<Car>();

	public void AddCar(Car car)
	{
		cars.Add(car);
	}
}

public delegate void WashingEventHandler();

public class CarWash
{
	public event WashingEventHandler OnWash;

	public void OnWashing(Car car)
	{
		if (!car.isClean)
		{
			car.isClean = true;
			Console.WriteLine($"Машина {car.name} успешно помыта");
		}
		else
		{
			Console.WriteLine($"Машина {car.name} уже чиста");
		}
	}
}

class Program
{
	public void Main()
	{
		Garage garage = new Garage();
		CarWash carWash = new CarWash();

		garage.AddCar(new Car(2020, "Toyota", "Geniy", false));

		carWash.WashingEvent += CarWash_WashingEvent;
	}
}