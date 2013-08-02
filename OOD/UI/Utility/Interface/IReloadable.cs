namespace OOD.UI.Utility.Interface
{
    public interface IReloadable
    {
        void Reload();

        int GetLevel();

        void Restore();

        bool RestoreAble();
    }
}