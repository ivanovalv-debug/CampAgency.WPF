using CampAgency.WPF.Models.Entities;
using CommunityToolkit.Mvvm.ComponentModel;
using System;

namespace CampAgency.WPF.ViewModels.Parent
{
    public partial class ChildSelectionWrapper : ObservableObject
    {
        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if (SetProperty(ref _isSelected, value))
                {
                    OnSelectionChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }
        public Child Child { get; set; } = null!;
        public event EventHandler? OnSelectionChanged;
    }
}