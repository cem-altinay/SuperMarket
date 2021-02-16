using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public class BaseResponseViewModel
    {
        public BaseResponseViewModel()
        {
            ResponseViewModelList = new List<ResponseViewModel>();
        }


        public IList<ResponseViewModel> ResponseViewModelList { get; set; }

        public bool IsRedirect { get; set; }

        public string RedirectUrl { get; set; }

    }

    public class ResponseViewModel
    {     
        public string Status { get; set; }

        public string ResultDescription { get; set; }

    }
}
