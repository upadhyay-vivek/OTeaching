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

        public Staff GetStaffById(int sid)
        {
            return _oTeachingContext.Staffs.Where(x => x.SID == sid).FirstOrDefault();
        }

        public int UpdateStaff(Staff inputModel)
        {
            var staff = _oTeachingContext.Staffs.Where(x => x.SID == inputModel.SID).FirstOrDefault();
            if (!string.IsNullOrEmpty(inputModel.Address))
            {
                staff.Address = inputModel.Address;
            }
            if (!string.IsNullOrEmpty(inputModel.City))
            {
                staff.City = inputModel.City;
            }
            if (!string.IsNullOrEmpty(inputModel.Email))
            {
                staff.Email = inputModel.Email;
            }
            if (!string.IsNullOrEmpty(inputModel.Image))
            {
                staff.Image = inputModel.Image;
            }
            if (!string.IsNullOrEmpty(inputModel.Mobile))
            {
                staff.Mobile = inputModel.Mobile;
            }
            if (!string.IsNullOrEmpty(inputModel.Pincode))
            {
                staff.Pincode = inputModel.Pincode;
            }

            var result=_oTeachingContext.SaveChanges();
            if (result>0)
            {
                return result;
            }
            return 0;
        }

        public Staff CheckStaff(string userName, string password)
        {
            return _oTeachingContext.Staffs.Where(x => x.Email == userName && x.Password==password).FirstOrDefault();
        }
    }
}