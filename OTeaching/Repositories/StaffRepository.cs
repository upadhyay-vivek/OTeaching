using OTeaching.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OTeaching.Repositories
{
    public class StaffRepository
    {
        private readonly OTeachingContext _oTeachingContext;
        public StaffRepository()
        {
            _oTeachingContext = new OTeachingContext();
        }

        public List<Staff> GetAllStaffs()
        {
            return _oTeachingContext.Staffs.ToList();
        }

        public int DeleteStaff(int sid)
        {
            var staff = _oTeachingContext.Staffs.Where(x => x.SID == sid).FirstOrDefault();

            _oTeachingContext.Staffs.Remove(staff);
            return _oTeachingContext.SaveChanges();
        }

        public int AddStaff(Staff staff)
        {
            _oTeachingContext.Staffs.Add(staff);
            return _oTeachingContext.SaveChanges();
        }
    }
}