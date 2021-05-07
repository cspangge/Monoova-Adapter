using System;
using System.IO;
using MonoovaAdapter.Entities;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MonoovaAdapter.Entities.Automatcher;
using MonoovaAdapter.Entities.BPAY;
using MonoovaAdapter.Entities.Events;
using MonoovaAdapter.Entities.MAccount;
using MonoovaAdapter.Entities.MWallet;
using MonoovaAdapter.Entities.PayID;
using MonoovaAdapter.Entities.Reports;
using MonoovaAdapter.Entities.Security;
using MonoovaAdapter.Entities.Subscriptions;
using MonoovaAdapter.Entities.Token;
using MonoovaAdapter.Entities.Tools;
using MonoovaAdapter.Entities.Transaction;
using MonoovaAdapter.Entities.Transaction.Dto;
using MonoovaAdapter.Entities.Verify;
using MonoovaAdapter.Entities.Whitelisting;
using MonoovaAdapter.Utilities;
using Newtonsoft.Json;

namespace MonoovaAdapter.Providers
{
    public class MonoovaProvider : IMonoovaProvider
    {
        private readonly ProviderParam _param;
        private readonly ApiClient _apiClient;
        private readonly JsonSerializerSettings _settings;

        private const string TokenUrl = "/token/v1";
        private const string SecurityUrl = "/security/v1";
        private const string ReportsUrl = "/reports/v1";
        private const string MWalletUrl = "/mWallet/v1";
        private const string MAccountUrl = "/mAccount/v1";
        private const string SubscriptionsUrl = "/subscriptions/v1";
        private const string ToolsUrl = "/tools/v1";
        private const string PayIdUrl = "/receivables/v1/payid";
        private const string WhitelistingUrl = "/receivables/v1/whitelisting";
        private const string AutomatcherUrl = "/receivables/v1";
        private const string VerifyUrl = "/verify/v1";
        private const string BpayUrl = "/bpay/v1";
        private const string FinancialUrl = "/financial/v2";
        private const string PublicUrl = "/public/v1";

        public MonoovaProvider(ProviderParam param)
        {
            _param = param;
            _apiClient = new ApiClient(param);
            _settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
        }

        public ProviderParam GetProviderParam()
        {
            return _param;
        }

        // Receive and Pay
        // Financial / Payments
        // Process a transaction
        public TransactionResponse ProcessTransaction(TransactionRequestMAccount request = null)
        {
            if (request == null) return null;
            var json = JsonConvert.SerializeObject(request);
            var response = _apiClient.Post<string>(FinancialUrl + "/transaction/execute",
                new StringContent(json, Encoding.UTF8, "application/json"));
            var result = JsonConvert.DeserializeObject<TransactionResponse>(response.Result.ResponseText, _settings);
            PrintObj.Print(result);
            return result;
        }

        // Validate a transaction
        public TransactionResponse ValidateTransaction(TransactionRequestMAccount request = null)
        {
            if (request == null) return null;
            var json = JsonConvert.SerializeObject(request);
            var response = _apiClient.Post<string>(FinancialUrl + "/transaction/validate",
                new StringContent(json, Encoding.UTF8, "application/json"));
            var result = JsonConvert.DeserializeObject<TransactionResponse>(response.Result.ResponseText, _settings);
            PrintObj.Print(result);
            return result;
        }

        // Get transaction status by UID
        public GetTransactionResponse GetTransactionByUid(GetTransactionRequest request)
        {
            if (request == null) return null;
            var response = _apiClient.Get<string>(FinancialUrl + "/status/" + request.UniqueReference);
            var result = JsonConvert.DeserializeObject<GetTransactionResponse>(response.Result.ResponseText, _settings);
            PrintObj.Print(result);
            return result;
        }

        // Get transaction status by Date
        public GetTransactionByDateResponse GetTransactionByDate(GetTransactionByDateRequest request)
        {
            if (request == null) return null;
            var response = _apiClient.Get<string>(FinancialUrl + "/status/" + request.StartDate + "/" + request.EndDate);
            var result = JsonConvert.DeserializeObject<GetTransactionByDateResponse>(response.Result.ResponseText, _settings);
            PrintObj.Print(result);
            return result;
        }

        // Process Credit Card Refund
        public RefundResponse ProcessCreditCardRefund(RefundRequest request = null)
        {
            if (request == null) return null;
            var json = JsonConvert.SerializeObject(request);
            var response = _apiClient.Post<string>(FinancialUrl + "/refund/execute",
                new StringContent(json, Encoding.UTF8, "application/json"));
            var result = JsonConvert.DeserializeObject<RefundResponse>(response.Result.ResponseText, _settings);
            PrintObj.Print(result);
            return result;
        }

        // Validate Credit Card Refund
        public RefundResponse ValidateCreditCardRefund(RefundRequest request = null)
        {
            if (request == null) return null;
            var json = JsonConvert.SerializeObject(request);
            var response = _apiClient.Post<string>(FinancialUrl + "/refund/validate",
                new StringContent(json, Encoding.UTF8, "application/json"));
            var result = JsonConvert.DeserializeObject<RefundResponse>(response.Result.ResponseText, _settings);
            PrintObj.Print(result);
            return result;
        }


