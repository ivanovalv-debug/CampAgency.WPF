using CampAgency.WPF.Models.Entities;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CampAgency.WPF.ViewModels.Parent
{
    public class MedicalNoteWrapper : ObservableObject
    {
        public MedicalNote MedicalNote { get; set; } = null!;

        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set => SetProperty(ref _isSelected, value);
        }
    }
}