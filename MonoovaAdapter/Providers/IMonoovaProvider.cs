using System.Threading.Tasks;
using MonoovaAdapter.Entities;
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

namespace MonoovaAdapter.Providers
{
    public interface IMonoovaProvider
    {
        ProviderParam GetProviderParam();

        // -------------------------------------------------------------------------------------------------------------
        // Receive and Pay
        // Financial / Payments
        // Process a transaction
        TransactionResponse ProcessTransaction(TransactionRequestMAccount transaction = null); 
        
        // Validate a transaction
        TransactionResponse ValidateTransaction(TransactionRequestMAccount transaction = null); 
        
        // Get transaction status by UID
        GetTransactionResponse GetTransactionByUid(GetTransactionRequest request);
        
        // Get transaction status by Date
        GetTransactionByDateResponse GetTransactionByDate(GetTransactionByDateRequest request);
        
        // Process Credit Card Refund
        RefundResponse ProcessCreditCardRefund(RefundRequest refund = null);
        
        // Validate Credit Card Refund
        RefundResponse ValidateCreditCardRefund(RefundRequest refund = null);
        // -------------------------------------------------------------------------------------------------------------
        
        
        // -------------------------------------------------------------------------------------------------------------
        // BPAY
        // Validate a BPAY transaction
        ValidateBpayTransactionResponse ValidateBpayTransaction(ValidateBpayTransactionRequest request = null);
        
        // Get BPAY biller code details
        GetBpayBillerCodeDetailsResponse GetBpayBillerCodeDetails(GetBpayBillerCodeDetailsRequest request = null);
        
        // Search for BPAY billers
        SearchBpayBillersResponse SearchBpayBillers(SearchBpayBillersRequest request = null);
        
        // Get a wallet's BPAY History
        GetBpayHistoryResponse GetBpayHistory(GetBpayHistoryRequest request = null);
        
        // BPAY Receivables Report
        string BpayReceivablesReport(BpayReceivablesReportRequest request = null);
        // -------------------------------------------------------------------------------------------------------------
        
        
        // -------------------------------------------------------------------------------------------------------------
        // Verify
        // Initiate a NPP verification transaction
        InitiateResponse InitiateVerification(InitiateRequest initiate = null);
        
        // Initiate a verification transaction
        InitiateV1Response InitiateV1Verification(InitiateV1Request initiate = null);
        
        // Complete an account verification
        CompleteVerificationResponse CompleteVerification(CompleteVerificationRequest request = null);
        
        // Get a verification token's details
        GetVerificationDetailResponse GetVerificationDetail(GetVerificationDetailRequest request = null);
        
        // List verified bank accounts
        ListVerifiedBackAccResponse ListVerifiedBackAcc();
        
        // Update a verified bank account
        UpdateVerifiedAccountResponse UpdateVerifiedAccount(UpdateVerifiedAccountRequest request = null);
        // -------------------------------------------------------------------------------------------------------------
        
        
        // -------------------------------------------------------------------------------------------------------------
        // Automatcher (Bank Account Receivables)
        // Create a Automatcher (Receivables) Account
        CreateAutomatcherResponse CreateAutomatcher(CreateAutomatcherRequest request = null);
        
        // Set Account Status
        SetAccountStatusResponse SetAccountStatus(SetAccountStatusRequest request = null);
        
        // Get Account Status By BankAccount
        GetAccountStatusByBankAccountResponse GetAccountStatusByBankAccount(GetAccountStatusByBankAccountRequest request = null);
        
        // Get Account Status By ClientUniqueId
        GetAccountStatusByClientUniqueIdResponse GetAccountStatusByClientUniqueId(
            GetAccountStatusByClientUniqueIdRequest request = null);
        
        // Report
        string Report(ReportRequest request = null);
        
        // Last Settlement
        LastSettlementResponse LastSettlement();
        
        // List Accounts
        ListAccountsResponse ListAccounts();
        
        // Batch Create
        BatchCreateResponse BatchCreate(BatchCreateRequest request = null);
        
        // Batch Status
        BatchStatusResponse BatchStatus(BatchStatusRequest request = null);
        
        // Receivables Refund
        ReceivablesRefundResponse ReceivablesRefund(ReceivablesRefundRequest request = null);
        
        // Process Direct Debit
        ProcessDirectDebitResponse ProcessDirectDebit(ProcessDirectDebitRequest request = null);
        