        // -------------------------------------------------------------------------------------------------------------
        // BPAY
        // Validate a BPAY transaction
        public ValidateBpayTransactionResponse ValidateBpayTransaction(ValidateBpayTransactionRequest request = null)
        {
            if (request == null) return null;
            var response = _apiClient.Get<string>(BpayUrl + "/validate/" + request.BillerCode + "?custRef=" + request.CustRef + "&amount=" + request.Amount);
            var result = JsonConvert.DeserializeObject<ValidateBpayTransactionResponse>(response.Result.ResponseText, _settings);
            PrintObj.Print(result);
            return result;
        }

        // Get BPAY biller code details
        public GetBpayBillerCodeDetailsResponse GetBpayBillerCodeDetails(GetBpayBillerCodeDetailsRequest request = null)
        {
            if (request == null) return null;
            var response = _apiClient.Get<string>(BpayUrl + "/biller/" + request.BillerCode);
            var result = JsonConvert.DeserializeObject<GetBpayBillerCodeDetailsResponse>(response.Result.ResponseText, _settings);
            PrintObj.Print(result);
            return result;
        }

        // Search for BPAY billers
        public SearchBpayBillersResponse SearchBpayBillers(SearchBpayBillersRequest request = null)
        {
            if (request == null) return null;
            var response = _apiClient.Get<string>(BpayUrl + "/billers?search" + request.Search + "&skip=" + request.Skip + "&take=" + request.Take);
            var result = JsonConvert.DeserializeObject<SearchBpayBillersResponse>(response.Result.ResponseText, _settings);
            PrintObj.Print(result);
            return result;
        }

        // Get a wallet's BPAY History
        public GetBpayHistoryResponse GetBpayHistory(GetBpayHistoryRequest request = null)
        {
            if (request == null) return null;
            var response = _apiClient.Get<string>(BpayUrl + "/history/" + request.AccountNumber + "?take=" + request.Take);
            var result = JsonConvert.DeserializeObject<GetBpayHistoryResponse>(response.Result.ResponseText, _settings);
            PrintObj.Print(result);
            return result;
        }

        // BPAY Receivables Report
        public string BpayReceivablesReport(BpayReceivablesReportRequest request = null)
        {
            if (request == null) return null;
            var response = _apiClient.Get<string>(BpayUrl + "/bpayInReport/" + request.Date + "?skip=" + request.Skip + "&take=" + request.Take);
            return response.Result.ResponseText;
        }
        // -------------------------------------------------------------------------------------------------------------


        // -------------------------------------------------------------------------------------------------------------
        // Verify
        // Initiate a NPP verification transaction
        public InitiateResponse InitiateVerification(InitiateRequest request = null)
        {
            if (request == null) return null;
            var json = JsonConvert.SerializeObject(request);
            var response = _apiClient.Post<string>("/verify/v2/aba/initiate",
                new StringContent(json, Encoding.UTF8, "application/json"));
            var result = JsonConvert.DeserializeObject<InitiateResponse>(response.Result.ResponseText, _settings);
            PrintObj.Print(result);
            return result;
        }

        // Initiate a verification transaction
        public InitiateV1Response InitiateV1Verification(InitiateV1Request request = null)
        {
            if (request == null) return null;
            var json = JsonConvert.SerializeObject(request);
            var response = _apiClient.Post<string>(VerifyUrl + "/aba/initiate",
                new StringContent(json, Encoding.UTF8, "application/json"));
            var result = JsonConvert.DeserializeObject<InitiateV1Response>(response.Result.ResponseText, _settings);
            PrintObj.Print(result);
            return result;
        }

        // Complete an account verification
        public CompleteVerificationResponse CompleteVerification(CompleteVerificationRequest request = null)
        {
            if (request == null) return null;
            var json = JsonConvert.SerializeObject(request);
            var response = _apiClient.Post<string>(VerifyUrl + "/aba/update",
                new StringContent(json, Encoding.UTF8, "application/json"));
            var result = JsonConvert.DeserializeObject<CompleteVerificationResponse>(response.Result.ResponseText, _settings);
            PrintObj.Print(result);
            return result;
        }

        // Get a verification token's details
        public GetVerificationDetailResponse GetVerificationDetail(GetVerificationDetailRequest request = null)
        {
            if (request == null) return null;
            var response = _apiClient.Get<string>(VerifyUrl + "/aba/get/" + request.Token);
            var result = JsonConvert.DeserializeObject<GetVerificationDetailResponse>(response.Result.ResponseText, _settings);
            PrintObj.Print(result);
            return result;
        }

        // List verified bank accounts
        public ListVerifiedBackAccResponse ListVerifiedBackAcc()
        {
            var response = _apiClient.Get<string>(VerifyUrl + "/aba/list");
            var result = JsonConvert.DeserializeObject<ListVerifiedBackAccResponse>(response.Result.ResponseText, _settings);
            PrintObj.Print(result);
            return result;
        }

        // Update a verified bank account
        public UpdateVerifiedAccountResponse UpdateVerifiedAccount(UpdateVerifiedAccountRequest request = null)
        {
            if (request == null) return null;
            var json = JsonConvert.SerializeObject(request);
            var response = _apiClient.Post<string>(VerifyUrl + "/aba/update",
                new StringContent(json, Encoding.UTF8, "application/json"));
            var result = JsonConvert.DeserializeObject<UpdateVerifiedAccountResponse>(response.Result.ResponseText, _settings);
            PrintObj.Print(result);
            return result;
        }
        // -------------------------------------------------------------------------------------------------------------


