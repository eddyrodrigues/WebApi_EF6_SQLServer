using Blog.Domain.Arguments;
using Blog.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blog.Tests;

[TestClass]
public class CategoryTest
{
    [TestMethod]
    [DataRow("", "")]
    [DataRow(null, "")]
    [DataRow(null, null)]
    public void RetornaFalsoQuandoCategoriaArgumentIsInvalida(string name, string slug)
    {
      var category = new CategoryArgument(name, slug);
      Assert.AreEqual(false, category.IsValid);
    }

    [TestMethod]
    [DataRow("Eduardo", "Rodrigues")]
    [DataRow("asdasdasd", "dddd")]
    [DataRow("Toca", "Borges")]
    public void RetornaTrueQuandoCategoriaArgumentIsValida(string name, string slug)
    {
      var category = new CategoryArgument(name, slug);
      Assert.AreEqual(true, category.IsValid);
    }

    
}