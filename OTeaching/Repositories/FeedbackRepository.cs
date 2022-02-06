using OTeaching.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OTeaching.Repositories
{
    public class FeedbackRepository
    {
        private readonly OTeachingContext _oTeachingContext;
        public FeedbackRepository()
        {
            _oTeachingContext = new OTeachingContext();
        }
        public Feedback AddFeedback(Feedback feedback)
        {
            _oTeachingContext.Feedbacks.Add(feedback);
            var result = _oTeachingContext.SaveChanges();
            if (result>0)
            {
                return feedback;
            }
            return null;
        }

        public List<Feedback> GetAllFeedbacks()
        {
            return _oTeachingContext.Feedbacks.ToList();
        }

        internal int DeleteFeedback(int fid)
        {
            var feedback = _oTeachingContext.Feedbacks.Where(x => x.FID == fid).FirstOrDefault();
            _oTeachingContext.Feedbacks.Remove(feedback);
            var result = _oTeachingContext.SaveChanges();
            if (result>0)
            {
                return result;
            }
            return 0;
        }
    }
}