        // -------------------------------------------------------------------------------------------------------------
        // Automatcher (Bank Account Receivables)
        // Create a Automatcher (Receivables) Account
        public CreateAutomatcherResponse CreateAutomatcher(CreateAutomatcherRequest request = null)
        {
            if (request == null) return null;
            var json = JsonConvert.SerializeObject(request);
            var response = _apiClient.Post<string>(AutomatcherUrl + "/create",
                new StringContent(json, Encoding.UTF8, "application/json"));
            var result = JsonConvert.DeserializeObject<CreateAutomatcherResponse>(response.Result.ResponseText, _settings);
            PrintObj.Print(result);
            return result;
        }

        // Set Account Status
        public SetAccountStatusResponse SetAccountStatus(SetAccountStatusRequest request = null)
        {
            if (request == null) return null;
            var json = JsonConvert.SerializeObject(request);
            var response = _apiClient.Post<string>(AutomatcherUrl + "/status",
                new StringContent(json, Encoding.UTF8, "application/json"));
            var result = JsonConvert.DeserializeObject<SetAccountStatusResponse>(response.Result.ResponseText, _settings);
            PrintObj.Print(result);
            return result;
        }

        // Get Account Status By BankAccount
        public GetAccountStatusByBankAccountResponse GetAccountStatusByBankAccount(
            GetAccountStatusByBankAccountRequest request = null)
        {
            if (request == null) return null;
            var response = _apiClient.Get<string>(AutomatcherUrl + "/statusByBankAccount/" + request.BankAccountNumber);
            var result = JsonConvert.DeserializeObject<GetAccountStatusByBankAccountResponse>(response.Result.ResponseText, _settings);
            PrintObj.Print(result);
            return result;
        }

        // Get Account Status By ClientUniqueId
        public GetAccountStatusByClientUniqueIdResponse GetAccountStatusByClientUniqueId(
            GetAccountStatusByClientUniqueIdRequest request = null)
        {
            if (request == null) return null;
            var response = _apiClient.Get<string>(AutomatcherUrl + "/statusByClientID/" + request.ClientUniqueId);
            var result = JsonConvert.DeserializeObject<GetAccountStatusByClientUniqueIdResponse>(response.Result.ResponseText, _settings);
            PrintObj.Print(result);
            return result;
        }

        // Report
        public string Report(ReportRequest request = null)
        {
            if (request == null) return null;
            var response = _apiClient.Get<string>(
                "/receivables/v5/report/" + request.Date + 
                "?endDate=" + request.EndDate + 
                "&skip" + request.Skip + 
                "&accountNumber" + request.AccountNumber + 
                "&transactionType" + request.TransactionType + 
                "&transactionCode" + request.TransactionCode +
                "&take" + request.Take +
                "&clientUniqueId" + request.ClientUniqueId
                );
            // var result = JsonConvert.DeserializeObject<ReportResponse>(response.Result.ResponseText, settings);
            // PrintObj.Print(result);
            Console.WriteLine(response.Result.ResponseText);
            return response.Result.ResponseText;
        }

        // Last Settlement
        public LastSettlementResponse LastSettlement()
        {
            var response = _apiClient.Get<string>(AutomatcherUrl + "/reportLastSettlement");
            var result = JsonConvert.DeserializeObject<LastSettlementResponse>(response.Result.ResponseText, _settings);
            PrintObj.Print(result);
            return result;
        }

        // List Accounts
        public ListAccountsResponse ListAccounts()
        {
            var response = _apiClient.Get<string>(AutomatcherUrl + "/listAccounts");
            var result = JsonConvert.DeserializeObject<ListAccountsResponse>(response.Result.ResponseText, _settings);
            PrintObj.Print(result);
            return result;
        }

        // Batch Create
        public BatchCreateResponse BatchCreate(BatchCreateRequest request = null)
        {
            if (request == null) return null;
            var response = _apiClient.PostBatch<string>(AutomatcherUrl + "/batchCreate",
                new ByteArrayContent(request.Content));
            var result = JsonConvert.DeserializeObject<BatchCreateResponse>(response.Result.ResponseText, _settings);
            PrintObj.Print(result);
            return result;
        }

        // Batch Status
        public BatchStatusResponse BatchStatus(BatchStatusRequest request = null)
        {
            if (request == null) return null;
            var response = _apiClient.PostBatch<string>(AutomatcherUrl + "/batchStatus",
                new ByteArrayContent(request.Content));
            var result = JsonConvert.DeserializeObject<BatchStatusResponse>(response.Result.ResponseText, _settings);
            PrintObj.Print(result);
            return result;
        }

        // Receivables Refund
        public ReceivablesRefundResponse ReceivablesRefund(ReceivablesRefundRequest request = null)
        {
            if (request == null) return null;
            var json = JsonConvert.SerializeObject(request);
            var response = _apiClient.Post<string>(AutomatcherUrl + "/refund",
                new StringContent(json, Encoding.UTF8, "application/json"));
            var result = JsonConvert.DeserializeObject<ReceivablesRefundResponse>(response.Result.ResponseText, _settings);
            PrintObj.Print(result);
            return result;
        }

