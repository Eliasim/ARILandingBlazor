using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MimeKit;
using ARILandingBlazor.Client.Interfaces;
using ARILandingBlazor.Client.Model;
using System.Xml.Linq;

namespace ARILandingBlazor.Client.Pages
{
    public partial class Index
    {
        [Inject]
        private IMailService _mailService { get; set; }

        public bool MensualPaymentType = false;
        public string Name { get; set; } = "";
        public string Mail { get; set; } = "";
        public string Message { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Company { get; set; } = "";
        public string Demo { get; set; } = "";
        public string Package { get; set; } = "";
        public string Plan { get; set; } = "Anual";
        public void SwitchPayment()
        {
            MensualPaymentType = !MensualPaymentType;
            if (Plan == "Anual")
            {
                Plan = "Mensual";
            }
            else if (Plan == "Mensual")
            {
                Plan = "Anual";
            }
        }
        public async void ActivateDemoButton()
        {
            Demo = "Solicita Demostración";
            await JSRuntime.InvokeVoidAsync("GoContact");
        }
        public async void Premium()
        {
            Package = "PLAN PREMIUM";
            await JSRuntime.InvokeVoidAsync("GoContact");
        }
        public async void Gold()
        {
            Package = "PLAN GOLD";
            await JSRuntime.InvokeVoidAsync("GoContact");
        }
        public async void Platinum()
        {
            Package = "PLAN PLATINUM";
            await JSRuntime.InvokeVoidAsync("GoContact");
        }
        public async Task SendEMail()
        {
            if (Package == "")
            {
                Plan = "";
            }

            EmailBody emailBody = new EmailBody()
            {
                Email = Mail,
                Name = Name,
                Text = Message,
                Phone = Phone,
                Company = Company,
                Package = Package,
                Demo = Demo,
                Plan = Plan
            };

            

            var res = await _mailService.Email(emailBody);

            if (res != null)
            {
                await JSRuntime.InvokeVoidAsync("alert", "Hemos recibido su solicitud de contacto");
            }
        }
    }

}
