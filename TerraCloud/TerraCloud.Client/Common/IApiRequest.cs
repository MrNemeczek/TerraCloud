using TerraCloud.Application.DTOs.Error;

namespace TerraCloud.Client.Common
{
    public interface IApiRequest
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <typeparam name="TBody"></typeparam>
        /// <param name="endpoint"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        Task<TResult> PostAsync<TResult, TBody>(string endpoint, TBody body);
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TBody"></typeparam>
        /// <param name="endpoint"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        Task<ErrorResponse?> OnlyPostAsync<TBody>(string endpoint, TBody body);
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        Task<TResult> GetAsync<TResult>();
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        Task<TResult> PutAsync<TResult>();
    }
}
