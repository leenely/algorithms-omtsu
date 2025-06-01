bool CheckLine(string line)
{
  string number = "";
  bool isChecking = false;

  foreach (char ch in line)
  {
    if (char.IsDigit(ch))
    {
      isChecking = true;
      number += ch;
    }
    else
    {
      if (isChecking)
      {
        int resultNumber = int.Parse(number);
        if (resultNumber % 2 != 0)
        {
          return true;
        }

        number = "";
        isChecking = false;
      }
    }
  }

  if (isChecking && int.Parse(number) % 2 != 0)
  {
    return true;
  }

  return false;
}


string path = Path.Combine("1.txt");
List<string> linesToWrite = new List<string>();
if (File.Exists(path))
{
  var lines = File.ReadAllLines(path);
  foreach (var line in lines)
  {
    Console.WriteLine(line);

    if (CheckLine(line))
    {
      linesToWrite.Add(line);
    }
  }
}

string pathToWrite = Path.Combine("output.txt");
File.WriteAllLines(pathToWrite, linesToWrite);