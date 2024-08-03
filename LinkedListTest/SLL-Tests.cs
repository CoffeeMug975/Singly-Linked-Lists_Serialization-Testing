using OO2_Assignment3_Group4;

namespace LinkedListTest
{
    [TestFixture]
    public class LinkedListTest
    {
        [Test]
        public void TestLinkedListIsEmpty()
        {
            SLL<int> list = new SLL<int>();
            Assert.AreEqual(0, list.Count);
        }

        [Test]
        public void TestPrepend()
        {
            SLL<int> list = new SLL<int>();
            list.Prepend(1);
            Assert.AreEqual(1, list.GetItemAtIndex(0));
            Assert.AreEqual(1, list.Count);
        }

        [Test]
        public void TestAppend()
        {
            SLL<int> list = new SLL<int>();
            list.Append(1);
            Assert.AreEqual(1, list.GetItemAtIndex(0));
            Assert.AreEqual(1, list.Count);
        }

        [Test]
        public void TestInsertAt()
        {
            SLL<int> list = new SLL<int>();
            list.Append(1);
            list.Append(3);
            list.Insert(1, 2);
            Assert.AreEqual(2, list.GetItemAtIndex(1));
            Assert.AreEqual(3, list.Count);
        }

        [Test]
        public void TestReplace()
        {
            SLL<int> list = new SLL<int>();
            list.Append(1);
            list.Append(2);
            list.Replace(1, 3);
            Assert.AreEqual(3, list.GetItemAtIndex(1));
        }

        [Test]
        public void TestRemoveFirst()
        {
            SLL<int> list = new SLL<int>();
            list.Append(1);
            list.Append(2);
            list.RemoveAtStart();
            Assert.AreEqual(2, list.GetItemAtIndex(0));
            Assert.AreEqual(1, list.Count);
        }

        [Test]
        public void TestRemoveLast()
        {
            SLL<int> list = new SLL<int>();
            list.Append(1);
            list.Append(2);
            list.RemoveAtEnd();
            Assert.AreEqual(1, list.GetItemAtIndex(0));
            Assert.AreEqual(1, list.Count);
        }

        [Test]
        public void TestRemoveAt()
        {
            SLL<int> list = new SLL<int>();
            list.Append(1);
            list.Append(2);
            list.Append(3);
            list.RemoveAtIndex(1);
            Assert.AreEqual(3, list.GetItemAtIndex(1));
            Assert.AreEqual(2, list.Count);
        }

        [Test]
        public void TestGetAt()
        {
            SLL<int> list = new SLL<int>();
            list.Append(1);
            list.Append(2);
            int value = list.GetItemAtIndex(1);
            Assert.AreEqual(2, value);
        }

        [Test]
        public void TestReverse()
        {
            SLL<int> list = new SLL<int>();
            list.Append(1);
            list.Append(2);
            list.Append(3);
            list.Reverse();
            Assert.AreEqual(3, list.GetItemAtIndex(0));
            Assert.AreEqual(2, list.GetItemAtIndex(1));
            Assert.AreEqual(1, list.GetItemAtIndex(2));
        }
    }
}