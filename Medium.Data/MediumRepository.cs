using Medium.Data.Contracts;
using System;

namespace Medium.Data
{
    public class MediumRepository : IMediumRepository
    {
        public string Add()
        {
            return "Veri tabanına ilk veriniz eklenmiştir";
        }
    }
}
