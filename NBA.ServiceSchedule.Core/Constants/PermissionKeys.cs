using NBA.ServiceSchedule.Core.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace NBA.ServiceSchedule.Core.Constants
{
    public static class PermissionKeys
    {
        public static readonly List<KeyValuePair<string, string>> Keys = new List<KeyValuePair<string, string>>();

        public static void FillKeys(Type type)
        {
            var permissions = GetClassConstants(type);
            Keys.AddRange(permissions);

            foreach (var typeInfo in type.GetTypeInfo().DeclaredNestedTypes)
            {
                var nestedType = typeInfo.AsType();
                FillKeys(nestedType);
            }
        }

        private static IEnumerable<KeyValuePair<string, string>> GetClassConstants(IReflect type)
        {
            var constants = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                .Where(fi => fi.IsLiteral && !fi.IsInitOnly).Select(fi => new KeyValuePair<string, string>(fi.GetValue(null).ToString(), fi.Description()));

            return constants;
        }

        public static class MenuKeys
        {
            public static class Documents
            {
                [Description("Servis quraşdırma sənədi")]
                public const string ServiceOperationDocument = "Menus.Documents.ServiceOperationDocument";
            }

            public static class Cards
            {
                [Description("Servis kartı")]
                public const string ServiceCard = "Menus.Cards.ServiceCard";
                [Description("Cari Hesab Ödəniş Qeydləri Kartı")]
                public const string ClientPaymentNoteCard = "Menus.Cards.ClientPaymentNoteCard";
                [Description("İstifadəçi kartı")]
                public const string UserCard = "Menus.Cards.UserCard";
            }

            public static class Reports
            {
                [Description("Müştəri servis borcları")]
                public const string ClientServicePaymentReport = "Menus.Reports.ClientServicePaymentReport";
                [Description("Kub hesabatı")]
                public const string CubeReport = "Menus.Reports.CubeReport";
                [Description("Servis quraşdırma sənədləri")]
                public const string ServiceOperationDocuments = "Menus.Reports.ServiceOperationDocuments";
            }

            public static class Lists
            {
                [Description("Servis quraşdırma sənədləri listi")]
                public const string ServiceOperationDocuments = "Menus.Lists.ServiceOperationDocuments";
                [Description("Servis listi")]
                public const string ServiceList = "Menus.Lists.ServiceList";
                [Description("Cari listi")]
                public const string ClientList = "Menus.Lists.ClientList";
                [Description("Cari qrup listi")]
                public const string ClientGroupList = "Menus.Lists.ClientGroupList";
                [Description("Cari ödəniş qeydləri listi")]
                public const string ClientPaymentNoteList = "Menus.Lists.ClientPaymentNoteList";
                [Description("İstifadəçi listi")]
                public const string UserList = "Menus.Lists.UserList";
            }

            public static class Parameters
            {
                [Description("Bağlantı pəncərəsi")]
                public const string ConnectionForm = "Menus.Parameters.ConnectionForm";
                [Description("İstifadəçi icazələri")]
                public const string PermissionForm = "Menus.Parameters.PermissionForm";
            }
        }
    }
}
