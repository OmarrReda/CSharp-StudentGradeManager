
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

