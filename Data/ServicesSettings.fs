namespace FSharpWcfService

open System.Configuration

module FSharpSettings =
 type Settings() =
    inherit ApplicationSettingsBase()
    [<ApplicationScopedSettingAttribute()>]
    member this.MySetting
     with get() = this.Item("mySetting") :?> int
    member this.Database
     with get() = 
        ConfigurationManager.ConnectionStrings.["PartialApplicationData"].ConnectionString