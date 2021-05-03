using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonoovaAdapter.Providers;
using MonoovaAdapter.Entities;
using MonoovaAdapter.Entities.Automatcher;
using MonoovaAdapter.Entities.BPAY;
using MonoovaAdapter.Entities.MAccount;
using MonoovaAdapter.Entities.MAccount.Dto;
using MonoovaAdapter.Entities.MWallet;
using MonoovaAdapter.Entities.PayID;
using MonoovaAdapter.Entities.Reports;
using MonoovaAdapter.Entities.Security;
using MonoovaAdapter.Entities.Subscriptions;
using MonoovaAdapter.Entities.Token;
using MonoovaAdapter.Entities.Tools;
using MonoovaAdapter.Entities.Transaction;
using MonoovaAdapter.Entities.Transaction.Disbursement;
using MonoovaAdapter.Entities.Verify;
using MonoovaAdapter.Entities.Whitelisting;
using MAccount = MonoovaAdapter.Entities.Transaction.MAccount;

namespace MonoovaAdapterTest
{
    [TestClass]
    public class UnitTest1
    {
        private IMonoovaProvider _provider;

        [TestInitialize]
        public void TestInit()
        {
            _provider = new MonoovaProvider(new ProviderParam()
            {
                BaseUrl = "https://api.m-pay.com.au",
                Username = "b0060869-63b4-4113-8db7-fff9aa328340",
                Password = ""
            });
        }

        // Receive and Pay
        // Financial / Payments
        // Process a transaction
        [TestMethod]
        public void TestProcessTransaction()
        {
            var request = new TransactionRequestMAccount
            {
                TotalAmount = (decimal)0.01,
                PaymentSource = PaymentSource.MAccount.ToString(),
                MAccount = new MAccount() { Token = _provider.GetProviderParam().Username },
                Disbursements = new List<object>
                {
                    new DirectCredit()
                    {
                        DisbursementMethod = "directCredit",
                        Description = "Demo Payment",
                        ToDirectCreditDetails = new DirectCreditDetail()
                        {
                            AccountName = "Demo",
                            AccountNumber = 123456,
                            BsbNumber = "012-878"
                        },
                        Amount = (decimal) 0.01
                    }
                }
            };
            _provider.ProcessTransaction(request);
        }

        // Validate a transaction
        [TestMethod]
        public void TestValidateTransaction()
        {
            var request = new TransactionRequestMAccount
            {
                TotalAmount = (decimal)0.01,
                PaymentSource = PaymentSource.MAccount.ToString(),
                MAccount = new MAccount() { Token = _provider.GetProviderParam().Username },
                Disbursements = new List<object>
                {
                    new DirectCredit()
                    {
                        DisbursementMethod = "directCredit",
                        Description = "Demo Payment",
                        ToDirectCreditDetails = new DirectCreditDetail()
                        {
                            AccountName = "Demo",
                            AccountNumber = 123456,
                            BsbNumber = "012-878"
                        },
                        Amount = (decimal) 0.01
                    }
                }
            };
            _provider.ValidateTransaction(request);
        }

        // Get transaction status by UID
        [TestMethod]
        public void TestGetTransactionByUis()
        {
            var request = new GetTransactionRequest();
            _provider.GetTransactionByUid(request);
        }

        // Get transaction status by Date
        [TestMethod]
        public void TestGetTransactionByDate()
        {
            var request = new GetTransactionByDateRequest()
            {
                EndDate = "2021-04-30",
                StartDate = "2021-04-30"
            };
            _provider.GetTransactionByDate(request);
        }

        [TestMethod]
        public void TestProcessCreditCardRefund()
        {
            var request = new RefundRequest
            {
                UniqueReference = "Refund-00001",
                RefundAmount = (decimal)0.01,
                Description = "Demo refund",
                OriginalTransactionId = 15
            };
            _provider.ProcessCreditCardRefund(request);
        }

        [TestMethod]
        public void TestValidateCreditCardRefund()
        {
            var request = new RefundRequest
            {
                UniqueReference = "Refund-00001",
                RefundAmount = (decimal)0.01,
                Description = "Demo refund",
                OriginalTransactionId = 15
            };
            _provider.ValidateCreditCardRefund(request);
        }


        // BPAY
        // Validate a BPAY transaction
        [TestMethod]
        public void TestValidateBpayTransaction()
        {
            var request = new ValidateBpayTransactionRequest();
            _provider.ValidateBpayTransaction(request);
        }

