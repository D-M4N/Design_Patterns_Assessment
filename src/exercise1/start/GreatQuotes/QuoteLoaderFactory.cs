using System;
using System.Collections.Generic;
using System.Text;
using GreatQuotes.ViewModels;

namespace GreatQuotes
{

    
    public static class QuoteLoaderFactory
    {
        // This must be assigned to a method which creates a new quote loader.
        public static Func<IQuoteLoader> Create { get; set; }
    }

   
}
