////int practicalMarksIndex = 4;


////function for finding maximum value of an array
//static int getMaxValue(int[] arr)
//{
//    int maxMarks = arr[0];
//    int indexForMaxMarks = 0;
//    for (int i = 1;i< arr.Length; i++)
//    {
//        if (arr[i] > maxMarks)
//        {
//            maxMarks = arr[i];
//            indexForMaxMarks = i;
//        }
//    }
//    //Array.ForEach(arr, num => {
//    //    // maxMarks = Math.Max(maxMarks,num))
//    //    if (num > maxMarks){
//    //        maxMarks = num;
//    //        indexForMaxMarks = 
//    //        };
//    //});

//    return maxMarks;
//}

////function for finding index of max element of the array
//static int getMaxIndex(int[] arr)
//{
//    int maxMarks = arr[0];
//    int indexForMaxMarks = 0;
//    for (int i = 1; i < arr.Length; i++)
//    {
//        if (arr[i] > maxMarks)
//        {
//            maxMarks = arr[i];
//            indexForMaxMarks = i;
//        }
//    }

//    return indexForMaxMarks;
//}


//// function for calculating sum of an array
//static int getSumOfArray(int[] arr) { 
//    int sum = 0;
//    Array.ForEach(arr, num => sum += num);
//    return sum;
//}


//int[,] marksDataStudentWise = { 
//   //s1 , s2, s3, s4, s5
//    { 70, 70, 70, 70, 0 },
//    { 80, 80, 40, 40, 0 }, 
//    { 70, 10, 70, 70, 0 }, 
//    { 10, 10, 70, 0, 0 }, 
//    { 70, 0, 80, 70, 0 } };

//int[,] marksDataSubjectWise = { { 70, 80, 70, 10, 70 },{ 70, 80, 10, 10, 0 }, {70, 40, 70, 70, 80 }, { 70, 40, 70, 0, 70}, { 0, 0, 0, 0, 0} };

//int numOfStudent = marksDataStudentWise.GetLength(0);
////Console.WriteLine(numOfStudent);
//int secretNum = 59;

//Console.WriteLine("Welcome to Student Marks Analyser");
//Console.WriteLine("You will have to play Guess the number for practical exam:");
//for(int i = 0; i < numOfStudent; i++)
//{
//    Console.WriteLine("\n\n");
//    Console.WriteLine($"Student{i+1}\n");
//    for (int j = 1; j <=2; j++)
//    {
//        int practicalMarks =0;
//        Console.WriteLine("Guess the number: ");
//        int guessedNum = int.Parse(Console.ReadLine());
//        if(guessedNum == secretNum) {
//            practicalMarks= (j == 1) ?100 :50;
//            Console.WriteLine( "You Passed");
//            Console.WriteLine( "Marks"+ practicalMarks);
//            marksDataStudentWise[i,4] = practicalMarks;
//            marksDataSubjectWise[4, i] = practicalMarks;
//            break;
//        }
//        else
//        {
//            Console.WriteLine( "You failed");
//        }
//    }

//}

//int[] SumOfMarksOfEachStudent = new int[numOfStudent];

////Function for creating a row out of a 2d array
//static int[] GetRow(int[,] array, int rowIndex)
//{
//    int columns = array.GetLength(1);
//    int[] row = new int[columns];

//    for (int i = 0; i < columns; i++)
//    {
//        row[i] = array[rowIndex, i];
//    }

//    return row;
//}


//// Calculating Sum of all students and storing in an array
//for (int i = 0;i < numOfStudent; i++)
//{
//    int[] row = GetRow(marksDataStudentWise, i);
//    SumOfMarksOfEachStudent[i] = getSumOfArray(row);
//}

//// overall topper

//int overallTopperIndex = getMaxIndex(SumOfMarksOfEachStudent);






// ACTUAL CODE BEGINS HERE


using Assignment2__Student_Marks_Analyser; // USING INTERNAL CLASS

int numberOfStudents = 2;  // number of students can be changes from here
int numberOfSubjects = 5;
int secretCode = 69;        // Secret code for guess number game
int numberOfChances = 2;    // number of chances allowed in game

string[] subjects = { "Hindi", "English", "Math", "Science", "Practical" };



Student[] student = new Student[numberOfStudents];

