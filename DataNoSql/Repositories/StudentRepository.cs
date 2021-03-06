﻿using System.Collections.Generic;
using System.Threading.Tasks;
using DataNoSql.Context;
using DataNoSql.Models;
using MongoDB.Driver;

namespace DataNoSql.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllAsync();
        Task<Student> GetByIdAsync(string id);
        Task<Student> CreateAsync(Student student);
        Task UpdateAsync(string id, Student student);
        Task DeleteAsync(string id);
    }
    public class StudentRepository : IStudentRepository
    {
        private readonly MongoContext _db;
        public StudentRepository(MongoContext db)
        {
            _db = db;
        }
        public async Task<List<Student>> GetAllAsync()
        {
            return await _db.Students.Find(s => true).ToListAsync();
        }
        public async Task<Student> GetByIdAsync(string id)
        {
            return await _db.Students.Find<Student>(s => s.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Student> CreateAsync(Student student)
        {
            await _db.Students.InsertOneAsync(student);
            return student;
        }
        public async Task UpdateAsync(string id, Student student)
        {
            await _db.Students.ReplaceOneAsync(s => s.Id == id, student);
        }
        public async Task DeleteAsync(string id)
        {
            await _db.Students.DeleteOneAsync(s => s.Id == id);
        }
    }
}
