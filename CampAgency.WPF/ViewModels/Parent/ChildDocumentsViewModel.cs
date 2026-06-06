using CampAgency.WPF.Models.Entities;
using CampAgency.WPF.Services.ChildServices;
using CampAgency.WPF.Services.DialogServices;
using CampAgency.WPF.Services.NavigationServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Linq;

namespace CampAgency.WPF.ViewModels.Parent
{
    public partial class ChildDocumentsViewModel : ObservableObject, INavigationAware
    {
        private readonly IChildService _childService;
        private readonly INavigationService _navigation;
        private readonly IDialogService _dialog;

        [ObservableProperty] private Child? _child;
        [ObservableProperty] private ObservableCollection<Document> _documents = new();
        [ObservableProperty] private ObservableCollection<DocumentType> _documentTypes = new();
        [ObservableProperty] private DocumentType? _selectedDocumentType;
        [ObservableProperty] private string _filePath = string.Empty;

        public ChildDocumentsViewModel(IChildService childService, INavigationService navigation, IDialogService dialog)
        {
            _childService = childService;
            _navigation = navigation;
            _dialog = dialog;
        }

        public void OnNavigatedTo(object? parameter)
        {
            if (parameter is Child child)
            {
                _child = child;
                LoadDocumentTypes();
                LoadDocuments();
            }
        }

        private void LoadDocumentTypes()
        {
            // Используем реальный метод IChildService
            var types = _childService.GetDocumentTypes();
            DocumentTypes = new ObservableCollection<DocumentType>(types);
        }

        private void LoadDocuments()
        {
            if (_child != null)
            {
                var list = _childService.GetDocumentsByChildId(_child.ChildId);
                Documents = new ObservableCollection<Document>(list);
            }
        }

        [RelayCommand]
        private void AddDocument()
        {
            if (SelectedDocumentType == null)
            {
                _dialog.ShowError("Выберите тип документа", "Ошибка");
                return;
            }
            if (string.IsNullOrWhiteSpace(FilePath))
            {
                _dialog.ShowError("Укажите путь или ссылку на файл", "Ошибка");
                return;
            }

            if (_childService.AddDocument(_child!.ChildId, SelectedDocumentType.DocumentTypeId, FilePath))
            {
                _dialog.ShowMessage("Документ добавлен", "Успех");
                LoadDocuments();
                FilePath = string.Empty;
                SelectedDocumentType = null;
            }
            else
                _dialog.ShowError("Ошибка добавления документа", "Ошибка");
        }

        [RelayCommand]
        private void BackToChildren() => _navigation.NavigateTo<ChildListViewModel>();
    }
}