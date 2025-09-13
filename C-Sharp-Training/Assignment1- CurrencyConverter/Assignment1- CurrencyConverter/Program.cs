// Prompt for user
Console.WriteLine("Enter INR rupees");
//Reading inr input from user
double INR = Convert.ToDouble(Console.ReadLine());

//converting inr to different Currencies
//Using Math. Round method to round of the values upto 4 places after decimal
double USD = Math.Round(INR * 0.011, 4);
double CAD = Math.Round(INR * 0.0157, 4);
double GBP = Math.Round(INR * 0.008365, 4);
double EUR = Math.Round(INR * 0.009673, 4);


// Printing outputs in 1 line
Console.WriteLine($"INR= {INR} is equals to {USD} USD, {CAD} CAD, {GBP} GBP and {EUR} EUR");