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
                context.SaveChanges(); // сохраняем, чтобы получить ChildId

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

        public bool UpdateChild(Child child)
        {
            using var context = _contextFactory.CreateDbContext();
            var existing = context.Children.Find(child.ChildId);
            if (existing == null) return false;
            existing.FullName = child.FullName;
            existing.GenderId = child.GenderId;
            existing.BirthDate = child.BirthDate;
            // Обновление медзаметок можно реализовать при необходимости
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
    }
}