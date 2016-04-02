using System.Collections.Generic;

namespace UniQode.Common
{
    public class ErrorCodeParser
    {
        private static readonly Dictionary<ErrorCode, string> Messages = new Dictionary<ErrorCode, string>
        {
            { ErrorCode.AccountAlreadyExists, "An account already exists with the current id/email" },
            { ErrorCode.AccountDeletionFailed, "An error occurred while deleting the account" },
            { ErrorCode.AccountCreationFailed, "An error occurred while creating the account" },
            { ErrorCode.AccountNotFound, "Cannot find any account with the given id/email" },
            { ErrorCode.PasswordMismatch, "The password is incorrect" },
            { ErrorCode.BruteForceDetected, "You entered the wrong credentials too many times. Try again in 10min" },
        };

        public static string GetMessage(ErrorCode code)
        {
            var message = $"An error occurred with the following code: {code}";

            Messages.TryGetValue(code, out message);

            return message;
        }
    }
}