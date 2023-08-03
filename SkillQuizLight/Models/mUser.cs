using Azure;
using SkillQuizLight.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace SkillQuizLight.Models;

public class mUser
{
    //Attributs
    public int? tUserID { get; set; }
    public string? Login { get; set; }
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
    public mUser() { }
    public mUser(int? _UserID, string _Login, string? _FirstName, string? _LastName, string? _Password, string? _Email
        , string? _Comment, int? pParamLangID)
    {
        this.tUserID = _UserID;
        this.Login = _Login;
        this.FirstName = _FirstName;
        this.LastName = _LastName;
        setPassword(_Password);
        this.Email = _Email;
        this.Comment = _Comment;
        this.AccessFailedCount = 0;
        this.ParamLangID = pParamLangID.Value;
        this.ParamUserTypeID = 0;
        this.IsActivate = true;
        this.CreatDate = DateTime.Now;
        this.CreatUserID = Program.currentUser.tUserID.Value;
        this.ModifDate = DateTime.Now;
        this.ModifUserID = Program.currentUser.tUserID.Value;
    }
    public mUser(int? _UserID, string _Login, string? _FirstName, string? _LastName, string? _Email, string? _Comment
        , int? pParamLangID)
    {
        this.tUserID = _UserID;
        this.Login = _Login;
        this.FirstName = _FirstName;
        this.LastName = _LastName;
        this.Email = _Email;
        this.Comment = _Comment;
        this.ParamLangID = pParamLangID.Value;
        this.ModifDate = DateTime.Now;
        this.ModifUserID = Program.currentUser.tUserID.Value;
    }

    //Accesseurs
    public void setPassword(string _Password)
    {
        Password = encryptPassword(_Password);
        PasswordEncrypted = Password;
    }
    public string getPassword() { return PasswordEncrypted; }
    
    //Méthode
    public string verifValidPassword(string pPassword)
    {
        string vMsgTmp = "";
        var hasNumber = new Regex(@"[0-9]+");
        var hasUpperChar = new Regex(@"[A-Z]+");
        var hasSpecChars = new Regex(@"[#?!@$%^&*-]");
        var hasMinimum8Chars = new Regex(@".{8,}");

        if (!hasNumber.IsMatch(pPassword))
        {
            vMsgTmp = vMsgTmp + "[MsgPwdMissNum]" + Environment.NewLine;
        }
        if (!hasUpperChar.IsMatch(pPassword))
        {
            vMsgTmp = vMsgTmp + "[MsgPwdMissUpC]" + Environment.NewLine;
        }
        if (!hasSpecChars.IsMatch(pPassword))
        {
            vMsgTmp = vMsgTmp + "[MsgPwdMissSpeC]" + Environment.NewLine;
        }
        if (!hasMinimum8Chars.IsMatch(pPassword))
        {
            vMsgTmp = vMsgTmp + "[MsgPwdMissMin8C]" + Environment.NewLine;
        }
        return vMsgTmp;
    }

    public string[] verifUserPassword(string pPassword, string pLastPasswordEncrypted = "")
    {
        string[] resErrMsgValMem = new string[2];

        mUser login = new mUser();
        login.setPassword(pPassword);
        // On vérifit que la personne ne fait pas une tentative avec le même mot de passe ou le mot de passe à vide
        if (pLastPasswordEncrypted == login.Password || pPassword == "")
        {
            resErrMsgValMem[0] = "[MsgPwdToEnter]";
        }
        else
        {
            resErrMsgValMem[1] = login.PasswordEncrypted;
            if (Program.currentUser.PasswordEncrypted == login.PasswordEncrypted && Program.currentUser.AccessFailedCount < 5)
            {
                Program.currentUser.managAccessFailedCount(true);
                resErrMsgValMem[0] = "";
            }
            else
            {
                resErrMsgValMem[0] = Program.currentUser.managAccessFailedCount(false, true);
            }
        }
        return resErrMsgValMem;
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
            message = "[MsgSup5Login]";
        }
        else if (AddAccessFailed)
        {
            AccessFailedCount = ++AccessFailedCount;
            UpdateMe();
            if (AccessFailedCount > 5)
            {
                message = "[MsgSup5Login]";
            }
            else
            {
                message = "[MsgLoginNumP1] " + AccessFailedCount + "[MsgLoginNumP2]";
            }
        }
        return message;
    }

    public async void UpdateMe()
    {
        HttpResponseMessage responseUpd = await Program.client.PutAsJsonAsync("api/User/putUser", this);
    }

    public async void UpdatePassword(string pOldPassword)
    {
        HttpResponseMessage responseUpd = await Program.client.PutAsJsonAsync($"api/User/putUserPassword/{pOldPassword}", this);
    }
}

