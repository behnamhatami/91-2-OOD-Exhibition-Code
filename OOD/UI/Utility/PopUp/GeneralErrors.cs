using System;

namespace OOD.UI.Utility.PopUp
{
    public static class GeneralErrors
    {
        public static bool IsEmptyField(string field, string name, string state = "")
        {
            if (field != "")
                return false;
            PopUp.ShowError(String.Format("لطفا {1} {0} خود را وارد کنید.", state, name));
            return true;
        }

        public static bool IsNull(object obj, string name)
        {
            if (obj != null)
                return false;
            PopUp.ShowError(String.Format("{0} را انتخاب کنید.", name));
            return true;
        }

        public static bool IsZero(int count, string name)
        {
            if (count != 0)
                return false;
            PopUp.ShowError(String.Format("شما باید حداقل یک {0} انتخاب نمایید.", name));
            return true;
        }

        public static bool IsNotValidInt(string input, int minValue, string name)
        {
            int res;
            if (!int.TryParse(input, out res))
            {
                PopUp.ShowError(String.Format("لطفا برای {0} یک عدد وارد نمایید.", name));
                return true;
            }
            if (res < minValue)
            {
                PopUp.ShowError(String.Format("لطفا برای {0} یک عدد بزرگتر از {1} وارد نمایید.", name, minValue));
                return true;
            }

            return false;
        }

        public static void AccessDenied()
        {
            PopUp.ShowError("شما حق دسترسی به این قسمت را ندارید.");
        }
    }
}