        // Get BPAY biller code details
        [TestMethod]
        public void TestGetBpayBillerCodeDetails()
        {
            var request = new GetBpayBillerCodeDetailsRequest();
            _provider.GetBpayBillerCodeDetails(request);
        }

        // Search for BPAY billers
        [TestMethod]
        public void TestSearchBpayBillers()
        {
            var request = new SearchBpayBillersRequest();
            _provider.SearchBpayBillers(request);
        }

        // Get a wallet's BPAY History
        [TestMethod]
        public void TestGetBpayHistory()
        {
            var request = new GetBpayHistoryRequest();
            _provider.GetBpayHistory(request);
        }

        // BPAY Receivables Report
        [TestMethod]
        public void TestBpayReceivablesReport()
        {
            var request = new BpayReceivablesReportRequest();
            _provider.BpayReceivablesReport(request);
        }


        // Verify
        // Initiate a NPP verification transaction
        [TestMethod]
        public void TestInitialVerification()
        {
            var request = new InitiateRequest()
            {
                CreditMethod = "NppCreditBankAccount",
                Bsb = "012-030",
                BankAccountNumber = "640746572",
                AccountName = "Demo Acc",
                Remitter = "Ran",
                PyIdType = PayIdType.Email.ToString(),
                PayId = "cs.pangge@gmail.com",
                VerificationIdentifier = "NPP Bank Account Verification Identifier",
            };
            _provider.InitiateVerification(request);
        }

        // Initiate a verification transaction
        [TestMethod]
        public void TestInitialV1Verification()
        {
            var request = new InitiateV1Request()
            {
                Bsb = "012-030",
                BankAccountNumber = "640746572",
                BankAccountTitle = "Demo Acc",
                Remitter = "MPRetail",
                VerificationIdentifier = "Demo Acc",
                HasDdAuthority = true
            };
            _provider.InitiateV1Verification(request);
        }

        // Complete an account verification
        [TestMethod]
        public void TestCompleteVerification()
        {
            var request = new CompleteVerificationRequest();
            _provider.CompleteVerification(request);
        }

        // Get a verification token's details
        [TestMethod]
        public void TestGetVerificationDetail()
        {
            var request = new GetVerificationDetailRequest();
            _provider.GetVerificationDetail(request);
        }

        // List verified bank accounts
        [TestMethod]
        public void TestListVerifiedBackAcc()
        {
            _provider.ListVerifiedBackAcc();
        }

        // Update a verified bank account
        [TestMethod]
        public void TestUpdateVerifiedAccount()
        {
            var request = new UpdateVerifiedAccountRequest();
            _provider.UpdateVerifiedAccount(request);
        }


        // Automatcher (Bank Account Receivables)
        // Create a Automatcher (Receivables) Account
        [TestMethod]
        public void TestCreateAutomatcher()
        {
            var request = new CreateAutomatcherRequest
            {
                BankAccountName = "Demo1234",
                ClientUniqueId = "demo12345678",
                IsActive = true
            };
            if (
                request.BankAccountName.Length <= 9 &&
                request.ClientUniqueId.Length >= 10 &&
                request.ClientUniqueId.Length <= 35
            )
            {
                _provider.CreateAutomatcher(request);
            }
        }

        // Set Account Status
        [TestMethod]
        public void TestSetAccountStatus()
        {
            var request = new SetAccountStatusRequest
            {
                BankAccountNumber = "119892624",
                ClientUniqueId = "demo12345678",
                IsActive = true
            };
            if (
                request.BankAccountNumber.Length <= 9 &&
                request.ClientUniqueId.Length >= 10 &&
                request.ClientUniqueId.Length <= 35
            )
            {
                _provider.SetAccountStatus(request);
            }
        }

        // Get Account Status By BankAccount
        [TestMethod]
        public void TestGetAccountStatusByBankAccount()
        {
            var request = new GetAccountStatusByBankAccountRequest
            {
                BankAccountNumber = "119892624"
            };
            _provider.GetAccountStatusByBankAccount(request);
        }

        // Get Account Status By ClientUniqueId
        [TestMethod]
        public void TestGetAccountStatusByClientUniqueId()
        {
            var request = new GetAccountStatusByClientUniqueIdRequest
            {
                ClientUniqueId = "demo12345678"
            };
            _provider.GetAccountStatusByClientUniqueId(request);
        }

