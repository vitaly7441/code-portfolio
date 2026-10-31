using System;
using Treasury.Dtos;

namespace Treasury.Services
{
    public class ConstellationService : IConstellationService
    {
        public RestoreCodeResponse RestoreCode(RestoreCodeRequest request)
        {
            for (int i = 0; i < request.Reference.Length; i++)
            {
                for (int j = i + 1; j < request.Reference.Length; j++)
                {
                    if (request.Reference[i] == request.Reference[j])
                    {
                        throw new ArgumentException("Эталонный код должен содержать только уникальные символы.");
                    }
                }
            }

            for (int i = 0; i < request.Damaged.Length; i++)
            {
                for (int j = i + 1; j < request.Damaged.Length; j++)
                {
                    if (request.Damaged[i] == request.Damaged[j])
                    {
                        throw new ArgumentException("Повреждённый код не должен содержать повторяющихся символов.");
                    }
                }
            }

            for (int i = 0; i < request.Damaged.Length; i++)
            {
                char dmgChar = request.Damaged[i];
                bool existsInReference = false;

                for (int j = 0; j < request.Reference.Length; j++)
                {
                    if (dmgChar == request.Reference[j])
                    {
                        existsInReference = true;
                        break;
                    }
                }

                if (!existsInReference)
                {
                    throw new ArgumentException($"Поврежденный код содержит символ(ы), которого(ых) нет в эталонном коде.");
                }
            }

            char[] missingChars = new char[request.Reference.Length];
            int missingCount = 0;

            for (int i = 0; i < request.Reference.Length; i++)
            {
                char refChar = request.Reference[i];
                bool found = false;

                for (int j = 0; j < request.Damaged.Length; j++)
                {
                    if (refChar == request.Damaged[j])
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    missingChars[missingCount] = refChar;
                    missingCount++;
                }
            }

            char[] finalMissing = new char[missingCount];

            for (int i = 0; i < missingCount; i++)
            {
                finalMissing[i] = missingChars[i];
            }

            System.Array.Sort(finalMissing);

            string missingString = "";
            for (int i = 0; i < finalMissing.Length; i++)
            {
                missingString += finalMissing[i];
            }

            return new RestoreCodeResponse
            {
                MissingSymbols = missingString,
                IsComplete = missingString.Length == 0
            };
        }
    }
}