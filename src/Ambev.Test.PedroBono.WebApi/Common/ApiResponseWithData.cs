﻿namespace Ambev.Test.PedroBono.WebApi.Common
{
    public class ApiResponseWithData<T> : ApiResponse
    {
        public T? Data { get; set; }
    }
}
