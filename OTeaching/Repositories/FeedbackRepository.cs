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
    }
}