// inputing data
for(int i=0; i< numberOfStudents; i++)
{
    // assigning memory to object reference
    student[i] = new Student();


    // 1. Inputing student name
    Console.WriteLine($"\nEnter name of Student {i+1}");
    student[i].name = Console.ReadLine();

    // 2. Inputing marks of each subject - using loop
    for(int j=0; j<numberOfSubjects-1; j++)
    {
        Console.WriteLine($"Enter Marks in {subjects[j]}");
        
        //checking if element is valid number string or is not negative or is more than 100
        while(!int.TryParse(Console.ReadLine(),out student[i].marks[j]) || student[i].marks[j]<0 || student[i].marks[j] >100 ){
            Console.Write("Invalid input. Enter a non-negative number that must be less than or equal to 100: ");
        }
    }


    // 3. Guess the number game for practical marks
    Console.WriteLine($"For Practical exams, You will have to play Guess the number for practical exam:\n" +
        $"You will get {numberOfChances} chances.\nIf you guess in first attempt, you will recieve 100 marks, if you guess in 2nd attempt, you will get 50 marks\n" +
        $"Otherwise you will fail with 0 marks");

    //Guess the number game - looping number of chances time to guess the number
    int practicalMarks = 0; // default value

    for (int j = 1; j <= numberOfChances; j++)
    {
        Console.WriteLine("Guess the number: ");
        int guessedNum;
        while (!int.TryParse(Console.ReadLine(), out guessedNum) || guessedNum < 0 || guessedNum > 100)
        {
            Console.Write("Invalid input. Enter a non-negative number that must be less than or equal to 100: ");
        }
        if (guessedNum == secretCode)
        {
            practicalMarks = (j == 1) ? 100 : 50;
            Console.WriteLine("You Passed");
            Console.WriteLine("Marks= " + practicalMarks);
            break;
        }
        else
        {
            Console.WriteLine($"Wrong Guess, {numberOfChances- j} chances left");
        }


    }
     // finally assigning practical marks to the student in case of failed
     student[i].marks[4] = practicalMarks;

    //if current student fails then display a msg
    if (student[i].marks[4] == 0) Console.WriteLine("You Failed in practical exam");

}

    // finding max overall total marks
    int maxTotal = student[0].total;
    foreach(var person in student)
    {
        if(person.total > maxTotal) maxTotal = person.total;
    }

    // finding subject wise max numbers
    int[] maxSubjectMarks = new int[numberOfSubjects]; // array for storing max marks of each subject

    for (int i = 0; i < numberOfSubjects; i++)
    {
        maxSubjectMarks[i] = student[0].marks[i]; //  by default first student's value
        
        // loop for calculating max of current subject
        for(int j = 0; j < numberOfStudents; j++) {
            if (student[j].marks[i] > maxSubjectMarks[i]) 
                maxSubjectMarks[i] = student[j].marks[i];
        }

    }

// printing tabular marks
Console.WriteLine("\n\nStudent Marks Table");
Console.WriteLine("\n____________________________________________________________________________________________\n");

Console.WriteLine("{0,-12}{1,9}{2,9}{3,9}{4,9}{5,10}{6,9}",
    "Student", "Hindi", "English", "Math", "Science", "Practical", "Total"
    );

Console.WriteLine("____________________________________________________________________________________________\n");
for (int i = 0; i < numberOfStudents; i++)
{
    Console.WriteLine("{0,-12}{1,9}{2,9}{3,9}{4,9}{5,10}{6,9}",
        student[i].name,
        student[i].marks[0],
        student[i].marks[1],
        student[i].marks[2],
        student[i].marks[3],
        student[i].marks[4],
        student[i].total 
        );
}
Console.WriteLine("____________________________________________________________________________________________\n\n\n");


//printing Results
Console.WriteLine("\n\nResult Table");
Console.WriteLine("\n____________________________________________________________________________________________\n\n");


Console.WriteLine("{0,-12}{1,9}{2,9}",
    "Criteria", "Name", "Marks"
    );


//  1. printing overall toppers
for(int i = 0;i < numberOfStudents; i++)
{
    if(student[i].total == maxTotal)
        Console.WriteLine("{0,-12}{1,9}{2,9}", "Overall", $"{ student[i].name}", $"{maxTotal}"
         );
}

// 2. Printing Subject wise toppers


for (int i = 0; i < numberOfSubjects; i++) // loop for each subjects
{
    for(int j = 0; j < numberOfStudents; j++)   //loop for Each student
    {
        if (maxSubjectMarks[i] == student[j].marks[i])
            Console.WriteLine("{0,-12}{1,9}{2,9}", $"{subjects[i]}", $"{student[j].name}", $"{maxSubjectMarks[i]}");
    }

}

Console.WriteLine("____________________________________________________________________________________________\n\n");