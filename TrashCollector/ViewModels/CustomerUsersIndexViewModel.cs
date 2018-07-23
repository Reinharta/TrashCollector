using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrashCollector.Models;

namespace TrashCollector.ViewModels
{
    public class CustomerUsersIndexViewModel : IEnumerable<PickUps>
    {
        public CustomerUsers Customer { get; set; }
        public IEnumerable<PickUps> CustomerPickUps { get; set; }
        public IEnumerable<PickUps> PickUps { get; set; }

        public IEnumerator<PickUps> GetEnumerator()
        {
            foreach (PickUps pickup in CustomerPickUps)
            {
                if(pickup == null)
                {
                    break;
                }
                yield return pickup;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}