        // Process Direct Debit
        public ProcessDirectDebitResponse ProcessDirectDebit(ProcessDirectDebitRequest request = null)
        {
            if (request == null) return null;
            var json = JsonConvert.SerializeObject(request);
            var response = _apiClient.Post<string>(AutomatcherUrl + "/processdirectdebit",
                new StringContent(json, Encoding.UTF8, "application/json"));
            var result = JsonConvert.DeserializeObject<ProcessDirectDebitResponse>(response.Result.ResponseText, _settings);
            PrintObj.Print(result);
            return result;
        }

        // Inbound Direct Debit Report
        public string InboundDirectDebitReport(InboundDirectDebitReportRequest request = null)
        {
            if (request == null) return null;
            var response = _apiClient.Get<string>(AutomatcherUrl + "/list/" + request.Date);
            return response.Result.ResponseText;
        }
        // -------------------------------------------------------------------------------------------------------------


        // -------------------------------------------------------------------------------------------------------------
        // Whitelisting for Automatcher (Bank Account Receivables)
        // Create Whitelist Source Account
        public CreateWhitelistResponse CreateWhitelist(CreateWhitelistRequest request = null)
        {
            if (request == null) return null;
            var json = JsonConvert.SerializeObject(request);
            var response = _apiClient.Post<string>(WhitelistingUrl + "/create",
                new StringContent(json, Encoding.UTF8, "application/json"));
            var result = JsonConvert.DeserializeObject<CreateWhitelistResponse>(response.Result.ResponseText, _settings);
            PrintObj.Print(result);
            return result;
        }

        // Update Whitelist Source Account
        public UpdateWhitelistResponse UpdateWhitelist(UpdateWhitelistRequest request = null)
        {
            if (request == null) return null;
            var json = JsonConvert.SerializeObject(request);
            var response = _apiClient.Post<string>(WhitelistingUrl + "/update",
                new StringContent(json, Encoding.UTF8, "application/json"));
            var result = JsonConvert.DeserializeObject<UpdateWhitelistResponse>(response.Result.ResponseText, _settings);
            PrintObj.Print(result);
            return result;
        }

        // List Whitelist Source Accounts 
        public ListWhitelistResponse ListWhitelist(ListWhitelistRequest request = null)
        {
            if (request == null) return null;
            var response = _apiClient.Get<string>(WhitelistingUrl + "/list/" + request.AutomatcherBankAccountNumber);
            var result = JsonConvert.DeserializeObject<ListWhitelistResponse>(response.Result.ResponseText, _settings);
            PrintObj.Print(result);
            return result;
        }

        // Rejected Transactions Report
        public string RejectedTransactionsReport(
            RejectedTransactionsReportRequest request = null)
        {
            if (request == null) return null;
            var response = _apiClient.Get<string>(WhitelistingUrl + "/rejectedTransactions/" + request.Date);
            return response.Result.ResponseText;
        }
        // -------------------------------------------------------------------------------------------------------------


        // -------------------------------------------------------------------------------------------------------------
        // PayID
        // Register PayID
        public RegisterPayIdResponse RegisterPayId(RegisterPayIdRequest request = null)
        {
            if (request == null) return null;
            var json = JsonConvert.SerializeObject(request);
            var response = _apiClient.Post<string>(PayIdUrl + "/registerPayId",
                new StringContent(json, Encoding.UTF8, "application/json"));
            var result = JsonConvert.DeserializeObject<RegisterPayIdResponse>(response.Result.ResponseText, _settings);
            PrintObj.Print(result);
            return result;
        }

        // Update a PayID's status
        public UpdatePayIdStatusResponse UpdatePayIdStatus(UpdatePayIdStatusRequest request = null)
        {
            if (request == null) return null;
            var json = JsonConvert.SerializeObject(request);
            var response = _apiClient.Post<string>(PayIdUrl + "/updatePayIdStatus",
                new StringContent(json, Encoding.UTF8, "application/json"));
            var result = JsonConvert.DeserializeObject<UpdatePayIdStatusResponse>(response.Result.ResponseText, _settings);
            PrintObj.Print(result);
            return result;
        }

        // Update a PayID's name
        public UpdatePayIdNameResponse UpdatePayIdName(UpdatePayIdNameRequest request = null)
        {
            if (request == null) return null;
            var json = JsonConvert.SerializeObject(request);
            var response = _apiClient.Post<string>(PayIdUrl + "/updatePayIdName",
                new StringContent(json, Encoding.UTF8, "application/json"));
            var result = JsonConvert.DeserializeObject<UpdatePayIdNameResponse>(response.Result.ResponseText, _settings);
            PrintObj.Print(result);
            return result;
        }

        // PayID Enquiry
        public PayIdEnquiryResponse PayIdEnquiry(PayIdEnquiryRequest request = null)
        {
            if (request == null) return null;
            var json = JsonConvert.SerializeObject(request);
            var response = _apiClient.Post<string>(PayIdUrl + "/payIdEnquiry",
                new StringContent(json, Encoding.UTF8, "application/json"));
            var result = JsonConvert.DeserializeObject<PayIdEnquiryResponse>(response.Result.ResponseText, _settings);
            PrintObj.Print(result);
            return result;
        }
        // -------------------------------------------------------------------------------------------------------------