        // Inbound Direct Debit Report
        string InboundDirectDebitReport(InboundDirectDebitReportRequest request = null);
        // -------------------------------------------------------------------------------------------------------------

        
        // -------------------------------------------------------------------------------------------------------------
        // Whitelisting for Automatcher (Bank Account Receivables)
        // Create Whitelist Source Account
        CreateWhitelistResponse CreateWhitelist(CreateWhitelistRequest request = null);
        
        // Update Whitelist Source Account
        UpdateWhitelistResponse UpdateWhitelist(UpdateWhitelistRequest request = null);
        
        // List Whitelist Source Accounts 
        ListWhitelistResponse ListWhitelist(ListWhitelistRequest request = null);
        
        // Rejected Transactions Report
        string RejectedTransactionsReport(RejectedTransactionsReportRequest request = null);
        // -------------------------------------------------------------------------------------------------------------
        
        
        // -------------------------------------------------------------------------------------------------------------
        // PayID
        // Register PayID
        RegisterPayIdResponse RegisterPayId(RegisterPayIdRequest request = null);
        
        // Update a PayID's status
        UpdatePayIdStatusResponse UpdatePayIdStatus(UpdatePayIdStatusRequest request = null);
        
        // Update a PayID's name
        UpdatePayIdNameResponse UpdatePayIdName(UpdatePayIdNameRequest request = null);
        
        // PayID Enquiry
        PayIdEnquiryResponse PayIdEnquiry(PayIdEnquiryRequest request = null);
        // -------------------------------------------------------------------------------------------------------------
        

        // -------------------------------------------------------------------------------------------------------------
        // Tools
        // Ping (test authentication)
        PingResponse Ping();
        
        // Validate a BSB
        ValidateBsbResponse ValidateBsb(ValidateBsbRequest request = null);
        
        // Validate an ABN
        ValidateAbnResponse ValidateAbn(ValidateAbnRequest request = null);
        
        // Email an issuer
        EmailIssuerResponse EmailIssuer(EmailIssuerRequest request = null);
        // -------------------------------------------------------------------------------------------------------------
        
        
        // -------------------------------------------------------------------------------------------------------------
        // Manage
        // Subscriptions
        // Subscribe to new Webhook
        SubscribeWebhookResponse SubscribeWebhook(SubscribeWebhookRequest request = null);
        
        // Update an existing Webhook
        UpdateWebhookResponse UpdateWebhook(UpdateWebhookRequest request = null);
        
        // List all existing webhooks
        ListAllWebhooksResponse ListAllWebhooks();
        
        // Unsubscribe from an existing webhook
        UnsubscribeFromExistingWebhookResponse UnsubscribeFromExistingWebhook(
            UnsubscribeFromExistingWebhookRequest request = null);
        
        // Request resending of a notification using the TransactionId
        RequestResendingNotificationUsingTransactionIdResponse RequestResendingNotificationUsingTransactionId(
            RequestResendingNotificationUsingTransactionIdRequest request = null);
        // -------------------------------------------------------------------------------------------------------------
        
        
        // -------------------------------------------------------------------------------------------------------------
        // Events
        // Receive Payment Webhook
        ReceivePaymentWebhookResponse ReceivePaymentWebhook(ReceivePaymentWebhookRequest request = null);
        
        // Receive Inbound Direct Credits Webhook
        ReceiveInboundDirectCreditsWebhookResponse ReceiveInboundDirectCreditsWebhook(
            ReceiveInboundDirectCreditsWebhookRequest request = null);
        
        // Receive Inbound Direct Debits Webhook
        ReceiveInboundDirectDebitsWebhookResponse ReceiveInboundDirectDebitsWebhook(
            ReceiveInboundDirectDebitsWebhookRequest request = null);
        
        // Receive Direct Entry Dishonours Webhook
        ReceiveDirectEntryDishonoursWebhookResponse ReceiveDirectEntryDishonoursWebhook(ReceiveDirectEntryDishonoursWebhookRequest request = null);
        // -------------------------------------------------------------------------------------------------------------
        
        
        // -------------------------------------------------------------------------------------------------------------
        // mAccount
        // Create an mAccount
        CreateMAccountResponse CreateMAccount(CreateMAccountRequest account = null);
        
        // Close an mAccount
        CloseMAccountResponse CloseMAccount(CloseMAccountRequest request = null);
        
