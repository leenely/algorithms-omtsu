// Объект: (структура) поле id_студента, поле ФИО, два указателя в структуре (один на левое поддерево, другой - на правое поддерево). На вход подаются объекты заданной структуры. Необходимо используя айди студента в качество ключевого поля построить бинарное дерево. Вывод как угодно, главное показать уровень дерева

using System;

struct Student
{
  public int id;
  public string name;
  public unsafe Student* left;
  public unsafe Student* right;

  public unsafe Student(int id, string name)
  {
    this.id = id;
    this.name = name;
    this.left = null;
    this.right = null;
  }

  public string Log()
  {
    return $"[{id} {name}]";
  }
}

class BinaryTree
{
  public unsafe Student* head;

  public unsafe void Add(Student student)
  {
    Insert(ref head, student);
  }

  public unsafe void Insert(ref Student* node, Student student)
  {
    if (node == null)
    {
      node 
    }
  }
}