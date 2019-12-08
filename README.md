# EPAM_Tasks
### Задание 1 (NET.W.2019.Oliseichik.01).
- Реализовать методы быстрой сортировки и сортировки слиянием для
целочисленного массива. 
- Протестировать работу методов в консольном
приложении или с помощью модульного тестирования.

---
### Задание 2 (NET.W.2019.Oliseichik.02).
- Даны два целых знаковых четырех байтовых числа и две позиции битов i и j
(i<j). Реализовать+ алгоритм InsertNumber вставки битов с j-ого по i-ый бит
одного числа в другое так, чтобы биты второго числа занимали позиции с бита j
по бит i (биты нумеруются справа налево). Разработать модульные тесты
(NUnit и(!) MS Unit Test) для тестирования метода. 
- Реализовать метод FindNextBiggerNumber, который принимает
положительное целое число и возвращает ближайше наибольшее целое,
состоящее из цифр исходного числа, и - 1 (null), если такого числа не
существует. Разработать модульные тесты (NUnit или MS Unit Test) для
тестирования метода.
- Добавить к методу FindNextBiggerNumber возможность вернуть время
нахождения заданного числа, рассмотрев различные языковые
возможности. Разработать модульные тесты (NUnit или MS Unit Test) для
тестирования метода.
- Реализовать метод FilterDigit который принимает список целых чисел и
фильтрует список, таким образом, чтобы на выходе остались только числа,
содержащие заданную цифру. LINQ не использовать! Например, для цифры
7, FilterDigit (7,1,2,3,4,5,6,7,68,69,70, 15,17) -> {7, 70, 17}. Разработать
модульные тесты (NUnit или MS Unit Test) для тестирования метода. 
- Реализовать алгоритм FindNthRoot, позволяющий вычислять корень n-ой
степени ( n∈N ) из числа ( a∈R ) методом Ньютона с заданной точностью.
Разработать модульные тесты (NUnit и (или) MS Unit Test) для тестирования
метода.

---
### Задание 3 (NET.W.2019.Oliseichik.04).
- Разработать класс, позволяющий выполнять вычисления НОД по алгоритму
Евклида для двух, трех и т.д. целых чисел. Методы класса помимо вычисления НОД
должны определять значение времени, необходимое для выполнения расчета.
Добавить к разработанному классу методы, реализующие алгоритм Стейна
(бинарный алгоритм Евклида) для расчета НОД двух, трех и т.д. целых чисел. Методы должны также определять значение
времени, необходимое для выполнения расчетов. Разработать unit-тесты для
тестирования методов данного типа. 
- Реализовать метод расширения для получения строкового двоичного
представления вещественного числа двойной точности в формате IEEE 754
(желательно не использовать готовые классы-конверторы). Разработать
модульные тесты.

---
### Задание 4 (NET.W.2019.Oliseichik.06).
- Разработать неизменяемый класс Polynomial (полином) для работы
с многочленами степени от одной переменной вещественного типа
(в качестве внутренней структуры для хранения коэффициентов
использовать sz-массив). Для разработанного класса:
   + переопределить виртуальные методы класса Object;
   + перегрузить операции, допустимые для работы с многочленами (исключая
     деление многочлена на многочлен), включая “==” и “!=”.
Разработать unit-тесты.
- Реализовать алгоритм “пузырьковой” сортировки непрямоугольного (jagged array)
целочисленного массива (методы сортировки класса System.Array не
использовать) таким образом, чтобы была возможность упорядочить строки матрицы:
   + в порядке возрастания (убывания) сумм элементов строк матрицы;
   + в порядке возрастания (убывания) максимальных элементов строк матрицы;
   + в порядке возрастания (убывания) минимальных элементов строк матрицы. 
Разработать unit-тесты.

---
### Задание 5 (NET.W.2019.Oliseichik.08).
- Разработать класс Book (ISBN, автор, название, издательство, год издания,
количество страниц, цена), переопределив для него необходимые методы класса
Object. Для объектов класса реализовать отношения эквивалентности и порядка
(используя соответствующие интерфейсы). Для выполнения основных операций со
списком книг, который можно загрузить и, если возникнет необходимость,
сохранить в некоторое хранилище BookListStorage разработать класс BookListService
(как сервис для работы с коллекцией книг) с функциональностью AddBook (добавить
книгу, если такой книги нет, в противном случае выбросить исключение); RemoveBook
(удалить книгу, если она есть, в противном случае выбросить исключение);
FindBookByTag (найти книгу по заданному критерию); SortBooksByTag (отсортировать
список книг по заданному критерию), при реализации делегаты не использовать!
Работу классов продемонстрировать на примере консольного приложения.
В качестве хранилища использовать двоичный файл, для работы с которым использовать только классы BinaryReader,
BinaryWriter. Хранилище в дальнейшем может измениться/добавиться.
- Разработать систему типов для описания работы с банковским счетом. Состояние
счета определяется его номером, данными о владельце счета (имя, фамилия), суммой
на счете и некоторыми бонусными баллами, которые увеличиваются/уменьшаются
каждый раз при пополнении счета/списании со счета на величины различные для
пополнения и списания и рассчитываемые в зависимости от некоторых значений
величин «стоимости» баланса и «стоимости» пополнения. Величины «стоимости»
баланса и «стоимости» пополнения являются целочисленными значениями и зависят
от градации счета, который может быть, например, Base, Gold, Platinum.
Для работы со счетом реализовать следующие возможности:
   + выполнить пополнение на счет;
   + выполнить списание со счета;
   + создать новый счет;
   + закрыть счет.

Информация о счетах храниться в бинарном файле.
Работу классов продемонстрировать на примере консольного приложения.

---
### Задание 6 (NET.W.2019.Oliseichik.10).
1. Для объектов класса Book (ISBN, автор, название, издательство, год издания,
количество страниц, цена) (домашнее задание 8-ого дня)
- реализовать возможность строкового представления различного вида.
Например, для объекта со значениями ISBN = 978-0-7356-6745-7, AuthorName
= Jeffrey Richter, Title = CLR via C#, Publisher = Microsoft Press, Year = 2012,
NumberOPpages = 826, Price = 59.99$, могут быть следующие варианты:
+ Jeffrey Richter, CLR via C#
+ Jeffrey Richter, CLR via C#, &quot;Microsoft Press&quot;, 2012
+ ISBN 13: 978-0-7356-6745-7, Jeffrey Richter, CLR via C#, &quot;Microsoft Press&quot;,
2012, P. 826.
+ Jeffrey Richter, CLR via C#, &quot;Microsoft Press&quot;, 2012
+ ISBN 13: 978-0-7356-6745-7, Jeffrey Richter, CLR via C#, &quot;Microsoft Press&quot;,
2012, P. 826., 59.99$.
и т.д.