        // Report
        [TestMethod]
        public void TestReport()
        {
            var request = new ReportRequest
            {
                Date = "2021-05-03",
                Skip = 0,
                Take = 1000,
                AccountNumber = 119892624,
                ClientUniqueId = "demo12345678",
                TransactionType = "NPP",
                TransactionCode = 50
            };
            _provider.Report(request);
        }

        // Last Settlement
        [TestMethod]
        public void TestLastSettlement()
        {
            _provider.LastSettlement();
        }

        // List Accounts
        [TestMethod]
        public void TestListAccounts()
        {
            _provider.ListAccounts();
        }

        // Batch Create
        [TestMethod]
        public void TestBatchCreate()
        {
            var request = new BatchCreateRequest();
            _provider.BatchCreate(request);
        }

        // Batch Status
        [TestMethod]
        public void TestBatchStatus()
        {
            var request = new BatchStatusRequest();
            const string path = @"sampleBatchStatus.txt";
            var readText = File.ReadAllBytes(path);
            request.Content = readText;
            _provider.BatchStatus(request);
        }

        // Receivables Refund
        [TestMethod]
        public void TestReceivablesRefund()
        {
            var request = new ReceivablesRefundRequest();
            _provider.ReceivablesRefund(request);
        }

        // Process Direct Debit
        [TestMethod]
        public void TestProcessDirectDebit()
        {
            var request = new ProcessDirectDebitRequest();
            _provider.ProcessDirectDebit(request);
        }

        // Inbound Direct Debit Report
        [TestMethod]
        public void TestInboundDirectDebitReport()
        {
            var request = new InboundDirectDebitReportRequest();
            _provider.InboundDirectDebitReport(request);
        }


        // Whitelisting for Automatcher (Bank Account Receivables)
        // Create Whitelist Source Account
        [TestMethod]
        public void TestCreateWhitelist()
        {
            var request = new CreateWhitelistRequest();
            _provider.CreateWhitelist(request);
        }

        // Update Whitelist Source Account
        [TestMethod]
        public void TestUpdateWhitelist()
        {
            var request = new UpdateWhitelistRequest();
            _provider.UpdateWhitelist(request);
        }

        // List Whitelist Source Accounts 
        [TestMethod]
        public void TestListWhitelist()
        {
            var request = new ListWhitelistRequest
            {
                AutomatcherBankAccountNumber = 119892624
            };
            _provider.ListWhitelist(request);
        }

        // Rejected Transactions Report
        [TestMethod]
        public void TestRejectedTransactionsReport()
        {
            var request = new RejectedTransactionsReportRequest();
            _provider.RejectedTransactionsReport(request);
        }


        // PayID
        // Register PayID
        [TestMethod]
        public void TestRegisterPayId()
        {
            var request = new RegisterPayIdRequest
            {
                BankAccountNumber = 119892624,
                PayIdName = "Demo Acc",
                PayId = ""
            };
            _provider.RegisterPayId(request);
        }

        // Update a PayID's status
        [TestMethod]
        public void TestUpdatePayIdStatus()
        {
            var request = new UpdatePayIdStatusRequest();
            _provider.UpdatePayIdStatus(request);
        }

        // Update a PayID's name
        [TestMethod]
        public void TestUpdatePayIdName()
        {
            var request = new UpdatePayIdNameRequest();
            _provider.UpdatePayIdName(request);
        }

        // PayID Enquiry
        [TestMethod]
        public void TestPayIdEnquiry()
        {
            var request = new PayIdEnquiryRequest
            {
                PayId = "G04BM0@monoova.me"
            };
            _provider.PayIdEnquiry(request);
        }


        // Tools
        // Ping (test authentication)
        [TestMethod]
        public void TestPing()
        {
            _provider.Ping();
        }

        // Validate a BSB
        [TestMethod]
        public void TestValidateBsb()
        {
            var request = new ValidateBsbRequest();
            _provider.ValidateBsb(request);
        }

        // Validate an ABN
        [TestMethod]
        public void TestValidateAbn()
        {
            var request = new ValidateAbnRequest();
            _provider.ValidateAbn(request);
        }

        // Email an issuer
        [TestMethod]
        public void TestEmailIssuer()
        {
            var request = new EmailIssuerRequest();
            _provider.EmailIssuer(request);
        }


