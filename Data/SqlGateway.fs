namespace FSharpWcfService

open System.Data
open System.Data.SqlClient

module SqlGateway =
 let getTradingAccount connectionString (accountCode : string) =
    let sql = "
        SELECT *
        FROM [dbo].[TradingAccount]
        WHERE AccountCode = '@accountCode'"
    use conn = new SqlConnection(connectionString)
    use cmd = new SqlCommand(sql, conn)
    cmd.Parameters.AddWithValue("@accountCode", accountCode) |> ignore
    conn.Open()
    cmd.ExecuteScalar() :?> TradingAccount