namespace EmployeeManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> name = new List<string>();
            List<string> surname = new List<string>();
            List<string> fatherName = new List<string>();
            List<int> age = new List<int>();
            List<string> FIN = new List<string>();
            List<string> phoneNo = new List<string>();
            List<string> position = new List<string>();
            List<decimal> salary = new List<decimal>();
            while (true)
            {
                Console.WriteLine("-For adding new new employee enter 1");
                Console.WriteLine("-For seeing informations about employees enter 2");
                string option = Console.ReadLine();
                if (option == "1")
                {
                    int i = 0;
                    while (true)
                    {
                        name.Add(GetName());
                        surname.Add(GetSurname());
                        fatherName.Add(GetFatherName());
                        age.Add(GetAge());
                        FIN.Add(GetFIN());
                        phoneNo.Add(GetPhoneNumber());
                        position.Add(GetPosition());
                        salary.Add(GetSalary());
                        Console.WriteLine($"Information added, {name[i]} {surname[i]}");
                        Console.WriteLine("To exit write /exit");
                        option = Console.ReadLine();
                        if (option == "/exit")
                            break;
                        i++;
                    }
                }
                else if (option == "2")
                {
                    for (int i = 0; i < name.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}.Full Name : {name[i]} {surname[i]} {fatherName[i]}, Age : {age[i]}, FIN : {FIN[i]}," +
                            $" Phone number : {phoneNo[i]}, Position : {position[i]}, Salary : {salary[i]}");
                    }
                }
                else
                    Console.WriteLine("Please enter valid input");
                Console.WriteLine("===============================================================================");
            }
        }
        private static string GetName()
        {
            string name;
            while (true)
            {
                Console.Write("Your name : ");
                name = Console.ReadLine();
                if (IsFirstUpperAndRestLower(name) && IsLengthCorrect(name, 2, 20))
                {
                    break;
                }
                else
                    Console.WriteLine("Please enter valid input\n" +
                        "(length should be between 2 and 20 , first letter should be Upper and Rest are Lower ");
            }
            return name;

        }

        private static string GetSurname()
        {
            string surname;
            while (true)
            {
                Console.Write("Your surname : ");
                surname = Console.ReadLine();
                if (IsFirstUpperAndRestLower(surname) && IsLengthCorrect(surname, 2, 35))
                {
                    break;
                }
                else
                    Console.WriteLine("Please enter valid input\n" +
                        "(length should be between 2 and 35 , first letter should be Upper and Rest are Lower ");
            }
            return surname;

        }

        private static string GetFatherName()
        {
            string name;
            while (true)
            {
                Console.Write("Your father's name : ");
                name = Console.ReadLine();
                if (IsFirstUpperAndRestLower(name) && IsLengthCorrect(name, 2, 20))
                {
                    break;
                }
                else
                    Console.WriteLine("Please enter valid input\n(length should be between 2 and 20 , first letter should be Upper and Rest are Lower ");
            }
            return name;
        }

        private static int GetAge()
        {
            int age = 0;
            while (true)
            {
                Console.Write("Your age : ");
                age = int.Parse(Console.ReadLine());
                if (age > 18 && age < 65)
                    break;
                else
                    Console.WriteLine("Please enter valid input\n(age should be between 18 and 65)");
            }
            return age;
        }

        private static string GetFIN()
        {
            string fin;
            while (true)
            {
                Console.Write("Your FIN code : ");
                fin = Console.ReadLine();
                if (fin.Length == 7 && IsFINCorrect(fin))
                    break;
                else
                    Console.WriteLine("Please enter valid input\n" +
                        "FIN code should contain only numbers and capital letters , and lenght should be 7 ");
            }
            return fin;
        }

        private static string GetPhoneNumber()
        {
            string phoneNo;
            while (true)
            {
                Console.Write("Your Phone number : ");
                phoneNo = Console.ReadLine();
                if (phoneNo.Length == 13 && IsPhoneNoCorrect(phoneNo))
                    break;
                else
                    Console.WriteLine("Please enter valid input\n" +
                  "Phone number should look like '+994*********' ");
            }
            return phoneNo;
        }

        private static string GetPosition()
        {
            string[] positions = { "HR", "Audit", "Engineer" };
            string position;
            bool isContains = false;
            while (true)
            {
                Console.Write("Your position : ");
                position = Console.ReadLine();
                for (int i = 0; i < positions.Length; i++)
                {
                    if (position == positions[i])
                    {
                        isContains = true;
                        break;
                    }
                }
                if (isContains)
                    break;
                else
                {
                    Console.WriteLine("Please enter valid position from the list : ");
                    for (int i = 0; i < positions.Length; i++)
                    {
                        Console.WriteLine(positions[i]);
                    }
                }
            }
            return position;
        }

        private static decimal GetSalary()
        {
            decimal salary;
            while (true)
            {
                Console.Write("Your salary : ");
                salary = decimal.Parse(Console.ReadLine());
                if (salary >= 1500 && salary <= 5000)
                    break;
                else
                    Console.WriteLine("Please enter valid input\nsalary should be between 1500 and 5000");
            }
            return salary;
        }


        private static bool IsFirstUpperAndRestLower(string word)
        {
            bool isFirstUpper = false;
            bool isLower = true;
            if ((int)word[0] >= 65 && (int)word[0] <= 90)
                isFirstUpper = true;
            for (int i = 1; i < word.Length; i++)
            {
                int value = (int)word[i];
                if (value < 97 || value > 122)
                {
                    isLower = false;
                    break;
                }
            }
            if (isFirstUpper && isLower)
                return true;
            return false;
        }

        private static bool IsLengthCorrect(string word, int start, int end)
        {
            if (word.Length > start && word.Length < end)
                return true;
            return false;
        }

        private static bool IsFINCorrect(string fin)
        {
            for (int i = 0; i < fin.Length; i++)
            {
                int value = (int)(fin[i]);
                if (!(value >= 65 && value <= 90) && !(value >= 48 && value <= 57))
                    return false;
            }
            return true;
        }

        private static bool IsPhoneNoCorrect(string phoneNo)
        {
            bool isCountryCodeCorrect = false;
            bool isNumberCorrect = true;
            if (phoneNo[0] == '+' && phoneNo[1] == '9' && phoneNo[2] == '9' && phoneNo[3] == '4')
                isCountryCodeCorrect = true;
            for (int i = 4; i < phoneNo.Length; i++)
            {
                int value = (int)phoneNo[i];
                if (value < 48 || value > 57)
                {
                    isNumberCorrect = false;
                    break;
                }
            }
            if (isCountryCodeCorrect && isNumberCorrect)
                return true;
            return false;
        }
    }
}