        // Get mAccount Balance
        MAccountBalanceResponse GetMAccountBalance(MAccountBalanceRequest request = null);
        
        // Get mAccount details
        GetMAccountDetailsResponse GetMAccountDetails(GetMAccountDetailsRequest request = null);
        
        // List as issuer
        ListIssuerResponse ListIssuer();
        
        // Send a statement
        SendStatementResponse SendStatement(SendStatementRequest request = null);
        
        // Get transactions by mAccount
        GetTransactionsByMAccountResponse GetTransactionsByMAccount(GetTransactionsByMAccountRequest request = null);
        
        // Update mAccount details
        UpdateMAccountDetailsResponse UpdateMAccountDetails(UpdateMAccountDetailsRequest request = null);
        // -------------------------------------------------------------------------------------------------------------
        
        
        // -------------------------------------------------------------------------------------------------------------
        // Reports
        // Get all transactions in a daily settlement
        GetAllTransactionsInDailySettlementResponse GetAllTransactionsInDailySettlement(
            GetAllTransactionsInDailySettlementRequest request = null);
        
        // Get all successful transactions for a date
        GetAllSuccessfulTransactionsByDateResponse GetAllSuccessfulTransactionsByDate(
            GetAllSuccessfulTransactionsByDateRequest request = null);
        // -------------------------------------------------------------------------------------------------------------
        
        
        // -------------------------------------------------------------------------------------------------------------
        // Security
        // Create OneShot security Token
        CreateOneShotSecurityTokenResponse CreateOneShotSecurityToken(CreateOneShotSecurityTokenRequest request = null);
        
        // Get Sign-in account fees & permissions
        GetSignInAccountFeesAndPermissionsResponse GetSignInAccountFeesAndPermissions();
        // -------------------------------------------------------------------------------------------------------------
        
        
        // -------------------------------------------------------------------------------------------------------------
        // Token
        // Create bank account token
        CreateBankAccountTokenResponse CreateBankAccountToken(CreateBankAccountTokenRequest request = null);
        
        // Create BPAY token
        CreateBpayTokenResponse CreateBpayToken(CreateBpayTokenRequest request = null);
        
        // Delete token
        DeleteTokenResponse DeleteToken(DeleteTokenRequest request = null);
        
        // Get token details
        GetTokenDetailsResponse GetTokenDetails(GetTokenDetailsRequest request = null);
        
        // List tokens by mAccount
        ListTokensByMAccountResponse ListTokensByMAccount(ListTokensByMAccountRequest request = null);
        
        // Update bank account token
        UpdateBankAccountTokenResponse UpdateBankAccountToken(UpdateBankAccountTokenRequest request = null);
        
        // Update BPAY token
        UpdateBpayTokenResponse UpdateBpayToken(UpdateBpayTokenRequest request = null);
        
        // Validate token
        ValidateTokenResponse ValidateToken(ValidateTokenRequest request = null);
        // -------------------------------------------------------------------------------------------------------------
        

        // -------------------------------------------------------------------------------------------------------------
        // MWallet
        // Create an mWallet
        CreateMWalletResponse CreateMWallet(CreateMWalletRequest request = null);

        // Close an mWallet
        CloseMWalletResponse CloseMWallet(CloseMWalletRequest request = null);

        // Get mWallet Balance
        GetMWalletBalanceResponse GetMWalletBalance(GetMWalletBalanceRequest request = null);

        // Reopen a closed mWallet
        ReopenClosedMWalletResponse ReopenClosedMWallet(ReopenClosedMWalletRequest request = null);

        // Reset an mWallet PIN
        ResetMWalletPinResponse ResetMWalletPin(ResetMWalletPinRequest request = null);

        // mWallet search
        MWalletSearchResponse MWalletSearch(MWalletSearchRequest request = null);

        // Get transactions by mWallet
        GetTransactionsByMWalletResponse GetTransactionsByMWallet(GetTransactionsByMWalletRequest request = null);

        // Update mWallet details
        UpdateMWalletDetailsResponse UpdateMWalletDetails(UpdateMWalletDetailsRequest request = null);
        // -------------------------------------------------------------------------------------------------------------
        
        // -------------------------------------------------------------------------------------------------------------
        PingResponse PublicPing();

        string RetrievePublicKey();
        // -------------------------------------------------------------------------------------------------------------
    } 
}
