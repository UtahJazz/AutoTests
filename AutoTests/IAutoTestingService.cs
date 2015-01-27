using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using DBWrapper.Entities;

namespace AutoTests
{
    [ServiceContract]
    public interface IAutoTestingService
    {
        [OperationContract]
        List<User> GetAllUsers();

        [OperationContract]
        string AddUser(User user);

        [OperationContract]
        string LogIn(string userName, string password);

        [OperationContract]
        List<TestSet> GetAllTestSets();

        [OperationContract]
        string AddTestSetWithUser(TestSet test, int userId);

        [OperationContract]
        string AddTestSetAndTestsWithUser(TestSet test, int userId, List<Test> tests);

        [OperationContract]
        List<Test> GetAllTests();

        [OperationContract]
        List<Test> GetTestsInTestSet(int testSetId);

        [OperationContract]
        string AddTest(Test test);

        [OperationContract]
        string AddTestWithTestSet(Test test, int testSetId);

        [OperationContract]
        string AddStatistic(Statistic statistic, int testSetId, int userId);

        [OperationContract]
        List<Statistic> GetAllUsersStatistic(int userId);

        [OperationContract]
        List<Statistic> GetAllStatistic();
    }

    [DataContract]
    public class Statistic
    {
        public Statistic(DBWrapper.Entities.Statistic statistic)
        {
            StatisticId = statistic.StatisticId;
            Mark = statistic.Mark;
            RightTasks = statistic.RightTasks;
            UserId = statistic.UserData == null ? 270 : statistic.UserData.UserId;
            var db = new DbWrapper.DbWrapper();
            if (statistic.TestSet != null)
                TestSet = new TestSet(db.GetTestSetById(statistic.TestSet.TestSetId));
        }

        [DataMember]
        public int StatisticId { get; set; }

        [DataMember]
        public int Mark { get; set; }

        [DataMember]
        public int RightTasks { get; set; }

        [DataMember]
        public TestSet TestSet { get; set; }

        [DataMember]
        public int UserId { get; set; }
    }

    [DataContract]
    public class User
    {
        public User(UserData userData)
        {
            Id = userData.UserId;
            UserRights = userData.Rights;
            UserName = userData.Name;
            Password = userData.Password;
        }

        public User(int id, short userRights, string userName, string password)
        {
            Id = id;
            UserRights = userRights;
            UserName = userName;
            Password = password;
        }

        [DataMember]
        public short? UserRights { get; set; }

        [DataMember]
        public string UserName { get; set; }
        
        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public int Id { get; set; }
    }

    [DataContract]
    public class TestSet
    {
        public TestSet(DBWrapper.Entities.TestSet testSet)
        {
            Id = testSet.TestSetId;
            Complexity = testSet.Complexity;
            Name = testSet.Name;
            Tests = new List<Test>();
            foreach (var test in testSet.Test)
                Tests.Add(new Test(test));
        }

        public TestSet(int id, short? complexity, string name, List<Test> tests = null)
        {
            Id = id;
            Complexity = complexity;
            Name = name;
            Tests = tests;
        }

        [DataMember]
        public short? Complexity { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Id { get; private set; }

        [DataMember]
        public List<Test> Tests { get; set; } 
    }

    [DataContract]
    public class Test
    {
        public Test(DBWrapper.Entities.Test test)
        {
            Id = test.TestId;
            Complexity = test.Complexity;
            Text = test.Text;
            Answer = test.Answer;

            if (test.TestSet != null)
                TestSet = new TestSet
                    (test.TestSet.TestSetId, test.TestSet.Complexity, test.TestSet.Name);

            FakeAnswers = new List<string>();

            if (test.FakeAnswers == null)
                return;
            var fakeAnswers = test.FakeAnswers.Split(';');
            foreach (var fakeAnswer in fakeAnswers)
            {
                FakeAnswers.Add(fakeAnswer);
            }

        }

        public Test(int id, short? complexity, string text, string answer, TestSet testSet, List<string> fakeAnswers)
        {
            Id = id;
            Complexity = complexity;
            Text = text;
            Answer = answer;
            TestSet = testSet;
            FakeAnswers = fakeAnswers;
        }

        [DataMember] 
        public List<string> FakeAnswers;
        
        [DataMember]
        public TestSet TestSet { get; set; }

        [DataMember]
        public short? Complexity { get; set; }

        [DataMember]
        public string Text { get; set; }

        [DataMember]
        public string Answer { get; set; }

        [DataMember]
        public int Id { get; set; }
    }
}
