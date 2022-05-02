using Microsoft.VisualStudio.TestTools.UnitTesting;
public class FunctionTest
{
    public FunctionTest()
    {
        Functions testFunction = new Functions();
        Assert.IsNotNull(testFunction);
        Assert.IsInstanceOfType(testFunction, typeof(Functions));
    }
    public void Eql_Obj_Test_Null()
    {
        Functions target = new Functions();
        object inobject = null;
        bool expected = false;
        bool actual = target.Equals(inobject);
        Assert.AreEqual(expected, actual);
    }
    [TestMethod]
    public void Eql_Test_Null()
    {
        string expectedResult = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|DB\Database.mdf;Integrated Security=True";
        string actualResult = Functions.ConnectionString("Admin");
        Assert.AreEqual<string>(expectedResult, actualResult);

    }
}