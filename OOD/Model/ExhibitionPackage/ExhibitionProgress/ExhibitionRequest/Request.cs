﻿#region

using System;
using OOD.Model.ExhibitionPackage.ExhibitionDefinition;
using OOD.Model.ModelContext;
using OOD.Model.NotificationPackage;
using OOD.Model.UserManagingPackage;

#endregion

namespace OOD.Model.ExhibitionPackage.ExhibitionProgress.ExhibitionRequest
{
    public class Request
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
        public string Response { get; set; }
        public bool Responsed { get; set; }
        public bool Agreed { get; set; }

        public virtual Exhibition Exhibition { get; set; }
        public virtual User User { get; set; }


        public void NotifyResponse()
        {
            DataManager.DataContext.Notifications.Add(new Notification
            {
                Title = "به درخواست شما پاسخ داده شد",
                Content = Content + "\n" + Response,
                CreationDate = DateTime.Today,
                Exhibition = Exhibition,
                User = User
            });
        }

        public void NotifyAgree()
        {
            DataManager.DataContext.Notifications.Add(new Notification
            {
                Content = "درخواست شما: " + Content,
                CreationDate = DateTime.Today,
                Exhibition = Exhibition,
                Title = "با درخواست شما موافقت شد",
                User = User
            });
        }

        public override string ToString()
        {
            return String.Format("[از طرف: {0}، موضوع: {1}]", User, Title);
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public override bool Equals(object obj)
        {
            var request = obj as Request;
            if (request == null || request.Id != Id)
                return false;
            return true;
        }
    }
}