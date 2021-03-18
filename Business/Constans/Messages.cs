using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constans
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün Eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string ProductListed = "Ürünler Listelendi";
        public static string MaintanceTime = "Sistem bakımda";
        public static string ProductCountOfCategoryError = "En fazla 10 ürün olabilir";
        public static string ProductNameError="Aynı isimde ürün eklenemez";
        public static string CategoryLimitError="Kategori limiti aşıldığı için yeni ürün eklenemiyor";
        public static string AuthorizationDenied="Yetkiniz yok";
        public static string UserRegistered="Kullanıcı kaydedildi";
        public static string UserNotFound="Kullanıcı bulunamadı";
        public static string PasswordError="Şifre hatası";
        public static string SuccessfulLogin="Giriş başarılı";
        public static string UserAlreadyExists="Kullanıcı zaten var";
        public static string AccessTokenCreated=" Access token oluşturuldu";
    }
}
