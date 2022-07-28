using EvaluationProduit.MVC.Services;

namespace EvaluationProduitMVC.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void RecupererlaMoyenneEvaluationEstCorrecte()
        {
            // Arrange
            IProduitService produitService = new ProduitService();
            var evaluation1 = 2;
            var evaluation2 = 2;

            // Act
            var resultat = produitService.RecupererlaMoyenneEvaluation(evaluation1, evaluation2);
            // Assert
            Assert.AreEqual(2, resultat);
        }
    }
}