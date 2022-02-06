using OTeaching.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OTeaching.Repositories
{
    public class UserRepository
    {
        private readonly OTeachingContext _oTeachingContext;
        public UserRepository()
        {
            _oTeachingContext = new OTeachingContext();
        }

        public int AddUser(User user)
        {
            _oTeachingContext.Users.Add(user);
            var result = _oTeachingContext.SaveChanges();
            if (result>0)
            {
                return result;
            }
            return 0;
        }

        public List<User> GetAllUsers()
        {
            return _oTeachingContext.Users.ToList();
        }
        public int DeleteUser(int sid)
        {
            var user = _oTeachingContext.Users.Where(x => x.SID == sid).FirstOrDefault();

            _oTeachingContext.Users.Remove(user);
            return _oTeachingContext.SaveChanges();
        }

        public User CheckStudent(string userName, string password)
        {
            return _oTeachingContext.Users.Where(x => x.Uname == userName && x.Password == password).FirstOrDefault();
        }
    }
}