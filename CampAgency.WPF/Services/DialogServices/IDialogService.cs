namespace CampAgency.WPF.Services.DialogServices
{
    public interface IDialogService
    {
        void ShowMessage(string message, string title = "Информация");
        void ShowError(string message, string title = "Ошибка");
        bool ShowConfirmation(string message, string title = "Подтверждение");
    }
}