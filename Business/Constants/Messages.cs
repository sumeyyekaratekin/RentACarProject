using Core.Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string AddedBrand = "Marka başarıyla eklendi.";
        public static string DeletedBrand = "Marka başarıyla silindi.";
        public static string UpdatedBrand = "Marka başarıyla güncellendi.";
        public static string FailedBrandAddOrUpdate = "Lütfen marka isminin uzunluğunu 2 karakterden fazla giriniz.";

        public static string AddedCar = "Araba başarıyla eklendi.";
        public static string DeletedCar = "Araba başarıyla silindi.";
        public static string UpdatedCar = "Araba başarıyla güncellendi.";
        public static string BrandListed = "Markalar Listelendi";
        public static string FailedCarAddOrUpdate = "Lütfen günlük fiyat kısmını 0'dan büyük giriniz.";

        public static string AddedColor = "Renk başarıyla eklendi.";
        public static string DeletedColor = "Renk başarıyla silindi.";
        public static string UpdatedColor = "Renk başarıyla güncellendi.";
        public static string ColorListed = "Renkler Listelendi";

        public static string AddedCustomer = "Müşteri başarıyla eklendi.";
        public static string DeletedCustomer = "Müşteri başarıyla silindi.";
        public static string UpdatedCustomer = "Müşteri başarıyla güncellendi.";

        public static string AddedUser = "Kullanıcı başarıyla eklendi.";
        public static string DeletedUser = "Kullanıcı başarıyla silindi.";
        public static string UpdatedUser = "Kullanıcı başarıyla güncellendi.";

        public static string AddedRental = "Araba Kiralama işlemi başarıyla gerçekleşti.";
        public static string DeletedRental = "Araba Kiralama işlemi iptal edildi.";
        public static string UpdatedRental = "Araba Kiralama işlemi güncellendi.";
        public static string FailedRentalAddOrUpdate = "Bu araba henüz teslim edilmediği için kiralayamazsınız.";
        public static string ReturnedRental = "Kiraladığınız araç teslim edildi.";

        public static string AddedCarImage = "Araba için yüklenilen resim başarıyla eklendi.";
        public static string DeletedCarImage = "Arabanın resmi başarıyla silindi.";
        public static string UpdatedCarImage = "Araba için yüklenilen resim başarıyla güncellendi.";
        public static string FailedCarImageAdd = "Bir araba 5'den fazla resme sahip olamaz.";
        public static string CarImageNotFound = "Araba Resmi Bulunamadı.";

        public static string AuthorizationDenied = "Yetkiniz yok.";
        public static string UserRegistered = "Kullanıcı başarıyla kayıt oldu.";

        public static string UserNotFound = "Kullanıcı bulunamadı.";
        public static string SuccessfulLogin = "Başarıyla giriş yapıldı";
        public static string PasswordError = "Parola hatası!";
        public static string UserAlreadyExists = "Kullanıcı mevcut!";
        public static string AccessTokenCreated = "Token oluşturuldu.";
        public static string CustomerDetailListed = "Müşteriler Listelendi";
        public static string UsersListed = "Kullanıcılar Listelendi";
        public static string UpdatedUserInfos = "Kullanıcı Bilgileri Güncellendi.";

        public static string GetErrorCarMessage = "Araç Bilgileri getirilemedi";
        public static string CarsListed = "Arabalar Listelendi.";
        public static string CarIsntAvailable = "Araç kiralanmaz.!";
        public static string CarAdded = "Kredi Kartı eklendi.";

        public static string PasswordChanged = "Parola değiştirildi";
        public static string CardSaved = "Kart Kaydedildi.";
        public static string CardDeleted = "Kart Silindi.";
      
    }
}
