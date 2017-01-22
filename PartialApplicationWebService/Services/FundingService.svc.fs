namespace FSharpWcfService

open System
open FSharpWcfService.Contracts

type FundingService() =
    interface IFundingService with
        member x.SetupPayment request =
            try Success
            with
             | ex -> 
                Failure (InvalidOperation request)

//            match composite.BoolValue with
//            | true -> composite.StringValue <- 
//                          sprintf "%A%A" composite.StringValue "Suffix"
//            | _ -> "do nothing" |> ignore

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
