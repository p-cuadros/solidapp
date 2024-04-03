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

    [TestMethod]
    public void GivenLiskovSustitutionPrincipleExample_ExecuteWithOutPrinciple_ResultSuccess()
    {
        Account RegularBankAccount = new Account();
        RegularBankAccount.Deposit(1000);
        RegularBankAccount.Deposit(500);
        RegularBankAccount.Withdraw(900);
        var ex = Assert.ThrowsException<InvalidOperationException>(() => RegularBankAccount.Withdraw(800));
        Assert.AreEqual("Insufficient funds", ex.Message);;

        Account FixedTermDepositBankAccount = new FixedTermDepositAccount();
        FixedTermDepositBankAccount.Deposit(1000);
        ex = Assert.ThrowsException<InvalidOperationException>(() => FixedTermDepositBankAccount.Withdraw(500));
        Assert.AreEqual("Cannot withdraw from a fixed term deposit account until term ends", ex.Message);;
    }

    [TestMethod]
    public void GivenInterfaceSegregationPrincipleExample_ExecuteWithOutPrinciple_ResultSuccess()
    {
        ReadOnlyUser readOnlyUser = new ReadOnlyUser();
        readOnlyUser.CreateDocument("document"); //Compile Time Error
        readOnlyUser.ReadDocument(1);
        readOnlyUser.UpdateDocument(1, "document");  //Compile Time Error
        readOnlyUser.DeleteDocument(1);  //Compile Time Error
    }

    [TestMethod]
    public void GivenDependencyInversionPrincipleExample_ExecuteWithOutPrinciple_ResultSuccess()
    {
        // var creditCardPayment = new CreditCard();
        var paymentProcessor1 = new PaymentProcessor();
        var voucher = paymentProcessor1.ExecutePayment(100m);
        Assert.IsTrue(voucher.Contains("100"));
        // var paypalPayment = new PayPal();
        // var paymentProcessor2 = new PaymentProcessor(paypalPayment);
        // voucher = paymentProcessor2.ExecutePayment(100m);
        // Assert.IsTrue(voucher.Contains("100"));
    }
}