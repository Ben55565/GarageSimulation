namespace Ex03.ConsoleUI
{
    internal class InputValidations
    {
        public static bool MenuChoiceInputValidation(string i_Input)
        {
            bool isValid = true;
            if (i_Input == null || i_Input.Length != 1)
            {
                isValid = false;
            }
            else
            {
                char.TryParse(i_Input, out char inputChar);
                if (inputChar == 'q' || inputChar == 'Q')
                {
                    isValid = true;
                }
                else if (char.IsDigit(inputChar))
                {
                    int.TryParse(i_Input, out int inputInt);
                    if (inputInt < 1 || inputInt > 7)
                    {
                        isValid = false;
                    }
                }
                else
                {
                    isValid = false;
                }
            }

            return isValid;
        }

        public static bool CarIdValidation(string i_Input)
        {
            bool isValid = true;
            if (i_Input == null)
            {
                isValid = false;
            }
            else
            {
                foreach (char digit in i_Input)
                {
                    if (char.IsDigit(digit))
                    {
                        continue;
                    }

                    isValid = false;
                    break;
                }
            }

            return isValid;
        }
    }
}
