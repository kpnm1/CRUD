﻿namespace src
{
    internal class Program
    {

        public static List<string> PhoneNumbers = new List<string>();

        public static void DataSeed()
        {
            PhoneNumbers.Add("+998946542132");
            PhoneNumbers.Add("+998907418877");
            PhoneNumbers.Add("+998956547888");
            PhoneNumbers.Add("+998911112233");
            PhoneNumbers.Add("+998334445566");
        }

        static void Main(string[] args)
        {
            // CRUD Phone number

            DataSeed();
            StartFrontend();
        }

        public static void StartFrontend()
        {
            while (true)
            {
                Console.WriteLine("1. Add phone number");
                Console.WriteLine("2. Delete phone number");
                Console.WriteLine("3. Update phone number");
                Console.WriteLine("4. Read");
                Console.Write("Choose: ");
                var number = int.Parse(Console.ReadLine());

                if (number == 1)
                {
                    Console.Write("Enter phone number: ");
                    var phoneNumber = Console.ReadLine();
                    var result = AddPhoneNumber(phoneNumber);
                    if (result >= 0)
                    {
                        Console.WriteLine($"Phone number successfully \nadded to '{result}' index");
                    }
                    else
                    {
                        Console.WriteLine("Error, something wrong!");
                    }
                }
                else if (number == 2)
                {
                    Console.Write("Enter deletable phone number: ");
                    var text = Console.ReadLine();
                    var result = DeletePhoneNumber(text);
                    if (result is true)
                    {
                        Console.WriteLine("Phone number successfully deleted!");
                    }
                    else
                    {
                        Console.WriteLine("Error, something wrong!");
                    }
                }
                else if (number == 3)
                {
                    Console.Write("Enter updatable phone number: ");
                    var oldPNumber = Console.ReadLine();
                    Console.Write("Enter new phone number: ");
                    var newPNumber = Console.ReadLine();

                    var result = UpdatePhoneNumber(oldPNumber, newPNumber);
                    if (result is true)
                    {
                        Console.WriteLine("Phone number successfully updated!");
                    }
                    else
                    {
                        Console.WriteLine("Error, something wrong!");
                    }
                }
                else if (number == 4)
                {
                    var response = PhoneNumbers;
                    foreach (var phoneNumber in response)
                    {
                        Console.WriteLine(phoneNumber);
                    }
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        public static int AddPhoneNumber(string phoneNumber)
        {
            var intValue = -1;
            var exists = PhoneNumbers.Contains(phoneNumber);
            var isValidFormat = CheckFormat(phoneNumber);
            if (exists is true || isValidFormat is false)
            {
                return intValue;
            }
            PhoneNumbers.Add(phoneNumber);

            return PhoneNumbers.Count + intValue;
        }

        public static bool DeletePhoneNumber(string phoneNumber)
        {
            var boolValue = true;
            var exists = PhoneNumbers.Contains(phoneNumber);
            if (exists is true)
            {
                PhoneNumbers.Remove(phoneNumber);
            }
            else
            {
                boolValue = false;
            }

            return boolValue;
        }

        public static bool UpdatePhoneNumber(string oldPhoneNumber, string newPhoneNumber)
        {
            var boolValue = true;
            var exists = PhoneNumbers.Contains(oldPhoneNumber);
            var isValidFormat = CheckFormat(newPhoneNumber);
            if (exists is true && isValidFormat is true)
            {
                var indexOfOLdPhoneNumber = PhoneNumbers.IndexOf(oldPhoneNumber);
                PhoneNumbers[indexOfOLdPhoneNumber] = newPhoneNumber;
            }
            else
            {
                boolValue = false;
            }

            return boolValue;
        }

        public static bool CheckFormat(string phoneNumber)
        {
            var length = phoneNumber.Length == 13;
            var starting = phoneNumber[0] == '+' && phoneNumber[1] == '9' &&
                phoneNumber[2] == '9' && phoneNumber[3] == '8';
            var isNumber = true;
            for (var i = 1; i <= phoneNumber.Length - 1; i++)
            {
                if (char.IsDigit(phoneNumber[i]) is false)
                {
                    isNumber = false;
                    break;
                }
            }

            return isNumber && starting && length;
        }

        public static List<string> ShowPhoneNumbers()
        {
            return PhoneNumbers;
        }
    }
}
