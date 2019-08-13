using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using kataSupersize.Models;

namespace kataSupersize.Controllers
{
    [Route("api/[controller]")]
    public class SizedValuesController : Controller
    {
        [HttpGet("{valueToSize}")]
        public ActionResult<IEnumerable<Models.SizedValues>> GetSizedValues(int valueToSize){
            int sizedValue = 0;            
            var listchars = valueToSize.ToString().ToList();
            List<int> list = listchars.Select(x => Convert.ToInt32(x.ToString())).ToList();
            var descendingOrder = list.OrderByDescending(i => i);            
            sizedValue = int.Parse(string.Join("", descendingOrder.Select(n => n).ToArray()));
            return new List<SizedValues>{
                new SizedValues {
                    OriginalValue = valueToSize,
                    SizedValue = sizedValue
                }
            };
        }
    }
}