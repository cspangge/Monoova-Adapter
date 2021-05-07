using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class WebHookController : ApiController
    {
        private readonly ApplicationDbContext _db = new();

        [HttpPost]
        [Route("api/v1/ReceivePayment")]
        public async Task<IHttpActionResult> ReceivePayment([FromBody]ReceivePayment receivePayment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            // Check if transaction record exists
            var existReceivePayment = await _db.ReceivePayments.Where(x => x.TransactionId == receivePayment.TransactionId)
                .ToListAsync();

            if (existReceivePayment.Count > 0)
            {
                foreach (var tmp in existReceivePayment)
                {
                    tmp.DateTime = receivePayment.DateTime;
                    tmp.RemitterName = receivePayment.RemitterName;
                    tmp.Amount = receivePayment.Amount;
                    tmp.AccountName = receivePayment.AccountName;
                    tmp.AccountNumber = receivePayment.AccountNumber;
                    tmp.Bsb = receivePayment.Bsb;
                    tmp.PaymentDescription = receivePayment.PaymentDescription;
                    tmp.PayId = receivePayment.PayId;
                    tmp.PayIdName = receivePayment.PayIdName;
                    tmp.SourceBsb = receivePayment.SourceBsb;
                    tmp.SourceAccountNumber = receivePayment.SourceAccountNumber;
                    tmp.SourceAccountName = receivePayment.SourceAccountName;
                    tmp.EndToEndId = receivePayment.EndToEndId;
                    tmp.CategoryPurposeCode = receivePayment.CategoryPurposeCode;
                    tmp.CreditorReferenceInformation = receivePayment.CreditorReferenceInformation;
                    tmp.UsiNumber = receivePayment.UsiNumber;
                    tmp.UsiScheme = receivePayment.UsiScheme;
                    tmp.UltimateCreditorName = receivePayment.UltimateCreditorName;
                }
            }
            else
            {
                _db.ReceivePayments.Add(receivePayment);
            }
            
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ReceivePaymentExists(receivePayment.TransactionId))
                {
                    return Conflict();
                }
                throw;
            }
            return Ok();
        }
        
        [HttpPost]
        [Route("api/v1/ReceiveInboundDirectCredits")]
        public async Task<IHttpActionResult> ReceiveInboundDirectCredits([FromBody]ReceiveInboundDirectCredits receiveInboundDirectCredits)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var found = false;

            // Check if receiveInboundDirectCredits record exists
            foreach (var tmp in receiveInboundDirectCredits.DirectCreditDetails)
            {
                var existReceiveInboundDirectCredits = await _db.DbDirectCreditDetails
                    .Where(x => x.TransactionId == tmp.TransactionId).ToListAsync();
                found = existReceiveInboundDirectCredits.Count > 0;
                foreach (var tmp1 in existReceiveInboundDirectCredits)
                {
                    tmp1.BatchId = tmp.BatchId;
                    tmp1.DateTime = tmp.DateTime;
                    tmp1.Bsb = tmp.Bsb;
                    tmp1.AccountNumber = tmp.AccountNumber;
                    tmp1.AccountName = tmp.AccountName;
                    tmp1.TransactionCode = tmp.TransactionCode;
                    tmp1.Amount = tmp.Amount;
                    tmp1.LodgementRef = tmp.LodgementRef;
                    tmp1.RemitterName = tmp.RemitterName;
                    tmp1.NameOfUserSupplyingFile = tmp.NameOfUserSupplyingFile;
                    tmp1.NumberOfUserSupplyingFile = tmp.NumberOfUserSupplyingFile;
                    tmp1.DescriptionOfEntriesOnFile = tmp.DescriptionOfEntriesOnFile;
                    tmp1.Indicator = tmp.Indicator;
                    tmp1.WithholdingTaxAmount = tmp.WithholdingTaxAmount;
                    tmp1.SourceBsb = tmp.SourceBsb;
                    tmp1.SourceAccountNumber = tmp.SourceAccountNumber;
                }
            }

            if (!found)
            {
                var id = Guid.NewGuid();

                var inboundDirectCredits = new DbReceiveInboundDirectCredits
                {
                    Id = id,
                    TotalAmount = receiveInboundDirectCredits.TotalAmount,
                    TotalCount = receiveInboundDirectCredits.TotalCount,
                };
            
                _db.DbReceiveInboundDirectCredits.Add(inboundDirectCredits);
            
                foreach (var dbDirectCreditDetail in receiveInboundDirectCredits.DirectCreditDetails.Select(directCreditDetails => new DbDirectCreditDetail()
                {
                    TransactionId = directCreditDetails.TransactionId,
                    BatchId = directCreditDetails.BatchId,
                    DateTime = directCreditDetails.DateTime,
                    Bsb = directCreditDetails.Bsb,
                    AccountNumber = directCreditDetails.AccountNumber,
                    AccountName = directCreditDetails.AccountName,
                    TransactionCode = directCreditDetails.TransactionCode,
                    Amount = directCreditDetails.Amount,
                    LodgementRef = directCreditDetails.LodgementRef,
                    RemitterName = directCreditDetails.RemitterName,
                    NameOfUserSupplyingFile = directCreditDetails.NameOfUserSupplyingFile,
                    NumberOfUserSupplyingFile = directCreditDetails.NumberOfUserSupplyingFile,
                    DescriptionOfEntriesOnFile = directCreditDetails.DescriptionOfEntriesOnFile,
                    Indicator = directCreditDetails.Indicator,
                    WithholdingTaxAmount = directCreditDetails.WithholdingTaxAmount,
                    SourceBsb = directCreditDetails.SourceBsb,
                    SourceAccountNumber = directCreditDetails.SourceAccountNumber,
                    DbReceiveInboundDirectCreditsId = id
                }))
                {
                    _db.DbDirectCreditDetails.Add(dbDirectCreditDetail);
                }
            }

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (Exception)
            {
                return Conflict();
            }
            
            return Ok();
        }
        
        [HttpPost]
        [Route("api/v1/ReceiveInboundDirectDebits")]
        public async Task<IHttpActionResult> ReceiveInboundDirectDebits([FromBody]ReceiveInboundDirectDebits receiveInboundDirectDebits)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var found = false;

            // Check if receiveInboundDirectCredits record exists
            foreach (var tmp in receiveInboundDirectDebits.DirectDebitDetails)
            {
                var existReceiveInboundDirectDebits = await _db.DbDirectDebitDetails
                    .Where(x => x.TransactionId == tmp.TransactionId).ToListAsync();
                found = existReceiveInboundDirectDebits.Count > 0;
                foreach (var tmp1 in existReceiveInboundDirectDebits)
                {
                    tmp1.BatchId = tmp.BatchId;
                    tmp1.DateTime = tmp.DateTime;
                    tmp1.Status = tmp.Status;
                    tmp1.RespondBeforeDateTime = tmp.RespondBeforeDateTime;
                    tmp1.Bsb = tmp.Bsb;
                    tmp1.AccountNumber = tmp.AccountNumber;
                    tmp1.AccountName = tmp.AccountName;
                    tmp1.Amount = tmp.Amount;
                    tmp1.LodgementRef = tmp.LodgementRef;
                    tmp1.RemitterName = tmp.RemitterName;
                    tmp1.NameOfUserSupplyingFile = tmp.NameOfUserSupplyingFile;
                    tmp1.NumberOfUserSupplyingFile = tmp.NumberOfUserSupplyingFile;
                    tmp1.DescriptionOfEntriesOnFile = tmp.DescriptionOfEntriesOnFile;
                    tmp1.Indicator = tmp.Indicator;
                    tmp1.WithholdingTaxAmount = tmp.WithholdingTaxAmount;
                }
            }

            if (!found)
            {
                var id = Guid.NewGuid();
            
                var inboundDirectDebits = new DbReceiveInboundDirectDebits()
                {
                    Id = id,
                    TotalAmount = receiveInboundDirectDebits.TotalAmount,
                    TotalCount = receiveInboundDirectDebits.TotalCount,
                };
            
                _db.DbReceiveInboundDirectDebits.Add(inboundDirectDebits);
            
                foreach (var dbDirectDebitDetail in receiveInboundDirectDebits.DirectDebitDetails.Select(directDebitDetails => new DbDirectDebitDetail()
                {
                    TransactionId = directDebitDetails.TransactionId,
                    BatchId = directDebitDetails.BatchId,
                    DateTime = directDebitDetails.DateTime,
                    Status = directDebitDetails.Status,
                    RespondBeforeDateTime = directDebitDetails.RespondBeforeDateTime,
                    Bsb = directDebitDetails.Bsb,
                    AccountNumber = directDebitDetails.AccountNumber,
                    AccountName = directDebitDetails.AccountName,
                    Amount = directDebitDetails.Amount,
                    LodgementRef = directDebitDetails.LodgementRef,
                    RemitterName = directDebitDetails.RemitterName,
                    NameOfUserSupplyingFile = directDebitDetails.NameOfUserSupplyingFile,
                    NumberOfUserSupplyingFile = directDebitDetails.NumberOfUserSupplyingFile,
                    DescriptionOfEntriesOnFile = directDebitDetails.DescriptionOfEntriesOnFile,
                    Indicator = directDebitDetails.Indicator,
                    WithholdingTaxAmount = directDebitDetails.WithholdingTaxAmount,
                    DbReceiveInboundDirectDebitsId = id
                }))
                {
                    _db.DbDirectDebitDetails.Add(dbDirectDebitDetail);
                }
            }
            
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (Exception)
            {
                return Conflict();
            }
            return Ok();
        }
        
        [HttpPost]
        [Route("api/v1/ReceiveDirectEntryDishonours")]
        public async Task<IHttpActionResult> ReceiveDirectEntryDishonours([FromBody]ReceiveDirectEntryDishonours receiveDirectEntryDishonours)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var id = Guid.NewGuid();
            
            var directEntryDishonours = new DbReceiveDirectEntryDishonours()
            {
                Id = id,
                ReturnDate = receiveDirectEntryDishonours.ReturnDate,
                Amount = receiveDirectEntryDishonours.Amount,
                Type = receiveDirectEntryDishonours.Type,
                ReturnReason = receiveDirectEntryDishonours.ReturnReason,
                TransactionDate = receiveDirectEntryDishonours.TransactionDate,
                OriginalTransactionId = receiveDirectEntryDishonours.OriginalTransactionId,
                TransactionReference = receiveDirectEntryDishonours.TransactionReference,
            };
            
            _db.DbReceiveDirectEntryDishonours.Add(directEntryDishonours);

            var bankDetail = new DbBankDetail()
            {
                Id = Guid.NewGuid(),
                DbReceiveDirectEntryDishonoursId = id,
                Bsb = receiveDirectEntryDishonours.BankDetails.Bsb,
                AccountNumber = receiveDirectEntryDishonours.BankDetails.AccountNumber,
                AccountName = receiveDirectEntryDishonours.BankDetails.AccountName,
                Token = receiveDirectEntryDishonours.BankDetails.Token,
            };
            
            _db.DbBankDetails.Add(bankDetail);
            
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (Exception)
            {
                return Conflict();
            }
            return Ok();
        }

        private bool ReceivePaymentExists(string id)
        {
            return _db.ReceivePayments.Count(e => e.TransactionId == id) > 0;
        }
    }
}
