﻿namespace FSharpWcfService

open System
open FSharpWcfService.Contracts
open FSharpWcfService.LowLevelLang
open FSharpWcfService.LowLevelLang.Common

// how not to do:
// using methods and dotted notation results in having to use lambdas
// type inference doesn't work

//type ClassValidation(request : SetupPaymentRequest) = class 
//    member x.RequestValidation(request: SetupPaymentRequest -> Result<bool, string>) = 
//        let valid request:SetupPaymentRequest -> bool = (fun r -> r.Amount > 0m)
//        valid
//end

// much better
module RequestValidation =
    let amountIsPositive request = 
        match request with
         | r when r.Amount > 0m -> Success request
         | _ -> Failure "Amount must be positive"

    let tradingAccountIsValid request =
        match request with
        | r when not (System.String.IsNullOrEmpty r.TradingAccountCode) -> Success request
        | _ -> Failure "TradingAccount must be specified"

    let assignDefaultSource request =
        { request with RequestSource = if request.RequestSource = 0 then 1 else request.RequestSource }

    let inputChecks =
        amountIsPositive
        >> bind tradingAccountIsValid
        >=> switch assignDefaultSource

//Rule<SetupPaymentRequest> TradingAccountExistsInSystem();
//Rule<SetupPaymentRequest> MaxCardsLimitIsNotExceeded();
//Rule<SetupPaymentRequest> IsDepositAmountBetweenSystemMinAndMax();
//Rule<SetupPaymentRequest> DoesSystemHaveCorrectSettingsForSetupPayment();
//Rule<SetupPaymentRequest> IsDepositRestrictedForCustomer();
//Rule<SetupPaymentRequest> IsCustomerAccountTypeAllowedToFund();