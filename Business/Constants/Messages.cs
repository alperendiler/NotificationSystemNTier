using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public class Messages
    {
        public static string MaximumCharCount = "200 Karakter sınırını aştınız";
        public static string? UserMailAlreadyExists = "Böyle bir mail sisteme kayıtlıdır";
        public static string UserNotBeExist = "Kullanıcı mevcut değil";
        public static string MailOrPasswordIncorrect = "E-Posta veya şifre geçersiz";
        public static string UserNameOrPasswordIncorrect = "Kullanıcı adı veya şifre geçersiz";
        public static string? UserAlreadyExists = "Böyle bir kullanıcı mevcut";
        public static string MustContainUpperLowerChar = "Şifre en az bir büyük harf, bir küçük harf, bir rakam içermeli";
        public static string MustFilling = "*Doldurulması zorunlu alan";
        public static string? PasswordDontMatch = "Şifre eşleşmiyor";
        public static string MustContainAtMinTwoChar = "En az 2  karakter girmelisiniz";
        public static string InvalidEmail = "Girdiğiniz -posta adresi geçersizdir.";
        public static string MustContainMinEightChar = "En az sekiz karakter uzunluğunda olmalıdır.";
        public static string MustContainAtMaxFiftyChar = "En fazla 50 karakter uzunluğunda olmalıdır";

        
        public static string? NotificationNotExists = "Böyle bir notification bulunamadı";
        public static string? UserInformationNotExists = "Böyle bir userInformation bulunamadı";


    }
}
