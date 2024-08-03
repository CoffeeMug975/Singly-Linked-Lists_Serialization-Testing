using OO2_Assignment3_Group4;

namespace SerializationTests
{
    [TestFixture]
    public class SerializationTests
    {
        private SLL<User> users;
        private readonly string testFileName = "test_users.bin";

        [SetUp]
        public void Setup()
        {
            users = new SLL<User>();

            users.Append(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            users.Append(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
            users.Append(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));
            users.Append(new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999"));
        }

        [TearDown]
        public void TearDown()
        {
            users.ClearList();
            if (File.Exists(testFileName))
            {
                File.Delete(testFileName);
            }
        }

        [Test]
        public void TestSerialization()
        {
            SerializationHelper.SerializeUsers(users, testFileName);
            Assert.IsTrue(File.Exists(testFileName));
        }

        [Test]
        public void TestDeSerialization()
        {
            SerializationHelper.SerializeUsers(users, testFileName);
            SLL<User> deserializedUsers = SerializationHelper.DeserializeUsers(testFileName);

            Assert.AreEqual(users.Count, deserializedUsers.Count);

            for (int i = 0; i < users.Count; i++)
            {
                User expected = users.GetItemAtIndex(i);
                User actual = deserializedUsers.GetItemAtIndex(i);

                Assert.AreEqual(expected.Id, actual.Id);
                Assert.AreEqual(expected.Name, actual.Name);
                Assert.AreEqual(expected.Email, actual.Email);
                Assert.AreEqual(expected.Password, actual.Password);
            }
        }
    }
}