using System;
using System.Text;

namespace HotelsWizard.Models.Response
{
    public class Meta
    {

        public int StatusCode;

        public Meta() { }

        public Meta(int statusCode) { StatusCode = statusCode; }

    }
}