        // Manage
        // Subscriptions
        // Subscribe to new Webhook
        [TestMethod]
        public void TestSubscribeWebhook()
        {
            var request = new SubscribeWebhookRequest();
            _provider.SubscribeWebhook(request);
        }

        // Update an existing Webhook
        [TestMethod]
        public void TestUpdateWebhook()
        {
            var request = new UpdateWebhookRequest();
            _provider.UpdateWebhook(request);
        }

        // List all existing webhooks
        [TestMethod]
        public void TestListAllWebhooks()
        {
            _provider.ListAllWebhooks();
        }

        // Unsubscribe from an existing webhook
        [TestMethod]
        public void TestUnsubscribeFromExistingWebhook()
        {
            var request = new UnsubscribeFromExistingWebhookRequest();
            _provider.UnsubscribeFromExistingWebhook(request);
        }

        // Request resending of a notification using the TransactionId
        [TestMethod]
        public void TestRequestResendingNotificationUsingTransactionId()
        {
            var request = new RequestResendingNotificationUsingTransactionIdRequest();
            _provider.RequestResendingNotificationUsingTransactionId(request);
        }


        // Events
        // Receive Payment Webhook
        [TestMethod]
        public void TestReceivePaymentWebhook()
        {
            // var request = new ReceivePaymentWebhookRequest();
            _provider.ReceivePaymentWebhook();
        }

        // Receive Inbound Direct Credits Webhook
        [TestMethod]
        public void TestReceiveInboundDirectCreditsWebhook()
        {
            // var request = new ReceiveInboundDirectCreditsWebhookRequest();
            _provider.ReceiveInboundDirectCreditsWebhook();
        }

        // Receive Inbound Direct Debits Webhook
        [TestMethod]
        public void TestReceiveInboundDirectDebitsWebhook()
        {
            // var request = new ReceiveInboundDirectDebitsWebhookRequest();
            _provider.ReceiveInboundDirectDebitsWebhook();
        }

        // Receive Direct Entry Dishonours Webhook
        [TestMethod]
        public void TestReceiveDirectEntryDishonoursWebhook()
        {
            // var request = new ReceiveDirectEntryDishonoursWebhookRequest();
            _provider.ReceiveDirectEntryDishonoursWebhook();
        }


        // mAccount
        // Create an mAccount
        [TestMethod]
        public void TestCreateMAccount()
        {
            var request = new CreateMAccountRequest
            {
                AccountNumber = "",
                AllowDuplicates = true,
                Name = "Seacow Technology Pty Ltd",
                Abn = "15 167 507 039",
                ContactName = "Ran",
                ContactNumber = "0429 486 670",
                Email = "cs.pangge@gmail.com",
                AddressLine1 = "U1008",
                AddressLine2 = "260 Coward Street",
                Suburb = "Mascot",
                State = "NSW",
                PostCode = "2020",
                Bsb = "012-878",
                BankAccountNumber = "123456789",
                BankAccountTitle = "Back Acc",
                Financials = null,
                Options = new List<object>()
                {
                    new MinimumSettlementAmount()
                    {
                        Key = "MinimumSettlementAmount",
                        Value = (decimal) 0.02
                    }
                }
            };
            _provider.CreateMAccount(request);
        }

        // Close an mAccount
        [TestMethod]
        public void TestCloseMAccount()
        {
            var request = new CloseMAccountRequest();
            _provider.CloseMAccount(request);
        }

        // Get mAccount Balance
        [TestMethod]
        public void TestMAccountBalance()
        {
            _provider.GetMAccountBalance();
        }

        // Get mAccount details
        [TestMethod]
        public void TestGetMAccountDetails()
        {
            var request = new GetMAccountDetailsRequest();
            _provider.GetMAccountDetails(request);
        }

        // List as issuer
        [TestMethod]
        public void TestListIssuer()
        {
            _provider.ListIssuer();
        }

        // Send a statement
        [TestMethod]
        public void TestSendStatement()
        {
            var request = new SendStatementRequest();
            _provider.SendStatement(request);
        }

        // Get transactions by mAccount
        [TestMethod]
        public void TestGetTransactionsByMAccount()
        {
            var request = new GetTransactionsByMAccountRequest();
            _provider.GetTransactionsByMAccount(request);
        }