        // Tools
        // Ping (test authentication)
        public PingResponse Ping()
        {
            var response = _apiClient.Get<string>(ToolsUrl + "/ping");
            var result = JsonConvert.DeserializeObject<PingResponse>(response.Result.ResponseText, _settings);
            PrintObj.Print(result);
            return result;
        }

        // Validate a BSB
        public ValidateBsbResponse ValidateBsb(ValidateBsbRequest request = null)
        {
            if (request == null) return null;
            var response = _apiClient.Get<string>(ToolsUrl + "/bsbValidate/" + request.BsbNumber);
            var result = JsonConvert.DeserializeObject<ValidateBsbResponse>(response.Result.ResponseText, _settings);
            PrintObj.Print(result);
            return result;
        }

        // Validate an ABN
        public ValidateAbnResponse ValidateAbn(ValidateAbnRequest request = null)
        {
            if (request == null) return null;
            var response = _apiClient.Get<string>(ToolsUrl + "/abnValidate/" + request.AbnNumber);
            var result = JsonConvert.DeserializeObject<ValidateAbnResponse>(response.Result.ResponseText, _settings);
            PrintObj.Print(result);
            return result;
        }

        // Email an issuer
        public EmailIssuerResponse EmailIssuer(EmailIssuerRequest request = null)
        {
            if (request == null) return null;
            var json = JsonConvert.SerializeObject(request);
            var response = _apiClient.Post<string>(ToolsUrl + "/sendEmailToIssuer",
                new StringContent(json, Encoding.UTF8, "application/json"));
            var result = JsonConvert.DeserializeObject<EmailIssuerResponse>(response.Result.ResponseText, _settings);
            PrintObj.Print(result);
            return result;
        }
        // -------------------------------------------------------------------------------------------------------------


        // -------------------------------------------------------------------------------------------------------------
        // Manage
        // Subscriptions
        // Subscribe to new Webhook
        public SubscribeWebhookResponse SubscribeWebhook(SubscribeWebhookRequest request = null)
        {
            if (request == null) return null;
            var json = JsonConvert.SerializeObject(request);
            var response = _apiClient.Post<string>(SubscriptionsUrl + "/create",
                new StringContent(json, Encoding.UTF8, "application/json"));
            var result = JsonConvert.DeserializeObject<SubscribeWebhookResponse>(response.Result.ResponseText, _settings);
            PrintObj.Print(result);
            return result;
        }

        // Update an existing Webhook
        public UpdateWebhookResponse UpdateWebhook(UpdateWebhookRequest request = null)
        {
            if (request == null) return null;
            var json = JsonConvert.SerializeObject(request);
            var response = _apiClient.Post<string>(SubscriptionsUrl + "/update",
                new StringContent(json, Encoding.UTF8, "application/json"));
            var result = JsonConvert.DeserializeObject<UpdateWebhookResponse>(response.Result.ResponseText, _settings);
            PrintObj.Print(result);
            return result;
        }

        // List all existing webhooks
        public ListAllWebhooksResponse ListAllWebhooks()
        {
            var response = _apiClient.Get<string>(SubscriptionsUrl + "/list");
            var result = JsonConvert.DeserializeObject<ListAllWebhooksResponse>(response.Result.ResponseText, _settings);
            PrintObj.Print(result);
            return result;
        }

        // Unsubscribe from an existing webhook
        public UnsubscribeFromExistingWebhookResponse UnsubscribeFromExistingWebhook(
            UnsubscribeFromExistingWebhookRequest request = null)
        {
            if (request == null) return null;
            var response = _apiClient.Delete<string>(SubscriptionsUrl + "/delete/" + request.Id);
            var result = JsonConvert.DeserializeObject<UnsubscribeFromExistingWebhookResponse>(response.Result.ResponseText, _settings);
            PrintObj.Print(result);
            return result;
        }

        // Request resending of a notification using the TransactionId
        public RequestResendingNotificationUsingTransactionIdResponse RequestResendingNotificationUsingTransactionId(
            RequestResendingNotificationUsingTransactionIdRequest request = null)
        {
            if (request == null) return null;
            var json = JsonConvert.SerializeObject(request);
            var response = _apiClient.Post<string>(SubscriptionsUrl + "/resend",
                new StringContent(json, Encoding.UTF8, "application/json"));
            var result = JsonConvert.DeserializeObject<RequestResendingNotificationUsingTransactionIdResponse>(response.Result.ResponseText, _settings);
            PrintObj.Print(result);
            return result;
        }
        // -------------------------------------------------------------------------------------------------------------


        // -------------------------------------------------------------------------------------------------------------
        // Events
        // Receive Payment Webhook
        public ReceivePaymentWebhookResponse ReceivePaymentWebhook(ReceivePaymentWebhookRequest request = null)
        {
            return null;
        }

        // Receive Inbound Direct Credits Webhook
        public ReceiveInboundDirectCreditsWebhookResponse ReceiveInboundDirectCreditsWebhook(
            ReceiveInboundDirectCreditsWebhookRequest request = null)
        {
            return null;
        }

