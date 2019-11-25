using System;
using System.Collections.Generic;
using System.Text;
using GreatQuotes.ViewModels;
using System.Collections.ObjectModel;

namespace GreatQuotes
{
    public class QuoteManager
    {
        static readonly Lazy<QuoteManager> instance = new Lazy<QuoteManager>(() => new QuoteManager());

        private IQuoteLoader loader;

        public static QuoteManager Instance { get => instance.Value; }

        public IList<GreatQuoteViewModel> Quotes { get; set; }

        private QuoteManager()
        {
            loader = QuoteLoaderFactory.Create();
            Quotes = new ObservableCollection<GreatQuoteViewModel>(loader.Load());
        }

        public void Save()
        {
            loader.Save(Quotes);
        }

        public void SayQuote(GreatQuoteViewModel quote)
        {
            if (quote == null)
                throw new ArgumentNullException("No quote set");

            ITextToSpeech tts = ServiceLocator.Instance.Resolve<ITextToSpeech>();

            if (tts != null)
            {
                var text = quote.QuoteText;

                if (!string.IsNullOrWhiteSpace(quote.Author))
                    text += $" by {quote.Author}";

                tts.Speak(text);
            }
        }
    }
}
