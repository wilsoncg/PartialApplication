﻿namespace FSharpWcfService

open System
open System.Configuration
open System.Runtime.Serialization
open System.ServiceModel
open FSharpWcfService.Contracts
open FSharpWcfService.RequestValidation
open FSharpWcfService.LowLevelLang
open SqlGateway
open FSharpSettings
open FSharpWcfService.LowLevelLang.Common

[<ServiceBehavior>]
type FundingService() = 
    interface IFundingService with        
        member this.SetupPayment request = 
            let x = either {
             let r = setupChecks request
             let ta = getTradingAccount (new Settings()).Database request.TradingAccountCode
             return! r } 
            match x with
                | Success _ -> { Code = 1; Description = "" }
                | Failure f -> { Code = -1; Description = f }
        
        member this.MakePayment request =
            let result = makePaymentChecks request
            match result with
                | Success _ -> { Code = 1; Description = "" }
                | Failure f -> { Code = -1; Description = f }

//let changeName observer customer newName = 
//    let newCustomer = {customer with name=newName}
//    observer newCustomer    // call the observer with the new customer
//    newCustomer             // return the new customer

//1. do something to make a result value
//2. call the observer with the result value
//3. return the result value

//try
//with
//    | ex -> { Code = 100; Description = ex.Message }

//public SetupPaymentResponse SetupPayment(SetupPaymentRequest request)
//        {
//            RequestDefaultValueSetter.SetForRequest(request);
//
//            var validation = RequestValidatorFactory.Create(request).Validate(request);
//
//            if (!validation.IsValid)
//                return new SetupPaymentResponse { Code = validation.ErrorCode, Description = validation.Description };
//
//            int? transactionId = null;
//            string serviceProviderReference = null;
//            int modifiedBy = 5002;
//            try
//            {
//                modifiedBy = SecurityHeaderExtractor.GetUserId();
//                transactionId = TransactionService.StartTransactionWithoutCard(request.Amount, request.Username, request.TradingAccountCode, request.RequestSource, modifiedBy); 
//                TransactionAuditor.StartSetupTransaction(transactionId.Value, modifiedBy);
//                
//                _log.InfoFormat("Getting hosted card capture url for trading account code {0} and amount {1}", request.TradingAccountCode, request.Amount);
//
//                var response = PaymentService.SetupPayment(request, transactionId.Value);
//                serviceProviderReference = response.ServiceProviderReference;
//                var card = CardService.SaveKnownCardDetails(request.Username, request.TradingAccountCode, request.LegalPartyId, modifiedBy);
//
//                TransactionService.UpdateTransactionWithCardId(transactionId.Value, card.Id);
//                TransactionService.UpdateTransactionDetails(transactionId.Value, response.ServiceProviderReference, "");
//                _log.InfoFormat("PaymentProvider response : {0} {1} {2} ", response.Code, response.Description, response.URL);
//                TransactionAuditor.RecordTransactionStepResult(transactionId.Value, "END", response.Code, GetGatewayResponseReason(response), modifiedBy);
//
//                return response;
//            }
//            catch (Exception ex)
//            {
//                _log.Error(ex.CreateMessage("Setup payment", request.Username, request.TradingAccountCode, transactionId, serviceProviderReference, request.Amount), ex);
//                if (transactionId.HasValue)
//                {
//                    TransactionService.UpdateTransactionEftFeedback(transactionId.Value, EFTFeedback.SystemException.Id);
//                    TransactionAuditor.RecordTransactionStepResult(transactionId.Value, "END setup exception", EFTFeedback.SystemException.Id, ex.Message, modifiedBy);
//                }
//                return new SetupPaymentResponse { Code = EFTFeedback.SystemException.Id, Description = EFTFeedback.SystemException.Message };
//            }
//        }