        // Receive Inbound Direct Debits Webhook
        public ReceiveInboundDirectDebitsWebhookResponse ReceiveInboundDirectDebitsWebhook(
            ReceiveInboundDirectDebitsWebhookRequest request = null)
        {
            return null;
        }

        // Receive Direct Entry Dishonours Webhook
        public ReceiveDirectEntryDishonoursWebhookResponse ReceiveDirectEntryDishonoursWebhook(
            ReceiveDirectEntryDishonoursWebhookRequest request = null)
        {
            return null;
        }
        // -------------------------------------------------------------------------------------------------------------


        // -------------------------------------------------------------------------------------------------------------
        // mAccount
        // Create an mAccount
        public CreateMAccountResponse CreateMAccount(CreateMAccountRequest request = null)
        {
            if (request == null) return null;
            var json = JsonConvert.SerializeObject(request);
            var response = _apiClient.Post<string>(MAccountUrl + "/create",
                new StringContent(json, Encoding.UTF8, "application/json"));
            var result = JsonConvert.DeserializeObject<CreateMAccountResponse>(response.Result.ResponseText, _settings);
            PrintObj.Print(result);
            return result;
        }

        // Close an mAccount
        public CloseMAccountResponse CloseMAccount(CloseMAccountRequest request = null)
        {
            if (request == null) return null;
            var response = _apiClient.Get<string>(MAccountUrl + "/close/" + request.AccountNumber);
            var result = JsonConvert.DeserializeObject<CloseMAccountResponse>(response.Result.ResponseText, _settings);
            PrintObj.Print(result);
            return result;
        }

        // Get mAccount Balance
        public MAccountBalanceResponse GetMAccountBalance(MAccountBalanceRequest request = null)
        {
            if (request == null) return null;
            var response = _apiClient.Get<string>(MAccountUrl + "/financials/" + request.AccountNumber);
            var result = JsonConvert.DeserializeObject<MAccountBalanceResponse>(response.Result.ResponseText, _settings);
            PrintObj.Print(result);
            return result;
        }

        // Get mAccount details
        public GetMAccountDetailsResponse GetMAccountDetails(GetMAccountDetailsRequest request = null)
        {
            if (request == null) return null;
            var response = _apiClient.Get<string>(MAccountUrl + "/get/" + request.AccountNumber);
            var result = JsonConvert.DeserializeObject<GetMAccountDetailsResponse>(response.Result.ResponseText, _settings);
            PrintObj.Print(result);
            return result;
        }

        // List as issuer
        public ListIssuerResponse ListIssuer()
        {
            var response = _apiClient.Get<string>(MAccountUrl + "/listAsIssuer");
            var result = JsonConvert.DeserializeObject<ListIssuerResponse>(response.Result.ResponseText, _settings);
            PrintObj.Print(result);
            return result;
        }

        // Send a statement
        public SendStatementResponse SendStatement(SendStatementRequest request = null)
        {
            if (request == null) return null;
            var json = JsonConvert.SerializeObject(request);
            var response = _apiClient.Post<string>(MAccountUrl + "/sendStatement",
                new StringContent(json, Encoding.UTF8, "application/json"));
            var result = JsonConvert.DeserializeObject<SendStatementResponse>(response.Result.ResponseText, _settings);
            PrintObj.Print(result);
            return result;
        }

        // Get transactions by mAccount
        public GetTransactionsByMAccountResponse GetTransactionsByMAccount(
            GetTransactionsByMAccountRequest request = null)
        {
            if (request == null) return null;
            var json = JsonConvert.SerializeObject(request);
            var response = _apiClient.Post<string>(MAccountUrl + "/transactions",
                new StringContent(json, Encoding.UTF8, "application/json"));
            var result = JsonConvert.DeserializeObject<GetTransactionsByMAccountResponse>(response.Result.ResponseText, _settings);
            PrintObj.Print(result);
            return result;
        }

        // Update mAccount details
        public UpdateMAccountDetailsResponse UpdateMAccountDetails(UpdateMAccountDetailsRequest request = null)
        {
            if (request == null) return null;
            var json = JsonConvert.SerializeObject(request);
            var response = _apiClient.Post<string>(MAccountUrl + "/update",
                new StringContent(json, Encoding.UTF8, "application/json"));
            var result = JsonConvert.DeserializeObject<UpdateMAccountDetailsResponse>(response.Result.ResponseText, _settings);
            PrintObj.Print(result);
            return result;
        }
        // -------------------------------------------------------------------------------------------------------------


        // -------------------------------------------------------------------------------------------------------------
        // Reports
        // Get all transactions in a daily settlement
        public GetAllTransactionsInDailySettlementResponse GetAllTransactionsInDailySettlement(
            GetAllTransactionsInDailySettlementRequest request = null)
        {
            if (request == null) return null;
            var response = _apiClient.Get<string>(ReportsUrl + "/settlement/" + request.Date);
            var result = JsonConvert.DeserializeObject<GetAllTransactionsInDailySettlementResponse>(response.Result.ResponseText, _settings);
            PrintObj.Print(result);
            return result;
        }

