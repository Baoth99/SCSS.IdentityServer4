﻿
namespace SCSS.IdentityServer4.Constants
{
    public class AccountUrlDefinition
    {
        public const string RegisterAccountDemo = "register-demo";
        public const string RegisterDealerAccount = "register/dealer";
        public const string RegisterDealerMemberAccount = "register/dealer-member";
        public const string RegisterCollectorAccount = "register/collector";
        public const string RegisterSellerAccount = "register/seller";
        public const string UpdateAccount = "update";
        public const string ChangeStatus = "change-status";
        public const string RestorePassword = "restore-password";
        public const string SendOTP = "send-otp";
        public const string ConfirmOTPToRegister = "confirm-otp-register";
        public const string SendOTPToRestorePassword = "send-otp-restore-password";
        public const string SendOTPToLogin = "send-otp-login";
        public const string ConfirmOTP = "confirm-otp";
        public const string ChangePassword = "change-password";
    }

    public class IdenittyUrlDefination
    {
        public const string UserInteractionLoginUrl = "/Identity/Account/Login";
        public const string UserInteractionLogoutUrl = "/Identity/Account/Logout";
    }
}
