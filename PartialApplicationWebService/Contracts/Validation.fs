namespace FSharpWcfService

// how not to do:
// using methods and dotted notation results in having to use lambdas
// type inference doesn't work

open System
open FSharpWcfService.Contracts

type ClassValidation(request : SetupPaymentRequest) = class 
    member x.RequestValidation(request: SetupPaymentRequest -> Result<bool, string>) = 
        let valid request:SetupPaymentRequest -> bool = (fun r -> r.Amount > 0m)
        valid
end

// much better
module RequestValidation =
    let amountIsValid request = 
        match request with
         | r when r.Amount <= 0m -> Success true
         | _ -> Failure "Amount invalid"