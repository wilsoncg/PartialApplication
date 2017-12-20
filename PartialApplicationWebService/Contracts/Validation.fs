namespace FSharpWcfService

open System
open FSharpWcfService.Contracts
open FSharpWcfService.LowLevelLang
open FSharpWcfService.LowLevelLang.Common

module RequestValidation =
    let amountIsPositive request = 
        match request with
        | r when r.Amount > 0m -> Success request
        | _ -> Failure "Amount must be positive"

    let tradingAccountCodeProvided request =
        match request with
        | r when not (String.IsNullOrEmpty r.TradingAccountCode) -> Success request
        | _ -> Failure "TradingAccount must be specified"
    
    let usernameProvided request =
        match request with
        | r when not (String.IsNullOrEmpty r.Username) -> Success request
        | _ -> Failure "Username must be specified"

    let assignDefaultSource request =
        { request with RequestSource = 
            if request.RequestSource = 0 then 1 
            else request.RequestSource }

    let providerReferenceIsValid request =
        match request with
        | r when not (String.IsNullOrEmpty r.ServiceProviderReference) -> Success request
        | _ -> Failure "ServiceProviderReference must be provided"

    let setupChecks =
        amountIsPositive
        >> bind tradingAccountCodeProvided
        >> bind usernameProvided
        >=> switch assignDefaultSource

    let makePaymentChecks =
        providerReferenceIsValid
        
// how not to do:
// using methods and dotted notation results in having to use lambdas
// type inference doesn't work

//type ClassValidation(request : SetupPaymentRequest) = class 
//    member x.RequestValidation(request: SetupPaymentRequest -> Result<bool, string>) = 
//        let valid request:SetupPaymentRequest -> bool = (fun r -> r.Amount > 0m)
//        valid
//end

//Rule<SetupPaymentRequest> TradingAccountExistsInSystem();
//Rule<SetupPaymentRequest> MaxCardsLimitIsNotExceeded();
//Rule<SetupPaymentRequest> IsDepositAmountBetweenSystemMinAndMax();
//Rule<SetupPaymentRequest> DoesSystemHaveCorrectSettingsForSetupPayment();
//Rule<SetupPaymentRequest> IsDepositRestrictedForCustomer();
//Rule<SetupPaymentRequest> IsCustomerAccountTypeAllowedToFund();