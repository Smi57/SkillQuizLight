using SkillQuizLight.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace SkillQuizLight.Models;

public class User
{
    //Attributs
    public int? tUserID { get; set; }
    public string Login { get; set; }
    public string? LastName { get; set; }
    public string? FirstName { get; set; }
    private string? Password { get; set; }
    public string? PasswordEncrypted { get; set; }
    public string? Email { get; set; }
    public string? Comment { get; set; }
    public int AccessFailedCount { get; set; }
    public int ParamLangID { get; set; }
    public int ParamUserTypeID { get; set; }
    public bool IsActivate { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatDate { get; set; }
    public int CreatUserID { get; set; }
    public DateTime ModifDate { get; set; }
    public int ModifUserID { get; set; }

    //Constructeurs
    public User() { }
    public User(int? _UserID, string _Login, string? _FirstName, string? _LastName, string? _Password, string? _Email, string? _Comment)
    {
        this.tUserID = _UserID;
        this.Login = _Login;
        this.FirstName = _FirstName;
        this.LastName = _LastName;
        setPassword(_Password);
        this.Email = _Email;
        this.Comment = _Comment;
        this.AccessFailedCount = 0;
        this.ParamLangID = 0;
        this.ParamUserTypeID = 0;
        this.IsActivate = true;
        this.CreatDate = DateTime.Now;
        this.CreatUserID = 0;
        this.ModifDate = DateTime.Now;
        this.ModifUserID = 0;
    }
    public User(int? _UserID, string _Login, string? _FirstName, string? _LastName, string? _Email, string? _Comment)
    {
        this.tUserID = _UserID;
        this.Login = _Login;
        this.FirstName = _FirstName;
        this.LastName = _LastName;
        this.Email = _Email;
        this.Comment = _Comment;
        this.AccessFailedCount = 0;
        this.ParamLangID = 0;
        this.ParamUserTypeID = 0;
        this.IsActivate = true;
        this.CreatDate = DateTime.Now;
        this.CreatUserID = 0;
        this.ModifDate = DateTime.Now;
        this.ModifUserID = 0;
    }

    //Accesseurs
    public void setPassword(string _Password)
    {
        Password = encryptPassword(_Password);
        PasswordEncrypted = getPassword();
    }
    public string getPassword() { return Password; }
    
    //Méthode
    public static string verifValidPassword(string plainText)
    {
        var hasNumber = new Regex(@"[0-9]+");
        var hasUpperChar = new Regex(@"[A-Z]+");
        var hasSpecChars = new Regex(@"[#?!@$%^&*-]");
        var hasMinimum8Chars = new Regex(@".{8,}");

        if (!hasNumber.IsMatch(plainText))
        {
            return "Password should contain At least one numeric value";
        }
        else if (!hasUpperChar.IsMatch(plainText))
        {
            return "Password should contain At least one lower case letter";
        }
        else if (!hasSpecChars.IsMatch(plainText))
        {
            return "Password should contain At least one special case characters";
        }
        else if (!hasMinimum8Chars.IsMatch(plainText))
        {
            return "Password should not be less than or greater than 8 characters";
        }
        else
        {
            return "";
        }

    }

    public static string encryptPassword(string s)
    {
        using var sha256 = SHA256.Create();
        byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(s));

        var sb = new StringBuilder();
        for (int i = 0; i < bytes.Length; i++)
        {
            sb.Append(bytes[i].ToString("x2"));
        }
        return sb.ToString();

        // Sha256encrypt
        //UTF8Encoding encoder = new UTF8Encoding();
        //SHA256Managed sha256hasher = new SHA256Managed();
        //byte[] hashedDataBytes = sha256hasher.ComputeHash(encoder.GetBytes(phrase));
        //return Convert.ToBase64String(hashedDataBytes);
    }

    public string managAccessFailedCount(bool Unbocked = false, bool AddAccessFailed = true)
    {
        string? message = null;

        if (Unbocked)
        {
            AccessFailedCount = 0;
            UpdateMe();
        }
        else if (AccessFailedCount >= 5)
        {
            message = "Vous avez dépassé les 5 tentatives de saisie de votre mot de passe, votre compte est bloqué.";
        }
        else if (AddAccessFailed)
        {
            AccessFailedCount = ++AccessFailedCount;
            UpdateMe();
            if (AccessFailedCount > 5)
            {
                message = "Vous avez dépassé les 5 tentatives de saisie de votre mot de passe, votre compte est bloqué.";
            }
            else
            {
                message = "Mot de passe incorrect ! " + AccessFailedCount + "/5 tentatives";
            }
        }
        return message;
    }

    public async void UpdateMe()
    {
        HttpResponseMessage responseUpd = await Program.client.PutAsJsonAsync("api/User/putUser", this);
    }

}