        // Update mAccount details
        [TestMethod]
        public void TestUpdateMAccountDetails()
        {
            var request = new UpdateMAccountDetailsRequest();
            _provider.UpdateMAccountDetails(request);
        }


        // Reports
        // Get all transactions in a daily settlement
        [TestMethod]
        public void TestGetAllTransactionsInDailySettlement()
        {
            var request = new GetAllTransactionsInDailySettlementRequest();
            _provider.GetAllTransactionsInDailySettlement(request);
        }

        // Get all successful transactions for a date
        [TestMethod]
        public void TestGetAllSuccessfulTransactionsByDate()
        {
            var request = new GetAllSuccessfulTransactionsByDateRequest();
            _provider.GetAllSuccessfulTransactionsByDate(request);
        }


        // Security
        // Create OneShot security Token
        [TestMethod]
        public void TestCreateOneShotSecurityToken()
        {
            var request = new CreateOneShotSecurityTokenRequest();
            _provider.CreateOneShotSecurityToken(request);
        }

        // Get Sign-in account fees & permissions
        [TestMethod]
        public void TestGetSignInAccountFeesAndPermissions()
        {
            _provider.GetSignInAccountFeesAndPermissions();
        }


        // Token
        // Create bank account token
        [TestMethod]
        public void TestCreateBankAccountToken()
        {
            var request = new CreateBankAccountTokenRequest();
            _provider.CreateBankAccountToken(request);
        }

        // Create BPAY token
        [TestMethod]
        public void TestCreateBpayToken()
        {
            var request = new CreateBpayTokenRequest();
            _provider.CreateBpayToken(request);
        }

        // Delete token
        [TestMethod]
        public void TestDeleteToken()
        {
            var request = new DeleteTokenRequest();
            _provider.DeleteToken(request);
        }

        // Get token details
        [TestMethod]
        public void TestGetTokenDetails()
        {
            var request = new GetTokenDetailsRequest();
            _provider.GetTokenDetails(request);
        }

        // List tokens by mAccount
        [TestMethod]
        public void TestListTokensByMAccount()
        {
            var request = new ListTokensByMAccountRequest();
            request.AccountNumber = _provider.GetProviderParam().Username;
            _provider.ListTokensByMAccount(request);
        }

        // Update bank account token
        [TestMethod]
        public void TestUpdateBankAccountToken()
        {
            var request = new UpdateBankAccountTokenRequest();
            _provider.UpdateBankAccountToken(request);
        }

        // Update BPAY token
        [TestMethod]
        public void TestUpdateBpayToken()
        {
            var request = new UpdateBpayTokenRequest();
            _provider.UpdateBpayToken(request);
        }

        // Validate token
        [TestMethod]
        public void TestValidateToken()
        {
            var request = new ValidateTokenRequest();
            _provider.ValidateToken(request);
        }


        // MWallet
        // Create an mWallet
        [TestMethod]
        public void TestCreateMWallet()
        {
            var request = new CreateMWalletRequest();
            _provider.CreateMWallet(request);
        }

        // Close an mWallet
        [TestMethod]
        public void TestCloseMWallet()
        {
            var request = new CloseMWalletRequest();
            _provider.CloseMWallet(request);
        }

        // Get mWallet Balance
        [TestMethod]
        public void TestGetMWalletBalance()
        {
            var request = new GetMWalletBalanceRequest();
            _provider.GetMWalletBalance(request);
        }

        // Reopen a closed mWallet
        [TestMethod]
        public void TestReopenClosedMWallet()
        {
            var request = new ReopenClosedMWalletRequest();
            _provider.ReopenClosedMWallet(request);
        }

        // Reset an mWallet PIN
        [TestMethod]
        public void TestResetMWalletPin()
        {
            var request = new ResetMWalletPinRequest();
            _provider.ResetMWalletPin(request);
        }

        // mWallet search
        [TestMethod]
        public void TestMWalletSearch()
        {
            var request = new MWalletSearchRequest();
            _provider.MWalletSearch(request);
        }

        // Get transactions by mWallet
        [TestMethod]
        public void TestGetTransactionsByMWallet()
        {
            var request = new GetTransactionsByMWalletRequest();
            _provider.GetTransactionsByMWallet(request);
        }

        // Update mWallet details
        [TestMethod]
        public void TestUpdateMWalletDetails()
        {
            var request = new UpdateMWalletDetailsRequest();
            _provider.UpdateMWalletDetails(request);
        }
    }
}
