﻿using System.Net.Http.Headers;
using System.Threading.Tasks;
using WebApiClientCore.HttpContents;

namespace WebApiClientCore.Attributes
{
    /// <summary>
    /// 表示json内容的结果特性
    /// </summary>
    public class JsonReturnAttribute : ApiReturnAttribute
    {
        /// <summary>
        /// json内容的结果特性
        /// </summary>
        public JsonReturnAttribute()
            : base(new MediaTypeWithQualityHeaderValue(JsonContent.MediaType))
        {
        }

        /// <summary>
        /// json内容的结果特性
        /// </summary>
        /// <param name="acceptQuality">accept的质比</param>
        public JsonReturnAttribute(double acceptQuality)
            : base(new MediaTypeWithQualityHeaderValue(JsonContent.MediaType, acceptQuality))
        {
        }

        /// <summary>
        /// 设置强类型模型结果值
        /// </summary>
        /// <param name="context">上下文</param>
        /// <returns></returns>
        public override async Task SetResultAsync(ApiResponseContext context)
        {
            if (context.ApiAction.Return.DataType.IsRawType == false)
            {
                var resultType = context.ApiAction.Return.DataType.Type;
                context.Result = await context.JsonDeserializeAsync(resultType).ConfigureAwait(false);
            }
        }
    }
}
