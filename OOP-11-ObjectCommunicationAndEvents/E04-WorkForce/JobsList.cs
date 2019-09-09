namespace E04_WorkForce
{
    using System;
    using System.Collections.Generic;

    public class JobsList : List<Job>
    {
        public void RemoveCompleted(object sender, EventArgs args)
        {
            var job = (Job)sender;
            this.Remove(job);
            job.JobCompleted -= RemoveCompleted;
        }
    }
}