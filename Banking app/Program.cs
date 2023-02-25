using System;
public class cardHolder
{
    String cardNum;
    int pin;
    String firstName;
    String lastName;
    double balance;

    public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }
    public String getNum()
    {
        return cardNum;
    }

    public int getPin()
    {
        return pin;
    }

    public String getFirstName()
    {
        return firstName;
    }

    public String getLastName()
    {
        return lastName;
    }

    public double getBalance()
    {
        return balance;
    }

    public void setPin(int newPin)
    {
        pin = newPin;
    }

    public void setFirstName(String newFirstName)
    {
        firstName = newFirstName;
    }

    public void setLastName(String newLastName)
    {
        lastName = newLastName;
    }

    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }

    public static void Main(String[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options...");
            Console.WriteLine("1. Deposite");
            Console.WriteLine("2. Withdrawl");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much money would you like to deposit: ");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + deposit);
            Console.WriteLine("Thank you for your deposit. Your new balance is; " + currentUser.getBalance());
        }

        void withdrawl(cardHolder currentUser)
        {
            Console.WriteLine("How much money would you like to withdraw: ");
            double withdrawl = Double.Parse(Console.ReadLine());
            //Check if user has enough money 
            if (currentUser.getBalance() < withdrawl)
            {
                Console.WriteLine("Insufficient balance");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdrawl);
                Console.WriteLine("Your transaction is complete thank you");
            }
        }

        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Current Balance:" + currentUser.getBalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("456123156456", 1234, "Jesse", "Santos", 10000000000.32));
        cardHolders.Add(new cardHolder("456123156457", 5678, "Eric", "Contretras", 510.30));
        cardHolders.Add(new cardHolder("456123156458", 9101, "Johnny", "Stockton", 1000.32));
        cardHolders.Add(new cardHolder("456123156459", 9213, "Gloria", "Smith", 55.05));
        cardHolders.Add(new cardHolder("456123156450", 9315, "Jessie", "Trujillo", 150.32));

        //Prompt User
        Console.WriteLine("Welcome to Simple Bank");
        Console.WriteLine("Please insert your debt card");

        String debitCardNum = "";
        cardHolder currentUser;

        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                //Check against DataBase
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if (currentUser != null) { break; }
                else { Console.WriteLine("Account not found. Please try again"); }
            }
            catch
            {
                Console.WriteLine("Account not found. Please try again");
            }
        }

        Console.WriteLine("Please enter your pin: ");
        int userPin = 0;

        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                //Check against DataBase
                if (currentUser.getPin() == userPin) { break; }
                else { Console.WriteLine("Incorrect pin. Please try again."); }
            }
            catch
            {
                Console.WriteLine("Incorrect pin. Please try again");
            }
        }

        Console.WriteLine("Welcome " + currentUser.getFirstName());
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch
            {

            }
            if(option == 1) { deposit(currentUser); }
            else if(option == 2) { withdrawl(currentUser); } 
            else if(option == 3) { balance(currentUser); }
            else if(option == 4 ) { break; }
            else { option = 0; }
        }
        while (option != 4);
        Console.WriteLine("Thank you! Have a great day");
    }
}