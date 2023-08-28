using ARILandingBlazor.Client.Model;

namespace ARILandingBlazor.Client.Interfaces
{
    public interface IMailService
    {
        Task<bool> Email(EmailBody email);
    }
}
