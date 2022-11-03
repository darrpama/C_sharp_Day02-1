# Day 02 – .NET Boot camp
### OOP

# Contents
1. [Chapter I](#chapter-i) \
	[General Rules](#general-rules)
2. [Chapter II](#chapter-ii) \
	[Rules of the Day](#rules-of-the-day)
3. [Chapter III](#chapter-iii) \
	[Exercise 00 – How much money does money cost?](#exercise-00-how-much-money-does-money-cost)
4. [Chapter IV](#chapter-iv) \
	[Exercise 01 – Work-life balance](#exercise-01-work-life-balance)


# Chapter I 

## General Rules
- Make sure you have [the .NET 5 SDK](<https://dotnet.microsoft.com/download>) installed on your computer and use it.
- Remember, your code will be read! Pay special attention to the design of your code and the naming of variables. Adhere to commonly accepted [C# Coding Conventions](<https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions>).
- Choose your own IDE that is convenient for you.
- The program must be able to run from the dotnet command line.
- Each of the exercise contains examples of input and output. The solution should use them as the correct format.
- At the beginning of each task, there is a list of allowed language constructs.
- If you find the problem difficult to solve, ask questions to other piscine participants, the Internet, Google or go to StackOverflow.
- You may see the main features of C# language in [official specification](<https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/introduction>).
- Avoid hard coding and "magic numbers".
- You demonstrate the complete solution, the correct result of the program is just one of the ways to check its correct operation. Therefore, when it is necessary to obtain a certain output as a result of the work of your programs, it is forbidden to show a pre-calculated result.
- Pay special attention to the terms highlighted in **bold** font: their study will be useful to you both in performing the current task, and in your future career of a .NET developer.
- Have fun :)


# Chapter II
##  Rules of the Day

- You cannot use nuget packages.
- All projects must be in the same solution.
- Each of the tasks must correspond to a separate console application created based on a standard .NET SDK template.
- Use **top-level-statements**  and **var**.
- The name of the project (and its separate catalog) should look like d{xx}_ex{yy}, where xx is the digits of the current day, yy is the digits of the current task.
- The name of the solution (and its separate catalog) is d_{xx}, where xx are the digits of the current day.
- To format the output data, use the en-GB **culture**: N2 for the output of monetary amounts, d for dates.
- Data files in exercises are considered correct and do not need validation.


# Chapter III
## Exercise 00 – How much money does money cost?

“Engineering is a profession that can do the job of almost all other professions.”

**― Amit Kalantri, Wealth of Words**

### What's new

- Structs
- Override
- String interpolation
- System.IO

### Project structure:
```
d02_ex00
      Program.cs
      Exchanger.cs
      Models
            ExchangeRate.cs
            ExchangeSum.cs
```

### The objective

You are already a more experienced programmer, so with your experience, the complexity of your tasks increases. You are already guided by the principles of **SOLID** in development and break your code into **classes** and **structs**.

Your next challenge is the implementation of a currency converter for EUR-RUB, USD-RUB, EUR-USD, USD-EUR, RUB-USD, RUB-EUR pairs. At the input, the program will request an amount in one of the permitted currencies (EUR, RUB, USD). In response, it will display a table that contains the amounts converted into other permitted currencies. For convenience, we determine that each currency has its own unique identifier code (EUR, RUB, USD). For data representation, **structs** are suitable: then for the amount in the currency, you can define *ExchangeSum* (amount, identifier), and for exchange information - *ExchangeRate* (currency "from”, currency "to", exchange rate).

Use the **single-responsibility principle**! According to it, your structs should not be aware of other currencies and exchange rates. But they can independently parse data from text or define the format of output data when casting to a string. **Overriding** the ToString() method can help you. 

Information about the exchange rates is provided by the exchanger / stock exchange. In the archive attached to the exercise, you will find files with conversion ratios. We assume that the data format in the file is strictly specified. The files are supposed to be updated once a day, so the folder path will be one of the input arguments.

The functionality of the exchanger should be separated into a separate *Exchanger* class. It will contain a collection of exchange rates, parse them from files and convert them. Remember, *Exchanger* does not need to know where it is called from and what the result is used for - do not make it responsible for outputting to the terminal.

If the conversion method returns a list of possible amounts in the currency, its use will be much more flexible.

Look into the **yield** statement, it can be useful. 

|Argument|Type|Description|
|---|---|---|
| sum |string | Amount with currency indication |
|ratesDirectory | string | The path to the folder with files with conversion rates|

### Output format
```
Amount in the original currency: 100.00 RUB
Amount in USD: 1.36 USD
Amount in EUR: 1.11 EUR

Amount in the original currency: 100.00 EUR
Amount in USD: 81.97 USD
Amount in RUB: 8,990.38 RUB
```

### The user specified incorrect data
```
Input error. Check the input data and repeat the request.
```

### Example of launching an application from the project folder

```
$ dotnet run “100 RUB” “path/to/folder”
Amount in the original currency: 100.00 RUB
Amount in USD: 1.36 USD
Amount in EUR: 1.11 EUR
```

# Chapter IV
### Exercise 01 – Work-life balance

“My point is, life is about balance. The good and the bad. The highs and the lows. The pina and the colada.”

**― Ellen DeGeneres, Seriously... I'm Kidding**

### What's new

- Classes, records
- Enum
- Lists, arrays
- Inheritance
- Polymorphism
- Override
- String interpolation

### Project structure:

```
d02_ex01
      Program.cs
      Tasks/
            Task.cs
            TaskType.cs
            TaskPriority.cs
            TaskState.cs

```

### The objective

You work more long hours. Your family, your cat and your favorite succulent began to forget what you look like. In order to strike balance between work, study and personal life, you decide to create a personal task tracker for yourself. 

Think about what a task is, so we can design our application based on the **domain knowledge**. Task is a goal, a problem to solve. To know the content of a goal, you need to describe it. To find it among others, you need to set a title. To achieve your goals, you need to set deadlines. So, the task should have: *a title*, *a description*, and *a due date*.

In addition, tasks will be much more convenient to navigate, if *a priority (Low, Normal, High)* and *a category (Work, Study, Personal)* can be assigned. This is where **enum** will help us.

The status of the task can change: it is created as a *New* one, after all the work is completed, it becomes *Completed*, in addition, the tasks that no longer make sense to work on, can be marked with the *Irrelevant* status, so you do not return to them again. The task can only be in one status and move between them in a certain order (*Completed* ones cannot become *Irrelevant*): sounds like **a state machine**.

You need to implement a program that allows you to create a task list with the ability to display the list, add a new one, or mark the task as Completed or Irrelevant.
Task properties must be closed for external changes. To change statuses, the task must provide special methods that **encapsulate** the logic of changing the status.

### Method 1. Creating the task

```
> add
> Enter a title
> {title}
> Enter a description
> {summary}
> Enter the deadline
> {dueDate}
> Enter the type
> {type}
> Assign the priority
> {priority}

```

Note: the status of the task is not specified by input. The task should always be created in the *New* status.

#### Input parameters

|Argument|Type|Description|
|---|---|---|
| title |string, required | Task title |
|summary | string, not required | Description of what needs to be done|
|dueDate | datetime (nullable), not required | By what date the task is planned to be completed|
|type | enum [Work, Study, Personal], required | Task type |
|priority| enum [Low, Normal, High], not required (default value: Normal)| Task priority |

Pay attention to the required input arguments! If the parameter is required, you need to check it at the input. If it is not required, the corresponding field in the class must be nullable. Remember, string is **a reference type**, and it is **nullable** by default. DateTime and enum are **value types**, and they need to be explicitly specified as nullable.

#### Output format

```
{task.Title}
[{task.Type}] [{task.State}]
Priority: {task.Priority}, Due till {task.DueDate}
{task.Summary}
```

#### Response format in case of an empty date

```
{task.Title}
[{task.Type}] [{task.State}]
Priority: {task.Priority}
{task.Summary}
```

#### Sample response

```
- Water the flowers
[Personal] [New]
Priority: High, Due till 11/21/2021
Water the flowers in the kitchen and living room. Do not forget about your favorite succulent!
```
#### The user specified incorrect data
```
Input error. Check the input data and repeat the request.
```

### Method 2. Task List

```
> list
```

To set the format for displaying a task in one place, you can override the ToString() method of the task. If the list is empty, you need to display a message about it.
You don't need to sort the tasks.

#### Output format

```
- {task.Title}
[{task.Type}] [{task.State}]
Priority: {task.Priority}, Due till {task.DueDate}
{task.Summary}
```

#### Empty list
```
The task list is still empty.
```

### Sample response

```
- Water the flowers
[Personal] [New]
Priority: Normal, Due till 11/5/2021
Water the flowers in the kitchen and living room. Do not forget about your favorite succulent

- Finish Day 02
[Study] [Done]
Priority: High, Due till 11/21/2021
Finish all the exercises of the day 02 of the .NET piscine, upload everything to the repository.

```

### Method 3. Completing the task

```
> done
> Enter a title
> {title}
```

Here we refer to a specific task by the title, considering it to be a unique identifier for simplicity.

#### Input parameters

|Argument|Type|Description|
|---|---|---|
| title |string, required | The title of the required task to close |

#### The task does not exist
```
Input error. The task with this title was not found
```

#### The user specified incorrect data
```
Input error. Check the input data and repeat the request.
```

#### Sample response
```
The task [Water the flowers] is completed!
```
### Method 4. The task is not relevant

```
> wontdo
> Enter a title
> {title}
```

Here we refer to a specific task by the title, considering it to be a unique identifier for simplicity.

#### Input parameters

|Argument|Type|Description|
|---|---|---|
| title |string, required | The title of the required task to close |

#### The task does not exist
```
Input error. The task with this title was not found
```

#### The user specified incorrect data
```
Input error. Check the input data and repeat the request.
```

#### Sample response
```
The task [Water the flowers] is no longer relevant!
```

### Exit

The application shuts down if you enter

```
> quit
```

or

```
> q
```
