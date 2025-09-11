// Prompt for user
Console.WriteLine("Enter INR rupees");
//Reading inr input from user
double INR = Convert.ToDouble(Console.ReadLine());

//converting inr to different Currencies
double USD = INR * 0.011;
double CAD = INR * 0.0157;
double GBP = INR * 0.008365;
double EUR = INR * 0.009673;


// Printing outputs in 1 line
Console.WriteLine($"INR= {INR} is equals to {USD} USD, {CAD} CAD, {GBP} GBP and {EUR} EUR");