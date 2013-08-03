#region

using OOD.Model.ExhibitionPackage.ExhibitionDefinition;
using OOD.Model.ExhibitionPackage.ExhibitionRoles;

#endregion

namespace OOD.UI.Utility.Helper
{
    internal class NotificationFactory
    {
        public static string ExhibitionRoleAddedTitle
        {
            get { return "افزودن نقش جدید"; }
        }

        public static string ExhibitionRoleRemovedTitle
        {
            get { return "حذف نقش نمایشگاه"; }
        }

        public static string ExhibitionCreationTitle
        {
            get { return "نمایشگاه جدید"; }
        }

        public static string ExhibitionRoleAddedContent(Exhibition exhibition, ExhibitionRole role)
        {
            return string.Format("شما به عنوان {0} در نمایشگاه {1} عضو شدید.", role, exhibition);
        }

        public static string ExhibitionRoleRemovedContent(Exhibition exhibition, ExhibitionRole role)
        {
            return string.Format("شما از نقش {0} در نمایشگاه {1} حذف شدید.", role, exhibition);
        }

        public static string ExhibitionCreationContent(Exhibition exhibition)
        {
            return string.Format("نمایشگاه {0} ساخته شد.", exhibition);
        }
    }
}