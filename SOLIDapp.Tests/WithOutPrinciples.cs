using SOLIDapp.Domain.WithOutPrinciple;

namespace SOLIDapp.Tests;

[TestClass]
public class WithOutPrinciples
{
    [TestMethod]
    public void GivenSimpleResponsabilityPrincipleExample_ExecuteWithOutPrinciple_ResultSuccess()
    {
            BankAccount johnsAccount = new BankAccount(123456);
            johnsAccount.Deposit(500);
            johnsAccount.Withdraw(100);
            johnsAccount.PrintStatement();
            string report = johnsAccount.PrintStatement();
            Assert.IsTrue(report.Contains("123456"));
            Assert.IsTrue(report.Contains("500"));
            Assert.IsTrue(report.Contains("100"));
    }

    [TestMethod]
    public void GivenOpenClosedPrincipleExample_ExecuteWithOutPrinciple_ResultSuccess()
    {
        Invoice FInvoice = new Invoice();
        double FInvoiceAmount = FInvoice.GetInvoiceDiscount(10000, InvoiceType.FinalInvoice);
        Assert.IsTrue( FInvoiceAmount == 9940);

        Invoice PInvoice = new Invoice();
        double PInvoiceAmount = PInvoice.GetInvoiceDiscount(10000, InvoiceType.ProposedInvoice);
        Assert.IsTrue( PInvoiceAmount == 9950);
    }    
}