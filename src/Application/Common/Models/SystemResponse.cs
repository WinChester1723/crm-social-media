
namespace Application.Common.Models;

/// <summary>
/// Operational State. Needs to be used for mapping appropriate.
/// (For ex. Success could be mapped to STATUS.OK [HTTP 200])
/// </summary>
public enum OpState : byte
{
    /// <summary>
    /// Success case of the opertation. 
    /// (For ex. maps to HTTP 2XX)
    /// </summary>
    Succeeded = 0,
    /// <summary>
    /// Fail case of the opertation. 
    /// (For ex. maps to HTTP 4XX)
    /// </summary>
    Failed = 1,
    /// <summary>
    /// Not found case of the opertation. 
    /// (For ex. maps to HTTP 404)
    /// </summary>
    NotFound = 2,
    /// <summary>
    /// Unauthorized case of the opertation. 
    /// (For ex. maps to HTTP 403)
    /// </summary>
    Unauthorized = 3,

    /// <summary>
    /// Operation state indicating given operation failed due to invalid inputs. 
    /// (For ex. maps to HTTP 400)
    /// </summary>
    BadRequest = 4
}






/// <summary>
/// Default response type for the oprations.
/// </summary>
/// <typeparam name="T">
/// The type of the response payload.
/// Use bool for the non returning requests
/// </typeparam>
public class SystemResponse<T>
{
    private readonly List<string> _errors = new List<string>();

    public SystemResponse()
    {
    }

    public OpState OpState { get; set; }
    public T Payload { get; set; }
    public string DisplayText { get; set; }
    public IEnumerable<string> Errors => _errors;
    public static SystemResponse<T> Failed(OpState opState = OpState.Failed, params string[] errors)
    {
        var response = SystemResponse<T>.Failed(errors);
        response.OpState = opState;

        return response;
    }

    public static SystemResponse<T> Failed(params string[] errors)
    {
        var response = new SystemResponse<T>
        {
            OpState = OpState.Failed
        };

        if (errors is not null)
        {
            response._errors.AddRange(errors);
        }

        return response;
    }

    public static SystemResponse<T> Succeeded(T payload, OpState opState = OpState.Succeeded)
    {
        var response = new SystemResponse<T>
        {
            OpState = opState,
            Payload = payload
        };
        return response;
    }

    // public static SystemResponse<T> Succeeded(string displayText = null)
    //     => new SystemResponse<T>
    //     {
    //         OpState = OpState.Succeeded,
    //         DisplayText = displayText
    //     };
}