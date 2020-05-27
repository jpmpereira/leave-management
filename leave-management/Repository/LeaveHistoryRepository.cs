using leave_management.Contracts;
using leave_management.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Repository
{
    public class LeaveHistoryRepository : ILeaveHistoryRepository
    {
        private readonly ApplicationDbContext _db;

        public LeaveHistoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(LeaveHistory entity)
        {
            _db.LeaveHistories.Add(entity);
            return Save();
        }

        public bool Delete(LeaveHistory entity)
        {
            _db.LeaveHistories.Remove(entity);
            return Save();
        }

        public ICollection<LeaveHistory> FindAll()
        {
            var leaveTypes = _db.LeaveHistories.ToList();
            return leaveTypes;
        }

        public LeaveHistory FindById(int id)
        {
            var leaveHistory = _db.LeaveHistories.Where(i => i.Id == id).FirstOrDefault();
            return leaveHistory;
        }



        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(LeaveHistory entity)
        {
            _db.LeaveHistories.Update(entity);
            return Save();
        }
        public bool IfExists(int Id)
        {
            return _db.LeaveHistories.Any(l => l.Id == Id);
        }
    }
}
