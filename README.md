
# Student Grade Management System

A simple **C# Console Application** for managing students, courses, and grades.
This project was built to practice **OOP principles**, data structures, and clean program structure in C#.

---

## 📌 Features

- Add students with unique IDs
- Add courses with unique course IDs
- Assign one grade per student per course
- Calculate:
  - Student average grade
  - Course average grade
- Generate reports without tightly coupling logic to console output
- Menu-driven console interface


---

## 🧠 Design Overview

- **Student**
  - Stores grades in a `Dictionary<string, double>`
  - Calculates student average
- **Course**
  - Manages enrolled students
  - Calculates course average
- **Grade (Manager)**
  - Acts as the coordinator between students and courses
  - Handles searching, adding, and reporting
- **Program**
  - Handles all user interaction (input/output)

> Business logic is kept out of `Program.cs` as much as possible.

---

## ▶️ How to Run

1. Open the project in **Visual Studio**
2. Build the solution
3. Run the program
4. Use the menu to interact with the system

---

## 🧪 Example Actions

- Add a student → `ID: 101`
- Add a course → `ID: cs101`
- Assign grade → Student `101`, Course `cs101`, Grade `90`
- Calculate averages
- Generate reports

---

## 🎯 Learning Goals

This project focuses on:
- Object-Oriented Programming (OOP)
- Separation of concerns
- Dictionaries & Lists
- Nullable types (`double?`)
- Clean method responsibilities
- Avoiding tight coupling with `Console.WriteLine`

---

