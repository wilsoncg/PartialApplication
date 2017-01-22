namespace FSharpWcfService.Contracts

open System.Runtime.Serialization
open System.ServiceModel

[<ServiceContract>]
type IFundingService =
    [<OperationContract>]
    abstract SetupPayment: request:SetupPaymentRequest -> Result Success SetupPaymentResponse
