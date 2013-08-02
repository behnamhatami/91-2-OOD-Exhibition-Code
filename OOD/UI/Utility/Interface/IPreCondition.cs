namespace OOD.UI.Utility.Interface
{
    public interface IPreCondition
    {
        bool NeedUser();

        bool NeedExhibition();

        bool ValidatePreConditions();

        void PreConditionResolver();
    }
}