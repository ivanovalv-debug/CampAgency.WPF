using CampAgency.WPF.Models.Entities;
using System.Collections.Generic;

namespace CampAgency.WPF.Services.ChildServices
{
    public interface IChildService
    {
        List<Child> GetChildrenByUserId(int userId);
        bool AddChild(int userId, string fullName, int genderId, DateOnly birthDate, List<int> medicalNoteIds);
        bool UpdateChild(Child child, List<int> medicalNoteIds);
        bool DeleteChild(int childId);
        List<Gender> GetGenders();
        List<MedicalNote> GetMedicalNotes();
        List<Document> GetDocumentsByChildId(int childId);
        bool AddDocument(int childId, int documentTypeId, string filePath);
        List<DocumentType> GetDocumentTypes();
    }
}