        // Get all successful transactions for a date
        public GetAllSuccessfulTransactionsByDateResponse GetAllSuccessfulTransactionsByDate(
            GetAllSuccessfulTransactionsByDateRequest request = null)
        {
            if (request == null) return null;
            var response = _apiClient.Get<string>(ReportsUrl + "/statement/" + request.Date);
            var result = JsonConvert.DeserializeObject<GetAllSuccessfulTransactionsByDateResponse>(response.Result.ResponseText, _settings);
            PrintObj.Print(result);
            return result;
        }
        // -------------------------------------------------------------------------------------------------------------


        // -------------------------------------------------------------------------------------------------------------
        // Security
        // Create OneShot security Token
        public CreateOneShotSecurityTokenResponse CreateOneShotSecurityToken(
            CreateOneShotSecurityTokenRequest request = null)
        {
            if (request == null) return null;
            var response = _apiClient.Get<string>(SecurityUrl + "/createOneShotSecurityToken/" + request.TimeOutMin + "/" + request.TokenClaims);
            var result = JsonConvert.DeserializeObject<CreateOneShotSecurityTokenResponse>(response.Result.ResponseText, _settings);
            PrintObj.Print(result);
            return result;
        }

        // Get Sign-in account fees & permissions
        public GetSignInAccountFeesAndPermissionsResponse GetSignInAccountFeesAndPermissions()
        {
            var response = _apiClient.Get<string>(SecurityUrl + "/signInAccountSettings");
            var result = JsonConvert.DeserializeObject<GetSignInAccountFeesAndPermissionsResponse>(response.Result.ResponseText, _settings);
            PrintObj.Print(result);
            return result;
        }
        // -------------------------------------------------------------------------------------------------------------


        // -------------------------------------------------------------------------------------------------------------
        // Token
        // Create bank account token
        public CreateBankAccountTokenResponse CreateBankAccountToken(CreateBankAccountTokenRequest request = null)
        {
            if (request == null) return null;
            var json = JsonConvert.SerializeObject(request);
            var response = _apiClient.Post<string>(TokenUrl + "/createAustralianBankAccount",
                new StringContent(json, Encoding.UTF8, "application/json"));
            var result = JsonConvert.DeserializeObject<CreateBankAccountTokenResponse>(response.Result.ResponseText, _settings);
            PrintObj.Print(result);
            return result;
        }

        // Create BPAY token
        public CreateBpayTokenResponse CreateBpayToken(CreateBpayTokenRequest request = null)
        {
            if (request == null) return null;
            var json = JsonConvert.SerializeObject(request);
            var response = _apiClient.Post<string>(TokenUrl + "/createBPAY",
                new StringContent(json, Encoding.UTF8, "application/json"));
            var result = JsonConvert.DeserializeObject<CreateBpayTokenResponse>(response.Result.ResponseText, _settings);
            PrintObj.Print(result);
            return result;
        }

        // Delete token
        public DeleteTokenResponse DeleteToken(DeleteTokenRequest request = null)
        {
            if (request == null) return null;
            var response = _apiClient.Delete<string>(TokenUrl + "/delete/" + request.Token);
            var result = JsonConvert.DeserializeObject<DeleteTokenResponse>(response.Result.ResponseText, _settings);
            PrintObj.Print(result);
            return result;
        }

        // Get token details
        public GetTokenDetailsResponse GetTokenDetails(GetTokenDetailsRequest request = null)
        {
            if (request == null) return null;
            var response = _apiClient.Get<string>(TokenUrl + "/get/" + request.Token);
            var result = JsonConvert.DeserializeObject<GetTokenDetailsResponse>(response.Result.ResponseText, _settings);
            PrintObj.Print(result);
            return result;
        }

        // List tokens by mAccount
        public ListTokensByMAccountResponse ListTokensByMAccount(ListTokensByMAccountRequest request = null)
        {
            if (request == null) return null;
            var response = _apiClient.Get<string>(TokenUrl + "/list/" + request.AccountNumber);
            var result = JsonConvert.DeserializeObject<ListTokensByMAccountResponse>(response.Result.ResponseText, _settings);
            PrintObj.Print(result);
            return result;
        }

        // Update bank account token
        public UpdateBankAccountTokenResponse UpdateBankAccountToken(UpdateBankAccountTokenRequest request = null)
        {
            if (request == null) return null;
            var json = JsonConvert.SerializeObject(request);
            var response = _apiClient.Post<string>(TokenUrl + "/updateAustralianBankAccount",
                new StringContent(json, Encoding.UTF8, "application/json"));
            var result = JsonConvert.DeserializeObject<UpdateBankAccountTokenResponse>(response.Result.ResponseText, _settings);
            PrintObj.Print(result);
            return result;
        }

        // Update BPAY token
        public UpdateBpayTokenResponse UpdateBpayToken(UpdateBpayTokenRequest request = null)
        {
            if (request == null) return null;
            var json = JsonConvert.SerializeObject(request);
            var response = _apiClient.Post<string>(TokenUrl + "/updateBPAY",
                new StringContent(json, Encoding.UTF8, "application/json"));
            var result = JsonConvert.DeserializeObject<UpdateBpayTokenResponse>(response.Result.ResponseText, _settings);
            PrintObj.Print(result);
            return result;
        }

