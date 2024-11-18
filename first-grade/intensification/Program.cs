string startDate = "01.01.1901";
string endDate = "09.04.2065";
int P = 5000;
int resultP = 0;

bool isLeap(int year)
{
	return (year % 4 == 0 && year % 100 != 0) || year % 400 == 0;
}

int countDaysInMonth(int month, int year)
{
	int[] daysInEveryMonth = { 31, isLeap(year) ? 29 : 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};

	return daysInEveryMonth[month - 1];
}

int daysBetweenTwoDates(string startDate, string endDate)
{
	int countDaysFromStart(int day, int month, int year)
	{
		int totalDays = 0;

		for(int i = 1; i < year; i++)
		{
			totalDays += isLeap(i) ? 366 : 365;
		}

		for(int i = 1; i < month; i++)
		{
			totalDays += countDaysInMonth(i, year);
		}

		return totalDays + day;
	}

	int startDateDay = int.Parse(startDate.Split('.')[0]);
	int startDateMonth = int.Parse(startDate.Split('.')[1]);
	int startDateYear = int.Parse(startDate.Split('.')[2]);

	int endDateDay = int.Parse(endDate.Split('.')[0]);
	int endDateMonth = int.Parse(endDate.Split('.')[1]);
	int endDateYear = int.Parse(endDate.Split('.')[2]);

	int startDateDays = countDaysFromStart(startDateDay, startDateMonth, startDateYear);
	int endDateDays = countDaysFromStart(endDateDay, endDateMonth, endDateYear);

	return endDateDays - startDateDays + 1;
}

int days = daysBetweenTwoDates(startDate, endDate);

for(int i = 0; i < days; i++)
{
	resultP += P;
	P += 1;
}

Console.WriteLine(resultP);