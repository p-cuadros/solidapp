using SOLIDapp.Domain.WithPrinciple;

namespace SOLIDapp.Tests;
[TestClass]
public class WithPrinciples
{
    [TestMethod]
    public void GivenSimpleResponsabilityPrincipleExample_ExecuteWithPrinciple_ResultSuccess()
    {
            BankAccount johnsAccount = new BankAccount(123456);
            johnsAccount.Deposit(500);
            johnsAccount.Withdraw(100);
            StatementPrinter printer = new StatementPrinter();
            string report = printer.Print(johnsAccount);
            Assert.IsTrue(report.Contains("123456"));
            Assert.IsTrue(report.Contains("500"));
            Assert.IsTrue(report.Contains("100"));
    }

    [TestMethod]
    public void GivenOpenClosedPrincipleExample_ExecuteWithPrinciple_ResultSuccess()
    {
        Invoice FInvoice = new FinalInvoice();
        double FInvoiceAmount = FInvoice.GetInvoiceDiscount(10000);
        Assert.IsTrue( FInvoiceAmount == 9940);

        Invoice PInvoice = new ProposedInvoice();
        double PInvoiceAmount = PInvoice.GetInvoiceDiscount(10000);
        Assert.IsTrue( PInvoiceAmount == 9950);

        Invoice RInvoice = new RecurringInvoice();
        double RInvoiceAmount = RInvoice.GetInvoiceDiscount(10000);
        Assert.IsTrue( RInvoiceAmount == 9960);
    }
}