        // Validate token
        public ValidateTokenResponse ValidateToken(ValidateTokenRequest request = null)
        {
            if (request == null) return null;
            var response = _apiClient.Get<string>(TokenUrl + "/validate/" + request.Token);
            var result = JsonConvert.DeserializeObject<ValidateTokenResponse>(response.Result.ResponseText, _settings);
            PrintObj.Print(result);
            return result;
        }
        // -------------------------------------------------------------------------------------------------------------


        // -------------------------------------------------------------------------------------------------------------
        // MWallet
        // Create an mWallet
        public CreateMWalletResponse CreateMWallet(CreateMWalletRequest request = null)
        {
            if (request == null) return null;
            var json = JsonConvert.SerializeObject(request);
            var response = _apiClient.Post<string>(MWalletUrl + "/create",
                new StringContent(json, Encoding.UTF8, "application/json"));
            var result = JsonConvert.DeserializeObject<CreateMWalletResponse>(response.Result.ResponseText, _settings);
            PrintObj.Print(result);
            return result;
        }

        // Close an mWallet
        public CloseMWalletResponse CloseMWallet(CloseMWalletRequest request = null)
        {
            if (request == null) return null;
            var response = _apiClient.Get<string>(MWalletUrl + "/close/" + request.AccountNumber + "/" + request.Pin);
            var result = JsonConvert.DeserializeObject<CloseMWalletResponse>(response.Result.ResponseText, _settings);
            PrintObj.Print(result);
            return result;
        }

        // Get mWallet Balance
        public GetMWalletBalanceResponse GetMWalletBalance(GetMWalletBalanceRequest request = null)
        {
            if (request == null) return null;
            var response = _apiClient.Get<string>(MWalletUrl + "/financials/" + request.AccountNumber + "/" + request.Pin);
            var result = JsonConvert.DeserializeObject<GetMWalletBalanceResponse>(response.Result.ResponseText, _settings);
            PrintObj.Print(result);
            return result;
        }

        // Reopen a closed mWallet
        public ReopenClosedMWalletResponse ReopenClosedMWallet(ReopenClosedMWalletRequest request = null)
        {
            if (request == null) return null;
            var response = _apiClient.Get<string>(MWalletUrl + "/reopen/" + request.AccountNumber + "/" + request.Pin);
            var result = JsonConvert.DeserializeObject<ReopenClosedMWalletResponse>(response.Result.ResponseText, _settings);
            PrintObj.Print(result);
            return result;
        }

        // Reset an mWallet PIN
        public ResetMWalletPinResponse ResetMWalletPin(ResetMWalletPinRequest request = null)
        {
            if (request == null) return null;
            var json = JsonConvert.SerializeObject(request);
            var response = _apiClient.Post<string>(MWalletUrl + "/resetPin",
                new StringContent(json, Encoding.UTF8, "application/json"));
            var result = JsonConvert.DeserializeObject<ResetMWalletPinResponse>(response.Result.ResponseText, _settings);
            PrintObj.Print(result);
            return result;
        }

        // mWallet search
        public MWalletSearchResponse MWalletSearch(MWalletSearchRequest request = null)
        {
            if (request == null) return null;
            var response = _apiClient.Get<string>(MWalletUrl + "/search?identifier=" + request.Identifier);
            var result = JsonConvert.DeserializeObject<MWalletSearchResponse>(response.Result.ResponseText, _settings);
            PrintObj.Print(result);
            return result;

        }

        // Get transactions by mWallet
        public GetTransactionsByMWalletResponse GetTransactionsByMWallet(GetTransactionsByMWalletRequest request = null)
        {
            if (request == null) return null;
            var json = JsonConvert.SerializeObject(request);
            var response = _apiClient.Post<string>(MWalletUrl + "/transactions",
                new StringContent(json, Encoding.UTF8, "application/json"));
            var result = JsonConvert.DeserializeObject<GetTransactionsByMWalletResponse>(response.Result.ResponseText, _settings);
            PrintObj.Print(result);
            return result;
        }

        // Update mWallet details
        public UpdateMWalletDetailsResponse UpdateMWalletDetails(UpdateMWalletDetailsRequest request = null)
        {
            if (request == null) return null;
            var json = JsonConvert.SerializeObject(request);
            var response = _apiClient.Post<string>(MWalletUrl + "/update",
                new StringContent(json, Encoding.UTF8, "application/json"));
            var result = JsonConvert.DeserializeObject<UpdateMWalletDetailsResponse>(response.Result.ResponseText, _settings);
            PrintObj.Print(result);
            return result;
        }
        // -------------------------------------------------------------------------------------------------------------
        
        // -------------------------------------------------------------------------------------------------------------
        public PingResponse PublicPing()
        {
            var response = _apiClient.Get<string>(PublicUrl + "/ping");
            var result = JsonConvert.DeserializeObject<PingResponse>(response.Result.ResponseText, _settings);
            PrintObj.Print(result);
            return result;
        }
        
        public string RetrievePublicKey()
        {
            var response = _apiClient.Get<string>(PublicUrl + "/certificate/public-key");
            Console.WriteLine(response.Result.ResponseText);
            return response.Result.ResponseText;
        }
        // -------------------------------------------------------------------------------------------------------------
    }
}