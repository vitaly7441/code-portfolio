using System;
using Treasury.Dtos;

namespace Treasury.Services
{
    public interface IConstellationService
    {
        RestoreCodeResponse RestoreCode(RestoreCodeRequest request);
    }
}