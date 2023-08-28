using Microsoft.JSInterop;

namespace ARILandingBlazor.Client.Pages
{
    public partial class Index
    {
        public bool MensualPaymentType = false;
        public string Plan { get; set; } = "Anual";
        public string Demo { get; set; } = "";
        public string Package { get; set; } = "";
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
    }

}
