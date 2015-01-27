using System.Collections.Generic;

namespace DBWrapper.Entities
{
    public class Group
    {
        public virtual int GroupId { get; protected set; }
        public virtual string Name { get; set; }
        public virtual int Number { get; set; }
        public virtual IList<UserData> UserData { get; set; }
        public virtual University University { get; set; }

        public Group()
        {
            UserData = new List<UserData>();
        }
    }

    public class University
    {
        public virtual int UniversityId { get; protected set; }
        public virtual string Name { get; set; }
        public virtual IList<UserData> UserData { get; set; }
        public virtual IList<Group> Group { get; set; }

        public University()
        {
            UserData = new List<UserData>();
            Group = new List<Group>();
        }
    }

    public class Statistic
    {
        public virtual int StatisticId { get; protected set; }
        public virtual int Mark { get; set; }
        public virtual int RightTasks { get; set; }
        public virtual UserData UserData { get; set; }
        public virtual TestSet TestSet { get; set; }
        public virtual Group Group { get; set; }
        public virtual University University { get; set; }

        /*public Statistic()
        {
            TestSet = new List<TestSet>();
            Group = new List<Group>();
            University = new List<University>();
            UserData = new List<UserData>();
        }*/
    }

    public class UserData
    {
        public virtual int UserId { get; protected set; }
        public virtual string Name { get; set; }
        public virtual string Password { get; set; }
        public virtual short? Rights { get; set; }
        public virtual Group Group { get; set; }
        public virtual University University { get; set; }
        public virtual IList<TestSet> TestSet { get; set; }

        public UserData()
        {
            TestSet = new List<TestSet>();
        }

    }

    public class Test
    {
        public virtual int TestId { get; protected set; }
        public virtual string Text { get; set; }
        public virtual short? Complexity { get; set; }
        public virtual string Answer { get; set; }
        public virtual string FakeAnswers { get; set; }
        public virtual TestSet TestSet { get; set; }
    }

    public class TestSet
    {
        public virtual int TestSetId { get; protected set; }
        public virtual string Name { get; set; }
        public virtual short? Complexity { get; set; }
        public virtual UserData UserData { get; set; }
        public virtual IList<Test> Test { get; set; } 

        public TestSet()
        {
            Test = new List<Test>();
        }
    }
}