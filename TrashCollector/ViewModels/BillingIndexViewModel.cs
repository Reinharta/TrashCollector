using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrashCollector.Models;

namespace TrashCollector.ViewModels
{
    public class BillingIndexViewModel : IEnumerable<Billing>
    {
        public CustomerUsers Customer { get; set; }

        public IEnumerable<Billing> CustomerBills { get; set; }

        public List<PickUps> CustomerPickUps { get; set; }

        public IEnumerator<Billing> GetEnumerator()
        {
            foreach (Billing bill in CustomerBills)
            {
                if (bill == null)
                {
                    break;
                }
                yield return bill;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}