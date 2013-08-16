namespace OOD.UI.UtilityPackage.Interface
{
    public interface IPreCondition
    {
        bool NeedUser();

        bool NeedExhibition();

        bool ValidatePreConditions();

        void PreConditionResolver();
    }
}