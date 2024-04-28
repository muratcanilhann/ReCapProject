using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants;

 public static class Messages
{

    public static string CarAdded = "Araç eklendi.";
    public static string CarDeleted = "Araç silindi.";
    public static string CarUpdated = "Araç güncellendi.";
    public static string MaintenanceTime = "Sistem bakımda";
    public static string CarsListed = "Araçlar listelendi.";
    public static string CarCountOfBrandError = "Aynı markaya ait 10 araçtan fazla olamaz";
    public static string AuthorizationDenied = "Yetkiniz yok";
    public static string UserRegistered = "Kayıt olundu.";
    public static string UserNotFound = "Kullanıcı bulunamadı.";
    public static string PasswordError = "Şifre hatalı";
    public static string SuccessfulLogin = "Giriş başarılı";
    public static string UserAlreadyExists = "Kullanıcı mevcut";
    public static string AccessTokenCreated = "Token oluşturuldu";
}
