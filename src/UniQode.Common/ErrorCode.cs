namespace UniQode.Common
{
    public enum ErrorCode
    {
        DataNotFound,

        AccountNotFound,
        AccountAlreadyExists,
        PasswordMismatch,
        AccountCreationFailed,
        AccountDeletionFailed,
        BruteForceDetected,

        AuthenticationFailed,

        CreateFailed,
        UpdateFailed,
        DeleteFailed,
    }
}