using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string AddedBrand = "Marka eklendi.";
        public static string DeletedBrand = "Marka silindi.";
        public static string UpdatedBrand = "Marka güncellendi.";
        public static string FailedBrandAddOrUpdate = "Lütfen marka isminin uzunluğunu 2 karakterden fazla giriniz.";

        public static string AddedCar = "Araba eklendi.";
        public static string DeletedCar = "Araba silindi.";
        public static string UpdatedCar = "Araba güncellendi.";
        public static string FailedCarAddOrUpdate = "Lütfen günlük fiyat kısmını 0'dan büyük giriniz.";

        public static string AddedColor = "Renk eklendi.";
        public static string DeletedColor = "Renk silindi.";
        public static string UpdatedColor = "Renk güncellendi.";

        public static string AddedCustomer = "Müşteri eklendi.";
        public static string DeletedCustomer = "Müşteri silindi.";
        public static string UpdatedCustomer = "Müşteri bilgileri güncellendi.";

        public static string AddedUser = "Kullanıcı eklendi.";
        public static string DeletedUser = "Kullanıcı silindi.";
        public static string UpdatedUser = "Kullanıcı bilgileri başarıyla güncellendi.";

        public static string AddedRental = "Araba Kiralama işlemi gerçekleşti.";
        public static string DeletedRental = "Araba Kiralama işlemi iptal edildi.";
        public static string UpdatedRental = "Araba Kiralama işlemi güncellendi.";
        public static string FailedRentalAddOrUpdate = "Bu araba henüz teslim edilmediği için kiralayamazsınız.";
        public static string ReturnedRental = "Kiraladığınız araç teslim edildi.";

        public static string AddedCarImage = "Araba için yüklenilen resim başarıyla eklendi.";
        public static string DeletedCarImage = "Arabanın resmi başarıyla silindi.";
        public static string UpdatedCarImage = "Araba için yüklenilen resim başarıyla güncellendi.";
        public static string FailedCarImageAdd = "Bir araba 5'den fazla resme sahip olamaz.";

        public static string AuthorizationDenied = "Yetkiniz yok.";
        public static string UserRegistered = "Kayıt oldu.";

        public static string UserNotFound = "Kullanıcı bulunamadı.";
        public static string SuccessfulLogin = "Başarıyla giriş yapıldı";
        public static string PasswordError = "Parola hatası!";
        public static string UserAlreadyExists = "Kullanıcı mevcut!";
        public static string AccessTokenCreated = "Token oluşturuldu.";
    }
}
