using System;

namespace VerySimpleTaskList
{
    public class TaskWithReminder : Task 
    {
        public TaskWithReminder(string description, int numOfHours) 
            : base(description)
        {
            _numberOfHours = numOfHours;
            _tempdate = DateTime.Now.AddHours(_numberOfHours);

        }
        public override string DescribeYourself()
        {
            string parentsDescription = base.DescribeYourself();
            //return $"{parentsDescription} and I will remind you in {_numberOfHours} {_tempdate}hour(s).";
            return $"{parentsDescription} and I will remind you at  {_tempdate} .";
        }
        private int _numberOfHours;
        private DateTime _tempdate;
    }
}
