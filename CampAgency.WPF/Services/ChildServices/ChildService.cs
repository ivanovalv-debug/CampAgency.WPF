using CampAgency.WPF.Data;
using CampAgency.WPF.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CampAgency.WPF.Services.ChildServices
{
    public class ChildService : IChildService
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public ChildService(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public List<Child> GetChildrenByUserId(int userId)
        {
            using var context = _contextFactory.CreateDbContext();
            return context.Children
                .Include(c => c.Gender)
                .Include(c => c.ChildMedicalNotes).ThenInclude(cmn => cmn.MedicalNote)
                .Where(c => c.UserId == userId)
                .ToList();
        }

        public bool AddChild(int userId, string fullName, int genderId, DateOnly birthDate, List<int> medicalNoteIds)
        {
            try
            {
                using var context = _contextFactory.CreateDbContext();
                var child = new Child
                {
                    UserId = userId,
                    FullName = fullName,
                    GenderId = genderId,
                    BirthDate = birthDate
                };
                context.Children.Add(child);
                context.SaveChanges(); // получаем ChildId

                foreach (var noteId in medicalNoteIds)
                {
                    context.ChildMedicalNotes.Add(new ChildMedicalNote
                    {
                        ChildId = child.ChildId,
                        MedicalNoteId = noteId
                    });
                }
                context.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public bool UpdateChild(Child child, List<int> medicalNoteIds)
        {
            using var context = _contextFactory.CreateDbContext();
            var existing = context.Children
                .Include(c => c.ChildMedicalNotes)
                .FirstOrDefault(c => c.ChildId == child.ChildId);
            if (existing == null) return false;

            existing.FullName = child.FullName;
            existing.GenderId = child.GenderId;
            existing.BirthDate = child.BirthDate;

            // Обновляем медицинские заметки: удаляем старые, добавляем новые
            existing.ChildMedicalNotes.Clear();
            foreach (var noteId in medicalNoteIds)
            {
                existing.ChildMedicalNotes.Add(new ChildMedicalNote
                {
                    ChildId = child.ChildId,
                    MedicalNoteId = noteId
                });
            }

            context.SaveChanges();
            return true;
        }

        public bool DeleteChild(int childId)
        {
            using var context = _contextFactory.CreateDbContext();
            var child = context.Children.Find(childId);
            if (child == null) return false;
            context.Children.Remove(child);
            context.SaveChanges();
            return true;
        }

        public List<Gender> GetGenders()
        {
            using var context = _contextFactory.CreateDbContext();
            return context.Genders.ToList();
        }

        public List<MedicalNote> GetMedicalNotes()
        {
            using var context = _contextFactory.CreateDbContext();
            return context.MedicalNotes.ToList();
        }

        public List<Document> GetDocumentsByChildId(int childId)
        {
            using var context = _contextFactory.CreateDbContext();
            return context.Documents
                .Include(d => d.DocumentType)
                .Include(d => d.DocumentStatus)
                .Where(d => d.ChildId == childId)
                .ToList();
        }

        public bool AddDocument(int childId, int documentTypeId, string filePath)
        {
            try
            {
                using var context = _contextFactory.CreateDbContext();
                var doc = new Document
                {
                    ChildId = childId,
                    DocumentTypeId = documentTypeId,
                    DocumentStatusId = 1, // "Загружен"
                    FilePath = filePath,
                    TimeStamp = DateTime.Now
                };
                context.Documents.Add(doc);
                context.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public List<DocumentType> GetDocumentTypes()
        {
            using var context = _contextFactory.CreateDbContext();
            return context.DocumentTypes.ToList();
        }

    }
}