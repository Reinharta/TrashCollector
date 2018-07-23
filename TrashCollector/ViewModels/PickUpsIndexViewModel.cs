using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrashCollector.Models;

namespace TrashCollector.ViewModels
{
    public class PickUpsIndexViewModel : IEnumerable<PickUps>
    {



        public IEnumerable<PickUps> PickUps { get; set; }

        public IEnumerator<PickUps> GetEnumerator()
        {
            foreach (PickUps pickup in PickUps)
            {
                if (pickup == null)
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