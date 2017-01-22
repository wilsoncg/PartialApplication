namespace FSharpWcfService.Contracts

open System.Runtime.Serialization
open System.ServiceModel

// Note: When running serialization code in partial trust, you may need to convert 
//       this to a class with a default constructor.
//[<DataContract>]
//type CompositeType =
//    { [<DataMember>] mutable BoolValue : bool 
//      [<DataMember>] mutable StringValue : string }

[<DataContract>]
type SetupPaymentRequest = {
    Amount : int 
    TradingAccountCode : string 
    RequestSource : int 
}

[<DataContract>]
type SetupPaymentResponse = {
    Code : int
    Description : string
}


type Result<'a,'error> = 
    | Success of 'a
    | Failure of 'error
