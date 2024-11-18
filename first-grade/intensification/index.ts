let startDate = '01.01.1901';
let endDate = '09.04.2065';
let P = 5000;
let resultP = 0;

/* Подсчёт количества дней между двумя датами */

function isLeap(year: number): boolean {
	return (year % 4 === 0 && year % 100 !== 0) || year % 400 === 0; // при помощи year % 400 === 0 учитываем "круглые года": 2000, 1900, 1800 и т.д
}

function countDaysInMonth(month: number, year: number): number {
	const daysInEveryMonth = [31, isLeap(year) ? 29 : 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];

	return daysInEveryMonth[month - 1];
}

function daysBetweenTwoDates(startDate: string, endDate: string): number {
	function countDaysFromStart(day: number, month: number, year: number): number {
		let totalDays = 0;

		// Высчитываем дни за полные года
		for (let i = 1; i < year; i++) {
			totalDays += isLeap(i) ? 366 : 365;
		}

		// Высчитываем дни за полные месяца
		for (let i = 1; i < month; i++) {
			totalDays += countDaysInMonth(i, year);
		}

		return totalDays + day; // Добавляем оставшиеся дни
	}

	let [startDateDay, startDateMonth, startDateYear] = startDate.split('.').map(Number);
	let [endDateDay, endDateMonth, endDateYear] = endDate.split('.').map(Number);

	const startDateDays = countDaysFromStart(startDateDay, startDateMonth, startDateYear);
	const endDateDays = countDaysFromStart(endDateDay, endDateMonth, endDateYear);

	return endDateDays - startDateDays + 1; // Добавляем 1 для учёта первого дня
}

let days = daysBetweenTwoDates(startDate, endDate);


/* */

for(let i = 0; i < days; i++) {
	resultP += P;
	P += 1;
}

console.log(resultP)