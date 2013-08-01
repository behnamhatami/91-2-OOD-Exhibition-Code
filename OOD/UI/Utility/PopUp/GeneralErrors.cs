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

        public static bool IsNull(object obj, string state)
        {
            if (obj != null)
                return false;
            PopUp.ShowError(String.Format("{0} را انتخاب کنید.", state));
            return true;
        }

        public static bool IsZero(int count, string state)
        {
            if (count != 0)
                return false;
            PopUp.ShowError(String.Format("شما باید حداقل یک {0} انتخاب نمایید.", state));
            return true;
        }
    }
}