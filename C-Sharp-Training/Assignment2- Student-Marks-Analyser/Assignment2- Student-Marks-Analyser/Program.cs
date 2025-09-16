using Assignment2StudentMarksAnalyser; // USING INTERNAL CLASS


int numberOfStudents;  // number of students can be changes from here
int numberOfSubjects = 5;
int numberOfGuesses = 2;    // number of Guesses allowed in game
int numberOfChances = 3;    // number of times user can enter invalid data

string[] subjects = { "Hindi", "English", "Math", "Science", "Practical" };



// FUNCTIONS
int readMarks(int limit)
{
    int subjectMarks, counter = 0;
    bool isNumber = int.TryParse(Console.ReadLine(), out subjectMarks);
    while (!isNumber || subjectMarks < 0 || subjectMarks > 100)
    {
        // If invalid answers crosses limit
        if (counter == limit)
        {
            Console.WriteLine("Number of limits exceeded. Marks set to 0");
            subjectMarks = 0;
            break;
        }

        counter++;
        Console.Write($"\nInvalid input!!\nEnter a non-negative number that must be less than or equal to 100." +
            $"\nChances Left: {limit - counter}\n" +
            $"After that defualt marks 0 will be alloted.\n\n ");

        //Again check if number is valid
        isNumber = int.TryParse(Console.ReadLine(), out subjectMarks);
    }
    return subjectMarks;

}




// Guess the number game function
void guessGame(Student[] students)
{
    Random random = new Random();  // Secret code for guess number game

    foreach (Student student in students)
    {

        Console.WriteLine($"____________________________________Practical exam for {student.name}____________________________________");
        int practicalMarks = 0; // default value

        for (int j = 1; j <= numberOfGuesses; j++)
        {
            int secretCode = random.Next(1, 101);
            int guessedNum;

            Console.WriteLine($"Guess the number:{secretCode} ");
            bool isNumber = int.TryParse(Console.ReadLine(), out guessedNum);
            if (isNumber && guessedNum == secretCode)
            {
                practicalMarks = 100 / j;
                Console.WriteLine("You Passed");
                Console.WriteLine("Marks = " + practicalMarks);
                break;
            }
            else
            {
                Console.WriteLine($"Wrong Guess, {numberOfGuesses - j} chances left");
            }


        }
        // finally assigning practical marks to the student in case of failed
        student.marks[4] = practicalMarks;

        //if current student fails then display a msg
        if (student.marks[4] == 0) Console.WriteLine("You Failed in practical exam");
    }


}



// FIND MAXTOTAL OVERALL MARKS
int findMaxOverallTotal(Student[] student)
{
    int maxTotal = student[0].total;
    foreach (var person in student)
    {
        if (person.total > maxTotal) maxTotal = person.total;
    }
    return maxTotal;
}


// FUNCTION FOR PRINTING RESULT
void PrintResult(ref Student[] student)
{
    Console.WriteLine("\n\nStudent Marks Table");
    Console.WriteLine(new string('_', 90));

    Console.WriteLine("{0,-15}{1,8}{2,10}{3,8}{4,10}{5,12}{6,10}",
        "Student", "Hindi", "English", "Math", "Science", "Practical", "Total");

    Console.WriteLine(new string('_', 90));

    for (int i = 0; i < student.Length; i++)
    {
        Console.WriteLine("{0,-15}{1,8}{2,10}{3,8}{4,10}{5,12}{6,10}",
            student[i].name,
            student[i].marks[0],
            student[i].marks[1],
            student[i].marks[2],
            student[i].marks[3],
            student[i].marks[4],
            student[i].total);
    }

    Console.WriteLine(new string('_', 90));
    Console.WriteLine();
}


//FUNCTION FOR PRINTING TOPPERS

void PrintTopers(ref Student[] student, ref int maxOverallTotal, ref int[] maxSubjectMarks)
{
    Console.WriteLine("\n\nResult Table");
    Console.WriteLine(new string('_', 90));
    Console.WriteLine();

    Console.WriteLine("{0,-15}{1,-10}{2}", "Criteria", "Marks", "Name(s)");
    Console.WriteLine(new string('-', 90));

    // 1. Overall Toppers
    Console.Write("{0,-15}{1,-10}", "Overall", maxOverallTotal);

    for (int i = 0; i < student.Length; i++)
    {
        if (student[i].total == maxOverallTotal)
        {
            Console.Write($"{student[i].name} ");
        }
    }

    Console.WriteLine(); // New line after overall toppers

    // 2. Subject-wise toppers
    for (int i = 0; i < numberOfSubjects; i++) // loop through subjects
    {
        bool first = true; // to manage only one line per subject
        for (int j = 0; j < numberOfStudents; j++) // loop through students
        {
            if (student[j].marks[i] == maxSubjectMarks[i])
            {
                if (first)
                {
                    Console.Write("{0,-15}{1,-10}", subjects[i], maxSubjectMarks[i]);
                    first = false;
                }
                Console.Write($"{student[j].name} ");
            }
        }
        Console.WriteLine(); // new line after each subject's toppers
    }

    Console.WriteLine(new string('_', 90));
    Console.WriteLine();
}







// ACTUAL CODE BEGINS HERE





//Reading number of students
Console.WriteLine("Enter the number of students\n");

bool isNumber = int.TryParse(Console.ReadLine(), out numberOfStudents);
while (!isNumber || numberOfStudents < 0 || numberOfStudents > 100)
{
    Console.Write("Invalid input!!\nEnter a non-negative number that must be less than or equal to 100: ");
    isNumber = int.TryParse(Console.ReadLine(), out numberOfStudents);
}


// Declaring students
Student[] student = new Student[numberOfStudents];


int[] maxSubjectMarks = new int[numberOfSubjects];
// INPUTING DATA OF STUDENTS FROM TEACHERS
for (int i = 0; i < numberOfStudents; i++)
{
    // assigning memory to object reference
    student[i] = new Student();


    // 1. Inputing student name
    Console.WriteLine($"\nEnter name of Student {i + 1}");
    student[i].name = Console.ReadLine();

    // 2. Inputing marks of each subject - using loop
    for (int j = 0; j < numberOfSubjects - 1; j++)
    {
        Console.WriteLine($"Enter Marks in {subjects[j]}");
        student[i].marks[j] = readMarks(numberOfChances);
        maxSubjectMarks[j] = Math.Max(student[i].marks[j], maxSubjectMarks[j]);

    }



}
foreach(int marks in maxSubjectMarks)
{
    Console.WriteLine("  "+marks);
}


// GUESS THE NUMBER GAME
Console.WriteLine($"\n\nFor Practical exams, You will have to play Guess the number for practical exam:\n" +
    $"You will get {numberOfChances} chances.\nIf you guess in first attempt, you will recieve 100 marks, if you guess in 2nd attempt, you will get 50 marks\n" +
    $"Otherwise you will fail with 0 marks\n\n");

guessGame(student);



// finding max overall total marks
int maxOverallTotal = findMaxOverallTotal(student);


// printing tabular marks
PrintResult(ref student);

//printing Results
PrintTopers(ref student,ref maxOverallTotal,ref maxSubjectMarks);
