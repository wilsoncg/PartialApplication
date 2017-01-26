namespace FSharpWcfService.Contracts

open System.Runtime.Serialization
open System.ServiceModel

// Note: When running serialization code in partial trust, you may need to convert 
//       this to a class with a default constructor.
//[<DataContract>]
//type CompositeType =
//    { [<DataMember>] mutable BoolValue : bool 
//      [<DataMember>] mutable StringValue : string }

// Record type
[<DataContract>]
type SetupPaymentRequest = {
    Amount : decimal 
    TradingAccountCode : string 
    RequestSource : int 
}

[<DataContract>]
type SetupPaymentResponse = {
    Code : int
    Description : string
}



[<ServiceContract>]
type public IFundingService =
    [<OperationContract>]
    abstract member SetupPayment: request:SetupPaymentRequest -> SetupPaymentResponse