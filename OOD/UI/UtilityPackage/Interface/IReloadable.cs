namespace OOD.UI.UtilityPackage.Interface
{
    public interface IReloadable
    {
        void Reload();

        int GetLevel();

        void Restore();

        bool RestoreAble();
    }
}