//-----------------------------------------------------------------------
// <copyright file="GSearchClient.cs" company="iron9light">
// Copyright (c) 2009 iron9light
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
// </copyright>
// <author>iron9light@gmail.com</author>
//-----------------------------------------------------------------------

namespace Google.API.Search
{
    using System;

    public abstract class GSearchClient : GoogleClient
    {
        private static readonly string addressString = "http://ajax.googleapis.com/ajax/services/search";

        private static readonly Uri address = new Uri(addressString);

        protected GSearchClient(string referrer)
            : base(referrer)
        {
        }

        protected override Uri Address
        {
            get
            {
                return address;
            }
        }

        internal T GetResponseData<T>(RequestCallback<ResultObject<T>, ISearchService> request)
        {
            return RequestUtility.GetResponseData(request, this.Address, this.Binding, this.Referrer);
        }
    }
}