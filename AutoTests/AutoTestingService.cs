using System;
using System.Collections.Generic;
using System.Linq;
using DBWrapper.Entities;

namespace AutoTests
{
    public class AutoTestingService : IAutoTestingService
    {
        private readonly DbWrapper.DbWrapper _dbWrapper;

        public AutoTestingService()
        {
            _dbWrapper = new DbWrapper.DbWrapper();
        }

        public List<User> GetAllUsers()
        {
            var result = _dbWrapper.GetAllUsersData().Select(user => new User(user)).ToList();
            return result;
        }
        public string LogIn(string userName, string password)
        {
            var users = GetAllUsers();
            foreach (var user in users.Where(user => user.UserName == userName))
            {
                if (user.Password == password)
                    return ("Sucess;" + user.Id + ";" + user.UserRights);
                return null;
            }
            return null;
        }

        public List<TestSet> GetAllTestSets()
        {
            var result = _dbWrapper.GetAllTestSets().Select(testSet => new TestSet(testSet)).ToList();
            return result;
        }

        public List<Test> GetAllTests()
        {
            var result = _dbWrapper.GetAllTests().Select(test => new Test(test)).ToList();
            _dbWrapper.CurrentSession.Dispose();
            return result;
        }

        public List<Test> GetTestsInTestSet(int testSetId)
        {
            var result = _dbWrapper.GetTestsInTestSet(testSetId).Select(test => new Test(test)).ToList();
            return result;
        }

        public string AddTest(Test test)
        {
            try
            {
                var newTest = new DBWrapper.Entities.Test
                {
                    Answer = test.Answer, Complexity = test.Complexity, Text = test.Text,
                    FakeAnswers = ConvertFakeAnswersToString(test.FakeAnswers)
                };
                _dbWrapper.AddTest(newTest);
                return null;
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        public List<Statistic> GetAllStatistic()
        {
            return _dbWrapper.GetAllStatistic().Select(statistic => new Statistic(statistic)).ToList();
        }


        public List<Statistic> GetAllUsersStatistic(int userId)
        {
           return _dbWrapper.GetAllStatisticByUserId(userId).Select(statistic => new Statistic(statistic)).ToList();
        }

        public string AddStatistic(Statistic statistic, int testSetId, int userId)
        {
            try
            {
                var newStatistic = new DBWrapper.Entities.Statistic
                {
                    RightTasks = statistic.RightTasks,
                    Mark = statistic.Mark,  
                };
                _dbWrapper.AddStatistic(newStatistic, testSetId, userId);
                return null;
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }


        public string AddTestWithTestSet(Test test, int testSetId)
        {
            try
            {
                var newTest = new DBWrapper.Entities.Test
                {
                    Answer = test.Answer,
                    Complexity = test.Complexity,
                    Text = test.Text,
                    FakeAnswers = ConvertFakeAnswersToString(test.FakeAnswers)
                };
                _dbWrapper.AddTest(newTest, testSetId);
                return null;
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        public string AddTestSetAndTestsWithUser(TestSet testSet, int userId, List<Test> tests)
        {
            try
            {
                var newTestSet = new DBWrapper.Entities.TestSet
                {
                    Complexity = testSet.Complexity,
                    Name = testSet.Name
                };
                var newTests = tests.Select(test => new DBWrapper.Entities.Test
                {
                    Answer = test.Answer,
                    Complexity = test.Complexity,
                    Text = test.Text,
                    FakeAnswers = ConvertFakeAnswersToString(test.FakeAnswers)
                }).ToList();
                _dbWrapper.AddTestSet(newTestSet, userId, newTests);
                return null;
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        public string AddTestSetWithUser(TestSet testSet, int userId)
        {
            try
            {
                var newTestSet = new DBWrapper.Entities.TestSet
                {
                    Complexity = testSet.Complexity, Name = testSet.Name
                };
                _dbWrapper.AddTestSet(newTestSet, userId);
                return null;
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        public string AddUser(User user)
        {
            try
            {
                _dbWrapper.AddUser(new UserData{Name = user.UserName, Rights = user.UserRights});
                return "Sucess" + ";" + user.Id + ";" + user.UserRights;
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
        private static string ConvertFakeAnswersToString(IEnumerable<string> fakeAnswers)
        {
            string result = null;
            if (fakeAnswers == null)
                return null;
            foreach (var answer in fakeAnswers)
            {
                if (result == null)
                    result = answer;
                else
                    result = (result + ';' + answer);
            }
            return result;
        }

        /*
        public List<TestSet> GetAllTestSets()
        {
            var db = new DbWrapper.DbWrapper();
            return db.GetAllTestSets();
        }

        public List<Test> GetAllTests()
        {
            var db = new DbWrapper.DbWrapper();
            return db.GetAllTests();
        }

        public string GetUserName()
        {
            return null;
        }*/
    }
}
