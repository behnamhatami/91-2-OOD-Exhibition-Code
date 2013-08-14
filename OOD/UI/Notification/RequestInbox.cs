#region

using System;
using OOD.UI.Utility.Base;

#endregion

namespace OOD.UI.Notification
{
    public partial class RequestInbox : MainWindow
    {
        public RequestInbox()
        {
            InitializeComponent();
        }

        // IResetAble

        public override void Reset()
        {
            tabControl1.Controls.Clear();

            ExhibitionRequestTabPageReset();
            if (HasExhibitionRequestTabPagePreCondition())
                tabControl1.Controls.Add(exhibitionRequestTabPage);
        }

        // IPrecondition

        public override bool NeedUser()
        {
            return true;
        }


        public override bool NeedExhibition()
        {
            return false;
        }

        public override bool ValidatePreConditions()
        {
            //TODO
            if (!base.ValidatePreConditions())
                return false;
        }

        //IReloadAble

        public override int GetLevel()
        {
            return 3;
        }

        public override bool RestoreAble()
        {
            return true;
        }

        // Finish

        // Exhibition Request

        private bool HasExhibitionRequestTabPagePreCondition()
        {
            return Program.Exhibition == null;
        }

        private void ExhibitionRequestTabPageReset()
        {
            //TODO
        }

        private void exhibitionShowButton_Click(object sender, EventArgs e)
        {
            //TODO
        }
    }
}